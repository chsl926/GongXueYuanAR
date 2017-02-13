using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
//获取怪物的数据
public class SceneData : Data {
	
	public int id;                    //场景ID(id)
	public string[] games;
    public string time; //场景名称(name)

    //读取每一行数据
    public SceneData(XmlNode node = null)
	{
		if (node == null)
			return;
		id = StringUtil.ToInt(node.Attributes["id"].Value);
		string name = node.Attributes["name"].Value;
        games = name.Split('|');
        time = node.Attributes["time"].Value;
    }
}
