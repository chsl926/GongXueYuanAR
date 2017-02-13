using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextScene(int i)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(i);
    }
    public void SelectMusic(bool isTrue)
    {
        //音乐相关
    }
}
