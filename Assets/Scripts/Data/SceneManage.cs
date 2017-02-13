using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class SceneManage : Manager {
    public static SceneManage instance;

    private List<SceneData> sceneData = new List<SceneData>();

    public static SceneManage Instance
	{
		get{
			if (instance == null) {
				GameObject g = new GameObject ();
                instance = g.AddComponent<SceneManage>();
			}
			return instance;
		}
	}

	void Awake () {
		instance = this;
        InitData();
    }

	public override void InitData () {
		dataDict.Clear ();
        sceneData.Clear();
        XmlDocument xml = new XmlDocument ();
        string path =SimpleFramework.Util.DataPath+ "/SceneData.xml";
		if (!File.Exists (path)) {
			Debug.Log ("SceneData.xml not find");
			return;
		}

		xml.Load (path);
		XmlNode xNode = xml.SelectSingleNode ("data");
		XmlNodeList nodeList = xNode.SelectNodes ("item");

		for (int i = 0; i < nodeList.Count; i++) {
            SceneData data = new SceneData(nodeList[i]);
			if (!dataDict.ContainsKey (data.id)) {
				dataDict.Add (data.id, data);
			} else {
				Debug.Log ("MonsData  has duplicate");
			}
		}
	}

	/**
	 * 获取所有场景信息
	 * */
    public List<SceneData> GetAllSceneInfo()
	{
        SceneData data;
        foreach (SceneData value in dataDict.Values)
        {
            data = value as SceneData;
			if (data.id != null) {
                sceneData.Add(data);
			}
		}
        return sceneData;
	}
}
