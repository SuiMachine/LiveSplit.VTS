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

			if (LuaMapping.OnPause != null)
			{
				try
				{
					LuaMapping.OnPause.Call();
					/*					Task.Factory.StartNew(new Action(async () =>
										{
											await vtsConnection.SetPostProcessing(options, values);
										}));*/
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}

			Flag_SendRedSplits = true;
		}

		private void State_OnReset(object sender, TimerPhase value)
		{
			if (ProcessTimeTask != null)
			{
				token.Cancel();
				ProcessTimeTask.Wait();
			}

			if (LuaMapping.OnReset != null)
			{
				try
				{
					LuaMapping.OnReset.Call();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
			/*				VTSPostProcessingUpdateOptions options = new VTSPostProcessingUpdateOptions(true, true, false, "Nothing", 0.25f, false, false, false, 0);
						PostProcessingValue[] values = new PostProcessingValue[0];

						Task.Factory.StartNew(new Action(async () =>
						{
							await vtsConnection.SetPostProcessing(options, values);
						}));*/
			Flag_SendRedSplits = true;
		}

		private void State_OnResume(object sender, System.EventArgs e)
		{
			if (LuaMapping.OnResume != null)
			{
				try
				{
					LuaMapping.OnResume.Call();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
		}

		private void State_OnSplit(object sender, System.EventArgs e)
		{
			if (LuaMapping.OnSplit != null)
			{
				try
				{
					LuaMapping.OnSplit.Call();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}

			if (state.CurrentSplit != null)
			{
				var currentTime = state.CurrentTime[state.CurrentTimingMethod];
				var pbTime = state.Run[state.CurrentSplitIndex - 1].PersonalBestSplitTime[state.CurrentTimingMethod];

				if (currentTime > pbTime)
				{
					if (LuaMapping.OnRedSplit != null)
					{
						try
						{
							LuaMapping.OnRedSplit.Call();
						}
						catch (Exception ex)
						{
							vtsConnection.LogError(ex.ToString());
						}
					}

					Flag_SendRedSplits = false;
				}
				else
				{
					var personalBest = state.Run[state.CurrentSplitIndex - 1].BestSegmentTime[state.CurrentTimingMethod];
					var lastSegmentTime = state.Run.GetLastSegmentTime(state.CurrentSplitIndex - 1, state.CurrentTimingMethod);

					if (lastSegmentTime < personalBest)
					{
						if (LuaMapping.OnGoldSplit != null)
						{
							try
							{
								LuaMapping.OnGoldSplit.Call();
							}
							catch (Exception ex)
							{
								vtsConnection.LogError(ex.ToString());
							}
						}
					}
					else
					{
						if (LuaMapping.OnGreenSplit != null)
						{
							try
							{
								LuaMapping.OnGreenSplit.Call();
							}
							catch (Exception ex)
							{
								vtsConnection.LogError(ex.ToString());
							}
						}
					}

					Flag_SendRedSplits = true;
				}
			}
		}

		private void State_OnStart(object sender, System.EventArgs e)
		{
			if (LuaMapping.OnStart != null)
			{
				try
				{
					LuaMapping.OnStart.Call();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}

			if (ProcessTimeTask == null)
				ProcessTimeTask = Task.Factory.StartNew(TrackTimerTask);
			token = new CancellationTokenSource();

			Flag_SendRedSplits = true;
		}

		private void State_OnUndoSplit(object sender, System.EventArgs e)
		{
			Flag_SendRedSplits = true;
			if (LuaMapping.OnUndoSplit != null)
			{
				try
				{
					LuaMapping.OnUndoSplit.Call();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
		}

		private void State_OnSkipSplit(object sender, System.EventArgs e)
		{
			Flag_SendRedSplits = true;
			if (LuaMapping.OnSkipSplit != null)
			{
				try
				{
					LuaMapping.OnSkipSplit.Call();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
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
						if (LuaMapping.OnRedSplit != null)
						{
							try
							{
								LuaMapping.OnRedSplit.Call();
							}
							catch (Exception ex)
							{
								vtsConnection.LogError(ex.ToString());
							}
						}

						Flag_SendRedSplits = false;
					}
				}
			}
		}
	}
}
