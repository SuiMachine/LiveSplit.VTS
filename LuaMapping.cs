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

		public static Closure OnStart { get; private set; }
		public static Closure OnPause { get; private set; }
		public static Closure OnReset { get; private set; }
		public static Closure OnResume { get; private set; }
		public static Closure OnSplit { get; private set; }
		public static Closure OnUndoSplit { get; private set; }
		public static Closure OnSkipSplit { get; private set; }
		public static Closure OnRedSplit { get; private set; }
		public static Closure OnGreenSplit { get; private set; }
		public static Closure OnGoldSplit { get; private set; }


		public static void ReadFile(string scriptFile)
		{
			Compiled = false;

			OnStart = null;
			OnPause = null;
			OnReset = null;
			OnResume = null;
			OnSplit = null;
			OnUndoSplit = null;
			OnSkipSplit = null;
			OnRedSplit = null;
			OnGreenSplit = null;
			OnGoldSplit = null;

			if (!File.Exists(scriptFile))
				return;

			UserData.RegisterType<TimeSpan>();
			UserData.RegisterType<Random>();
			UserData.RegisterType<CoreVTSPlugin>();
			UserData.RegisterType<VTSModelAnimationEventConfigOptions>();
			UserData.RegisterType<VTSModelLoadedEventConfigOptions>();
			UserData.RegisterType<VTSPostProcessingEventConfigOptions>();
			UserData.RegisterType<LiveSplit.Model.LiveSplitState>();


			script = new Script();
			script.DoFile(scriptFile);
			SetGlobals(script);

			try
			{
				OnStart = (Closure)script.Globals["OnStart"];
				OnPause = (Closure)script.Globals["OnPause"];
				OnReset = (Closure)script.Globals["OnReset"];
				OnResume = (Closure)script.Globals["OnResume"];

				OnSplit = (Closure)script.Globals["OnSplit"];
				OnUndoSplit = (Closure)script.Globals["OnUndoSplit"];
				OnSkipSplit = (Closure)script.Globals["OnSkipSlit"];

				OnRedSplit = (Closure)script.Globals["OnRedSplit"];
				OnGreenSplit = (Closure)script.Globals["OnGreenSplit"];
				OnGoldSplit = (Closure)script.Globals["OnGoldSplit"];
				Compiled = true;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private static void SetGlobals(Script script)
		{
			script.Globals["Log"] = (Action<string>)VTS_Connection.GetInstance().Log;
			script.Globals["LogError"] = (Action<string>)VTS_Connection.GetInstance().LogError;
			script.Globals["LogWarning"] = (Action<string>)VTS_Connection.GetInstance().LogWarning;

			script.Globals["VTSPLugin"] = VTS_Connection.GetInstance().Plugin;
			script.Globals["LiveSplitState"] = VTS_Connection.GetInstance().LiveSplitState;
		}
	}
}
