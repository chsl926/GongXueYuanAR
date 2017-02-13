using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tank : MonoBehaviour {
    public enum GameState {
        show,
        hide,
        introduction
    }

    public GameState gameStateManager;


    public PlayerManager playerManager;
    //敌人相关
    [Space(10)]
    public GameObject enemyPrefab;//敌人的预制体
    public Transform[] enemtInsTrans;//敌人生成的位置
    public Transform parentTrans;
    private List<GameObject> enemyObjList = new List<GameObject>();

    public float countOfEnemyIns;//生成敌人的时间
    private  float countMaxOfEnemyIns;
    // Use this for initialization
    void Start () {
        InitializeGameState(); 
    }
	
	// Update is called once per frame
	void Update () {
        switch (gameStateManager)
        {
            case GameState.show:
                Show();
                break;
            case GameState.hide:
                InitializeGameState();
                break;
            case GameState.introduction:
                Introduction();
                break;
        }
     //  this.OnBeCameInvisible

    }
    #region  状态

    private void Show()
    {
		playerManager.playerState = PlayerManager.PlayerState.show;
        //在一定的时间内生成敌人
        countOfEnemyIns -= Time.deltaTime;
        if (countOfEnemyIns <= 0)
        {
            countOfEnemyIns = countMaxOfEnemyIns;
            int index = Random.Range(0, enemtInsTrans.Length);
            GameObject tempObj = (GameObject)Instantiate(enemyPrefab, enemtInsTrans[index].position, Quaternion.identity);
            tempObj.transform.parent = parentTrans;
            enemyObjList.Add(tempObj);
        }
    }


    private void Introduction() {

    }

    #endregion


  
    public void InitializeGameState()
    {
        gameStateManager = GameState.hide;
        countMaxOfEnemyIns = countOfEnemyIns;
        foreach (GameObject temp in enemyObjList)
        {
            Destroy(temp);
        }
        enemyObjList.Clear();
        playerManager.playerState = PlayerManager.PlayerState.hide;

    }
}
