using LiveSplit.Model;
using LiveSplit.VTS.Extensions;
using MoonSharp.Interpreter;
using System;
using System.Linq;
using VTS.Core;

namespace LiveSplit.VTS
{
	public class VTS_TimerEvents
	{
		private VTS_Connection vtsConnection;
		LiveSplitState state;
		System.Timers.Timer WatchForFileChanges = new System.Timers.Timer(500);

		public void RegisterEvents(LiveSplitState state, VTS_Connection vtsConnection)
		{
			this.state = state;
			this.vtsConnection = vtsConnection;
			WatchForFileChanges.AutoReset = true;
			WatchForFileChanges.Elapsed += WatchForFileChanges_Elapsed;
			WatchForFileChanges.Start();
			state.OnPause += State_OnPause;
			state.OnReset += State_OnReset;
			state.OnResume += State_OnResume;
			state.OnSplit += State_OnSplit;
			state.OnStart += State_OnStart;
			state.OnUndoSplit += State_OnUndoSplit;
			state.OnSkipSplit += State_OnSkipSplit;
		}

		private void WatchForFileChanges_Elapsed(object sender, System.Timers.ElapsedEventArgs e) => vtsConnection.CheckLuaFile();

		public void UnregisterEvents(LiveSplitState state)
		{
			WatchForFileChanges.Stop();
			WatchForFileChanges.Elapsed -= WatchForFileChanges_Elapsed;

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
					LuaMapping.OnPause.CallAsync();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
		}

		private void State_OnReset(object sender, TimerPhase value)
		{
			WatchForFileChanges.Start();

			if (LuaMapping.OnReset != null)
			{
				try
				{
					LuaMapping.OnReset.CallAsync();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
		}

		private void State_OnResume(object sender, System.EventArgs e)
		{
			if (LuaMapping.OnResume != null)
			{
				try
				{
					LuaMapping.OnResume.CallAsync();
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
					LuaMapping.OnSplit.CallAsync();
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
					var personalBestSegmentTime = state.Run[state.CurrentSplitIndex - 1].BestSegmentTime[state.CurrentTimingMethod];
					var lastSegmentTime = state.Run.GetLastSegmentTime(state.CurrentSplitIndex - 1, state.CurrentTimingMethod);

					if (lastSegmentTime < personalBestSegmentTime)
					{
						if (LuaMapping.OnGold != null)
						{
							try
							{
								LuaMapping.OnGold.CallAsync();
							}
							catch (Exception ex)
							{
								vtsConnection.LogError(ex.ToString());
							}
						}
					}
					else
					{
						if (LuaMapping.OnRedSplit != null)
						{
							try
							{
								LuaMapping.OnRedSplit.CallAsync();
							}
							catch (Exception ex)
							{
								vtsConnection.LogError(ex.ToString());
							}
						}
					}
				}
				else
				{
					var personalBestSegmentTime = state.Run[state.CurrentSplitIndex - 1].BestSegmentTime[state.CurrentTimingMethod];
					var lastSegmentTime = state.Run.GetLastSegmentTime(state.CurrentSplitIndex - 1, state.CurrentTimingMethod);

					if (lastSegmentTime < personalBestSegmentTime)
					{
						if (LuaMapping.OnGoldSplit != null)
						{
							try
							{
								LuaMapping.OnGoldSplit.CallAsync();
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
								LuaMapping.OnGreenSplit.CallAsync();
							}
							catch (Exception ex)
							{
								vtsConnection.LogError(ex.ToString());
							}
						}
					}
				}
			}
			else if (state.CurrentPhase == TimerPhase.Ended)
			{
				var currentEndRunTime = state.CurrentTime[state.CurrentTimingMethod];
				var pbRunTime = state.Run.Last().PersonalBestSplitTime[state.CurrentTimingMethod];

				if (currentEndRunTime > pbRunTime)
				{
					try
					{
						if (LuaMapping.OnRunFinishedWithoutPB == null)
						{
							if (LuaMapping.OnRedSplit != null)
								LuaMapping.OnRedSplit.CallAsync();
						}
						else
							LuaMapping.OnRunFinishedWithoutPB.CallAsync();
					}
					catch (Exception ex)
					{
						vtsConnection.LogError(ex.ToString());
					}
				}
				else
				{
					try
					{
						if (LuaMapping.OnRunFinishedWithPB == null)
						{
							if (LuaMapping.OnGoldSplit != null)
								LuaMapping.OnGoldSplit.CallAsync();
						}
						else
							LuaMapping.OnRunFinishedWithPB.CallAsync();
					}
					catch (Exception ex)
					{
						vtsConnection.LogError(ex.ToString());
					}
				}
			}
		}

		private void State_OnStart(object sender, System.EventArgs e)
		{
			WatchForFileChanges.Stop();

			if (LuaMapping.OnStart != null)
			{
				try
				{
					LuaMapping.OnStart.CallAsync();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
		}

		private void State_OnUndoSplit(object sender, System.EventArgs e)
		{
			if (LuaMapping.OnUndoSplit != null)
			{
				try
				{
					LuaMapping.OnUndoSplit.CallAsync();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
		}

		private void State_OnSkipSplit(object sender, System.EventArgs e)
		{
			if (LuaMapping.OnSkipSplit != null)
			{
				try
				{
					LuaMapping.OnSkipSplit.CallAsync();
				}
				catch (Exception ex)
				{
					vtsConnection.LogError(ex.ToString());
				}
			}
		}
	}
}
