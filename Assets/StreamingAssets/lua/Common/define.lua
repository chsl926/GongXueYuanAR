require "System.Wrap"
CtrlName = {
	Prompt = "PromptCtrl",
	Message = "MessageCtrl"
}

--协议类型--
ProtocalType = {
	BINARY = 0,
	PB_LUA = 1,
	PBC = 2,
	SPROTO = 3,
}
--当前使用的协议类型--
TestProtoType = ProtocalType.BINARY;

Util = SimpleFramework.Util;
AppConst = SimpleFramework.AppConst;
LuaHelper = SimpleFramework.LuaHelper;
ByteBuffer = SimpleFramework.ByteBuffer;
ColliderEvent=SimpleFramework.ColliderEvent;

ResManager = LuaHelper.GetResManager();
NetManager = LuaHelper.GetNetManager();
PanelManager = LuaHelper.GetPanelManager();
MusicManager = LuaHelper.GetMusicManager();

ImageTargetBehaviour=EasyAR.ImageTargetBehaviour;
ARBuilder=EasyAR.ARBuilder
AugmenterBehaviour=EasyAR.AugmenterBehaviour;
BarCodeScannerBehaviour=EasyAR.BarCodeScannerBehaviour;
CameraDeviceBehaviour=EasyAR.CameraDeviceBehaviour;
EasyARBehaviour=EasyAR.EasyARBehaviour;
ImageTrackerBehaviour=EasyAR.ImageTrackerBehaviour;
RealityPlaneBehaviour=EasyAR.RealityPlaneBehaviour;
RenderCameraBehaviour=EasyAR.RenderCameraBehaviour;
StorageType=EasyAR.StorageType;
VideoPlayerBehaviour=EasyAR.VideoPlayerBehaviour;

