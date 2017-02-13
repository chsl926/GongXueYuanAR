using UnityEngine;
using System.Collections;
//using System.Runtime.InteropServices;
//using System.Collections.Generic;

public class test : MonoBehaviour {
	string str1="t1";
	string str2="t2";
	string str3="t3";
	string str4="t4";
	string str5="suc";
	string str6="gps";
	string str7="加载进度";
	string str8="下载进度";

	Texture2D tex=null;//相册选取的相片
	GameObject go;
    AnimationClip ac;
    //RecordMovie rm;
	void Start () 
	{
        //SDK.ali.strAccessId = "cgR0fMrqmKmuoYN8";
        //SDK.ali.strAccessKey = "0I4FJHmdbbI6h7QUUWC7QXj3wCJen5";
        //SDK.ali.iBuckName = "recoding";
        //SDK.ali.strArea = "oss.aliyuncs.com";
		//这些事件不用刻意不加
		SDK.DownLoadEndEvent+=DoDownLoadEnd;//下载场景资源包事件
		SDK.GetPhotoEvent	+=DrawGetPhoto;	//相册事件
		SDK.SpeakEvent		+=SpeakRecv;	//语音事件
		SDK.DownLoadImageEvent+=DoDownLoadImage;//下载图片事件
        SDK.UpLoadImageEvent += DoUpLoadImage;//图片上传事件
        SDK.GetActiveEvent+=SDK_GetActiveEvent;
        //	ali.strAccessId ="WgYwPpfuYXSAU3gf";
        //	ali.strAccessKey="YcBbboLktyewIQQTj9vighpBUhfRPh";
        //	ali.iBuckName	="zhimakaimen";

        //rm = GetComponent<RecordMovie>();
	}
    void SDK_GetActiveEvent(string val)
    { 

    }
	void SpeakRecv(float fLenth,bool bDownLoad)//parm1得到播放长度,parm2下载TRUE 上传FALSE
	{
		if(bDownLoad)
			str4 =  "语音长度："+fLenth.ToString();
		else
			str8=	"上传完成";
	}
    void DoUpLoadImage(string strLocalFile, string strSign)
    {
        str8 = strLocalFile + "上传完成" + strSign;
    }
	void DoDownLoadImage(byte[] bt, string strSrc,string strSign)//bt,src路径,标记
	{
		Debug.Log(strSrc+"图片读取完成");
		tex = new Texture2D(200,200);
		tex.LoadImage(bt);
	}
	void DrawGetPhoto(byte[] bt)
	{
		tex = new Texture2D(200,200);
		tex.LoadImage(bt);
	}

	void DoDownLoadEnd(GameObject obj, string strSrc, string strSign)//obj,src路径,标记
	{
		if(obj==null)//场景加载或下载到本地
		{
			Debug.Log(strSrc+"加载/下载完成");
		}
		else//下载资源包并实例化完成
		{
			Debug.Log(obj.name);
			if(obj.GetComponent<Animation>()!=null)
			{
				ac = obj.GetComponent<Animation>().clip;
               
			}
			//Animation animal = 

			if(obj.name == "mon_orcWarrior(Clone)")
				go = obj;
		}
		str8="下载完成";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Home) )
		{
			Application.Quit();
		}
        ////本地加载进度
        //if (SDK.www != null) 
        //{
        //    if (!SDK.www.isDone) 
        //    {
        //        str7=string.Format("Loading: {0:f2}%",SDK.www.progress*100);
        //    } 
        //    else
        //        str7="加载完成";
        //}
        ////阿里云下载进度
        //if (SDK.ali.nState == ALI_STATE.DOWNLOAD)
        //{
           // str8 = string.Format("下载进度:{0:f2}%", SDK.ali.progress * 100);
        //}
        //else if (SDK.ali.nState == ALI_STATE.UPLOAD)
        //{
        //    str8 = string.Format("上传进度:{0:f2}%", SDK.ali.progress * 100);
        //}
	}

	void OnGUI () {

		try
		{
            if(tex!=null)
            {
                GUI.DrawTexture(new Rect(0,0,200,200),tex);
            }
			if (GUI.Button (new Rect (100, 0, 100, 40), "得到个数")) {
				str3 =SDK.GetCount().ToString();
			}
            //if (GUI.Button(new Rect(210, 0, 100, 40), "开始截屏"))
            //{
            //    rm.StartMovie();
            //    //rm.MakeGif();
            //    //RecordMovie.StartMovie("screen");
            //}
            //if (GUI.Button(new Rect(320, 0, 100, 40), "生成GIF"))
            //{
            //    //rm.StartMovie("screen");
            //    rm.MakeGif();
            //    //RecordMovie.StartMovie("screen");
            //}
			if (GUI.Button (new Rect (100, 50, 100, 40), "得到人名")) {
				str1 =SDK.contactName(0);
			}
			if (GUI.Button (new Rect (100, 100, 100, 40), "得到电话")) {
				str2 =SDK.phoneNumber(0);
			}
			if (GUI.Button (new Rect (100, 150, 100, 40), "StartSpeak")) {
				SDK.StartSpeak("test4");
			}
			if (GUI.Button (new Rect (100, 200, 100, 40), "StopSpeak")) {
				SDK.StopSpeak();
			}
			if (GUI.Button (new Rect (100, 250, 100, 40), "PlaySpeak")) {
				SDK.PlaySpeak("test4").ToString();
			}
			if (GUI.Button (new Rect (100, 300, 100, 40), "DelSpeak")) {
				SDK.DelSpeak();
			}
			if (GUI.Button (new Rect (100, 350, 100, 40), "getGPSstring")) {
				str6 =SDK.getGPSstring();
			}
			if (GUI.Button (new Rect (220, 350, 100, 40), "打开相册选图片")) {
				SDK.TakePhoto();
			}
			if (GUI.Button (new Rect (100, 400, 100, 40), "加载场景")) {
				//SDK.LoadScene("paopao/scene/Level","scene/");		
			}
			if(GUI.Button(new Rect (100, 450, 100, 40), "加载物体"))
			{
                SDK.DownLoadImage("useravatar/user2.jpg", "role","",true);
                SDK.DownLoadImage("roleavatar/zhimakaimen.jpg", "role","",true);
                SDK.LoadMainGameObject("scene/ClassRoom", "role");
                SDK.DownLoadToLocal("scene/Bar", "role");
                SDK.LoadMainGameObject("scene/yangbanjian", "role", "");
                SDK.DownLoadToLocal("scene/Shop", "role");                
                //SDK.LoadMainGameObject("scene/Home", "role");
			}
			if(GUI.Button(new Rect (220, 450, 100, 40), "加载动画"))
			{
                if (go != null)
                {
                    go.GetComponent<Animation>().AddClip(ac, ac.name);
                    Debug.Log(ac.name);
                    go.GetComponent<Animation>().Play(ac.name);
                }
				
			}
			if(GUI.Button(new Rect (100, 500, 100, 40), "下载到本地"))
			{          
                //SDK.DownLoadImage("paopao/useravatar/2.jpg","useravatar/");

                //SDK.DownLoadImage("paopao/useravatar/user.jpg","useravatar/","1");
                //SDK.DownLoadImage("paopao/useravatar/user2.jpg","useravatar/","2");
                //SDK.DownLoadToLocal("paopao/role/hair/mon_orcWarrior","role/hair");  
                //SDK.DownLoadToLocal("roleattach/man_hair_Inthelong_01.assetbundle", "role/hair/", "");
                
			}
            if (GUI.Button(new Rect(210, 500, 100, 40), "上传到阿里云"))
            {
                SDK.UpLoadImage("", "role/user2.jpg");
            }

		}
		catch(System.Exception e)
		{
			str5 = e.ToString();
		}
		GUILayout.Label (str1);
		GUILayout.Label (str2);
		GUILayout.Label (str3);
		GUILayout.Label (str4);
		GUILayout.Label (str5);
		GUILayout.Label (str6);
		GUILayout.Label (str7);
		GUILayout.Label (str8);
		//GUILayout.Label (strName[1].ToString());
	}
}
