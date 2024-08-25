using MoonSharp.Interpreter;
using System;
using System.IO;
using VTS.Core;

namespace LiveSplit.VTS
{
	public class LuaMapping
	{
		//TODO: Try and figure out how the call stack looks like and if elements get popped on responses
		//or is there a chance that in some cases we will have stack overflow due to multiple nested calls
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
			UserData.RegisterType<VTSMoveModelData>();
			UserData.RegisterType<VTSMoveModelData.Data>();
			UserData.RegisterType<Model.LiveSplitState>();
			UserData.RegisterType<PostProcessingValue>();

			UserData.RegisterType<VTSPostProcessingUpdateOptions>();
			UserData.RegisterType<VTSPostProcessingUpdateResponseData>();
			UserData.RegisterType<VTSPostProcessingUpdateResponseData.Data>();

			UserData.RegisterType<VTSModelLoadData>();
			UserData.RegisterType<VTSModelLoadData.Data>();

			UserData.RegisterType<VTSCurrentModelData>();
			UserData.RegisterType<VTSCurrentModelData.Data>();

			UserData.RegisterType<VTSHotkeyTriggerData>();
			UserData.RegisterType<VTSHotkeyTriggerData.Data>();

			UserData.RegisterType<VTSItemPinResponseData>();
			UserData.RegisterType<VTSItemPinResponseData.Data>();

			UserData.RegisterType<VTSItemLoadOptions>();
			UserData.RegisterType<VTSItemUnloadOptions>();
			UserData.RegisterType<VTSItemUnloadResponseData>();
			UserData.RegisterType<VTSItemUnloadResponseData.Data>();

			UserData.RegisterType<BarycentricCoordinate>();

			UserData.RegisterType<VTSErrorData>();

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
			catch (Exception ex)
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

			script.Globals["Create_VTSPostProcessingUpdateOptions"] = (Func<VTSPostProcessingUpdateOptions>)(() => new VTSPostProcessingUpdateOptions());
			script.Globals["Create_VTSItemLoadOptions"] = (Func<VTSItemLoadOptions>)(() => new VTSItemLoadOptions());
			script.Globals["Create_VTSItemUnloadOptions"] = (Func<VTSItemUnloadOptions>)(() => new VTSItemUnloadOptions());

			script.Globals[nameof(SetPostProcessingEffectValues)] = (Action<VTSPostProcessingUpdateOptions, PostProcessingValue[], Closure, Closure>)SetPostProcessingEffectValues;
			script.Globals[nameof(LoadModel)] = (Action<string, Closure, Closure>)LoadModel;
			script.Globals[nameof(MoveModel)] = (Action<VTSMoveModelData.Data, Closure, Closure>)MoveModel;
			script.Globals[nameof(TriggerHotkey)] = (Action<string, Closure, Closure>)TriggerHotkey;
			script.Globals[nameof(GetCurrentModel)] = (Action<Closure, Closure>)GetCurrentModel;

			script.Globals[nameof(AnimateItem)] = (Action<string, VTSItemAnimationControlOptions, Closure, Closure>)AnimateItem;
			script.Globals[nameof(LoadItem)] = (Action<string, VTSItemLoadOptions, Closure, Closure>)LoadItem;
			script.Globals[nameof(UnloadItem)] = (Action<VTSItemUnloadOptions, Closure, Closure>)UnloadItem;

			script.Globals[nameof(PinItemToCenter)] = (Action<string, string, string, float, VTSItemAngleRelativityMode, float, VTSItemSizeRelativityMode, Closure, Closure>)PinItemToCenter;
			script.Globals[nameof(PinItemToPoint)] = (Action<string, string, string, float, VTSItemAngleRelativityMode, float, VTSItemSizeRelativityMode, BarycentricCoordinate, Closure, Closure>)PinItemToPoint;
			script.Globals[nameof(PinItemToRandom)] = (Action<string, string, string, float, VTSItemAngleRelativityMode, float, VTSItemSizeRelativityMode, Closure, Closure>)PinItemToRandom;
			script.Globals[nameof(SetExpressionState)] = (Action<string, bool, Closure, Closure>)SetExpressionState;

			script.Globals[nameof(UnpinItem)] = (Action<string, Closure, Closure>)UnpinItem;
		}

		private static void SetPostProcessingEffectValues(VTSPostProcessingUpdateOptions options, PostProcessingValue[] values, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.SetPostProcessingEffectValues(options, values,
				(VTSPostProcessingUpdateResponseData successData) =>
				{
					onSuccess?.Call(successData);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				}
			);
		}

		private static void LoadModel(string modelId, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.LoadModel(modelId,
				(VTSModelLoadData successData) =>
				{
					onSuccess?.Call(successData);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				}
			);
		}

		private static void MoveModel(VTSMoveModelData.Data position, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.MoveModel(position,
				(VTSMoveModelData moveData) =>
				{
					onSuccess?.Call(onSuccess);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void TriggerHotkey(string hotkey, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.TriggerHotkey(hotkey,
				(VTSHotkeyTriggerData data) =>
				{
					onSuccess?.Call(data);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void AnimateItem(string itemInstanceId, VTSItemAnimationControlOptions options, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.AnimateItem(itemInstanceId, options,
				(VTSItemAnimationControlResponseData data) =>
				{
					onSuccess?.Call(data);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void GetCurrentModel(Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.GetCurrentModel(
				(VTSCurrentModelData success) =>
				{
					onSuccess?.Call(success);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void SetExpressionState(string expersion, bool active, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.SetExpressionState(expersion, active,
				(VTSExpressionActivationData data) =>
				{
					onSuccess?.Call(onSuccess);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void PinItemToCenter(string itemInstanceID, string modelID, string artMeshID, float angle, VTSItemAngleRelativityMode angleRelativeTo, float size, VTSItemSizeRelativityMode sizeRelativeTo, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.PinItemToCenter(itemInstanceID, modelID, artMeshID,
				angle, angleRelativeTo, size, sizeRelativeTo,
				(VTSItemPinResponseData success) =>
				{
					onSuccess?.Call(success);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void PinItemToPoint(string itemInstanceID, string modelID, string artMeshID, float angle, VTSItemAngleRelativityMode angleRelativeTo, float size, VTSItemSizeRelativityMode sizeRelativeTo, BarycentricCoordinate coordinate, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.PinItemToPoint(itemInstanceID, modelID, artMeshID,
				angle, angleRelativeTo, size, sizeRelativeTo, coordinate,
				(VTSItemPinResponseData success) =>
				{
					onSuccess?.Call(success);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void PinItemToRandom(string itemInstanceID, string modelID, string artMeshID, float angle, VTSItemAngleRelativityMode angleRelativeTo, float size, VTSItemSizeRelativityMode sizeRelativeTo, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.PinItemToRandom(itemInstanceID, modelID, artMeshID,
				angle, angleRelativeTo, size, sizeRelativeTo,
				(VTSItemPinResponseData success) =>
				{
					onSuccess?.Call(success);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void UnpinItem(string itemInstanceID, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.UnpinItem(itemInstanceID,
				(VTSItemPinResponseData success) =>
				{
					onSuccess?.Call(success);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void LoadItem(string fileName, VTSItemLoadOptions loadOptions, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.LoadItem(fileName, loadOptions,
				(VTSItemLoadResponseData success) =>
				{
					onSuccess?.Call(success);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}

		private static void UnloadItem(VTSItemUnloadOptions options, Closure onSuccess, Closure onError)
		{
			VTS_Connection.GetInstance().Plugin.UnloadItem(options,
				(VTSItemUnloadResponseData success) =>
				{
					onSuccess?.Call(success);
				},
				(VTSErrorData error) =>
				{
					onError?.Call(error);
				});
		}
	}
}
