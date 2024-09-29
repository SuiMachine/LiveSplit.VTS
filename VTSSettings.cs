using LiveSplit.VTS.CustomAttributes;
using LiveSplit.VTS.Extensions;
using MoonSharp.Interpreter;
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

		private List<(PropertyInfo Property, LiveSplitVTSSettingsAttribute Attribute)> mappings;
		private List<(PropertyInfo Property, LiveSplitVTSSettingsAttribute Attribute)> layout_settingsMappings;
		private volatile Queue<string> messagesToAdd = new Queue<string>(); //Because invokes don't seem to work and I can't be bothered
		private Timer timer;
		private DateTime LastFileUpdate;

		public VTSSettings()
		{
			InitializeComponent();

			this.CB_Autoconnect.DataBindings.Add("Checked", this, nameof(Autoconnect), false, DataSourceUpdateMode.OnPropertyChanged);
			this.TB_Address.DataBindings.Add("Text", this, nameof(Api_Address), false, DataSourceUpdateMode.OnPropertyChanged);
			this.CB_Log_DebugMessages.DataBindings.Add("Checked", this, nameof(DebugLog), false, DataSourceUpdateMode.OnPropertyChanged);
			this.TB_ScriptFile.DataBindings.Add("Text", this, nameof(ScriptFile), false, DataSourceUpdateMode.OnPropertyChanged);

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

		private void VTSSettings_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible)
			{
				ConnectionStatusChanged(VTS_Connection.GetInstance().IsAutheniticated);
				VTS_Connection.GetInstance().OnConnectionChanged += ConnectionStatusChanged;
			}
			else
			{
				VTS_Connection.GetInstance().OnConnectionChanged -= ConnectionStatusChanged;
			}
		}

		private void ConnectionStatusChanged(bool active)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() =>
				{
					ConnectionStatusChanged(active);
				}));
				return;
			}
			else
			{
				if (active)
				{
					L_ConnectionStatus.Text = "Connected";
					L_ConnectionStatus.ForeColor = System.Drawing.Color.Green;
					B_Connect.Text = "Disconnect";
				}
				else
				{
					L_ConnectionStatus.Text = "Disconnected";
					L_ConnectionStatus.ForeColor = System.Drawing.Color.Red;
					B_Connect.Text = "Connect";
				}
			}
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
				if (this.Autoconnect && !VTS_Connection.GetInstance().IsAutheniticated)
				{
					Task.Factory.StartNew(VTS_Connection.GetInstance().Connect);
				}
				if (System.IO.File.Exists(ScriptFile))
					ProcessLua();
			}
		}

		private void B_Connect_Click(object sender, EventArgs e)
		{
			if (!VTS_Connection.GetInstance().IsAutheniticated)
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
					ScrollLogToEnd();
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
			System.Diagnostics.Debug.WriteLine("Processing lua");
			LuaMapping.ReadFile(ScriptFile);

			var fileInfo = new System.IO.FileInfo(ScriptFile);
			LastFileUpdate = fileInfo.LastWriteTime;

			if (LuaMapping.Compiled)
			{
				L_CompileState.Text = "Script compiled successfully";
				L_CompileState.ForeColor = System.Drawing.Color.Green;
			}
			else
			{
				L_CompileState.Text = "Failed to compile - check log!";
				L_CompileState.ForeColor = System.Drawing.Color.Red;
			}
		}

		private void B_ReloadScript_Click(object sender, EventArgs e)
		{
			ProcessLua();
		}

		internal void CheckLuaFile()
		{
			if (string.IsNullOrEmpty(ScriptFile) || !System.IO.File.Exists(ScriptFile))
				return;

			System.IO.FileInfo fileInfo = new System.IO.FileInfo(ScriptFile);
			if (fileInfo.LastWriteTime != LastFileUpdate)
				ProcessLua();
		}

		private void B_Test_OnStart_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnStart == null)
			{
				RB_LogText.AppendText("Error: No OnStart function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnStart.CallAsync();
		}

		private void B_Test_OnPause_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnPause == null)
			{
				RB_LogText.AppendText("Error: No OnPause function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnPause.CallAsync();
		}

		private void B_Test_OnReset_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnReset == null)
			{
				RB_LogText.AppendText("Error: No OnReset function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnReset.CallAsync();
		}

		private void B_Test_OnResume_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnResume == null)
			{
				RB_LogText.AppendText("Error: No OnResume function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnResume.CallAsync();
		}

		private void B_Test_OnUndoSplit_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnUndoSplit == null)
			{
				RB_LogText.AppendText("Error: No OnUndoSplit function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnUndoSplit.CallAsync();
		}

		private void B_Test_OnSkipSplit_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnUndoSplit == null)
			{
				RB_LogText.AppendText("Error: No OnUndoSplit function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnUndoSplit.CallAsync();
		}

		private void B_Test_OnRedSplit_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnRedSplit == null)
			{
				RB_LogText.AppendText("Error: No OnRedSplit function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnRedSplit.CallAsync();
		}

		private void B_Test_OnGreenSplit_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnGreenSplit == null)
			{
				RB_LogText.AppendText("Error: No OnGreenSplit function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnGreenSplit.CallAsync();
		}

		private void B_Test_OnGoldSplit_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnGoldSplit == null)
			{
				RB_LogText.AppendText("Error: No OnGoldSplit function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnGoldSplit.CallAsync();
		}

		private void B_Test_OnGold_Click(object sender, EventArgs e)
		{
			if (!LuaMapping.Compiled)
				return;

			if (LuaMapping.OnGold == null)
			{
				RB_LogText.AppendText("Error: No OnGold function in LuaFile\n");
				ScrollLogToEnd();
				return;
			}

			LuaMapping.OnGold.CallAsync();
		}

		private void ScrollLogToEnd()
		{
			RB_LogText.SelectionStart = RB_LogText.Text.Length;
			RB_LogText.ScrollToCaret();
		}
	}
}
