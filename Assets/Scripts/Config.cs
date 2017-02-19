using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour
{
    public static string strAccessId = "KKbQdUBXcPMRcdZu";
    public static string strAccessKey = "xj4Lh6T9BRHLDAZUfzaTJLMKn0D5UG";
    public static string iBuckName = "chsl926";   //资源bucket
    public static string iBuckUpdate = "avatarsources";//上传bucket
    public static string strArea = "oss-cn-shenzhen.aliyuncs.com";

    public static string FileURL;
    public static string DirPath;
    public static Config config;
    void Awake()
    {
        config = this;

#if UNITY_ANDROID
        FileURL = "jar:file:///" + Application.persistentDataPath+"/";
        DirPath = Application.persistentDataPath;
#elif UNITY_IPHONE
	FileURL="file:"+Application.persistentDataPath";
	 DirPath=Application.persistentDataPath;  
#elif  UNITY_EDITOR
  FileURL = "file://" + Application.streamingAssetsPath + "/" ;
        DirPath ="c:/";
#elif UNITY_STANDALONE_WIN 
  FileURL = "file://" + Application.persistentDataPath+"/";
       DirPath ="c:/";
#else
       PathURL= string.Empty;
#endif
        DontDestroyOnLoad(this);
    }



}
