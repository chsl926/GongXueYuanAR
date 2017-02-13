-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
Player = {
    PlayerState =
    {
        show = 'show';
        hide = 'hide';
    };
    playerState;
    -- 子弹
    shotSpeed = 4;
    -- 子弹速度
    shotMaxSpeed = 4;
    -- 最大速度
    shotPrefab;
    -- 子弹预制体
    gunTrans;
    -- 枪口
    firePoint;
    -- 摇杆
    parentTrans;
    playerShot = { };
    gameObject;
    bullet;
    enemy;
}

local this = Player;
this.__index = this

local switch = {
    [this.PlayerState.show] = function()
        this.Show();
    end;
    [this.PlayerState.hide] = function()
        this.Hide();
    end;
};
            
function Player.Start()
    this = Player
    this.__index = this
    local self = { };
    -- 初始化self，如果没有这句，那么类所建立的对象改变，其他对象都会改变
    setmetatable(self, this);
    this.playerState = this.PlayerState.hide;
    this = self
    UpdateBeat:Add(this.Update);
    return this;
    -- 返回自身
end

function Player.Update()
    local f = switch[this.playerState];
    if (f) then
        f()
    end
end
function Player.Show()
    if (this.gameObject == nil) then
        return;
    end

    if this.gunTrans == nil then
        this.gunTrans = this.gameObject.transform:FindChild('gunTrans');
        this.firePoint = this.gunTrans:FindChild('FirePoint').gameObject;
    end
    this.shotSpeed = this.shotSpeed - Time.deltaTime;
    local hitInfo;
    -- local ray = Ray.New(this.gameObject.transform.forward, this.gameObject.transform.position);
    local aa, obj = Physics.Linecast(this.gameObject.transform.position, this.gameObject.transform.forward * 10000, hitInfo);
    if obj.collider ~= nil then
        if  string.find(obj.collider.gameObject.name,'enemy',1) then
        GUIDebug.info='Find enemy--->OK';
            this.enemy = obj.collider.gameObject;
            if (this.shotSpeed < 0) then
                this.shotSpeed = this.shotMaxSpeed;
                local bulletObj = Object.Instantiate(ResManager:LoadAsset('shot', 'shot'));
                bulletObj.name = 'Bullet';
                bulletObj.transform.parent = ImageTarget.gameObject.transform;
                bulletObj.transform.position = this.firePoint.transform.position;
                bulletObj:AddComponent(ColliderEvent.GetClassType());
                require('Tank.Bullet')
                this.bullet = Bullet:Start();
                this.bullet.Init(bulletObj, this.enemy);
            end
        end
        if (this.enemy ~= nil) then
            local val = this.enemy.transform.position - this.gunTrans.transform.position;
            this.gunTrans.transform:LookAt(this.enemy.transform, this.gunTrans.transform.up)
        end
    end
end

function Player.Hide()

end
function Player.OnDestroy()
end
-- endregion
