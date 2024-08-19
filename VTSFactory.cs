﻿using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using LiveSplit.Model;

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
			// workaround for livesplit 1.4 oversight where components can be loaded from two places at once
			// remove all this junk when they fix it
			string caller = new StackFrame(1).GetMethod().Name;
			string callercaller = new StackFrame(2).GetMethod().Name;
			bool createAsLayoutComponent = (caller == "LoadLayoutComponent" || caller == "AddComponent");

			// if component is already loaded somewhere else
			if (_instance != null && !_instance.Disposed)
			{
				// "autosplit components" can't throw exceptions for some reason, so return a dummy component
				if (callercaller == "CreateAutoSplitter")
				{
					return new DummyComponent();
				}

				MessageBox.Show($"LiveSplit.VTS is already loaded in the {(_instance.IsLayoutComponent ? "Layout Editor" : "Splits Editor")}!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);

				throw new Exception("Component already loaded.");
			}

			return (_instance = new VTSComponent(state, createAsLayoutComponent));
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

	class DummyComponent : LogicComponent
	{
		public override string ComponentName { get { return "Dummy Component"; } }
		public override void Dispose() { }
		public override XmlNode GetSettings(XmlDocument document) { return document.CreateElement("Settings"); }
		public override Control GetSettingsControl(LayoutMode mode) { return null; }
		//public override void RenameComparison(string oldName, string newName) { }
		public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }
		public override void SetSettings(XmlNode settings) { }
	}
}
