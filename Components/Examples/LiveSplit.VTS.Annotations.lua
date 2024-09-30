---Logs a message
---@param message string
function Log(message) end

---Logs an error
---@param message string
function LogError(message) end

---Logs a warning
---@param message string
function LogWarning(message) end

---Gets current LiveSplit state object
---@return LiveSplitState
function GetLiveSplitState() end

---Gets Segments as an array
---@return ISegment[]
function GetRunAsArray() end

---Delays execution of task
---@param time integer Time in miliseconds
function Sleep(time) end

---@return string ModelName Model name
function GetCurrentModelName() end

---@return string ModelID Model id
function GetCurrentModelID() end

---Creates VTSItemLoadOptions
---@return VTSItemLoadOptions
function Create_VTSItemLoadOptions() end

---Creates VTSItemUnloadOptions
---@return VTSItemUnloadOptions
function Create_VTSItemUnloadOptions() end

---Creates VTSPostProcessingUpdateOptions
---@return VTSPostProcessingUpdateOptions
function Create_VTSPostProcessingUpdateOptions() end

---Creates VTSItemListOptions
---@return VTSItemListOptions
function Create_VTSItemListOptions() end

---Creates MovedItem
---@return MovedItem
function Create_MovedItem() end

---Creates VTSItemMoveEntry
---@return VTSItemMoveEntry
function Create_VTSItemMoveEntry() end

---Sets a post processing in VTS
---@param options VTSPostProcessingUpdateOptions
---@param value PostProcessingValue[]
---@return VTSPostProcessingUpdateResponseData
function SetPostProcessingEffectValues(options, value) end

---Sets a model in VTS
---@param modelId string Id of the model
---@return VTSModelLoadData
function LoadModel(modelId) end

---Moves a model
---@param position VTSMoveModelData_Data
---@return VTSMoveModelData
function MoveModel(position) end

---Triggers a Hotkey action in VTS
---@param hotkey string
---@return VTSHotkeyTriggerData
function TriggerHotkey(hotkey) end

---Gets a list of current items in the scene
---@param options VTSItemListOptions
---@return VTSItemListResponseData
function GetItemList(options) end

---Used to animate certain item
---@param itemInstanceId string
---@param options VTSItemAnimationControlOptions
---@return VTSItemAnimationControlOptions
function AnimateItem(itemInstanceId, options) end

---Gets a list of art meshes
---@return VTSArtMeshListData
function GetArtMeshList() end

---Loads an item into a scene
---@param fileName string
---@param loadOptions VTSItemLoadOptions
---@return VTSItemLoadResponseData
function LoadItem(fileName, loadOptions) end

---Moves item / items
---@param moveEntry VTSItemMoveEntry[]
---@return VTSItemMoveResponseData
function MoveItem(moveEntry) end

---Unloads an item from the scene
---@param VTSItemUnloadOptions VTSItemUnloadOptions
---@return VTSItemUnloadOptions
function UnloadItem(VTSItemUnloadOptions) end

---Used to obtain current model info
---@return VTSCurrentModelData CurrentModel
function GetCurrentModel() end

---Pins and item to a random spot?
---@param itemInstanceID string Instance ID of an item
---@param modelID string Model ID
---@param artMeshID string Art mesh ID
---@param angle number Angle at which to pin
---@param angleRelativeTo VTSItemAngleRelativityMode Angle mode
---@param size number Size
---@param sizeRelativeTo VTSItemSizeRelativityMode Scale mode
---@return VTSItemPinResponseData
function PinItemToRandom(itemInstanceID, modelID, artMeshID, angle, angleRelativeTo, size, sizeRelativeTo) end

---Pins an item to a center?
---@param itemInstanceID string Instance ID of an item
---@param modelID string Model ID
---@param artMeshID string Art mesh ID
---@param angle number Angle at which to pin
---@param angleRelativeTo VTSItemAngleRelativityMode
---@param size number
---@param sizeRelativeTo VTSItemSizeRelativityMode
---@return VTSItemPinResponseData
function PinItemToCenter(itemInstanceID, modelID, artMeshID, angle, angleRelativeTo, size, sizeRelativeTo) end

---Pins an item to a point
---@param itemInstanceID string Instance ID of an item
---@param modelID string Model ID
---@param artMeshID string Art mesh ID
---@param angle number Angle at which to pin
---@param angleRelativeTo VTSItemAngleRelativityMode Angle mode
---@param size number Size
---@param sizeRelativeTo VTSItemSizeRelativityMode Scale mode
---@return VTSItemPinResponseData
function PinItemToPoint(itemInstanceID, modelID, artMeshID, angle, angleRelativeTo, size, sizeRelativeTo) end

---Used to unpin an item
---@param itemInstanceID string
---@return VTSItemPinResponseData
function UnpinItem(itemInstanceID) end

---Sets an expression
---@param expersion string
---@param active boolean
---@return VTSExpressionActivationData
function SetExpressionState(expersion, active) end

---For moving objects in general
---@class VTSMoveModelData
---@field data VTSMoveModelData_Data

---@class VTSMoveModelData_Data
---@field timeInSeconds number
---@field valuesAreRelativeToModel boolean

---For response to loading a VTS model
---@class VTSModelLoadData
---@field data VTSModelLoadData_Data

---@class VTSModelLoadData_Data
---@field modelID string

---For response to Hotkey Trigger
---@class VTSHotkeyTriggerData
---@field data VTSHotkeyTriggerData_Data

---@class VTSHotkeyTriggerData_Data
---@field hotkeyID string
---@field itemInstanceID string

---For response when stuff goes wrong
---@class VTSErrorData
---@field data VTSErrorData_Data 

---For errors
---@class VTSErrorData_Data
---@field errorID ErrorID
---@field message string
---@enum ErrorID
ErrorID = {
    InternalServerError = 0,
	APIAccessDeactivated = 1,
	JSONInvalid = 2,
	APINameInvalid = 3,
	APIVersionInvalid = 4,
	RequestIDInvalid = 5,
	RequestTypeMissingOrEmpty = 6,
	RequestTypeUnknown = 7,
	RequestRequiresAuthetication = 8,
	RequestRequiresPermission = 9,
	TokenRequestDenied = 50,
	TokenRequestCurrentlyOngoing = 51,
	TokenRequestPluginNameInvalid = 52,
	TokenRequestDeveloperNameInvalid = 53,
	TokenRequestPluginIconInvalid = 54,
	AuthenticationTokenMissing = 100,
	AuthenticationPluginNameMissing = 101,
	AuthenticationPluginDeveloperMissing = 102,
	ModelIDMissing = 150,
	ModelIDInvalid = 151,
	ModelIDNotFound = 152,
	ModelLoadCooldownNotOver = 153,
	CannotCurrentlyChangeModel = 154,
	HotkeyQueueFull = 200,
	HotkeyExecutionFailedBecauseNoModelLoaded = 201,
	HotkeyIDNotFoundInModel = 202,
	HotkeyCooldownNotOver = 203,
	HotkeyIDFoundButHotkeyDataInvalid = 204,
	HotkeyExecutionFailedBecauseBadState = 205,
	HotkeyUnknownExecutionFailure = 206,
	HotkeyExecutionFailedBecauseLive2DItemNotFound = 207,
	HotkeyExecutionFailedBecauseLive2DItemsDoNotSupportThisHotkeyType = 208,
	ColorTintRequestNoModelLoaded = 250,
	ColorTintRequestMatchOrColorMissing = 251,
	ColorTintRequestInvalidColorValue = 252,
	MoveModelRequestNoModelLoaded = 300,
	MoveModelRequestMissingFields = 301,
	MoveModelRequestValuesOutOfRange = 302,
	CustomParamNameInvalid = 350,
	CustomParamValuesInvalid = 351,
	CustomParamAlreadyCreatedByOtherPlugin = 352,
	CustomParamExplanationTooLong = 353,
	CustomParamDefaultParamNameNotAllowed = 354,
	CustomParamLimitPerPluginExceeded = 355,
	CustomParamLimitTotalExceeded = 356,
	CustomParamDeletionNameInvalid = 400,
	CustomParamDeletionNotFound = 401,
	CustomParamDeletionCreatedByOtherPlugin = 402,
	CustomParamDeletionCannotDeleteDefaultParam = 403,
	InjectDataNoDataProvided = 450,
	InjectDataValueInvalid = 451,
	InjectDataWeightInvalid = 452,
	InjectDataParamNameNotFound = 453,
	InjectDataParamControlledByOtherPlugin = 454,
	InjectDataModeUnknown = 455,
	ParameterValueRequestParameterNotFound = 500,
	NDIConfigCooldownNotOver = 550,
	NDIConfigResolutionInvalid = 551,
	ExpressionStateRequestInvalidFilename = 600,
	ExpressionStateRequestFileNotFound = 601,
	ExpressionActivationRequestInvalidFilename = 650,
	ExpressionActivationRequestFileNotFound = 651,
	ExpressionActivationRequestNoModelLoaded = 652,
	SetCurrentModelPhysicsRequestNoModelLoaded = 700,
	SetCurrentModelPhysicsRequestModelHasNoPhysics = 701,
	SetCurrentModelPhysicsRequestPhysicsControlledByOtherPlugin = 702,
	SetCurrentModelPhysicsRequestNoOverridesProvided = 703,
	SetCurrentModelPhysicsRequestPhysicsGroupIDNotFound = 704,
	SetCurrentModelPhysicsRequestNoOverrideValueProvided = 705,
	SetCurrentModelPhysicsRequestDuplicatePhysicsGroupID = 706,
	ItemFileNameMissing = 750,
	ItemFileNameNotFound = 751,
	ItemLoadLoadCooldownNotOver = 752,
	CannotCurrentlyLoadItem = 753,
	CannotLoadItemSceneFull = 754,
	ItemOrderInvalid = 755,
	ItemOrderAlreadyTaken = 756,
	ItemLoadValuesInvalid = 757,
	ItemCustomDataInvalid = 758,
	ItemCustomDataCannotAskRightNow = 759,
	ItemCustomDataLoadRequestRejectedByUser = 760,
	CannotCurrentlyUnloadItem = 800,
	ItemAnimationControlInstanceIDNotFound = 850,
	ItemAnimationControlUnsupportedItemType = 851,
	ItemAnimationControlAutoStopFramesInvalid = 852,
	ItemAnimationControlTooManyAutoStopFrames = 853,
	ItemAnimationControlSimpleImageDoesNotSupportAnim = 854,
	ItemMoveRequestInstanceIDNotFound = 900,
	ItemMoveRequestInvalidFadeMode = 901,
	ItemMoveRequestItemOrderTakenOrInvalid = 902,
	ItemMoveRequestCannotCurrentlyChangeOrder = 903,
	EventSubscriptionRequestEventTypeUnknown = 950,
	ArtMeshSelectionRequestNoModelLoaded = 1000,
	ArtMeshSelectionRequestOtherWindowsOpen = 1001,
	ArtMeshSelectionRequestModelDoesNotHaveArtMesh = 1002,
	ArtMeshSelectionRequestArtMeshIDListError = 1003,
	ItemPinRequestGivenItemNotLoaded = 1050,
	ItemPinRequestInvalidAngleOrSizeType = 1051,
	ItemPinRequestModelNotFound = 1052,
	ItemPinRequestArtMeshNotFound = 1053,
	ItemPinRequestPinPositionInvalid = 1054,
	PermissionRequestUnknownPermission = 1100,
	PermissionRequestCannotRequestRightNow = 1101,
	PermissionRequestFileProblem = 1102,
	PostProcessingListReqestInvalidFilter = 1150,
	PostProcessingUpdateReqestCannotUpdateRightNow = 1200,
	PostProcessingUpdateRequestFadeTimeInvalid = 1201,
	PostProcessingUpdateRequestLoadingPresetAndValues = 1202,
	PostProcessingUpdateRequestPresetFileLoadFailed = 1203,
	PostProcessingUpdateRequestValueListInvalid = 1204,
	PostProcessingUpdateRequestValueListContainsDuplicates = 1205,
	PostProcessingUpdateRequestTriedToLoadRestrictedEffect = 1206,
	EVENT_OFFSET = 100000,
	Event_TestEvent_TestMessageTooLong = 100000,
	Event_ModelLoadedEvent_ModelIDInvalid = 100050
}

---For setting post processing
---@class VTSPostProcessingUpdateOptions
---@field postProcessingOn boolean
---@field setPostProcessingPreset boolean
---@field setPostProcessingValues boolean
---@field presetToSet string
---@field postProcessingFadeTime number
---@field setAllOtherValuesToDefault boolean
---@field usingRestrictedEffects boolean
---@field randomizeAll boolean
---@field randomizeAllChaosLevel number
local VTSPostProcessingUpdateOptions = {}

---@class PostProcessingValue
---@field configID EffectConfigs
---@field configValue string
local PostProcessingValue = {}

---@enum EffectConfigs
EffectConfigs = {
    ColorGrading_Strength = 0,
    ColorGrading_HueShift = 1,
    ColorGrading_Saturation = 2,
    ColorGrading_Brightness = 3,
    ColorGrading_Contrast = 4,
    ColorGrading_ColorFilter = 5,
    ColorGrading_WhitebalanceTemperature = 6,
    ColorGrading_WhitebalanceTint = 7,
    ColorGrading_Invert = 8,
    WeatherEffects_RainStrength = 9,
    WeatherEffects_SnowStrength = 10,
    WeatherEffects_RainInFront = 11,
    WeatherEffects_SnowInFront = 12,
    Bloom_Strength = 13,
    Bloom_ModelColorDarken = 14,
    Bloom_BackgroundColorDarken = 15,
    Bloom_MainThreshold = 16,
    Bloom_MainIntensity = 17,
    Bloom_MainColorTint = 18,
    Bloom_StreakThreshold = 19,
    Bloom_StreakIntensity = 20,
    Bloom_StreakColorTint = 21,
    Bloom_StreakVertical = 22,
    Bloom_MicIncreasesBloom = 23,
    Bloom_Quality = 24,
    Backlight_Strength = 25,
    Backlight_BgBlurOverModel = 26,
    Backlight_BgBlurOverBg = 27,
    Backlight_DarkenModel = 28,
    Backlight_DarkenBg = 29,
    Backlight_StrengthNormal = 30,
    Backlight_StrengthDirectional = 31,
    Backlight_BrightnessLimit = 32,
    Backlight_BacklightDirection = 33,
    Backlight_BacklightBothDirections = 34,
    Backlight_BacklightSoftness = 35,
    Backlight_BacklightColorTint = 36,
    Backlight_BacklightColorFromBg = 37,
    Backlight_OutlineSize = 38,
    Backlight_OutlineColorMain = 39,
    Backlight_OutlineColorStripes = 40,
    Backlight_OutlineStripeCount = 41,
    Backlight_OutlineStripeSpeed = 42,
    Backlight_OutlineStripeCurve = 43,
    Backlight_ShadowMainColor = 44,
    Backlight_ShadowOffsetX = 45,
    Backlight_ShadowOffsetY = 46,
    CustomParticles_Strength = 47,
    CustomParticles_BaseMoveWithHead = 48,
    CustomParticles_SparkleStrength = 49,
    CustomParticles_SparkleSize = 50,
    CustomParticles_SparkleColorA = 51,
    CustomParticles_SparkleColorB = 52,
    CustomParticles_FloatyStrength = 53,
    CustomParticles_FloatySize = 54,
    CustomParticles_FloatyColorA = 55,
    CustomParticles_FloatyColorB = 56,
    CustomParticles_CloudStrength = 57,
    CustomParticles_CloudSize = 58,
    CustomParticles_CloudColorA = 59,
    CustomParticles_CloudColorB = 60,
    CustomParticles_SphereStrength = 61,
    CustomParticles_SphereSize = 62,
    CustomParticles_SphereColorA = 63,
    CustomParticles_SphereColorB = 64,
    CustomParticles_HeartsStrength = 65,
    CustomParticles_HeartsSize = 66,
    CustomParticles_HeartsColorA = 67,
    CustomParticles_HeartsColorB = 68,
    CustomParticles_Custom1TextureFile = 69,
    CustomParticles_Custom1ColorA = 70,
    CustomParticles_Custom1ColorB = 71,
    CustomParticles_Custom1MaterialTypeId = 72,
    CustomParticles_Custom1InBack = 73,
    CustomParticles_Custom1MoveWithHead = 74,
    CustomParticles_Custom1Size = 75,
    CustomParticles_Custom1Amount = 76,
    CustomParticles_Custom1FillToCenter = 77,
    CustomParticles_Custom1BaseRotation = 78,
    CustomParticles_Custom1RotationSpeed = 79,
    CustomParticles_Custom1MoveFasterMicVol = 80,
    CustomParticles_Custom2TextureFile = 81,
    CustomParticles_Custom2ColorA = 82,
    CustomParticles_Custom2ColorB = 83,
    CustomParticles_Custom2MaterialTypeId = 84,
    CustomParticles_Custom2InBack = 85,
    CustomParticles_Custom2MoveWithHead = 86,
    CustomParticles_Custom2Size = 87,
    CustomParticles_Custom2Amount = 88,
    CustomParticles_Custom2FillToCenter = 89,
    CustomParticles_Custom2BaseRotation = 90,
    CustomParticles_Custom2RotationSpeed = 91,
    CustomParticles_Custom2MoveFasterMicVol = 92,
    BackgroundShift_Strength = 93,
    BackgroundShift_ZoomIn = 94,
    BackgroundShift_MicZoomIn = 95,
    BackgroundShift_TrackingX = 96,
    BackgroundShift_TrackingY = 97,
    BackgroundShift_TrackingSmoothing = 98,
    BackgroundShift_RandomMovementX = 99,
    BackgroundShift_RandomMovementY = 100,
    BackgroundShift_RandomMovementRotation = 101,
    BackgroundShift_RandomMovementSpeed = 102,
    BackgroundShift_BlurMixBack = 103,
    BackgroundShift_BlurMainBack = 104,
    BackgroundShift_BlurBrightnessBack = 105,
    BackgroundShift_BlurMixFront = 106,
    BackgroundShift_BlurMainFront = 107,
    BackgroundShift_BlurBrightnessFront = 108,
    SimpleOverlay_Strength = 109,
    SimpleOverlay_TextureFile = 110,
    SimpleOverlay_ZoomIn = 111,
    SimpleOverlay_TrackingX = 112,
    SimpleOverlay_TrackingY = 113,
    SimpleOverlay_TrackingSmoothing = 114,
    SimpleOverlay_RandomMovementX = 115,
    SimpleOverlay_RandomMovementY = 116,
    SimpleOverlay_RandomMovementRotation = 117,
    SimpleOverlay_RandomMovementSpeed = 118,
    SimpleOverlay_TintColor = 119,
    Vignette_Strength = 120,
    Vignette_Smoothness = 121,
    Vignette_Color = 122,
    Vignette_CenterX = 123,
    Vignette_CenterY = 124,
    Vignette_Roundness = 125,
    Vignette_Circular = 126,
    ChromaticAberration_Strength = 127,
    ChromaticAberration_BlurEdges = 128,
    OldFilm_Strength = 129,
    OldFilm_FilmFps = 130,
    OldFilm_FilmContrast = 131,
    OldFilm_FilmBurn = 132,
    OldFilm_FilmSceneCut = 133,
    Lowfps_Strength = 134,
    Lowfps_FpsLimit = 135,
    Lowfps_FpsRandom = 136,
    Lowfps_ScreenTearing = 137,
    Datamosh_Strength = 138,
    Datamosh_Size = 139,
    Datamosh_ResetAfterSecs = 140,
    Datamosh_Entropy = 141,
    Datamosh_NoiseContrast = 142,
    Datamosh_VelocityScale = 143,
    Datamosh_Diffusion = 144,
    LineScanner_Strength = 145,
    LineScanner_Direction = 146,
    LineScanner_ScanStepTotal = 147,
    LineScanner_ScanStepSize = 148,
    LineScanner_ScanLineColor = 149,
    LineScanner_ScanLineSize = 150,
    LineScanner_ScanLineWaitBetweenScansSecs = 151,
    ParticleShower_Strength = 152,
    ParticleShower_TextureFile1 = 153,
    ParticleShower_TextureFile2 = 154,
    ParticleShower_TextureFile3 = 155,
    ParticleShower_Speed1 = 156,
    ParticleShower_Speed2 = 157,
    ParticleShower_Speed3 = 158,
    ParticleShower_InBack1 = 159,
    ParticleShower_InBack2 = 160,
    ParticleShower_InBack3 = 161,
    AnalogGlitch_Strength = 162,
    AnalogGlitch_ScanlineJitter = 163,
    AnalogGlitch_VerticalJump = 164,
    AnalogGlitch_HorizontalShake = 165,
    AnalogGlitch_ColorDrift = 166,
    AnalogGlitch_MicEffect = 167,
    DigitalGlitch_Strength = 168,
    DigitalGlitch_Colorshift = 169,
    DigitalGlitch_MicEffect = 170,
    Letterbox_Strength = 171,
    Letterbox_ProgressY = 172,
    Letterbox_ProgressX = 173,
    Letterbox_Zoom = 174,
    Letterbox_Color = 175,
    FoggyWindow_Strength = 176,
    FoggyWindow_FogStrength = 177,
    FoggyWindow_FogTint = 178,
    FoggyWindow_FogBoost = 179,
    FoggyWindow_RaindropVisibility = 180,
    FoggyWindow_RaindropSpeed = 181,
    FoggyWindow_RaindropSize = 182,
    FoggyWindow_FogWipeSize = 183,
    FoggyWindow_FogWipeLifetimeSeconds = 184,
    FoggyWindow_FogLifetimeInfinite = 185,
    Speedlines_Strength = 186,
    Speedlines_XCenter = 187,
    Speedlines_YCenter = 188,
    Speedlines_ColorA = 189,
    Speedlines_ColorB = 190,
    Speedlines_MicEffect = 191,
    Pixelation_Strength = 192,
    Pixelation_Resolution = 193,
    Pixelation_Colorize = 194,
    Pixelation_C1 = 195,
    Pixelation_C2 = 196,
    Pixelation_C3 = 197,
    Pixelation_C4 = 198,
    Pixelation_C5 = 199,
    Pixelation_C6 = 200,
    Pixelation_C7 = 201,
    Pixelation_C8 = 202,
    Pixelation_Fry = 203,
    LensDistortion_Strength = 204,
    LensDistortion_LensStrength = 205,
    LensDistortion_ZoomIn = 206,
    LensDistortion_Squish = 207,
    WaveDistortion_Strength = 208,
    WaveDistortion_HeatStrength = 209,
    WaveDistortion_RaindropStrength = 210,
    WaveDistortion_RaindropFrequency = 211,
    WaveDistortion_ZoomIn = 212,
    WaveDistortion_RotationBase = 213,
    WaveDistortion_WaveXStrength = 214,
    WaveDistortion_WaveXScroll = 215,
    WaveDistortion_WaveXFrequency = 216,
    WaveDistortion_WaveYStrength = 217,
    WaveDistortion_WaveYScroll = 218,
    WaveDistortion_WaveYFrequency = 219,
    BlurEffects_Strength = 220,
    BlurEffects_BasicBlurVisibility = 221,
    BlurEffects_BasicBlurStrength = 222,
    BlurEffects_PixelationBlur = 223,
    BlurEffects_MotionBlur = 224,
    Grain_Strength = 225,
    Grain_Size = 226,
    Grain_Luminosity = 227,
    Grain_Colored = 228,
    Vhs_Strength = 229,
    Vhs_Fisheye = 230,
    Vhs_Vignette = 231,
    Vhs_ScreenBleed = 232,
    Vhs_NoiseGrain = 233,
    Vhs_NoiseLines = 234,
    Vhs_TwitchVertical = 235,
    Vhs_TwitchHorizontal = 236,
    Vhs_Interlacing = 237,
    Vhs_GammaCorrection = 238,
    Vhs_PaleColor = 239,
    Vhs_AfterImageAmount = 240,
    Vhs_AfterImageColor = 241,
    Outline_Strength = 242,
    Outline_Sharpen = 243,
    Outline_Visibility = 244,
    Outline_Color = 245,
    Outline_Threshold = 246,
    Outline_Contrast = 247,
    Posterize_Strength = 248,
    Ascii_Strength = 249,
    Ascii_Size = 250,
    Ascii_CharacterVisibility = 251,
    Ascii_CharacterColorStrength = 252,
    Ascii_CharacterColor = 253,
    ModelGlitch_StrengthExplode = 254,
    ModelGlitch_StrengthWiggle = 255,
    ModelGlitch_StrengthPulse = 256,
    ModelGlitch_StrengthLiquify = 257
}

---For response to setting post processing
---@class VTSPostProcessingUpdateResponseData
---@field data VTSPostProcessingUpdateResponseData_Data

---@class VTSPostProcessingUpdateResponseData_Data
---@field postProcessingActive boolean
---@field presetIsActive boolean
---@field activePreset string
---@field activeEffectCount integer

---For responses to getting current model
---@class VTSCurrentModelData
---@field data VTSCurrentModelData_Data

---@class VTSCurrentModelData_Data
---@field live2DModelName string
---@field modelLoadTime integer
---@field timeSinceModelLoaded integer
---@field numberOfLive2DParameters integer
---@field numberOfLive2DArtmeshes integer
---@field hasPhysicsFile boolean
---@field numberOfTextures integer
---@field textureResolution integer
---@field modelPosition ModelPosition

---@class ModelPosition
---@field positionX number
---@field positionY number
---@field rotation number
---@field size number

---@class VTSItemAnimationControlOptions
---@field framerate integer
---@field frame integer
---@field brightness number
---@field opacity number
---@field setAutoStopFrames boolean
---@field autoStopFrames integer[]
---@field setAnimationPlayState boolean
---@field animationPlayState boolean

---For Loading / unloading item
---@class VTSItemLoadOptions
---@field positionX number
---@field positionY number
---@field size number
---@field rotation number
---@field fadeTime number
---@field order integer
---@field failIfOrderTaken boolean
---@field smoothing number
---@field censored boolean
---@field flipped boolean
---@field locked boolean
---@field unloadWhenPluginDisconnects boolean

---@class VTSItemLoadResponseData
---@field data VTSItemLoadResponseData_Data

---@class VTSItemLoadResponseData_Data
---@field instanceID string

---@class VTSItemUnloadOptions
---@field itemInstanceIDs string[]
---@field fileNames string[]
---@field unloadAllInScene boolean
---@field unloadAllLoadedByThisPlugin boolean
---@field allowUnloadingItemsLoadedByUserOrOtherPlugins boolean

---@class VTSItemUnloadResponseData
---@field data VTSItemUnloadResponseData_Data

---@class VTSItemUnloadResponseData_Data
---@field unloadedItems UnloadedItem[]

---@class UnloadedItem
---@field instanceID string
---@field fileName string

---@class VTSItemPinResponseData
---@field data VTSItemPinResponseData_Data

---@class VTSItemPinResponseData_Data
---@field isPinned boolean
---@field itemInstanceID string
---@field itemFileName string

---@class VTSItemListOptions
---@field includeAvailableSpots boolean
---@field includeItemInstancesInScene boolean
---@field includeAvailableItemFiles boolean
---@field onlyItemsWithFileName string
---@field onlyItemsWithInstanceID string

---@class VTSItemListResponseData
---@field data VTSItemListResponseData_Data

---@class VTSItemListResponseData_Data
---@field itemsInSceneCount integer
---@field totalItemsAllowedCount integer
---@field canLoadItemsRightNow boolean
---@field availableSpots integer[]
---@field itemInstancesInScene ItemInstance[]
---@field availableItemFiles ItemFile[]

---@class ItemInstance
---@field fileName string
---@field instanceID string
---@field order integer
---@field type string
---@field censored boolean
---@field flipped boolean
---@field locked boolean
---@field smoothing number
---@field framerate number
---@field frameCount integer
---@field currentFrame integer
---@field pinnedToModel boolean
---@field pinnedModelID string
---@field pinnedArtMeshID string
---@field groupName string
---@field sceneName string
---@field fromWorkshop boolean

---@class ItemFile
---@field fileName string
---@field type string
---@field loadedCount integer

---@enum VTSItemAngleRelativityMode
VTSItemAngleRelativityMode = {
    RelativeToWorld = 0,
    RelativeToCurrentItemRotation = 1,
    RelativeToModel = 2,
    RelativeToPinPosition = 3
}

---@enum VTSItemSizeRelativityMode
VTSItemSizeRelativityMode = {
	RelativeToWorld = 0,
	RelativeToCurrentItemSize = 1
}

---@class BarycentricCoordinate
---@field vertexID1 integer
---@field vertexID2 integer
---@field vertexID3 integer
---@field vertexWeight1 number
---@field vertexWeight2 number
---@field vertexWeight3 number

---Expressions etc.
---@class VTSExpressionActivationData
---@field data VTSExpressionActivationData_Data

---@class VTSExpressionActivationData_Data
---@field expressionFile string
---@field active boolean

---Something?
---@class VTSArtMeshListData
---@field data VTSArtMeshListData_Data

---@class VTSArtMeshListData_Data
---@field modelLoaded boolean
---@field numberOfArtMeshNames integer
---@field numberOfArtMeshTags integer
---@field artMeshNames string[]
---@field artMeshTags string[]

---@class VTSItemMoveResponseData
---@field data VTSItemMoveResponseData_Data

---@class VTSItemMoveResponseData_Data
---@field movedItems MovedItem[]

---@class MovedItem
---@field itemInstanceID string
---@field success boolean
---@field errorID ErrorID

---@class VTSItemMoveEntry
---@field itemInsanceID string
---@field options VTSItemMoveOptions

---@class VTSItemMoveOptions
---@field timeInSeconds number
---@field fadeMode VTSItemMotionCurve
---@field positionX number
---@field positionY number
---@field order integer
---@field size number
---@field rotation number
---@field setFlip boolean
---@field flip boolean
---@field userCanStop boolean

---@enum VTSItemMotionCurve
VTSItemMotionCurve = {
	UNKNOW = -1,
	LINEAR = 0,
	EASE_IN = 1,
	EASE_OUT = 2,
	EASE_BOTH = 3,
	OVERSHOOT = 4,
	ZIP = 5
}

---@class LiveSplitState
---@field loadingTimes TimeSpan
---@field isGameTimePaused boolean
---@field Run IRun
---@field AttemptStarted AtomicDateTime 
---@field AttemptEnded AtomicDateTime
---@field AdjustedStartTime TimeStamp
---@field StartTimeWithOffset TimeStamp
---@field StartTime TimeStamp
---@field TimePausedAt TimeStamp
---@field GameTimePauseTime TimeSpan
---@field CurrentPhase TimerPhase
---@field CurrentComparison string
---@field CurrentTimingMethod TimingMethod
---@field CurrentHotkeyProfile string
---@field LoadingTimes TimeSpan
---@field IsGameTimeInitialized boolean
---@field IsGameTimePaused boolean
---@field CurrentTime Time
---@field PauseTime TimeSpan
---@field CurrentAttemptDuration TimeSpan
---@field CurrentSplitIndex integer
---@field CurrentSplit ISegment


---@class TimeSpan
---@field TotalDays number Total amount of days the timespan lasts
---@field TotalHours number Total amount of hours the timespan lasts
---@field TotalMinutes number Total amount of minutes the timespan lasts
---@field TotalSeconds number Total amount of seconds the timespan lasts
---@field TotalMilliseconds number Total amount of milliseconds the timespan lasts
---@field Days integer Returns the days component of a timespan
---@field Hours integer Returns the hours component of a timespan
---@field Minutes integer Returns the minutes component of a timespan
---@field Seconds integer Returns the seconds component of a timespan
---@field Milliseconds integer Returns the milliseconds component of a timespan

---@class AtomicDateTime
---@field Time DateTime
---@field SyncedWithAtomicClock boolean

---@class DateTime
---@field todo number

---@class TimeStamp
---@field value TimeSpan

---@class ISegment
---@field Name string
---@field PersonalBestSplitTime Time
---@field BestSegmentTime Time
---@field SplitTime Time

---@class Time
---@field RealTime TimeSpan
---@field GameTime TimeSpan

---@enum TimerPhase
TimerPhase = {
	NotRunning = 0,
	Running = 1,
	Ended = 2,
	Paused = 3
}

---@enum TimingMethod
TimingMethod = {
	RealTime = 0,
	GameTime = 1
}

---Warning
---Functions below requires Sui's VTube Studio API Extension
---@param options VTSExtendedDropItemRequest
---@return VTSExtendedDropItemOptionsResponse options
function ExtendedDropImages(options) end

---Creates VTSExtendedDropItemRequest object
---@return VTSExtendedDropItemRequest
function Create_VTSExtendedDropItemRequest() end

---@class VTSExtendedDropItemRequest
---@field fileName string
---@field count integer
---@field dropDefinition VTSExtendedDropItemDefinition

---@class VTSExtendedDropItemOptionsResponse
---@field data VTSExtendedDropItemOptionsResponse_Data

---@class VTSExtendedDropItemDefinition
---@field normalizeScale boolean
---@field startWithSmoothBorder boolean
---@field lifeTime number Default 3
---@field disappearTime number Default 3
---@field opacity number Default 1
---@field animationSpeed number 1
---@field gravity number 1
---@field sizeScale number 1
---@field dropSpeed number 0.6
---@field bounciness number 0.4
---@field rotation number 1.0
---@field bottomEdgeBounce number 2
---@field topEdgeBounce number 2
---@field leftEdgeBounce number 2
---@field rightEdgeBounce number 2

---@class VTSExtendedDropItemOptionsResponse_Data
---@field absolutely_fucking_nothing nil
