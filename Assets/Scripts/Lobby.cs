using UnityEngine;
using System.Collections;
//using AssetBundles;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using YZL.Compress.UPK;
using System;

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
    private Button ClickButton;
    private bool isMaskAni = false;
    private bool isCanelend = false;
    private int  maskAniPos = -1;
    private static float releaseReVal = 0;
    private static  List<string> cancelList = new List<string>();
    private enum State
    {
        NOMAL,
        EDIT,
        DOWNLOAD,
        UNDOWNlOAD,
        UNZIP,
        CANCELUNZIP,
    }
    private State Curstate=State.NOMAL;
    void Start()
    {
        SDK.CancelBack = OnCancelLoad;
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
        //if (loadreend == true && loadluaend == true)
        //{
        //    GoMainScene();
        //    loadreend = false;
        //    loadluaend = false;
        //}
        //播放按钮的mask填充动画
        MaskAni();
        //清除取消的资源
        ClearCanelRe();
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
        SDK.DoDownLoadText("SceneData.xml", SimpleFramework.AppConst.AppName, "", OnUpSceneList);
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
            SDK.DownLoadImage("icon/" + time + ".png", SimpleFramework.AppConst.AppName + "/Image", "time");
            for (int j = 0; j < info[i].games.Length; j++)
            {
                string game = info[i].games[j];
                SDK.DownLoadImage("icon/" + game + ".png", SimpleFramework.AppConst.AppName + "/Image", "game");
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
                 //正在初始化资源返回
                 if (!File.Exists(SimpleFramework.Util.DataPath + "files.txt") || !Directory.Exists(SimpleFramework.Util.DataPath + "lua"))
                     return;
                 //清除已经取消下载的资源(不能在下载过程中清除，被占用了，所以这里执行)
                // isCanelend = true;
                 //正在编辑资源和取消资源时返回
                 if (Curstate == State.EDIT || Curstate ==State.UNDOWNlOAD || Curstate == State.CANCELUNZIP) return;
                 if (Curstate == State.DOWNLOAD || Curstate == State.UNZIP)
                 {
                     if (ClickButton.name != name)
                     return;
                 } 
                 ClickButton = newButton;
                 //取消下载
                 //如果正在下载,取消下载
                 if (Curstate == State.DOWNLOAD)
                 {
                     SDK.CancelLoad("model/" + name);
                     GameObject mask = newButton.transform.FindChild("Mask").gameObject;
                     newButton.transform.FindChild("Tip").gameObject.SetActive(true);
                     mask.SetActive(true);
                     mask.GetComponent<Image>().fillAmount = 1;
                     cancelList.Add(name);
                     Curstate = State.UNDOWNlOAD;
                     return;
                 }
                 //如果正在解压，取消解压
                 else if (Curstate == State.UNZIP)
                 {
                     GameObject mask = newButton.transform.FindChild("Mask").gameObject;
                     newButton.transform.FindChild("Tip").gameObject.SetActive(true);
                     mask.SetActive(true);
                     mask.GetComponent<Image>().fillAmount = 1;
                     Curstate = State.CANCELUNZIP;
                     cancelList.Add(name);
                     return;
                 }
                 else
                     //检查下载资源
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
            //记录编辑选中场景
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
    // 返回取消下载资源
    private void OnCancelLoad(string name)
    {
        Curstate = State.NOMAL;
        isCanelend = true;
    }
    //清除取消的下载资源
    void ClearCanelRe()
    {
        if (isCanelend == false) return;
        try
        {
            while (cancelList.Count > 0)
            {
                if (File.Exists(SimpleFramework.Util.DataPath + cancelList[0] + ".upk"))
                    File.Delete(SimpleFramework.Util.DataPath + cancelList[0] + ".upk");
                if (Directory.Exists(SimpleFramework.Util.DataPath + cancelList[0]))
                    Directory.Delete(SimpleFramework.Util.DataPath + cancelList[0], true);
                if (Directory.Exists(SimpleFramework.Util.DataPath + "lua/" + cancelList[0] + ".upk") && SimpleFramework.AppConst.TestMode == false)
                    Directory.Delete(SimpleFramework.Util.DataPath + "lua/" + cancelList[0] + ".upk", true);
                if (Directory.Exists(SimpleFramework.Util.DataPath + "lua/" + cancelList[0]) && SimpleFramework.AppConst.TestMode == false)
                    Directory.Delete(SimpleFramework.Util.DataPath + "lua/" + cancelList[0], true);
                cancelList.RemoveAt(0);
                ClickButton.transform.FindChild("Tip").gameObject.SetActive(false);
                isCanelend = false;

            }
        }
        catch
        {
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
            if (Directory.Exists(SimpleFramework.Util.DataPath + "lua/" + SimpleFramework.AppConst.CurSceneName)&&SimpleFramework.AppConst.TestMode==false)
                Directory.Delete(SimpleFramework.Util.DataPath + "lua/" + SimpleFramework.AppConst.CurSceneName, true);
            if (Directory.Exists(SimpleFramework.Util.DataPath + SimpleFramework.AppConst.CurSceneName))
                Directory.Delete(SimpleFramework.Util.DataPath + SimpleFramework.AppConst.CurSceneName, true);
            //下载lua压缩包
            if (SimpleFramework.AppConst.TestMode == false)
            {
                SDK.DownLoadToLocal("lua/" + SimpleFramework.AppConst.CurSceneName + ".upk", SimpleFramework.AppConst.AppName + "/lua", OnReleaseLua, false);
            }
            Curstate = State.DOWNLOAD;
            isMaskAni = true;
            maskAniPos = 1;
            //下载资源压缩包
            SDK.DownLoadToLocal("model/" + SimpleFramework.AppConst.CurSceneName + ".upk", SimpleFramework.AppConst.AppName, OnReleaseResoucre);
           

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
        Image mask = ClickButton.transform.FindChild("Mask").GetComponent<Image>();
        mask.fillAmount = 0.5f;
        UPKFolder.UnPackFolderAsync(SimpleFramework.Util.DataPath + SimpleFramework.AppConst.CurSceneName + ".upk", SimpleFramework.Util.DataPath, ResProgress);
    }
    //资源解压进程
    void ResProgress(long all, long now)
    {
        
       
        double progress = (double)now / all;
        Debuger.Log("资源释放进度为: " + progress);
        if (progress >= 1)
        {
            isCanelend = true;
            Curstate = State.NOMAL;
            return;
        }
        if (Curstate == State.CANCELUNZIP)
        {
            releaseReVal = 1;
            return;
        }
        Curstate = State.UNZIP;
        isMaskAni = true;
        maskAniPos = 2;
        releaseReVal = 0.5f - (float)progress / 2;



    }
    void MaskAni()
    {
        if (isMaskAni == false) return;
        Image  mask = ClickButton.transform.FindChild("Mask").GetComponent<Image>();
        if (maskAniPos == 1)
        {
            if( mask.fillAmount > 0.5f)
                mask.fillAmount -= 0.01f;
            else isMaskAni = false;
        } 
        else if (maskAniPos == 2 )
        {
            mask.fillAmount = releaseReVal;
            if (mask.fillAmount <= 0)
            {
                mask.gameObject.SetActive(false);
                mask.fillAmount = 1;
                isMaskAni = false;
                Curstate = State.NOMAL;
            }
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
