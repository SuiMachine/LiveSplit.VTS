using LiveSplit.VTS.CustomAttributes;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;
using LiveSplit.VTS.Extensions;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

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

		public bool AutoReset { get; set; }
		public bool AutoStart { get; set; }

		private const bool DEFAULT_AUTORESET = false;
		private const bool DEFAULT_AUTOSTART = true;

		private List<(PropertyInfo Property, LiveSplitVTSSettingsAttribute Attribute)> mappings;
		private List<(PropertyInfo Property, LiveSplitVTSSettingsAttribute Attribute)> layout_settingsMappings;

		public VTSSettings()
		{
			InitializeComponent();

			this.CB_Autoconnect.DataBindings.Add("Checked", this, nameof(Autoconnect), false, DataSourceUpdateMode.OnPropertyChanged);
			this.TB_Address.DataBindings.Add("Text", this, nameof(Api_Address), false, DataSourceUpdateMode.OnPropertyChanged);

			// defaults
			ApplyDefaults();
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

			settingsNode.AppendChild(doc.ToElement("AutoReset", this.AutoReset));
			settingsNode.AppendChild(doc.ToElement("AutoStart", this.AutoStart));

			foreach (var mapping in layout_settingsMappings)
				mapping.Attribute.GetSetting(settingsNode, mapping.Property.GetValue(this));

			return settingsNode;
		}

		public void SetSettings(XmlNode settings)
		{
			CreateMappings();

			this.AutoReset = XML_Utils.ReadBool(settings, "AutoReset", DEFAULT_AUTORESET);
			this.AutoStart = XML_Utils.ReadBool(settings, "AutoStart", DEFAULT_AUTOSTART);

			foreach (var mapping in layout_settingsMappings)
				mapping.Property.SetValue(this, mapping.Attribute.SetSetting(settings, mapping.Property.GetValue(this)));

			if(!Loaded)
			{
				Loaded = true;
				if (this.Autoconnect && !VTS_Connection.GetInstance().Connected)
				{
					Task.Factory.StartNew(VTS_Connection.GetInstance().Connect);
				}
			}
		}

		private void B_Connect_Click(object sender, EventArgs e)
		{
			if (!VTS_Connection.GetInstance().Connected)
				Task.Factory.StartNew(VTS_Connection.GetInstance().Connect);
		}
	}
}
