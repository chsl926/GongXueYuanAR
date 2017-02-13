-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
require "System.Global"
Bullet = {
    enmy;
    tranend;
    gameObject;
    speed=0.1;
}
local this = Bullet;
this.__index = this;
function Bullet.Start()
    self = { }
    setmetatable(self, Bullet);
    this = self;
    UpdateBeat:Add(this.Update)
    return this
end;
   
function Bullet.Init(obj,enemy)
    this.enemy=enemy;
    this.gameObject = obj;
    this.gameObject:GetComponent(Rigidbody.GetClassType()).useGravity = false;
    this.gameObject.transform.localScale = Vector3.New(0.05, 0.05, 0.05);
end	

function Bullet.Update()
 if  this.enemy == nil then
    this.gameObject =nil;
    return
    end
    if  this.gameObject == nil  then
    this.enemy=nil;
    return
    end
    if  this.gameObject.transform == nil  then
    return
    end

    this.gameObject.transform:LookAt(this.enemy.transform);
    this.gameObject.transform:Translate(-this.enemy.transform.forward*0.05);--*(Time.deltaTime*0.5)
end

function Bullet.DesObj()
this.gameObject=nil;
this.enemy=nil;
end


-- endregion
