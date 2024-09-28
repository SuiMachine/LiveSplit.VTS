using LiveSplit.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using VTS.Core;


namespace LiveSplit.VTS
{
	public class VTS_Connection
	{
		private static VTS_Connection instance;
		public ConsoleVTSLoggerImpl Logger { get; private set; }
		public CoreVTSPlugin Plugin { get; private set; }
		private VTSSettings m_settingsForm;
		private VTS_TimerEvents timerEvents = new VTS_TimerEvents();
		public LiveSplitState LiveSplitState { get; private set; }
		public string CurrentModelId { get; private set; }
		public string CurrentModelName { get; private set; }

		public Action<bool> OnConnectionChanged;
		public bool IsAutheniticated => Plugin != null ? Plugin.IsAuthenticated : false;

		public static VTS_Connection GetInstance()
		{
			if (instance == null)
			{
				instance = new VTS_Connection();
				return instance;
			}

			return instance;
		}

		public async Task Connect()
		{
			if (!IsAutheniticated)
			{
				try
				{
					Logger = new ConsoleVTSLoggerImpl(); // Create a logger to log messages to the console (you can use your own logger implementation here like in the Advanced example)
					Plugin = new CoreVTSPlugin(instance.Logger, 100, "LiveSplit-VTS", "SuiMachine", "");
					await Plugin.InitializeAsync(new WebSocketImpl(Logger), new NewtonsoftJsonUtilityImpl(), new TokenStorageImpl(""), Disconnected);
					Log("Connected!");
					OnConnectionChanged?.Invoke(true);
					var apiState = await Plugin.GetAPIState();

					Log("Using VTubeStudio " + apiState.data.vTubeStudioVersion);
					var currentModel = await Plugin.GetCurrentModel();

					Log("The current model is: " + currentModel.data.modelName);

					// Subscribe to your events here using the plugin.SubscribeTo* methods
					await Plugin.SubscribeToBackgroundChangedEvent((backgroundInfo) =>
					{
						Log($"The background was changed to: {backgroundInfo.data.backgroundName}");
					});

					await Plugin.SubscribeToModelConfigChangedEvent((modelConfig) =>
					{
						Log($"Model changed to: {modelConfig.data.modelName}");
						CurrentModelId = modelConfig.data.modelID;
						CurrentModelName = modelConfig.data.modelName;
					});

					var VTSModelAnimationEventConfigOptions = new VTSModelAnimationEventConfigOptions();
					await Plugin.SubscribeToModelAnimationEvent(VTSModelAnimationEventConfigOptions, e =>
					{
						Log($"Animation changed: {e.data.animationName} ({e.data.animationEventData})");
					});

					var modelLoaded = new VTSModelLoadedEventConfigOptions();
					await Plugin.SubscribeToModelLoadedEvent(modelLoaded, e =>
					{
						Log($"Model changed: {e.data.modelName}");
					});

					var postProcessingEventConfig = new VTSPostProcessingEventConfigOptions();
					await Plugin.SubscribeToPostProcessingEvent(postProcessingEventConfig, e =>
					{
						Log($"Post processing changed changed: {e.data.currentPreset}");
					});
				}
				catch (VTSException error)
				{
					OnConnectionChanged?.Invoke(false);
					LogError(error.ToString());
				}
			}
		}

		public async Task Disconnect()
		{
			if (Plugin.IsAuthenticated)
			{
				try
				{
					var apiState = await Plugin.GetAPIState();
					if (apiState.data.currentSessionAuthenticated && apiState.data.active)
					{
						Plugin.Disconnect();
						OnConnectionChanged?.Invoke(false);
					}
				}
				catch (Exception ex)
				{
					Log("Error" + ex.ToString());
				}


				Plugin.Dispose();
				Plugin = null;
				Logger = null;
				Log("Disconnected");
			}
		}

		private void Disconnected()
		{
			Plugin.Disconnect();
			Plugin = null;
			Logger = null;
			Log("Disconnected");
		}

		public void Log(string message)
		{
			Logger?.Log(message);
			if (m_settingsForm != null && m_settingsForm.DebugLog)
			{
				string t = "[Lua VTS]: " + message;
				m_settingsForm.AppendMessage(t);
				Debug.WriteLine(t);
			}
		}

		public void LogWarning(string message)
		{
			Logger?.Log(message);
			if (m_settingsForm != null && m_settingsForm.DebugLog)
			{
				string t = "[Lua VTS] Warning: " + message;
				m_settingsForm.AppendMessage(t);
				Debug.WriteLine(t);
			}
		}

		public void LogError(string error)
		{
			Logger?.LogError(error); // Log any errors that occur during initialization
			if (m_settingsForm != null && m_settingsForm.DebugLog)
			{
				string t = "[Lua VTS] Error: " + error;
				m_settingsForm.AppendMessage(t);
				Debug.WriteLine(t);
			}
		}

		public void SetFormReference(VTSSettings form) => m_settingsForm = form;

		public void RegisterEvents(LiveSplitState state)
		{
			this.LiveSplitState = state;
			timerEvents.RegisterEvents(state, this);
		}

		public void UnregisterEvents(LiveSplitState state) => timerEvents.UnregisterEvents(state);

		internal void CheckLuaFile()
		{
			if (m_settingsForm != null)
				m_settingsForm.CheckLuaFile();
		}
	}
}
