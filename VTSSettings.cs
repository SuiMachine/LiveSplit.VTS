using LiveSplit.VTS.CustomAttributes;
using LiveSplit.VTS.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.VTS
{
	public partial class VTSSettings : UserControl
	{
		private bool Loaded;
		[LiveSplitVTSStoreLayoutSetting]
		[LiveSplitVTSSettingsAttributeBool("Autoconnect", false)]
		public bool Autoconnect { get; set; }

		[LiveSplitVTSStoreLayoutSetting]
		[LiveSplitVTSSettingsAttributeString("Api_Address", "ws://127.0.0.1:8001")]
		public string Api_Address { get; set; }

		[LiveSplitVTSStoreLayoutSetting]
		[LiveSplitVTSSettingsAttributeString("ScriptFile", "LiveSplit.VTS.lua")]
		public string ScriptFile { get; set; }
		[LiveSplitVTSStoreLayoutSetting]
		[LiveSplitVTSSettingsAttributeBool("DebugLog", false)]
		public bool DebugLog { get; set; }
		[LiveSplitVTSStoreLayoutSetting]
		[LiveSplitVTSSettingsAttributeBool("LuaDebugger", false)]
		public bool LuaDebugger { get; set; }

		private List<(PropertyInfo Property, LiveSplitVTSSettingsAttribute Attribute)> mappings;
		private List<(PropertyInfo Property, LiveSplitVTSSettingsAttribute Attribute)> layout_settingsMappings;
		private volatile Queue<string> messagesToAdd = new Queue<string>(); //Because invokes don't seem to work and I can't be bothered
		private Timer timer;

		public VTSSettings()
		{
			InitializeComponent();

			this.CB_Autoconnect.DataBindings.Add("Checked", this, nameof(Autoconnect), false, DataSourceUpdateMode.OnPropertyChanged);
			this.TB_Address.DataBindings.Add("Text", this, nameof(Api_Address), false, DataSourceUpdateMode.OnPropertyChanged);
			this.CB_Log_DebugMessages.DataBindings.Add("Checked", this, nameof(DebugLog), false, DataSourceUpdateMode.OnPropertyChanged);
			this.TB_ScriptFile.DataBindings.Add("Text", this, nameof(ScriptFile), false, DataSourceUpdateMode.OnPropertyChanged);
			this.CB_EnableLuaDebugger.DataBindings.Add("Checked", this, nameof(LuaDebugger), false,  DataSourceUpdateMode.OnPropertyChanged);

			//Stupid workaround
			timer = new Timer();
			timer.Interval = 150;
			timer.Tick += ProcessLogManually;
			timer.Start();

			// defaults
			ApplyDefaults();
			VTS_Connection.GetInstance().SetFormReference(this);
			ProcessLua();
		}

		private void CreateMappings()
		{
			if (mappings == null)
			{
				mappings = new List<(PropertyInfo, LiveSplitVTSSettingsAttribute)>();

				var properties = typeof(VTSSettings).GetProperties();
				foreach (var property in properties)
				{
					var value = (LiveSplitVTSSettingsAttribute)property.GetCustomAttribute(typeof(LiveSplitVTSSettingsAttribute));
					if (value != null)
					{
						mappings.Add((property, value));
					}
				}
			}

			if (layout_settingsMappings == null)
			{
				layout_settingsMappings = new List<(PropertyInfo Property, LiveSplitVTSSettingsAttribute Attribute)>();

				var properties = typeof(VTSSettings).GetProperties();
				foreach (var property in properties)
				{
					var storeAttribute = (LiveSplitVTSStoreLayoutSetting)property.GetCustomAttribute(typeof(LiveSplitVTSStoreLayoutSetting));
					if (storeAttribute != null)
					{
						var value = (LiveSplitVTSSettingsAttribute)property.GetCustomAttribute(typeof(LiveSplitVTSSettingsAttribute));

						if (value != null && !string.IsNullOrEmpty(value.NAME))
						{
							layout_settingsMappings.Add((property, value));
						}
					}
				}
			}
		}

		private void ApplyDefaults()
		{
			CreateMappings();

			foreach (var mapping in mappings)
				mapping.Property.SetValue(this, mapping.Attribute.GetDefaultValue());
		}

		public XmlNode GetSettings(XmlDocument doc)
		{
			XmlElement settingsNode = doc.CreateElement("Settings");

			settingsNode.AppendChild(doc.ToElement("Version", Assembly.GetExecutingAssembly().GetName().Version.ToString(3)));

			foreach (var mapping in layout_settingsMappings)
				mapping.Attribute.GetSetting(settingsNode, mapping.Property.GetValue(this));

			return settingsNode;
		}

		public void SetSettings(XmlNode settings)
		{
			CreateMappings();

			foreach (var mapping in layout_settingsMappings)
				mapping.Property.SetValue(this, mapping.Attribute.SetSetting(settings, mapping.Property.GetValue(this)));

			if (!Loaded)
			{
				Loaded = true;
				if (this.Autoconnect && !VTS_Connection.GetInstance().Connected)
				{
					Task.Factory.StartNew(VTS_Connection.GetInstance().Connect);
				}
				if (System.IO.File.Exists(ScriptFile))
					ProcessLua();
			}
		}

		private void B_Connect_Click(object sender, EventArgs e)
		{
			if (!VTS_Connection.GetInstance().Connected)
				Task.Factory.StartNew(VTS_Connection.GetInstance().Connect);
			else
				Task.Factory.StartNew(VTS_Connection.GetInstance().Disconnect);
		}

		public void AppendMessage(string text) => messagesToAdd.Enqueue(text);

		private void ProcessLogManually(object sender, EventArgs e)
		{
			if (!DebugLog)
				return;

			while (messagesToAdd.Count > 0)
			{
				var message = messagesToAdd.Dequeue();
				if (!string.IsNullOrEmpty(message))
				{
					RB_LogText.AppendText(message + "\n");
				}
			}
		}

		private void B_BrowseScript_Click(object sender, EventArgs e)
		{
			var browseFile = new OpenFileDialog()
			{
				Filter = "Lua file|*.lua",
				Multiselect = false,
			};

			var result = browseFile.ShowDialog();
			if (result == DialogResult.Cancel)
				return;

			ScriptFile = browseFile.FileName;
			TB_ScriptFile.Text = ScriptFile;
			ProcessLua();
		}

		private void ProcessLua()
		{
			LuaMapping.ReadFile(ScriptFile, LuaDebugger);

			if (LuaMapping.Compiled)
				L_CompileState.Text = "Success";
			else
				L_CompileState.Text = "Failed to compile";
		}

		private void B_ReloadScript_Click(object sender, EventArgs e)
		{
			ProcessLua();
		}
	}
}
