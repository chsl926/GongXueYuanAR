#define Debug


using System;
using UnityEngine;
using System.Collections;
/***************各平台  语音 通讯录 定位 等功能*******************/
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UI;


public class SDK : MonoBehaviour
{
    private static string _strSpeak = "";//录音URL
    private static string _strPlay = "";//语音播放
    private static bool _bDownLoadSpeak = false;//语音下载
    private static bool _bUpLoadSpeak = false;//语音上传
    private static float _fSpeakLenth = 0;//播放语音的长度

    public static bool _bLoadLevel = false;//是否正在读取场景
    //public static bool _bDone = true;//是否空闲 下载
    //private static AsyncOperation async;//异步加载对象
    public static WWW www = null;//本地加载对象

    private static string _strLevel = "";//当前下载资源场景名
    //private static string _strPath = "";//当前下载资源完整路径
    private static string err = "";//调试信息
    //private static bool _bDownLoadScene = false;//正在下载场景
    //private static bool _bDownLoadObj = false;//正在下载角色
    //private static bool _bDownLoadToLocal = false;//正在下载资源包到本地 不实例化
    //private static bool _bDownLoadImage = false;//正在下载图片到本地
    //private static bool _bUpLoadImage = false;//正在上传图片到阿里云
    //private static List<CstrPath> _listDownLoadAsset = new List<CstrPath>();//下载资源包列表 实例化
    //private static List<CstrPath> _listDownLoadFile = new List<CstrPath>();//下载资源包列表 非实例化
    //private static List<CstrPath> _listDownLoadImage = new List<CstrPath>();//下载图片列表 
    //private static List<CstrPath> _listUpLoadImage = new List<CstrPath>();//上传图片列表

    //线程池处理
    //bool W2K;
    //int MaxCount;//允许线程池中运行最多10个线程
    //int nCookie = 0;//当前线程个数
    public static Aliyun ali = new Aliyun();
    public static SDK sdk;
    ////新建ManualResetEvent对象并且初始化为无信号状态
    //ManualResetEvent eventX;
    //Alpha oAlpha;

#if UNITY_ANDROID
    public static  string _aliTarget = "_apk";
    public static  string _pathSpeak = "/speak/";
    public static  string _pathLocal = Config.DirPath + "/";
    public static  string _pathUrl = "file://";
    //android 实例
    private static AndroidJavaObject m_jo;
    void Start()
    {
        _pathLocal = Config.DirPath + "/";
        sdk = this;
        ShowGui.info += "初始化sdk\n";
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        m_jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        CheckDirWithFile(_pathSpeak);
        InitThreadPool();
    }



    //通讯录
    public static int GetCount()//人数
    {
        return m_jo.Call<int>("GetCount");
    }
    public static string contactName(int i)//第i位的名字 小于人数
    {
        return m_jo.Call<string>("contactName", i);
    }
    public static string phoneNumber(int i)//第i位的号码 小于人数
    {
        return m_jo.Call<string>("phoneNumber", i);
    }
    //语音
    public static void StartSpeak(string str)//开始录音 parm 录音文件名 如"test" "test.**"
    {
        _strSpeak = str;
        m_jo.Call("StartSpeak", _pathLocal + _pathSpeak + _strSpeak);
    }
    public static void StopSpeak()//结束录音
    {
        if (_strSpeak == "")
            return;
        m_jo.Call("StopSpeak");

        ali.bShutdown = false;
        Interlocked.Increment(ref ali.nCookie);
        SomeState pa = new SomeState(ali.nCookie, string.Format("speak/" + _strSpeak), _pathLocal + _pathSpeak + _strSpeak, "", true, ALI_TYPE.UPLOAD_SPEAK);
        ThreadPool.QueueUserWorkItem(new WaitCallback(ali.UpLoad), pa);
        pa = null;
        _strSpeak = "";
    }
    public static float PlaySpeak(string str)//开始播放 parm 语音文件名 如"test" "test.**"  返回语音长度
    {
        _strPlay = str;
        if (File.Exists(_pathLocal + _pathSpeak + _strPlay))//判断本地是否有
        {
            _fSpeakLenth = m_jo.Call<float>("PlaySpeak", _pathLocal + _pathSpeak + _strPlay);
            SpeakAction(_fSpeakLenth, true);
            return _fSpeakLenth;
        }
        else
        {
            ali.bShutdown = false;
            Interlocked.Increment(ref ali.nCookie);
            SomeState pa = new SomeState(ali.nCookie, "speak/" + _strPlay, _pathLocal + _pathSpeak + _strPlay, "", true, ALI_TYPE.DOWNLOAD_SPEAK);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ali.down), pa);
            pa = null;
            return 0;
        }

    }
    public static void DelSpeak()//结束播放
    {
        m_jo.Call("DelSpeak");
    }
    //定位
    public static string getGPSstring()//定位信息 返回 "经度,纬度"
    {
        return m_jo.Call<string>("getGPSstring");
    }
    public static void TakePhoto()
    {
        m_jo.Call("TakePhoto");
    }

    public void GetPhoto(string strImage)
    {
        byte[] bt = System.Convert.FromBase64String(strImage);
        GetPhotoAction(bt);
    }

    ///   <summary> 

    ///   得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 

    ///   </summary> 

    ///   <param   name="CnChar">单个汉字</param> 

    ///   <returns>单个大写字母</returns> 
    public static string GetCharSpellCode(string CnChar)
    {
        char c = char.Parse(CnChar);
        c = m_jo.Call<char>("getSpells", c);
        return c.ToString().ToUpper();
    }

#elif UNITY_IPHONE
	public class IOS
	{
		//[DllImport("__Internal")]
		//public static extern int GetCount ();
		//[DllImport("__Internal")]
		//public static extern string contactName (int i);
		//[DllImport("__Internal")]
		//public static extern string phoneNumber (int i);				
		
		//[DllImport("__Internal")]
		//public static extern void StartSpeak (string strFile);	
		//[DllImport("__Internal")]
		//public static extern void StopSpeak ();	
		//[DllImport("__Internal")]
		//public static extern float PlaySpeak (string strFile);	
		//[DllImport("__Internal")]
		//public static extern void DelSpeak ();	
		
		//[DllImport("__Internal")]
		//public static extern string getGPSstring ();	
		//[DllImport("__Internal")]
		//public static extern void TakePhoto ();	
  //      [DllImport("__Internal")]
		//public static extern string GetCharSpellCode(string CnChar);

  //  	[DllImport("__Internal")]
		//public static extern string GetIOSVersion ();	
	}
	public static  string _aliTarget 	=	"_ios";
	public static string _pathSpeak ;
	public static string _pathLocal	;
	public static string _pathUrl 	= "file://localhost/";
	void Start () {
		_pathSpeak 	= "/speak/";
        _pathLocal = Config.DirPath + "/";
		CheckDirWithFile(_pathSpeak);
        InitThreadPool();
	}
 //   public static string GetIOSVersion()
 //   {
 //       return IOS.GetIOSVersion();
 //   }
	////通讯录
	//public static int GetCount()//人数
	//{
	//	return	IOS.GetCount();
	//}
	//public static string contactName(int i)//第i位的名字 小于人数
	//{
	//	return  IOS.contactName(i);
	//}
	//public static string phoneNumber(int i)//第i位的号码 小于人数
	//{
	//	return  IOS.phoneNumber(i);
	//}
	////语音
	//public static void StartSpeak(string str)//开始录音 parm 录音文件名 如"test" "test.**"
	//{
	//	_strSpeak = str;
	//	IOS.StartSpeak (_pathLocal+_pathSpeak+str);
	//}
	//public static void StopSpeak()//结束录音
	//{
	//	if(_strSpeak=="")
	//		return;
	//	IOS.StopSpeak ();

 //        ali.bShutdown=false;
 //        Interlocked.Increment(ref ali.nCookie);
 //        SomeState pa = new SomeState(ali.nCookie,string.Format("speak/"+_strSpeak),_pathLocal+_pathSpeak+_strSpeak, "", true, ALI_TYPE.UPLOAD_SPEAK);
 //        ThreadPool.QueueUserWorkItem(new WaitCallback(ali.UpLoad), pa);
 //       _strSpeak="";
 //       pa=null;
	//}
	//public static float PlaySpeak(string str)//开始播放 parm 语音文件名 如"test" "test.**" 返回语音长度
	//{
	//	_strPlay = str;
	//	if(File.Exists(_pathLocal+_pathSpeak + _strPlay))//判断本地是否有
	//	{
	//		_fSpeakLenth= IOS.PlaySpeak (_pathLocal+_pathSpeak+_strPlay);
	//		SpeakAction(_fSpeakLenth,true);
	//		return _fSpeakLenth;
	//	}
	//	else
	//	{			
 //           ali.bShutdown=false;
 //           Interlocked.Increment(ref ali.nCookie);
 //           SomeState pa = new SomeState(ali.nCookie,"speak/"+_strPlay,_pathLocal+_pathSpeak+_strPlay, "", true, ALI_TYPE.DOWNLOAD_SPEAK);
 //           ThreadPool.QueueUserWorkItem(new WaitCallback(ali.down), pa);
 //           pa=null;
 //           return 0;
	//	}
	//}
	//public static void DelSpeak()//结束播放
	//{
	//	IOS.DelSpeak ();
	//}
	////定位
	//public static string getGPSstring()//定位信息 返回 "经度,纬度"
	//{
	//	return IOS.getGPSstring ();
	//}
	//public static void TakePhoto()
	//{
	//	IOS.TakePhoto();
	//}
	//public void GetActive(string strVal)
	//{
	//	GetActiveAction(strVal);
	//}
	//public void GetPhoto(string strImage)
	//{ 
	//	byte[] bt = System.Convert.FromBase64String(strImage);
	//	GetPhotoAction(bt);
	//}
	//public static string GetCharSpellCode(string CnChar)
 //   {
	//	string str=IOS.GetCharSpellCode(CnChar);
 //       return str.ToUpper();
 //   }
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
    public static  string _aliTarget = "_pc";
    public static string _pathLocal = Config.DirPath + "/";
    public static string _pathUrl = "file:///";

    void Awake()
    {
        InitThreadPool();
        DontDestroyOnLoad(this);

    }
    void Start()
    {
        _pathLocal = Config.DirPath + "/";
    }

    //通讯录
    public static int GetCount()//人数
    {
        return 0;
    }

    public static string contactName(int i)//第i位的名字 小于人数
    {
        return "";
    }
    public static string phoneNumber(int i)//第i位的号码 小于人数
    {
        return "";
    }
    //语音
    public static void StartSpeak(string str)//开始录音 parm 录音文件名 如"test"
    {

    }
    public static void StopSpeak()//结束录音
    {

    }
    public static float PlaySpeak(string str)//开始播放 parm 语音文件名 如"test"  返回语音长度
    {
        return 0;
    }
    public static void DelSpeak()//结束播放
    {

    }
    //定位
    public static string getGPSstring()//定位信息 返回 "经度,纬度"
    {
        return "";
    }
    public static void TakePhoto()
    {

    }
    public void GetPhoto(string strImage)
    {
        byte[] bt = System.Convert.FromBase64String(strImage);
        GetPhotoAction(bt);
    }
    public static System.Action<string> CancelBack;
    #region 首字母拼音
    ///   <summary> 

    ///   得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 

    ///   </summary> 

    ///   <param   name="CnChar">单个汉字</param> 

    ///   <returns>单个大写字母</returns> 
    public static string GetCharSpellCode(string CnChar)
    {

        long iCnChar = 0;
        byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);
        //如果是字母，则直接返回 

        if (ZW.Length == 1)
        {

            return CnChar.ToUpper();

        }
        else
        {
            //   get   the     array   of   byte   from   the   single   char    
            int i1 = (short)(ZW[0]);
            int i2 = (short)(ZW[1]);
            iCnChar = i1 * 256 + i2;
        }

    #region table   of   the   constant   list

        //expresstion 

        //table   of   the   constant   list 

        // 'A';           //45217..45252 

        // 'B';           //45253..45760 

        // 'C';           //45761..46317 

        // 'D';           //46318..46825 

        // 'E';           //46826..47009 

        // 'F';           //47010..47296 

        // 'G';           //47297..47613 



        // 'H';           //47614..48118 

        // 'J';           //48119..49061 

        // 'K';           //49062..49323 

        // 'L';           //49324..49895 

        // 'M';           //49896..50370 

        // 'N';           //50371..50613 

        // 'O';           //50614..50621 

        // 'P';           //50622..50905 

        // 'Q';           //50906..51386 



        // 'R';           //51387..51445 

        // 'S';           //51446..52217 

        // 'T';           //52218..52697 

        //没有U,V 

        // 'W';           //52698..52979 

        // 'X';           //52980..53640 

        // 'Y';           //53689..54480 

        // 'Z';           //54481..55289 

    #endregion

        //   iCnChar match     the   constant 

        if ((iCnChar >= 45217) && (iCnChar <= 45252))
        {
            return "A";
        }
        else if ((iCnChar >= 45253) && (iCnChar <= 45760))
        {
            return "B";
        }
        else if ((iCnChar >= 45761) && (iCnChar <= 46317))
        {
            return "C";
        }
        else if ((iCnChar >= 46318) && (iCnChar <= 46825))
        {
            return "D";
        }

        else if ((iCnChar >= 46826) && (iCnChar <= 47009))
        {

            return "E";

        }

        else if ((iCnChar >= 47010) && (iCnChar <= 47296))
        {

            return "F";

        }

        else if ((iCnChar >= 47297) && (iCnChar <= 47613))
        {

            return "G";

        }

        else if ((iCnChar >= 47614) && (iCnChar <= 48118))
        {

            return "H";

        }

        else if ((iCnChar >= 48119) && (iCnChar <= 49061))
        {

            return "J";

        }

        else if ((iCnChar >= 49062) && (iCnChar <= 49323))
        {

            return "K";

        }

        else if ((iCnChar >= 49324) && (iCnChar <= 49895))
        {

            return "L";

        }

        else if ((iCnChar >= 49896) && (iCnChar <= 50370))
        {

            return "M";

        }



        else if ((iCnChar >= 50371) && (iCnChar <= 50613))
        {

            return "N";

        }

        else if ((iCnChar >= 50614) && (iCnChar <= 50621))
        {

            return "O";

        }

        else if ((iCnChar >= 50622) && (iCnChar <= 50905))
        {

            return "P";

        }

        else if ((iCnChar >= 50906) && (iCnChar <= .51386))
        {

            return "Q";

        }

        else if ((iCnChar >= 51387) && (iCnChar <= 51445))
        {

            return "R";

        }

        else if ((iCnChar >= 51446) && (iCnChar <= 52217))
        {

            return "S";

        }

        else if ((iCnChar >= 52218) && (iCnChar <= 52697))
        {

            return "T";

        }

        else if ((iCnChar >= 52698) && (iCnChar <= 52979))
        {

            return "W";

        }

        else if ((iCnChar >= 52980) && (iCnChar <= 53640))
        {

            return "X";

        }

        else if ((iCnChar >= 53689) && (iCnChar <= 54480))
        {

            return "Y";

        }

        else if ((iCnChar >= 54481) && (iCnChar <= 55289))
        {

            return "Z";

        }

        else return ("?");

    }
    #endregion
#endif


    #region 委托事件

    //下载（场景和资源包）
    public delegate void DownLoadEndDelegate(GameObject obj, string strSrc, string strSign);//下载的实例化物体，资源路径
    public static event DownLoadEndDelegate DownLoadEndEvent;
    static void DownLoadEndAction(GameObject obj, string strSrc, string strSign)
    {
        if (DownLoadEndEvent == null)
            return;//DownLoadEndEvent += new DownLoadEndDelegate(t_ProcessEvent);
        DownLoadEndEvent(obj, strSrc, strSign);
    }
    //图片
    public delegate void UpLoadImageDelegate(string strSrc, string strSign);
    public static event UpLoadImageDelegate UpLoadImageEvent;
    static void UpLoadImageAction(string strSrc, string strSign)//上传图片资源路径,标识
    {
        if (UpLoadImageEvent == null)
            return;
        UpLoadImageEvent(strSrc, strSign);
    }

    public delegate void DownLoadImageDelegate(byte[] bt, string strSrc, string strSign);//下载的图片数据流，资源路径
    public static event DownLoadImageDelegate DownLoadImageEvent;
    static void DownLoadImageAction(byte[] bt, string strSrc, string strSign)
    {
        if (DownLoadImageEvent == null)
            return;//DownLoadEndEvent += new DownLoadEndDelegate(t_ProcessEvent);
        DownLoadImageEvent(bt, strSrc, strSign);
    }

    //相册
    public delegate void GetPhotoDelegate(byte[] bt);
    public static event GetPhotoDelegate GetPhotoEvent;
    static void GetPhotoAction(byte[] bt)
    {
        if (GetPhotoEvent == null)
            return;//DownLoadEndEvent += new DownLoadEndDelegate(t_ProcessEvent);
        GetPhotoEvent(bt);
    }
    //iphone唤醒 回到事件
    public delegate void GetActiveDelegate(string strVal);
    public static event GetActiveDelegate GetActiveEvent;
    static void GetActiveAction(string strVal)
    {
        if (GetActiveEvent == null)
            return;
        GetActiveEvent(strVal);
    }
    //语音
    public delegate void SpeakDelegate(float fLenth, bool bDownLoad);
    public static event SpeakDelegate SpeakEvent;
    static void SpeakAction(float fLenth, bool bDownLoad)
    {
        if (SpeakEvent == null)
            return;//DownLoadEndEvent += new DownLoadEndDelegate(t_ProcessEvent);
        SpeakEvent(fLenth, bDownLoad);
    }
    #endregion
    static void CheckDirWithDir(string strDir)//判断资源存放文件夹是否存在
    {
        if (strDir.LastIndexOf('/') != strDir.Length - 1)
            strDir += "/";
        if (!Directory.Exists(_pathLocal + strDir))
        {
            Directory.CreateDirectory(_pathLocal + strDir);
        }
    }
    static void CheckDirWithFile(string strSrc)//判断资源存放文件夹是否存在
    {
        string strDir = strSrc.Substring(0, strSrc.LastIndexOf('/'));
        if (!Directory.Exists(_pathLocal + strDir))
        {
            Directory.CreateDirectory(_pathLocal + strDir);
        }
    }
    void Update()
    {
        RecvAli();
    }
    //检查等待下载列表
    void CheckWaitList()
    {
        if (ali.waitList.Count > 0)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ali.down), ali.waitList[0]);
            ali.waitList.RemoveAt(0);
        }
    }
    //检查超时 重新下载
    IEnumerator CheckSpeed()
    {
        while (true)
        {

            if (ali.HashCount.Count > 0)
            {
                lock (ali.HashCount)
                {
                    List<string> strKey = new List<string>(ali.HashCount.Keys);
                    for (int i = 0; i < strKey.Count; i++)
                    {
                        //Debug.Log("key:" + strKey[i] + ",i:" + i + ",strKey.Count:" + strKey.Count);
                        if (ali.HashCount[strKey[i]].state == ALI_STATE.DEL)//处理移除
                        {
                            //Debug.Log("del:" + i);
                            ali.HashCount.Remove(strKey[i]);
                            strKey.RemoveAt(i);
                            i--;
                        }
                        else//处理超时
                        {
                            if (ali.HashCount[strKey[i]].nSpeed < 32)//每秒小于32B
                            {
                                ali.HashCount[strKey[i]].nTimeOut++;
                                //Debug.Log("慢" + ali.HashCount[strKey[i]].nSpeed + "," + ali.HashCount[strKey[i]].nTimeOut + "," + strKey[i]);
                                if (ali.HashCount[strKey[i]].nTimeOut >= 10)
                                {
                                    ali.HashCount[strKey[i]].state = ALI_STATE.TIMEOUT;
                                    //ali.lTotalDownLoad -= ali.HashCount[strKey[i]].btTotalByte;
                                    ali.listDone.Add(strKey[i]);
                                }
                            }
                            ali.HashCount[strKey[i]].nSpeed = 0;
                        }
                    }
                    strKey.Clear();
                    strKey = null;
                }
            }
            yield return new WaitForSeconds(1);//1秒钟检查次超时
        }

    }
    //处理阿里云下载回调
    void RecvAli()
    {
        if (ali.listDone.Count > 0)
        {
            string o = ali.listDone[0];
            //查看取消列表
            for (int i = 0; i < ali.CancelList.Count; i++)
            {
                string[] str = ali.HashCount[o].remoteName.Split('.');
                if (str[0] == ali.CancelList[i])
                {
                    if (CancelBack != null)
                    {
                        CancelBack(str[0].Split('/')[1]);
                        ali.CancelList.Remove(ali.HashCount[o].remoteName);
                        ali.listDone.RemoveAt(0);
                    }
                    return;
                }
            }
           

            if (ali.HashCount[o].state == ALI_STATE.DONE)
            {
                if (ali.HashCount[o].type == ALI_TYPE.DOWNLOAD_ASSET)
                    StartCoroutine(LoadBundle(ali.HashCount[o]));
                else if (ali.HashCount[o].type == ALI_TYPE.DOWNLOAD_FILE)
                {
                    DownLoadEndAction(null, ali.HashCount[o].remoteName.Substring(0, ali.HashCount[o].remoteName.LastIndexOf("_")), ali.HashCount[o].strSign);
                    if (ali.HashCount[o].listSame.Count > 0)
                    {
                        for (int i = 0; i < ali.HashCount[o].listSame.Count; i++)
                        {
                            DownLoadEndAction(null, ali.HashCount[o].remoteName.Substring(0, ali.HashCount[o].remoteName.LastIndexOf("_")), ali.HashCount[o].listSame[i]);
                        }
                    }
                    if (ali.HashCount[o].Lcallback!=null)
                    {
                        ali.HashCount[o].Lcallback(true);
                    }
                }
                else if (ali.HashCount[o].type == ALI_TYPE.DOWNLOAD_IMAGE)
                    StartCoroutine(LoadImage(ali.HashCount[o]));
                else if (ali.HashCount[o].type == ALI_TYPE.DOWNLOAD_SPEAK)
                {
#if UNITY_ANDROID
                    _fSpeakLenth = m_jo.Call<float>("PlaySpeak", _pathLocal + _pathSpeak + _strPlay);
                    SpeakAction(_fSpeakLenth, true);
#elif UNITY_IPHONE
                        _fSpeakLenth= IOS.PlaySpeak (_pathLocal+_pathSpeak+_strPlay);
                        SpeakAction(_fSpeakLenth,true);
#endif
                }
                else if (ali.HashCount[o].type == ALI_TYPE.DOWNLOAD_LEVEL)
                {
                    StartCoroutine(LoadLevel(ali.HashCount[o]));
                }
                else if (ali.HashCount[o].type == ALI_TYPE.UPLOAD_IMAGE)
                {
                    UpLoadImageAction(ali.HashCount[o].localName, ali.HashCount[o].strSign);
                }
                else if (ali.HashCount[o].type == ALI_TYPE.UPLOAD_SPEAK)
                {
                    SpeakAction(0, false);
                }
                else if (ali.HashCount[o].type == ALI_TYPE.DOWNLOAD_TEXT)
                {
                    StartCoroutine(LoadText(ali.HashCount[o]));
                }
            }
            else if (ali.HashCount[o].state == ALI_STATE.TIMEOUT)
            {
                err = ali.err;

                if (ali.HashCount[o].type == ALI_TYPE.UPLOAD_IMAGE || ali.HashCount[o].type == ALI_TYPE.UPLOAD_SPEAK)
                {
                    ali.listDone.RemoveAt(0);
                }
                else
                {
                    Debug.Log("超时重新下载:" + ali.HashCount[o].remoteName);
                    //Communication.ShowData = "超时重新下载:" + ali.HashCount[o].remoteName;
                    lock (ali.HashCount[o])
                    {
                        ali.HashCount[o].state = ALI_STATE.DOWNLOAD;
                    }
                    ali.listDone.RemoveAt(0);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ali.down), ali.HashCount[o]);
                }
                return;
            }
            else if (ali.HashCount[o].state == ALI_STATE.ERR)
            {
                Debug.Log("网络出错" + err);
                // Communication.ShowData = ("网络出错:" + err);
            }
            else if (ali.HashCount[o].state == ALI_STATE.FREE)
            {
                Debug.Log("中断下载:" + ali.HashCount[o].remoteName);
            }
            ali.HashCount[o].state = ALI_STATE.DEL;
            ali.listDone.RemoveAt(0);
            //处理完后检查等待列表
            CheckWaitList();
        }
    }
    void InitThreadPool()//初始化线程池
    {
        DontDestroyOnLoad(this);
        sdk = this;
        StartCoroutine(CheckSpeed());//未读信息检查线程
    }
    #region 显示GUI

    void OnGUI()
    {
        if (ali.HashCount.Count == 0)
        {
            ali.lHaveDownLoad = 0;
            ali.lTotalDownLoad = 0;
            ali.lTotalUpLoad = 0;
            ali.lHaveUpLoad = 0;
            //Communication.ShowData = "";
        }
        else if (ali.lTotalUpLoad > 0)
        {
            // Communication.ShowData = "正在上传,";
        }
        else if (ali.lTotalDownLoad > 0)
        {
            // Communication.ShowData = "正在下载,";
        }
        //else
        //{
        //    GUI.Label(new Rect(0, 75, 400, 100), string.Format("上传总进度{0}/{1}", ali.lHaveUpLoad, ali.lTotalUpLoad));
        //    GUI.Label(new Rect(0, 175, 400, 100), string.Format("下载总进度{0}/{1}", ali.lHaveDownLoad, ali.lTotalDownLoad));
        //}
#if Debug
        //  GUI.Label(new Rect(200, 75, 400, 400), err);
        //if (err != "")
        //{
        //    StartCoroutine(CheckMessage());
        //}

#endif
    }

    IEnumerator CheckMessage()
    {
        yield return new WaitForSeconds(5);
        err = "";
        //ali.err = "";
    }
    #endregion
    #region 清理SDK
    public static void ClearSDK()
    {
        //ClearEvent();
        _bDownLoadSpeak = false;//语音下载
        _bUpLoadSpeak = false;//语音上传
        ali.lHaveDownLoad = 0;
        ali.lTotalDownLoad = 0;
        ali.lTotalUpLoad = 0;
        ali.lHaveUpLoad = 0;
        ali.bShutdown = true;
        ali.HashCount.Clear();
        ali.listDone.Clear();
        DownLoadEndEvent = null;
        //ali.nDone = 0;
    }
    public static void ClearEvent()//清空前场景事件
    {
        DownLoadEndEvent = null;
        DownLoadImageEvent = null;
        GetPhotoEvent = null;
        SpeakEvent = null;
        UpLoadImageEvent = null;
        GetActiveEvent = null;
    }
    #endregion

    #region 下载完成 实例化
    private IEnumerator LoadLevel(SomeState state)
    {
        AssetBundleCreateRequest acr = AssetBundle.LoadFromMemoryAsync(state.btTotalByte);
        yield return acr;
        AsyncOperation async = Application.LoadLevelAsync(_strLevel);
        acr = null;
        //_bDone = true;
        DownLoadEndAction(null, _strLevel, "");
        ClearEvent();//清空前场景事件
        yield return async;
    }
    private IEnumerator LoadImage(SomeState state)
    {

        if (state.bExists)
        {
            ShowGui.info += "LoadImage :" +_pathUrl+ state.localName + "\n";
            WWW www2 = new WWW(_pathUrl + state.localName);
            www = www2;
            yield return www2;
            byte[] bt = www2.bytes;
            ShowGui.info += "DownLoadImageAction : bt.Length " + bt.Length + "\n";
            if (ali.bShutdown)
                bt = null;
            else
            {
               
                DownLoadImageAction(bt, state.remoteName, state.strSign);
                if (state.listSame.Count > 0)
                {
                    for (int i = 0; i < state.listSame.Count; i++)
                    {
                        DownLoadImageAction(bt, state.remoteName, state.listSame[i]);
                    }
                }
            }
        }
        else
        {
            if (state.bAvar)
            {
                WWW www2 = new WWW(state.remoteName);
                www = www2;

                yield return www2;
                byte[] bt = www2.bytes;
                //保存头像到本地

                Texture2D tex;
                tex = new Texture2D(200, 200);
                tex.LoadImage(bt);
                byte[] byt = tex.EncodeToPNG();

                File.WriteAllBytes(state.localName, byt);
                DownLoadImageAction(bt, state.remoteName, state.strSign);
                if (state.listSame.Count > 0)
                {
                    for (int i = 0; i < state.listSame.Count; i++)
                    {
                        DownLoadImageAction(bt, state.remoteName, state.listSame[i]);
                    }
                }
            }
            else
            {
                //保存头像到本地
                DownLoadImageAction(state.btTotalByte, state.remoteName, state.strSign);
                if (state.listSame.Count > 0)
                {
                    for (int i = 0; i < state.listSame.Count; i++)
                    {
                        DownLoadImageAction(state.btTotalByte, state.remoteName, state.listSame[i]);
                    }
                }


            }
        }
        yield return 0;
    }
    private IEnumerator LoadBundle(SomeState state)
    {
        AssetBundle bundle;
        //Debug.Log(_pathUrl + state.localName);
        if (state.bExists)
        {
            
            WWW www2 = new WWW(_pathUrl + state.localName);
            www = www2;
            yield return www2;
            bundle = www2.assetBundle;
            www2 = null;
        }
        else
        {
            AssetBundleCreateRequest acr = AssetBundle.LoadFromMemoryAsync(state.btTotalByte);
            yield return acr;
            bundle = acr.assetBundle;
            acr = null;
        }
        ShowGui.info += "LoadBundle 下载完成:  "+bundle.name+" !\n";
        //AssetBundle bundle = acr.assetBundle; //       AssetBundle.CreateFromFile(ali.strPath);       
        // GameObject obj = Instantiate(bundle.mainAsset) as GameObject;
        GameObject obj = Instantiate(bundle.LoadAsset(bundle.GetAllAssetNames()[0])) as GameObject;

        if (ali.bShutdown)
            Destroy(obj);
        else
        {
            DownLoadEndAction(obj, state.remoteName.Substring(0, state.remoteName.LastIndexOf("_")), state.strSign);
            if (state.listSame.Count > 0)
            {
                for (int i = 0; i < state.listSame.Count; i++)
                {
                    DownLoadEndAction(obj, state.remoteName.Substring(0, state.remoteName.LastIndexOf("_")), state.listSame[i]);
                }
            }
        }

        bundle.Unload(false);
        bundle = null;
        yield return 0;
    }

    private IEnumerator LoadText(SomeState state)
    {

        ShowGui.info += "LoadText: "+ _pathUrl + state.localName + "\n";
        WWW www2 = new WWW(_pathUrl+ state.localName);
        yield return www2;
        state.Tcallback(www2.text);

    }
    #endregion

    
    #region 下载场景

    //public static void LoadScene(string strSrc, string strLocalDir)
    //{
    //    //_bLoadLevel = true;
    //    //_pathlevel._strRemote = strSrc;
    //    //_pathlevel._strLocal = strLocalDir;
    //    //StartCoroutine(LoadLevel(strSrc,strLocalDir));
    //}
    IEnumerator LoadLevel(string strSrc, string strLocalDir)//检测本地没有则下载场景并实例化
    {
        //if (_bDone)
        //{
        // _bDone = false;
        _strLevel = strSrc.Substring(strSrc.LastIndexOf("/") + 1);
        if (strLocalDir.LastIndexOf('/') != strLocalDir.Length - 1)
            strLocalDir += "/";
        CheckDirWithDir(strLocalDir);
        if (File.Exists(_pathLocal + strLocalDir + _strLevel))//判断本地是否有
        {
            WWW www = new WWW(_pathUrl + _pathLocal + strLocalDir + _strLevel);
            //www = new WWW(_pathUrl + _pathLocal + strLocalDir + _strLevel);
            yield return www;
            //var bundle = www.assetBundle;
            AsyncOperation async = Application.LoadLevelAsync(_strLevel);
            //Application.LoadLevel(_strLevel);
            //_bDone = true;
            DownLoadEndAction(null, _strLevel, "");
            ClearEvent();//清空前场景事件
            www = null;
            yield return async;
        }
        else
        {
            //_bDownLoadScene = true;
            //ali.DownloadFile(strSrc + _aliTarget, _pathLocal + strLocalDir + _strLevel);//parm1阿里云上存储文件 parm2下载到本地的文件
        }
        //}
        yield return 0;
    }
    #endregion
    /// <summary>
    /// 是否正在下载同名文件
    /// </summary>
    /// <param name="strSrc">下载的文件名</param>
    /// <returns>是否同名</returns>
    bool CheckDownLoadSame(string strSrc, string sign)
    {
        if (ali.HashCount.Count > 0)
        {
            if (ali.HashCount.ContainsKey(strSrc))
            {
                lock (ali.HashCount)
                {
                    ali.HashCount[strSrc].listSame.Add(sign);
                }
                return true;
            }
        }
        if (ali.waitList.Count > 0)
        {
            for (int i = 0; i < ali.waitList.Count; i++)
            {
                if (ali.waitList[i].remoteName == strSrc)
                {
                    lock (ali.waitList)
                    {
                        ali.waitList[i].listSame.Add(sign);
                    }
                    return true;
                }
            }
        }
        return false;

    }

    void JoinToDownLoadList(SomeState pa)
    {
        if (ali.HashCount.Count > 6)
        {
            ali.waitList.Add(pa);
        }
        else
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ali.down), pa);
        }
    }
    #region 下载游戏物体 实例化
    public static void LoadMainGameObject(string strSrc, string strLocalDir)
    {
        LoadMainGameObject(strSrc, strLocalDir, "");
    }
    public static void LoadMainGameObject(string strSrc, string strLocalDir, string strSign)
    {
        ShowGui.info += "LoadMainGameObject: " + sdk + " !\n";
        sdk.DoLoadMainGameObject(strSrc, strLocalDir, strSign);
    }

    void DoLoadMainGameObject(string strSrc, string strLocalDir, string strSign)//检测本地没有则下载物体并实例化到场景中
    {
        if (CheckDownLoadSame(strSrc + _aliTarget, strSign))
            return;
        ali.bShutdown = false;
        string strFileName = strSrc.Substring(strSrc.LastIndexOf("/") + 1);
        if (strLocalDir.LastIndexOf('/') != strLocalDir.Length - 1)
            strLocalDir += "/";

      
        CheckDirWithDir(strLocalDir);

        Interlocked.Increment(ref ali.nCookie);
        SomeState pa = new SomeState(ali.nCookie, strSrc + _aliTarget, _pathLocal + strLocalDir + strFileName, strSign, false, ALI_TYPE.DOWNLOAD_ASSET);

        ShowGui.info += "LoadBundle: " + _pathLocal + strLocalDir + strFileName + " !\n";

        if (File.Exists(_pathLocal + strLocalDir + strFileName))//判断本地是否有
        {
            pa.bExists = true;
            pa.state = ALI_STATE.DONE;
            if (!ali.HashCount.ContainsKey(pa.remoteName))
            {
                lock (ali.HashCount)
                {
                    ali.HashCount.Add(pa.remoteName, pa);
                }
                ali.listDone.Add(pa.remoteName);
            }
        }
        else
        {
            JoinToDownLoadList(pa);
        }
        pa = null;
    }

    #endregion
    #region 下载到本地 不实例化
    //从阿里云上下载到本地 不实例化
    public static void DownLoadToLocal(string strSrc, string strLocalDir, System.Action<bool> callback = null,bool isDisPlatefrom=true)//par1阿里云上文件
    {
        DownLoadToLocal(strSrc, strLocalDir, "", callback, isDisPlatefrom);
    }
    public static void DownLoadToLocal(string strSrc, string strLocalDir, string strSign, System.Action<bool> callback, bool isDisPlatefrom )//par1阿里云上文件
    {
        sdk.DoDownLoadToLocal(strSrc, strLocalDir, strSign, callback, isDisPlatefrom);
    }
    void DoDownLoadToLocal(string strSrc, string strLocalDir, string strSign, System.Action<bool> callback, bool isDisPlatefrom)//par1阿里云上文件
    {
        string filename = "";
        if (!isDisPlatefrom)
            filename = strSrc;
        else
            filename = strSrc + _aliTarget;

        if (CheckDownLoadSame(filename, strSign))
            return;
        ali.bShutdown = false;
        if (strLocalDir.LastIndexOf('/') != strLocalDir.Length - 1)
            strLocalDir += "/";
        CheckDirWithDir(strLocalDir);
        string strFileName = strSrc.Substring(strSrc.LastIndexOf("/") + 1);
        Interlocked.Increment(ref ali.nCookie);
        SomeState pa = new SomeState(ali.nCookie, filename, _pathLocal + strLocalDir + strFileName, strSign, false, ALI_TYPE.DOWNLOAD_FILE);
        pa.Lcallback = callback;
        if (File.Exists(_pathLocal + strLocalDir + strFileName))//判断本地是否有
        {
            //Debug.Log(pa.remoteName.Substring(0, pa.remoteName.LastIndexOf("_")));
            DownLoadEndAction(null, pa.remoteName.Substring(0, pa.remoteName.LastIndexOf("_")), pa.strSign);
            pa.Lcallback(true);
        }
        else
        {
            JoinToDownLoadList(pa);
        }
        pa = null;
    }
    #endregion
    #region 下载图片

    public static void DownLoadImage(string strSrc, string strLocalDir, System.Action<Sprite> callback = null)
    {
        DownLoadImage(strSrc, strLocalDir, "", callback);
    }
    public static void DownLoadImage(string strSrc, string strLocalDir, string strSign, System.Action<Sprite> callback = null)//1阿里云上文件,2本地文件夹,3标识
    {
        DownLoadImage(strSrc, strLocalDir, strSign, false, callback);
    }
    public static void DownLoadImage(string strSrc, string strLocalDir, string strSign, bool bAvar, System.Action<Sprite> callback = null)
    {
        sdk.DoDownLoadImage(strSrc, strLocalDir, strSign, bAvar, callback);
    }


    void DoDownLoadImage(string strSrc, string strLocalDir, string strSign, bool bAvar, System.Action<Sprite> callback = null)//1阿里云上文件,2本地文件夹,3标识
    {
        if (CheckDownLoadSame(strSrc, strSign))
            return;
        ali.bShutdown = false;
        if (strLocalDir.LastIndexOf('/') != strLocalDir.Length - 1)
            strLocalDir += "/";
        CheckDirWithDir(strLocalDir);
        string strFileName;// = strSrc.Substring(strSrc.LastIndexOf("/") + 1);
        if (bAvar)
        {
            //头像图片名
            strFileName = strSrc.Replace('/', '_');
            strFileName = strFileName.Substring(strFileName.IndexOf(':') + 22);
            strFileName += ".png";
        }
        else
            strFileName = strSrc.Substring(strSrc.LastIndexOf("/") + 1);
        Interlocked.Increment(ref ali.nCookie);
        SomeState pa = new SomeState(ali.nCookie, strSrc, _pathLocal + strLocalDir + strFileName, strSign, bAvar, ALI_TYPE.DOWNLOAD_IMAGE);
        if (File.Exists(_pathLocal + strLocalDir + strFileName))//判断本地是否有
        {
            pa.bExists = true;
            pa.state = ALI_STATE.DONE;
            pa.Icallback = callback;
            if (!ali.HashCount.ContainsKey(pa.remoteName))
            {
                lock (ali.HashCount)
                {
                    ali.HashCount.Add(pa.remoteName, pa);
                }
                ali.listDone.Add(pa.remoteName);
            }
        }
        else
        {
            if (!bAvar)
                JoinToDownLoadList(pa);
            else
            {
                pa.bExists = false;
                pa.state = ALI_STATE.DONE;
                pa.Icallback = callback;
                if (!ali.HashCount.ContainsKey(pa.remoteName))
                {
                    lock (ali.HashCount)
                    {
                        ali.HashCount.Add(pa.remoteName, pa);
                    }
                    ali.listDone.Add(pa.remoteName);
                }
            }
        }
        pa = null;
    }
    #endregion
    #region 上传图片

    public static void UpLoadImage(string strRemoteDir, string strLocalFile)
    {
        UpLoadImage(strRemoteDir, strLocalFile, "");
    }
    public static void UpLoadImage(string strRemoteDir, string strLocalFile, string strSign)
    {
        //CstrPath pa = new CstrPath(strRemoteDir, strLocalFile, strSign);
        //if (!_listUpLoadImage.Contains(pa))//添加进上传列表
        //    _listUpLoadImage.Add(pa);
        sdk.DoUpLoadImage(strRemoteDir, strLocalFile, strSign);
    }
    void DoUpLoadImage(string strRemoteDir, string strLocalFile, string strSign)
    {
        ali.bShutdown = false;
        //if (_bDone)
        //{
        //    _bDone = false;
        if (strRemoteDir.LastIndexOf('/') != strRemoteDir.Length - 1)
            strRemoteDir += "/";
        string strFileName = strLocalFile.Substring(strLocalFile.LastIndexOf("/") + 1);
        Interlocked.Increment(ref ali.nCookie);
        SomeState pa = new SomeState(ali.nCookie, strRemoteDir + strFileName, _pathLocal + strLocalFile, strSign, true, ALI_TYPE.UPLOAD_IMAGE);
        if (!File.Exists(_pathLocal + strLocalFile))//文件不存在
        {
            UpLoadImageAction(pa.localName, "文件不存在");
            return;
        }
        else
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ali.UpLoad), pa);
        }
        pa = null;
        //_bUpLoadImage = true;
        //ali.UploadFile(_pathLocal + strLocalFile, strRemoteDir + strFileName);
        //}
    }
    #endregion
    #region 下载文本
    public static void DoDownLoadText(string strSrc, string strLocalDir, string strSign, System.Action<string> callback)
    {
        ShowGui.info += "DoDownLoadText1:   " + "sdk:"+ sdk+"\n";
        sdk.DoDownLoadText(strSrc, strLocalDir, strSign, false, callback);
    }
    void DoDownLoadText(string strSrc, string strLocalDir, string strSign, bool bAvar, System.Action<string> callback)
    {
        ShowGui.info += "DoDownLoadText2" + "\n";
        if (CheckDownLoadSame(strSrc, strSign))
            return;
        ali.bShutdown = false;
        if (strLocalDir.LastIndexOf('/') != strLocalDir.Length - 1)
            strLocalDir += "/";
        ShowGui.info += "strLocalDir" + "\n";
        CheckDirWithDir(strLocalDir);
        string strFileName;// = strSrc.Substring(strSrc.LastIndexOf("/") + 1);

        strFileName = strSrc.Substring(strSrc.LastIndexOf("/") + 1);
        Interlocked.Increment(ref ali.nCookie);
        SomeState pa = new SomeState(ali.nCookie, strSrc, _pathLocal + strLocalDir + strFileName, strSign, bAvar, ALI_TYPE.DOWNLOAD_TEXT);
        pa.Tcallback = callback;
        ShowGui.info += "判断本地路径：" + _pathLocal + strLocalDir + strFileName + "\n";
        if (File.Exists(_pathLocal + strLocalDir + strFileName))//判断本地是否有
        {
            pa.bExists = true;
            pa.state = ALI_STATE.DONE;
            if (!ali.HashCount.ContainsKey(pa.remoteName))
            {
                lock (ali.HashCount)
                {
                    ali.HashCount.Add(pa.remoteName, pa);
                }
                ali.listDone.Add(pa.remoteName);
            }
        }
        else
        {
            if (!bAvar)
                JoinToDownLoadList(pa);
            else
            {
                pa.bExists = false;
                pa.state = ALI_STATE.DONE;
                if (!ali.HashCount.ContainsKey(pa.remoteName))
                {
                    lock (ali.HashCount)
                    {
                        ali.HashCount.Add(pa.remoteName, pa);
                    }
                    ali.listDone.Add(pa.remoteName);
                }
            }
        }
        pa = null;
    }
    #endregion
    #region 取消下载
    public static  void  CancelLoad(string name)
    {
        ali.CancelList.Add(name);
    }
     #endregion

    #region 退出程序结束阿里云线程
    void OnApplicationQuit()
    {
        //ali.bShutdown = true;
        ClearSDK();
    }
    #endregion

}
