using UnityEngine;
using System.Collections;

public class GUIShow : MonoBehaviour {
    private bool isShow = false;
    private static  string message = "";
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (isShow == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, 10, 200, 100), message);
        }
    }
    public static void Show(string _message)
    {
        message = _message;
    }
}
