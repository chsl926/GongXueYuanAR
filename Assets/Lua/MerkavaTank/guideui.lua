-- region *.lua
guideui = { }
local panel;
local prompt;
local transform;
local gameObject;
local start;
local startdown = false;
local explain;
local explaindown = false;
local quit;
local scene;
this = guideui;
this.__index = this
function guideui.New(_scene)
    local self = { };
    setmetatable(self, this);
    PanelManager:CreatePanel('guideui', this.OnCreate);
    scene = _scene;
    return self;
end

function guideui.Awake(obj)


end 
function guideui.Start()

end

function guideui.OnCreate(obj)
    gameObject = obj;
    transform = obj.transform;

    panel = transform:GetComponent('UIPanel');
    prompt = transform:GetComponent('LuaBehaviour');

    start = transform:FindChild('Start').gameObject;
    explain = transform:FindChild('Explain').gameObject;
    quit = transform:FindChild('Quit').gameObject;

    prompt:AddClick(start, this.OnClick);
    prompt:AddClick(explain, this.OnClick);
    prompt:AddClick(quit, this.OnClick);
end
function guideui.OnClick(go)
    if go.name == 'Explain' then
        if explaindown == false then
            go.transform:FindChild('Over').gameObject:SetActive(false);
            go.transform:FindChild('Down').gameObject:SetActive(true);
            MusicManager:PlayBG("sound_bg", true);
            explaindown = true;
        else
            go.transform:FindChild('Over').gameObject:SetActive(true);
            go.transform:FindChild('Down').gameObject:SetActive(false);
            MusicManager:PauseBG();
            explaindown = false;
        end
    end
    if go.name == 'Start' then
        if startdown == false then
            go.transform:FindChild('Over').gameObject:SetActive(false);
            go.transform:FindChild('Down').gameObject:SetActive(true);
            startdown = true;
            scene.StartGame();
        else
            go.transform:FindChild('Over').gameObject:SetActive(true);
            go.transform:FindChild('Down').gameObject:SetActive(false);
            startdown = false;
            scene.StopGame();
        end

    end
    if go.name == 'Quit' then
       prompt:ClearClick();
       --UpdateBeat:Clear();
       SceneManagement.SceneManager.LoadScene(0);
    end

end

-- endregion
