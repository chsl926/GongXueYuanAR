-- region *.lua
require "MerkavaTank.Player"
require "MerkavaTank.ImageTargetbehaviour"
require "System.Global"
require "MerkavaTank.Enemy"

Scene = {

    GameState =
    {
        show = 'show';
        hide = 'hide';
        introduction = 'introduction';
    };
    gameStateManager;
    -- 敌人相关
    -- 敌人的预制体
    enemyPrefab;
    -- 敌人生成的位置
    enemtInsTrans = { };
    parentTrans;
    enemyObjList = { };
    -- 生成敌人的时间

    countOfEnemyIns = 5;
    countMaxOfEnemyIns = 5;
    player;
    UI;
    -- gameObject;
};
local this = Scene;

local switch =
{
    [this.GameState.show] = function()
        this.Show();
    end,
    [this.GameState.hide] = function()
        this.InitializeGameState();
    end,
    [this.GameState.introduction] = function()
        this.Introduction();
    end
};
ImageTarget='';
GUIDebug="";
local EasyTouch;
local ImageAR;
function Scene.Start()
    GUIDebug=GameObject.Find('Scene'):GetComponent('GUIDebug');
    GUIDebug.info='Scene.Start---->OK';
    this.Init();
    this.InitializeGameState();
    UpdateBeat:Add(this.Update);
end

-- Update is called once per frame
function Scene.Update()
    if (Input.GetKeyDown(KeyCode.Space))
    then
        this.gameStateManager = this.GameState.show;
    end
    local f = switch[this.gameStateManager];
    if (f) then
        f()
    end
end

function Scene.Show()
    this.player.playerState = Player.PlayerState.show;
    -- 在一定的时间内生成敌人
    this.countOfEnemyIns = this.countOfEnemyIns - Time.deltaTime;
    if (this.countOfEnemyIns <= 0 and Enemy.gameObject == nill) then
        this.countOfEnemyIns = this.countMaxOfEnemyIns;
        local index = math.Random(0, 5);
        local enemyobj = Object.Instantiate(ResManager:LoadAsset('enemy', 'enemy'));
        enemyobj.name = 'enemy'
        enemyobj.transform.parent = ImageTarget.gameObject.transform;
        enemyobj.transform.localScale = Vector3.New(0.03, 0.03, 0.03);
        -- this.gameStateManager = this.GameState.hide;
        local enemy = Enemy.Start(this)
        enemy.gameObject = enemyobj;
        enemy.SetPos(enemy.gameObject);
    end
end
function Scene.Introduction()
end

function Scene.InitializeGameState()
    this.gameStateManager = this.GameState.hide;
    this.countMaxOfEnemyIns = this.countOfEnemyIns;
    for obj in ipairs(this.enemyObjList) do
        Object:Destroy(obj);
    end
    this.enemyObjList = { }
    --this.playerManager.playerState = PlayerManager.PlayerState.hide;
end
function Scene.Init()
    EasyTouch=nil;
    ImageAR=nil;
    -- 以下是同步从Resources目录加载资源
    ImageAR = Object.Instantiate(Resources.Load('ImageAR'));
    ImageAR.name = 'ImageAR'
    ImageTarget = ImageAR.gameObject.transform:FindChild('ImageTarget'):GetComponent('EasyImageTargetBehaviour');
    ImageTarget.Path = Application.persistentDataPath .. '/sbsar/MerkavaTank/idback.jpg';
    ImageTarget.Name = "namecard";
    -- 以下是同步从游戏目录加载资源
    local obj = Object.Instantiate(ResManager:LoadAsset('tank', 'tank'));
    obj.name = 'Player'
    obj.transform.parent = ImageTarget.gameObject.transform;
    obj.transform.localPosition = Vector3.New(0, 0, 0);
    obj.transform.localScale = Vector3.New(0.03, 0.03, 0.03);
    this.player = Player.Start();
     this.player.gameObject=obj;
    GUIDebug.info='Create Player--->';
    require "MerkavaTank.guideui"
    guideui.New(this);
end
function Scene.StartGame()
    if (EasyTouch == nil) then
        EasyTouch = Object.Instantiate(Resources.Load('EasyTouch'));
        EasyTouch.name = 'EasyTouch'
        local ETCJoystick = EasyTouch.transform:FindChild("JoystickLift"):GetComponent("ETCJoystick")
        ETCJoystick.isTurnAndMove = true;
        ETCJoystick.tmSpeed = 1;
    else
        EasyTouch:SetActive(true);
    end
    if(Application.isEditor)then 
    ImageTarget.gameObject:SetActive(true)
    end
    this.gameStateManager =this.GameState.show;
end
function Scene.StopGame()
    if (EasyTouch ~= nil) then
        EasyTouch:SetActive(false);
    end
    this.gameStateManager =this.GameState.hide;
end

-- function Tank.OnLoadPlayer(obj)
-- tempobj= Object.Instantiate(obj:LoadAsset(obj.name));
-- tempobj.name='Player'
-- this.gameObject=tempobj;
--    this.gameObject.transform.position=Vector3.New(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
-- end

