using LiveSplit.VTS.Extensions;
using System;
using System.Xml;

namespace LiveSplit.VTS.CustomAttributes
{
	public class LiveSplitVTSStoreLayoutSetting : Attribute { }

	public abstract class LiveSplitVTSSettingsAttribute : Attribute
	{
		public string NAME { get; protected set; }

		public abstract object GetDefaultValue();
		public abstract void GetSetting(XmlElement settingNode, object objToStore);
		public abstract object SetSetting(XmlNode settingNode, object objToStoreTo);

	}

	public class LiveSplitVTSSettingsAttributeBool : LiveSplitVTSSettingsAttribute
	{
		public bool DEFAULT_VALUE { get; private set; }

		public LiveSplitVTSSettingsAttributeBool(bool defaultValue)
		{
			DEFAULT_VALUE = defaultValue;
		}

		public LiveSplitVTSSettingsAttributeBool(string Name, bool defaultValue)
		{
			this.NAME = Name;
			DEFAULT_VALUE = defaultValue;
		}

		public override object GetDefaultValue() => DEFAULT_VALUE;

		public override void GetSetting(XmlElement settingNode, object objToStore)
		{
			settingNode.AppendChild(settingNode.OwnerDocument.ToElement(this.NAME, (bool)objToStore));
		}

		public override object SetSetting(XmlNode settingNode, object objToStoreTo)
		{
			var value = XML_Utils.ReadBool(settingNode, this.NAME, DEFAULT_VALUE);
			return value;
		}
	}

	public class LiveSplitVTSSettingsAttributeString : LiveSplitVTSSettingsAttribute
	{
		public string DEFAULT_VALUE { get; private set; }

		public LiveSplitVTSSettingsAttributeString(string defaultValue)
		{
			DEFAULT_VALUE = defaultValue;
		}

		public LiveSplitVTSSettingsAttributeString(string Name, string defaultValue)
		{
			this.NAME = Name;
			DEFAULT_VALUE = defaultValue;
		}

		public override object GetDefaultValue() => DEFAULT_VALUE;

		public override void GetSetting(XmlElement settingNode, object objToStore)
		{
			settingNode.AppendChild(settingNode.OwnerDocument.ToElement(this.NAME, (string)objToStore));
		}

		public override object SetSetting(XmlNode settingNode, object objToStoreTo)
		{
			var value = XML_Utils.ReadString(settingNode, this.NAME, DEFAULT_VALUE);
			return value;
		}
	}
}
