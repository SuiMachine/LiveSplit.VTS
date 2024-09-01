using LiveSplit.Model;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VTS.Core;

namespace LiveSplit.VTS
{
	public class LuaMapping
	{
		//TODO: Try and figure out how the call stack looks like and if elements get popped on responses
		//or is there a chance that in some cases we will have stack overflow due to multiple nested calls
		private static Script script;
		private static MoonSharpVsCodeDebugServer debuggerServer;
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

			if (debuggerServer != null && debuggerServer.Current != null && script != null)
			{
				debuggerServer.Detach(script);
			}
			else if (debuggerServer == null)
			{
				debuggerServer = new MoonSharpVsCodeDebugServer();
				debuggerServer.Start();
			}

			if (!File.Exists(scriptFile))
				return;

			UserData.RegisterType<TimeSpan>();
			UserData.RegisterType<Random>();
			UserData.RegisterType<CoreVTSPlugin>();
			UserData.RegisterType<VTSModelAnimationEventConfigOptions>();
			UserData.RegisterType<VTSModelLoadedEventConfigOptions>();
			UserData.RegisterType<VTSMoveModelData>();
			UserData.RegisterType<VTSMoveModelData.Data>();
			UserData.RegisterType<LiveSplitState>();
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
			UserData.RegisterType<VTSExpressionActivationData>();
			UserData.RegisterType<VTSArtMeshListData>();

			UserData.RegisterType<VTSItemPinResponseData>();
			UserData.RegisterType<VTSItemPinResponseData.Data>();

			UserData.RegisterType<VTSItemLoadOptions>();
			UserData.RegisterType<VTSItemUnloadOptions>();
			UserData.RegisterType<VTSItemUnloadResponseData>();
			UserData.RegisterType<VTSItemUnloadResponseData.Data>();

			UserData.RegisterType<VTSItemLoadResponseData>();
			UserData.RegisterType<VTSItemLoadResponseData.Data>();

			UserData.RegisterType<VTSItemListResponseData>();
			UserData.RegisterType<VTSItemListResponseData.Data>();
			UserData.RegisterType<ItemInstance>();
			UserData.RegisterType<ItemFile>();
			UserData.RegisterType<VTSItemListOptions>();

			UserData.RegisterType<VTSItemMoveResponseData>();
			UserData.RegisterType<VTSItemMoveResponseData.Data>();
			UserData.RegisterType<VTSItemMoveOptions>();
			UserData.RegisterType<MovedItem>();
			UserData.RegisterType<VTSItemMoveEntry>();
			UserData.RegisterType<ModelPosition>();

			UserData.RegisterType<BarycentricCoordinate>();

			UserData.RegisterType<VTSErrorData>();

			UserData.RegisterType<TimeSpan>();
			UserData.RegisterType<TimeSpan?>();
			UserData.RegisterType<DateTime>();
			UserData.RegisterType<DateTime?>();
			UserData.RegisterType<Time>();
			UserData.RegisterType<AtomicDateTime>();
			UserData.RegisterType<ISegment>();
			UserData.RegisterType<ISegment[]>();

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
				return;
			}

			debuggerServer.AttachToScript(script, "VTS control script");
		}

		private static void SetGlobals(Script script)
		{
			script.Globals["Log"] = (Action<string>)VTS_Connection.GetInstance().Log;
			script.Globals["LogError"] = (Action<string>)VTS_Connection.GetInstance().LogError;
			script.Globals["LogWarning"] = (Action<string>)VTS_Connection.GetInstance().LogWarning;

			script.Globals["GetLiveSplitState"] = (Func<LiveSplitState>)(() => VTS_Connection.GetInstance().LiveSplitState);
			script.Globals["GetRunAsArray"] = (Func<ISegment[]>)(() => VTS_Connection.GetInstance().LiveSplitState.Run.ToArray());

			script.Globals["Create_VTSPostProcessingUpdateOptions"] = (Func<VTSPostProcessingUpdateOptions>)(() => new VTSPostProcessingUpdateOptions());
			script.Globals["Create_VTSItemLoadOptions"] = (Func<VTSItemLoadOptions>)(() => new VTSItemLoadOptions());
			script.Globals["Create_VTSItemUnloadOptions"] = (Func<VTSItemUnloadOptions>)(() => new VTSItemUnloadOptions());
			script.Globals["Create_VTSItemListOptions"] = (Func<VTSItemListOptions>)(() => new VTSItemListOptions());
			script.Globals["Create_MovedItem"] = (Func<MovedItem>)(() => new MovedItem());
			script.Globals["Create_VTSItemMoveEntry"] = (Func<VTSItemMoveEntry>)(() => new VTSItemMoveEntry());

			script.Globals["GetCurrentModelID"] = (Func<string>)(() => VTS_Connection.GetInstance().CurrentModelId);
			script.Globals["GetCurrentModelName"] = (Func<string>)(() => VTS_Connection.GetInstance().CurrentModelName);

			script.Globals["Sleep"] = (Action<int>)((int sleep) => Task.Delay(sleep).GetAwaiter().GetResult());

			script.Globals[nameof(SetPostProcessingEffectValues)] = (Func<VTSPostProcessingUpdateOptions, PostProcessingValue[], VTSPostProcessingUpdateResponseData>)SetPostProcessingEffectValues;
			script.Globals[nameof(LoadModel)] = (Func<string, VTSModelLoadData>)LoadModel;
			script.Globals[nameof(MoveModel)] = (Func<VTSMoveModelData.Data, VTSMoveModelData>)MoveModel;
			script.Globals[nameof(TriggerHotkey)] = (Func<string, VTSHotkeyTriggerData>)TriggerHotkey;
			script.Globals[nameof(GetCurrentModel)] = (Func<VTSCurrentModelData>)GetCurrentModel;
			script.Globals[nameof(GetArtMeshList)] = (Func<VTSArtMeshListData>)GetArtMeshList;

			script.Globals[nameof(AnimateItem)] = (Func<string, VTSItemAnimationControlOptions, VTSItemAnimationControlResponseData>)AnimateItem;
			script.Globals[nameof(GetItemList)] = (Func<VTSItemListOptions, VTSItemListResponseData>)GetItemList;
			script.Globals[nameof(LoadItem)] = (Func<string, VTSItemLoadOptions, VTSItemLoadResponseData>)LoadItem;
			script.Globals[nameof(UnloadItem)] = (Func<VTSItemUnloadOptions, VTSItemUnloadResponseData>)UnloadItem;
			script.Globals[nameof(MoveItem)] = (Func<VTSItemMoveEntry[], VTSItemMoveResponseData>)MoveItem;

			script.Globals[nameof(PinItemToCenter)] = (Func<string, string, string, float, VTSItemAngleRelativityMode, float, VTSItemSizeRelativityMode, VTSItemPinResponseData>)PinItemToCenter;
			script.Globals[nameof(PinItemToPoint)] = (Func<string, string, string, float, VTSItemAngleRelativityMode, float, VTSItemSizeRelativityMode, BarycentricCoordinate, VTSItemPinResponseData>)PinItemToPoint;
			script.Globals[nameof(PinItemToRandom)] = (Func<string, string, string, float, VTSItemAngleRelativityMode, float, VTSItemSizeRelativityMode, VTSItemPinResponseData>)PinItemToRandom;
			script.Globals[nameof(UnpinItem)] = (Func<string, VTSItemPinResponseData>)UnpinItem;
			script.Globals[nameof(ExtendedDropImages)] = (Func<string, bool, VTSExtendedDropItemOptionsResponse>)ExtendedDropImages;
		}

		private static VTSPostProcessingUpdateResponseData SetPostProcessingEffectValues(VTSPostProcessingUpdateOptions options, PostProcessingValue[] values) => VTS_Connection.GetInstance().Plugin?.SetPostProcessingEffectValues(options, values).Result;
		private static VTSModelLoadData LoadModel(string modelId) => VTS_Connection.GetInstance().Plugin?.LoadModel(modelId).Result;
		private static VTSMoveModelData MoveModel(VTSMoveModelData.Data position) => VTS_Connection.GetInstance().Plugin?.MoveModel(position).Result;
		private static VTSHotkeyTriggerData TriggerHotkey(string hotkey) => VTS_Connection.GetInstance().Plugin?.TriggerHotkey(hotkey).Result;
		private static VTSItemAnimationControlResponseData AnimateItem(string itemInstanceId, VTSItemAnimationControlOptions options) => VTS_Connection.GetInstance().Plugin?.AnimateItem(itemInstanceId, options).Result;
		private static VTSCurrentModelData GetCurrentModel() => VTS_Connection.GetInstance().Plugin?.GetCurrentModel().Result;
		private static VTSArtMeshListData GetArtMeshList() => VTS_Connection.GetInstance().Plugin?.GetArtMeshList().Result;
		private static VTSExpressionActivationData SetExpressionState(string expersion, bool active) => VTS_Connection.GetInstance().Plugin?.SetExpressionState(expersion, active).Result;
		private static VTSItemPinResponseData PinItemToCenter(string itemInstanceID, string modelID, string artMeshID, float angle, VTSItemAngleRelativityMode angleRelativeTo, float size, VTSItemSizeRelativityMode sizeRelativeTo) => VTS_Connection.GetInstance().Plugin?.PinItemToCenter(itemInstanceID, modelID, artMeshID, angle, angleRelativeTo, size, sizeRelativeTo).Result;
		private static VTSItemPinResponseData PinItemToPoint(string itemInstanceID, string modelID, string artMeshID, float angle, VTSItemAngleRelativityMode angleRelativeTo, float size, VTSItemSizeRelativityMode sizeRelativeTo, BarycentricCoordinate coordinate) => VTS_Connection.GetInstance().Plugin?.PinItemToPoint(itemInstanceID, modelID, artMeshID, angle, angleRelativeTo, size, sizeRelativeTo, coordinate).Result;
		private static VTSItemPinResponseData PinItemToRandom(string itemInstanceID, string modelID, string artMeshID, float angle, VTSItemAngleRelativityMode angleRelativeTo, float size, VTSItemSizeRelativityMode sizeRelativeTo) => VTS_Connection.GetInstance().Plugin?.PinItemToRandom(itemInstanceID, modelID, artMeshID, angle, angleRelativeTo, size, sizeRelativeTo).Result;
		private static VTSItemPinResponseData UnpinItem(string itemInstanceID) => VTS_Connection.GetInstance().Plugin?.UnpinItem(itemInstanceID).Result;
		private static VTSItemListResponseData GetItemList(VTSItemListOptions options) => VTS_Connection.GetInstance().Plugin?.GetItemList(options).Result;
		private static VTSItemLoadResponseData LoadItem(string fileName, VTSItemLoadOptions loadOptions) => VTS_Connection.GetInstance().Plugin?.LoadItem(fileName, loadOptions).Result;
		private static VTSItemMoveResponseData MoveItem(VTSItemMoveEntry[] moveEntry) => VTS_Connection.GetInstance().Plugin?.MoveItem(moveEntry).Result;
		private static VTSItemUnloadResponseData UnloadItem(VTSItemUnloadOptions options) => VTS_Connection.GetInstance().Plugin?.UnloadItem(options).Result;
		private static VTSExtendedDropItemOptionsResponse ExtendedDropImages(string expersion, bool active) => VTS_Connection.GetInstance().Plugin?.ExtendedDropImages(new VTSExtendedDropItemOptions()).Result;

	}
}
