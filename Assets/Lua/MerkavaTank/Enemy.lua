-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
Enemy = {
    gameObject;
}
local EnemyPos =
{
    [1] = '0.2:0.2';
    [2] = '0.8:0.8';
    [3] = '0.2:0.8';
    [4] = '0.8:0.2';
    [5] = '0.2:0.5';
    [6] = '0.8:0.2';
}
local oldId=0;
local boom;
local speed = 0.1;
local this = Enemy
local scene;
local timer;
this.__index = this
function Enemy.Start(obj)
    this = Enemy;
    this.__index = this
    scene = obj
    local self = { };
    -- 初始化self，如果没有这句，那么类所建立的对象改变，其他对象都会改变
    setmetatable(self, this);
    UpdateBeat:Add(this.Update);
    TriggerEnteBeat:Add(this.OnTriggerEnter);
    OnDestroyBeat:Add(this.OnDestroy);
    OnBeCameInvisibleBeat:Add(this.OnBeCameInvisible);
    return this;
end

function Enemy.SetPos(obj)
    if boom ~= nil then
        Object.DestroyObject(boom);
    end
    local id = math.ceil(math.Random(1, 6));
  while id==oldId do
   id = math.ceil(math.Random(1, 6));
  end
  oldId=id;
    local str = EnemyPos[id];
    local list = string.split(str, ':');
    local x;
    local y;
    for key, value in pairs(list) do
        if key == 1 then
            x = Camera.main.pixelWidth * tonumber(value);
        end
        if key == 2 then
            y = Camera.main.pixelHeight * tonumber(value);
        end
    end
    obj.transform.localPosition = Vector3.New(0, 0, 0);
    local screenPosition = Camera.main:WorldToScreenPoint(obj.transform.position);

    local point = Vector3.New(x, y, screenPosition.z);
    obj.transform.position = Camera.main:ScreenToWorldPoint(point);
    -- obj.transform.localScale = Vector3.New(0.03, 0.03, 0.03);
    obj.transform.position = Vector3.New(obj.transform.position.x, scene.player.gameObject.transform.position.y, obj.transform.position.z);
    GUIDebug.info = serialize(scene.player.gameObject.transform.position);
    GUIDebug.info = GUIDebug.info .. serialize(obj.transform.position);
end
 

 function Enemy.CountPos()
 end

function Enemy.Update()
    if this == nil or this.gameObject == nil then
        return;
    end
    if this.gameObject:GetComponent(ColliderEvent.GetClassType()) == nil then
        this.gameObject:AddComponent(ColliderEvent.GetClassType());
    end
    if (timer ~= nil and timer.time > 3) then
        -- Destory(boom.gameObject);

    end
    --    local  pos = Camera.main:WorldToViewportPoint(this.gameObject.transform.position);
    --    local screen=  Camera.main:ViewportToWorldPoint(pos);
    --    if screen.z>1.2 or screen.z<-1.5   or screen.x>2 or screen.x<-2 then
    --        Object.DestroyObject(this.gameObject);
    --        this.gameObject = nil
    --        return;
    --    end
    --    this.gameObject.transform:Translate(0, 0, speed * Time.deltaTime);
end

function Enemy.OnTriggerEnter(my, obj)
    if this.gameObject ~= my then
        return;
    end
    require "MerkavaTank.Boom"
    local boomObj = Object.Instantiate(ResManager:LoadAsset('boom', 'boom'));
    boomObj.name = 'boom'
    boomObj.transform.parent = ImageTarget.gameObject.transform;
    boomObj.transform.position = this.gameObject.transform.position;
    boom = Boom.New(boomObj);
    -- timer=Timer.New(this.CheckBoom,0.01,0,1);
    this.gameObject = nil;
    Object.DestroyObject(my);
    Object.DestroyObject(obj);
    scene.player.bullet.enemy = nil;
    scene.player.bullet.gameObject = nil;
    -- tank.player.bullet.DesObj();
    scene.player.enemy = nil;


    TriggerEnteBeat:Remove(this.OnTriggerEnter);
    UpdateBeat:Remove(this.Update);
end

function Enemy.CheckBoom()
    log('CheckBoom-->')
end

function Enemy.OnDestroy(my)
    if this.gameObject == my then
        this.gameObject = nil
    end
end
function Enemy.OnBeCameInvisible(my)

    --    if this.gameObject == my then
    --        Object.DestroyObject(this.gameObject);
    --        this.gameObject = nil
    --    end
end

-- endregion
