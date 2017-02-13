-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

Boom = {
    gameObject;
}
local this = Boom;
local time=0;
local isTimer=false;
this.__index = this
function Boom.New(obj)
    this.__index = this
    setmetatable(self, this);
    this.gameObject=obj;
    this.Start();
    UpdateBeat:Add(this.Update);
    return this;
end
function Boom.Update()
if(isTimer==true) then
time=time+Time.deltaTime;
end
if(time>=3) then
isTimer=false;
time=0;
 Object.DestroyObject(this.gameObject);
end
end
function Boom.Start()

isTimer=true;
end

-- endregion
