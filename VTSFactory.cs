using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

namespace LiveSplit.VTS
{
	public class VTSFactory : IComponentFactory
	{
		private VTSComponent _instance;

		public string ComponentName
		{
			get { return "VTube Studio Connection"; }
		}

		public string Description
		{
			get { return "Allows to execute actions in VTube Studio based on LiveSplit state."; }
		}

		public ComponentCategory Category
		{
			get { return ComponentCategory.Other; }
		}

		public IComponent Create(LiveSplitState state)
		{
			return (_instance = new VTSComponent(state));
		}

		public string UpdateName
		{
			get { return this.ComponentName; }
		}

		public string UpdateURL
		{
			get { return "https://raw.githubusercontent.com/SuiMachine/LiveSplit.VTS/master/"; }
		}

		public Version Version
		{
			get { return Assembly.GetExecutingAssembly().GetName().Version; }
		}

		public string XMLURL
		{
			get { return this.UpdateURL + "Components/update.LiveSplit.VTS.xml"; }
		}
	}
}
