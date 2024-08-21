using MoonSharp.Interpreter;
using System;
using System.IO;
using VTS.Core;

namespace LiveSplit.VTS
{
	public class LuaMapping
	{
		private static Script script;
		public static bool Compiled { get; private set; } = false;

		public static void ReadFile(string scriptFile)
		{
			Compiled = false;

			if (!File.Exists(scriptFile))
				return;

			UserData.RegisterType<TimeSpan>();
			UserData.RegisterType<Random>();
			UserData.RegisterType<CoreVTSPlugin>();
			UserData.RegisterType<VTSModelAnimationEventConfigOptions>();
			UserData.RegisterType<VTSModelLoadedEventConfigOptions>();
			UserData.RegisterType<VTSPostProcessingEventConfigOptions>();


			script = new Script();
			script.DoFile(scriptFile);

		}
	}
}
