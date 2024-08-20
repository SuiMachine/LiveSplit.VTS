using LiveSplit.Model;
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
		}

		private void State_OnResume(object sender, System.EventArgs e)
		{
		}

		private void State_OnSplit(object sender, System.EventArgs e)
		{
			if (state.CurrentSplit != null)
			{
				var time = state.CurrentSplit.BestSegmentTime;

				if (state.CurrentTime.GameTime > time.GameTime)
				{
					VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "RedSplits", 0.25f, false, false, false, 0);
					PostProcessingValue[] values = new PostProcessingValue[0];
					Task.Factory.StartNew(new Action(async () =>
					{
						await vtsConnection.SetPostProcessing(options, values);
					}));
				}
				else
				{
					VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "GreenSplits", 0.25f, false, false, false, 0);
					PostProcessingValue[] values = new PostProcessingValue[0];
					Task.Factory.StartNew(new Action(async () =>
					{
						await vtsConnection.SetPostProcessing(options, values);
					}));
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
			{
				token = new CancellationTokenSource();
				ProcessTimeTask = Task.Factory.StartNew(trackTimerTask);
			}
		}

		private void State_OnUndoSplit(object sender, System.EventArgs e)
		{
			VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
			PostProcessingValue[] values = new PostProcessingValue[0];
			Task.Factory.StartNew(new Action(async () =>
			{
				await vtsConnection.SetPostProcessing(options, values);
			}));
		}

		private void State_OnSkipSplit(object sender, System.EventArgs e)
		{
			VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
			PostProcessingValue[] values = new PostProcessingValue[0];
			Task.Factory.StartNew(new Action(async () =>
			{
				await vtsConnection.SetPostProcessing(options, values);
			}));
		}

		private async Task trackTimerTask()
		{
			while (true)
			{
				await Task.Delay(200);
				if (token.IsCancellationRequested)
				{
					ProcessTimeTask = null;
					return;
				}

				if (state.CurrentSplit != null)
				{
					var time = state.CurrentSplit.BestSegmentTime;

					if (state.CurrentTime.GameTime > time.GameTime)
					{
						VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "RedSplits", 0.25f, false, false, false, 0);
						PostProcessingValue[] values = new PostProcessingValue[0];
						await vtsConnection.SetPostProcessing(options, values);
					}
				}
			}
		}
	}
}
