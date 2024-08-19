using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.VTS
{
	class VTSComponent : LogicComponent
	{
		public override string ComponentName
		{
			get { return "VTube Studio Connection"; }
		}

		public VTSSettings Settings { get; set; }

		public bool Disposed { get; private set; }

		private TimerModel _timer;
		private GameMemory _gameMemory;
		private LiveSplitState _state;

		public VTSComponent(LiveSplitState state)
		{
			_state = state;

			this.Settings = new VTSSettings();

			_timer = new TimerModel { CurrentState = state };
			_timer.CurrentState.OnStart += timer_OnStart;

			_gameMemory = new GameMemory(this.Settings);
			_gameMemory.OnFirstLevelLoading += gameMemory_OnFirstLevelLoading;
			_gameMemory.OnPlayerGainedControl += gameMemory_OnPlayerGainedControl;
			_gameMemory.OnLoadStarted += gameMemory_OnLoadStarted;
			_gameMemory.OnLoadFinished += gameMemory_OnLoadFinished;
			state.OnStart += State_OnStart;
			_gameMemory.StartMonitoring();
		}

		public override void Dispose()
		{
			this.Disposed = true;

			_state.OnStart -= State_OnStart;
			_timer.CurrentState.OnStart -= timer_OnStart;

			if (_gameMemory != null)
			{
				_gameMemory.Stop();
			}

		}

		void State_OnStart(object sender, EventArgs e)
		{
		}

		void timer_OnStart(object sender, EventArgs e)
		{
			_timer.InitializeGameTime();
		}

		void gameMemory_OnFirstLevelLoading(object sender, EventArgs e)
		{
			if (this.Settings.AutoReset)
			{
				_timer.Reset();
			}
		}

		void gameMemory_OnPlayerGainedControl(object sender, EventArgs e)
		{
			if (this.Settings.AutoStart)
			{
				_timer.Start();
			}
		}

		void gameMemory_OnLoadStarted(object sender, EventArgs e)
		{
			_state.IsGameTimePaused = true;
		}

		void gameMemory_OnLoadFinished(object sender, EventArgs e)
		{
			_state.IsGameTimePaused = false;
		}

		public override XmlNode GetSettings(XmlDocument document)
		{
			return this.Settings.GetSettings(document);
		}

		public override Control GetSettingsControl(LayoutMode mode)
		{
			return this.Settings;
		}

		public override void SetSettings(XmlNode settings)
		{
			this.Settings.SetSettings(settings);
		}

		public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }
		//public override void RenameComparison(string oldName, string newName) { }
	}
}
