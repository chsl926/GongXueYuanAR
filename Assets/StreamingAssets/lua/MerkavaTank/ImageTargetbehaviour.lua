--region *.lua
ImageTargetbehaviour={
gameObject;
imageTargetbehaviour;
}
local this;
function ImageTargetbehaviour.Start()
self={};
this=ImageTargetbehaviour;
setmetatable(self,this)
this.ImageTargetbehaviour=ImageTargetbehaviour.gameObject:AddComponent(ImageTargetBehaviour:GetClassType())
return self;
end


--endregion
