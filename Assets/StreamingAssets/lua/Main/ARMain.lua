
ARMain = { }
local obj = { };
local ImageTarget = { };
local  value = 10
local  RotateSpeed=1000;
local  TranslateSpeed=10

function ARMain.Start()
	Debugger.Log('ARMain Start--->>>');
    UpdateBeat:Add(ARMain.Update,ARMain)
    ImageTarget =GameObject.New();
    ImageTarget.name='ImageTarget';
    ImageTarget.gameObject:AddComponent(ImageTargetBehaviour.GetClassType())
end
function ARMain.Update()
     if Input.GetKeyDown(KeyCode.A) then
     Debugger.Log('ARMain Update--->>>');
     end
end
function ARMain.LeftRota()
	-- ������ת
	ControllObj.LeftRota()
end
function ARMain.ForwordMove()

	-- ��ǰ�ƶ�
	ControllObj.ForwordMove()
end
function ARMain.RightRota()

	-- ������ת
	ControllObj.RightRota()
end
function ARMain.BackMove()

	-- ����ƶ�
	ControllObj.BackMove()
end
function ARMain.LeftMove()

	-- �����ƶ�
	ControllObj.LeftMove()
end
function ARMain.RightMove()

	-- �����ƶ�
	ControllObj.RightMove()
end

function ARMain.CreatObj()
	 obj =Object.Instantiate(Resources.Load('Sphere'));
end
function ARMain.RotaObj()
	obj.transform:Rotate(Vector3.up * Time.deltaTime * (-RotateSpeed));
end
function ARMain.MoveObj()
	  obj.transform:Translate(Vector3.forward * Time.deltaTime * TranslateSpeed);
end
		

		