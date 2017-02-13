using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
    public enum PlayerState
    {
        show,
        hide
    }

    public PlayerState playerState;

    //子弹
    public float shotSpeed;//子弹速度
    public float shotMaxSpeed;//最大速度
    public GameObject shotPrefab;//子弹预制体
    public Transform gunTrans;//枪口
    public GameObject rocker;//摇杆
	public Transform parentTrans;
    List<GameObject> playerShot = new List<GameObject>();

    // Use this for initialization
    void Start () {
        Hide();
    }
	
	// Update is called once per frame
	void Update () {
        switch (playerState)
        {
            case PlayerState.hide:
                Hide();
                break;
            case PlayerState.show:
                Show();
                break;
        }
	}

    /// <summary>
    /// 隐藏
    /// </summary>
    public void Hide()
    {
		shotMaxSpeed = shotSpeed;
        //playerState = PlayerState.hide;
        foreach (GameObject temp in playerShot)
        {
            Destroy(temp);
        }
        playerShot.Clear();
        if (rocker.activeSelf == true)
            rocker.SetActive(false);
        //shotMaxSpeed= shotSpeed;
    }

    /// <summary>
    /// 识别到图片
    /// </summary>
    public void Show()
    {
        if (rocker.activeSelf == false)
            rocker.SetActive(true);
		
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point,Color.red);//划出射线，只有在scene视图中才能看到
            GameObject gameObj = hitInfo.collider.gameObject;
           //Debug.Log("click object name is " + gameObj.name);
            if (gameObj.tag == "Enemy")
            {
				shotSpeed -= Time.deltaTime;
				if (shotSpeed < 0) {
					shotSpeed = shotMaxSpeed;
					gunTrans.transform.LookAt(gameObj.transform);
					GameObject temp = (GameObject)Instantiate(shotPrefab, gunTrans.transform.position, gunTrans.transform.rotation);
					playerShot.Add(temp);
					temp.transform.parent = parentTrans;
					temp.GetComponent<shot>().init = this.transform;
					temp.GetComponent<shot>().end = gameObj.transform;
                }
               
            }
        }
    }
}
