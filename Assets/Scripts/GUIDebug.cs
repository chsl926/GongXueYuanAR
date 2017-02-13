using UnityEngine;
using System.Collections;
using System.IO;

public class GUIDebug : MonoBehaviour {

    public static string info="";
    public static  GUIDebug Instance;
    public bool isDebugMode=false;
	// Use this for initialization
	void Start () {
        Instance = this;
        //info = Application.persistentDataPath+"：  ";
        //if(File.Exists(Application.persistentDataPath + "/namecard.jpg"))
        //info +=true;
        //else
        //info += false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (isDebugMode == false)
            return;
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), info);
    }
}
