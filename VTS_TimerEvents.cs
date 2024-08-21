using LiveSplit.Model;
using LiveSplit.VTS.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using VTS.Core;

namespace LiveSplit.VTS
{
	public class VTS_TimerEvents
	{
		private VTS_Connection vtsConnection;
		Task ProcessTimeTask;
		CancellationTokenSource token;
		LiveSplitState state;
		private bool Flag_SendRedSplits;

		public void RegisterEvents(LiveSplitState state, VTS_Connection vtsConnection)
		{
			this.state = state;
			this.vtsConnection = vtsConnection;
			state.OnPause += State_OnPause;
			state.OnReset += State_OnReset;
			state.OnResume += State_OnResume;
			state.OnSplit += State_OnSplit;
			state.OnStart += State_OnStart;
			state.OnUndoSplit += State_OnUndoSplit;
			state.OnSkipSplit += State_OnSkipSplit;
		}

		public void UnregisterEvents(LiveSplitState state)
		{
			state.OnPause -= State_OnPause;
			state.OnReset -= State_OnReset;
			state.OnResume -= State_OnResume;
			state.OnSplit -= State_OnSplit;
			state.OnStart -= State_OnStart;
			state.OnUndoSplit -= State_OnUndoSplit;
			state.OnSkipSplit -= State_OnSkipSplit;
		}

		private void State_OnPause(object sender, System.EventArgs e)
		{
			VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
			PostProcessingValue[] values = new PostProcessingValue[0];

			Task.Factory.StartNew(new Action(async () =>
			{
				await vtsConnection.SetPostProcessing(options, values);
			}));
			Flag_SendRedSplits = true;
		}

		private void State_OnReset(object sender, TimerPhase value)
		{
			if (ProcessTimeTask != null)
			{
				token.Cancel();
				ProcessTimeTask.Wait();
			}

			VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
			PostProcessingValue[] values = new PostProcessingValue[0];

			Task.Factory.StartNew(new Action(async () =>
			{
				await vtsConnection.SetPostProcessing(options, values);
			}));
			Flag_SendRedSplits = true;
		}

		private void State_OnResume(object sender, System.EventArgs e)
		{
		}

		private void State_OnSplit(object sender, System.EventArgs e)
		{
			if (state.CurrentSplit != null)
			{
				var currentTime = state.CurrentTime[state.CurrentTimingMethod];
				var pbTime = state.Run[state.CurrentSplitIndex - 1].PersonalBestSplitTime[state.CurrentTimingMethod];

				if (currentTime > pbTime)
				{
					VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "RedSplits", 0.25f, false, false, false, 0);
					PostProcessingValue[] values = new PostProcessingValue[0];
					Task.Factory.StartNew(new Action(async () =>
					{
						await vtsConnection.SetPostProcessing(options, values);
					}));
					Flag_SendRedSplits = false;
				}
				else
				{
					var personalBest = state.Run[state.CurrentSplitIndex - 1].BestSegmentTime[state.CurrentTimingMethod];
					var lastSegmentTime = state.Run.GetLastSegmentTime(state.CurrentSplitIndex - 1, state.CurrentTimingMethod);

					VTSPostProcessingUpdateOptions options;
					if (lastSegmentTime < personalBest)
						options = new VTSPostProcessingUpdateOptions(true, true, false, "Gold", 0.25f, false, false, false, 0);
					else
						options = new VTSPostProcessingUpdateOptions(true, true, false, "GreenSplits", 0.25f, false, false, false, 0);

					PostProcessingValue[] values = new PostProcessingValue[0];
					Task.Factory.StartNew(new Action(async () =>
					{
						await vtsConnection.SetPostProcessing(options, values);
					}));
					Flag_SendRedSplits = true;
				}
			}
		}

		private void State_OnStart(object sender, System.EventArgs e)
		{
			VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
			PostProcessingValue[] values = new PostProcessingValue[0];

			Task.Factory.StartNew(new Action(async () =>
			{
				await vtsConnection.SetPostProcessing(options, values);
			}));

			if (ProcessTimeTask == null)
				ProcessTimeTask = Task.Factory.StartNew(TrackTimerTask);
			token = new CancellationTokenSource();

			Flag_SendRedSplits = true;
		}

		private void State_OnUndoSplit(object sender, System.EventArgs e)
		{
			Flag_SendRedSplits = true;
			VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
			PostProcessingValue[] values = new PostProcessingValue[0];
			Task.Factory.StartNew(new Action(async () =>
			{
				await vtsConnection.SetPostProcessing(options, values);
			}));
		}

		private void State_OnSkipSplit(object sender, System.EventArgs e)
		{
			Flag_SendRedSplits = true;
			VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
			PostProcessingValue[] values = new PostProcessingValue[0];
			Task.Factory.StartNew(new Action(async () =>
			{
				await vtsConnection.SetPostProcessing(options, values);
			}));
		}

		private async Task TrackTimerTask()
		{
			while (true)
			{
				await Task.Delay(200);

				if (token.IsCancellationRequested)
				{
					ProcessTimeTask = null;
					return;
				}

				if (state.CurrentSplit != null && Flag_SendRedSplits)
				{
					var time = state.CurrentSplit.PersonalBestSplitTime[state.CurrentTimingMethod];

					if (state.CurrentTime[state.CurrentTimingMethod] > time)
					{
						//Debug.WriteLine("Send update");
						VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "RedSplits", 0.25f, false, false, false, 0);
						PostProcessingValue[] values = new PostProcessingValue[0];
						await vtsConnection.SetPostProcessing(options, values);
						Flag_SendRedSplits = false;
					}
				}
			}
		}
	}
}
