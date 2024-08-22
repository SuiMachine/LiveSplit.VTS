using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
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
		private LiveSplitState _state;

		public VTSComponent(LiveSplitState state)
		{
			_state = state;

			_timer = new TimerModel { CurrentState = state };
			VTS_Connection.GetInstance().RegisterEvents(_state);
			this.Settings = new VTSSettings();
		}

		public override void Dispose()
		{
			this.Disposed = true;
			VTS_Connection.GetInstance().UnregisterEvents(_state);
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
