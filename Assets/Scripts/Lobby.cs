using UnityEngine;
using System.Collections;
//using AssetBundles;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using YZL.Compress.UPK;

public class Lobby : MonoBehaviour
{
    private GameObject button;
    private GameObject cover;
    private Button DelButton;
    private Button GobackButton;
    private bool isinit = false;
    private bool loadreend = false;
    private bool loadluaend = false;
    public string TestSceneName;
    private List<string> delReList=new List<string>();
    private enum State
    {
        NOMAL,
        EDIT
    }
    private State Curstate=State.NOMAL;
    void Start()
    {
        ShowGui.info = "";
        SDK.ClearSDK();
        if (SDK.sdk == null)
        {
            GameObject sdk = new GameObject();
            sdk.name = "SDK";
            sdk.AddComponent<SDK>();
        }
        if (Config.config == null)
        {
            GameObject config = new GameObject();
            config.name = "Config";
            config.AddComponent<Config>();
        }

        if (ShowGui.showGui == null)
        {
            GameObject showGui = new GameObject();
            showGui.name = "ShowGui";
            showGui.AddComponent<ShowGui>();
        }
        //删除资源按钮
        if (DelButton == null)
        {
            DelButton = transform.FindChild("DelButton").GetComponent<Button>();
            DelButton.onClick.AddListener(()=>
            {
                DelData();
                GameObject Group = transform.FindChild("Mask/Content/BookGroup").gameObject;
                for (int i =2; i < Group.transform.childCount; i++)
                {
                    if (Group.transform.GetChild(i).GetComponent<Button>())
                    {
                        if (Directory.Exists(SimpleFramework.Util.DataPath + "lua/" + Group.transform.GetChild(i).name) && Directory.Exists(SimpleFramework.Util.DataPath + Group.transform.GetChild(i).name))
                        {
                            Group.transform.GetChild(i).transform.FindChild("Mask").gameObject.SetActive(false);
                            Group.transform.GetChild(i).FindChild("Select").GetComponent<Toggle>().isOn = false;
                        }
                        else
                        {
                            Group.transform.GetChild(i).transform.FindChild("Mask").gameObject.SetActive(true);
                            Group.transform.GetChild(i).FindChild("Select").GetComponent<Toggle>().isOn = false;
                        }
                            
                    }
                       
                }
            } );

        }
        //退出编辑按钮
        if (GobackButton == null)
        {
            GobackButton = transform.FindChild("GobackButton").GetComponent<Button>();
            GobackButton.onClick.AddListener(()=>
            {
                DelButton.gameObject.SetActive(false);
                GobackButton.gameObject.SetActive(false);
                GameObject Group = transform.FindChild("Mask/Content/BookGroup").gameObject;
                for (int i =2; i < Group.transform.childCount; i++)
                {
                    if(Group.transform.GetChild(i).GetComponent<Button>())
                    Group.transform.GetChild(i).FindChild("Select").gameObject.SetActive(false);
                }
                Curstate= State.NOMAL;
            });
            ;
        }


    }
    //删除选中数据
    void DelData()
    {
        for (int i = 0; i < delReList.Count; i++)
        {
            if (Directory.Exists(SimpleFramework.Util.DataPath + "/" + delReList[i]))
            {
                Directory.Delete(SimpleFramework.Util.DataPath + "/" + delReList[i], true);
            }
            if (File.Exists(SimpleFramework.Util.DataPath + delReList[i] + ".upk"))
            {
                File.Delete(SimpleFramework.Util.DataPath + delReList[i] + ".upk");
            }
            if (Directory.Exists(SimpleFramework.Util.DataPath + "/lua/" + delReList[i]))
            {
                Directory.Delete(SimpleFramework.Util.DataPath + "/lua/" + delReList[i], true);
            }
            if (File.Exists(SimpleFramework.Util.DataPath + "/lua/" + delReList[i]+".upk"))
            {
                File.Delete(SimpleFramework.Util.DataPath + "/lua/" + delReList[i] + ".upk");
            }
        }
    }
    //删除所有数据
    void ClearData()
    {
        //if (Directory.Exists(SimpleFramework.Util.DataPath + "/Image"))
        //{
        //    Directory.Delete(SimpleFramework.Util.DataPath + "/Image", true);
        //}
        //if (Directory.Exists(SimpleFramework.Util.DataPath + "/lua"))
        //{
        //    Directory.Delete(SimpleFramework.Util.DataPath + "/lua", true);
        //}
        //if (Directory.Exists(SimpleFramework.Util.DataPath + "/"+SimpleFramework.AppConst.CurSceneName))
        //{
        //    Directory.Delete(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName, true);
        //}
        //if (Directory.Exists(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName+"_pc"))
        //{
        //    Directory.Delete(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName + "_pc", true);
        //}
        //if (Directory.Exists(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName + "_apk"))
        //{
        //    Directory.Delete(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName + "_apk", true);
        //}
        //if (File.Exists(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName+".upk"))
        //{
        //    File.Delete(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName + ".upk");
        //}
        //for (int i = 1; i < button.transform.parent.childCount; i++)
        //{
        //    Destroy(button.transform.parent.GetChild(i).gameObject);
        //}
        if (Directory.Exists(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName))
        {
            Directory.Delete(SimpleFramework.Util.DataPath + "/" + SimpleFramework.AppConst.CurSceneName, true);
        }

        SceneManage.Instance.InitData();
        SDK.ClearSDK();
        SDK.ClearEvent();
        SimpleFramework.Manager.GameManager.Instance.Init();
        Init();
    }
    void Update()
    {

#if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape)&&SimpleFramework.AppConst.TestMode ==true)
        {
            Application.Quit();
        }
#endif

        if (isinit == false && SDK.sdk)
        {
            Init();
            isinit = true;
        }
        if (loadreend == true && loadluaend == true)
        {
            GoMainScene();
            loadreend = false;
            loadluaend = false;
        }
    }
    //初始化
    void Init()
    {
        SDK.DownLoadImageEvent += DoDownLoadImage;//下载图片事件
        button = transform.FindChild("Mask/Content/BookGroup/Button").gameObject;
        cover= transform.FindChild("Mask/Content/BookGroup/Cover").gameObject;
        ShowGui.info = "开始下载： " + SimpleFramework.Util.DataPath + "\n";
        if (File.Exists(SimpleFramework.Util.DataPath + "SceneData.xml"))
            File.Delete(SimpleFramework.Util.DataPath + "SceneData.xml");
        SDK.DoDownLoadText("SceneData.xml", SimpleFramework.Util.DataPath, "", OnUpSceneList);
    }
    //检查游戏场景列表
    void OnUpSceneList(string txt)
    {
        List<SceneData> info = new List<SceneData>();
        info = SceneManage.Instance.GetAllSceneInfo();
        ShowGui.info += "获取SceneData成功！\n";
        for (int i = 0; i < info.Count; i++)
        {
            string time = info[i].time;
            SDK.DownLoadImage("icon/" + time + ".png", SimpleFramework.Util.DataPath + "Image", "time");
            for (int j = 0; j < info[i].games.Length; j++)
            {
                string game = info[i].games[j];
                SDK.DownLoadImage("icon/" + game + ".png", SimpleFramework.Util.DataPath + "Image", "game");
            }
           
        }

    }
    //成功下载场景icon
    void DoDownLoadImage(byte[] bt, string strSrc, string strSign)//bt,src路径,标记
    {
        Texture2D tex;
        tex = new Texture2D(200, 200);
        tex.LoadImage(bt);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        OnLoadIcon(sprite, strSrc, strSign);
    }
    //初始化场景icon
    void OnLoadIcon(Sprite icon, string strSrc, string strSign)
    {
        if (button == null)
            return;
        //得到游戏场景图标
        if (strSign == "game")
        {
            string name = strSrc.Split('/')[1];
            name = name.Substring(0, name.Length - 4);
            ShowGui.info += "获取icon：" + strSrc + " 成功！\n";
            Button newButton = Instantiate(button).GetComponent<Button>();
            newButton.transform.parent = transform.FindChild("Mask/Content/BookGroup");
            newButton.GetComponent<Image>().sprite = icon;
            newButton.GetComponent<RectTransform>().localScale = button.transform.localScale;
            newButton.gameObject.SetActive(true);
            newButton.name = name;
            if (Directory.Exists(SimpleFramework.Util.DataPath+"lua/"+name)&& Directory.Exists(SimpleFramework.Util.DataPath+ name))
            {
                newButton.transform.FindChild("Mask").gameObject.SetActive(false);
            }
            //点击按钮
            newButton.GetComponent<DownTime>().ClickEvent=(end)=>
             {
                 //正在初始化资源
                 if (!File.Exists(SimpleFramework.Util.DataPath + "files.txt") || !Directory.Exists(SimpleFramework.Util.DataPath + "lua"))
                     return;
                 //正在编辑资源
                 if (Curstate == State.EDIT) return;
                 CheckResoucre(name);
             };
            //长按按钮
            newButton.GetComponent<DownTime>().DownEvent = (end) =>
            {
                //正在初始化资源
                if (!File.Exists(SimpleFramework.Util.DataPath + "files.txt") || !Directory.Exists(SimpleFramework.Util.DataPath + "lua"))
                    return;
                if (end == false) return;
                DelButton.gameObject.SetActive(true);
                GobackButton.gameObject.SetActive(true);
                delReList.Clear();
                GameObject Group = transform.FindChild("Mask/Content/BookGroup").gameObject;
                for (int i = 2; i < Group.transform.childCount; i++)
                {
                    if (Group.transform.GetChild(i).GetComponent<Button>())
                    {
                        Group.transform.GetChild(i).FindChild("Select").gameObject.SetActive(true);
                        Group.transform.GetChild(i).FindChild("Select").GetComponent<Toggle>().isOn = false;
                    }
                }
                Curstate = State.EDIT;
            };
            //记录选中场景
            newButton.transform.FindChild("Select").GetComponent<Toggle>().onValueChanged.AddListener((bool sel) =>
            {
                if (sel == true & !delReList.Contains(newButton.name))
                    delReList.Add(newButton.name);
                else if (sel == false && delReList.Contains(newButton.name))
                    delReList.Remove(newButton.name);
            });
        }
        //得到期刊日期图标
        else if (strSign == "time")
        {
            string name = strSrc.Split('/')[1];
            name = name.Substring(0, name.Length - 4);
            Image coverobj = Instantiate(cover).GetComponent<Image>();
            coverobj.transform.parent = transform.FindChild("Mask/Content/BookGroup");
            coverobj.GetComponent<Image>().sprite = icon;
            coverobj.GetComponent<RectTransform>().localScale = cover.transform.localScale;
            coverobj.gameObject.SetActive(true);
            coverobj.name = name;
        }
    }
    //检查场景资源
    void CheckResoucre(string name)
    {
        if (SimpleFramework.AppConst.TestMode)
        {
            if (TestSceneName == "")
                return;
            SimpleFramework.AppConst.CurSceneName = TestSceneName;
        }
        else
            SimpleFramework.AppConst.CurSceneName = name;

        //如果有资源
        if (Directory.Exists(SimpleFramework.Util.DataPath + "lua/" + SimpleFramework.AppConst.CurSceneName) && Directory.Exists(SimpleFramework.Util.DataPath + SimpleFramework.AppConst.CurSceneName))
            GoMainScene();
        //如果没有资源
        else
        {
            if (Directory.Exists(SimpleFramework.Util.DataPath + "lua/" + SimpleFramework.AppConst.CurSceneName))
                Directory.Delete(SimpleFramework.Util.DataPath + "lua/" + SimpleFramework.AppConst.CurSceneName, true);
            if (Directory.Exists(SimpleFramework.Util.DataPath + SimpleFramework.AppConst.CurSceneName))
                Directory.Delete(SimpleFramework.Util.DataPath + SimpleFramework.AppConst.CurSceneName, true);
            //下载lua压缩包
            SDK.DownLoadToLocal("lua/" + SimpleFramework.AppConst.CurSceneName + ".upk", SimpleFramework.Util.DataPath + "lua", OnReleaseLua, false);
            //下载资源压缩包
            SDK.DownLoadToLocal("model/" + SimpleFramework.AppConst.CurSceneName + ".upk", SimpleFramework.Util.DataPath, OnReleaseResoucre);
        }
    }
    //解压lua压缩包
    void OnReleaseLua(bool end)
    {
        UPKFolder.UnPackFolderAsync(SimpleFramework.Util.DataPath + "lua/" + SimpleFramework.AppConst.CurSceneName + ".upk", SimpleFramework.Util.DataPath, LuaProgress);
    }
    //解压资源压缩包
    void OnReleaseResoucre(bool end)
    {
        UPKFolder.UnPackFolderAsync(SimpleFramework.Util.DataPath + SimpleFramework.AppConst.CurSceneName + ".upk", SimpleFramework.Util.DataPath, ResProgress);
    }
    //资源解压进程
    void ResProgress(long all, long now)
    {
        double progress = (double)now / all;
       // Debug.Log("资源释放进度为: " + progress);
        GUIDebug.info = "资源释放进度为: " + progress;
        if (progress >= 1)
        {
            loadreend = true;
            GameObject Group = transform.FindChild("Mask/Content/BookGroup").gameObject;
            Group.transform.FindChild("Mask").gameObject.SetActive(true);
        }
    }
    //lua解压进程
    void LuaProgress(long all, long now)
    {
        double progress = (double)now / all;
       // Debug.Log("lua释放进度为: " + progress);
        GUIDebug.info = "lua释放进度为: " + progress;
        if (progress >= 1)
        {
            loadluaend = true;
        }
    }
    //进入游戏场景
    void GoMainScene()
    {
        isinit = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Destroy(this.gameObject);
    }
    void OnDestory()
    {
        SDK.DownLoadImageEvent -= DoDownLoadImage;//下载图片事件
    }


}
