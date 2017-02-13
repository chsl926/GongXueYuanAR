using UnityEngine;
using System.Collections;

public class ShowGui : MonoBehaviour {
    public static string info="";
    private bool isTest = false;
    public static ShowGui showGui;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        showGui = this;
       // GameManager.dontDestryObj.Add(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (isTest == false)
            return;
        GUI.Label(new Rect(100, 100, Screen.width, Screen.height), info);

    }
    void OnDestory()
    {
        info="";
    }
}
