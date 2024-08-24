
---Sets a post processing in VTS
---@param options VTSPostProcessingUpdateOptions
---@param value array<PostProcessingValue>
---@param onSuccess function Function that accepts VTSPostProcessingUpdateResponseData object as an argument
---@param onError function Function that accepts VTSErrorData as an argument 
function SetPostProcessingEffectValues(options, value, onSuccess, onError) end

---Sets a model in VTS
---@param modelId string Id of the model
---@param onSuccess function Function that accepts VTSModelLoadData object as an argument
---@param onError function Function that accepts VTSErrorData as an argument 
function LoadModel(modelId, onSuccess, onError) end

---Creates VTSPostProcessingUpdateOptions
---@return VTSPostProcessingUpdateOptions
function Create_VTSPostProcessingUpdateOptions() end

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
