using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using Excel;
using System.Data;

using System.Xml;

public class Xlsx : EditorWindow
{
    [MenuItem("Tools/Design Tools/Export Xlsx")]
    public static void AddWindow()
    {
        Rect wr = new Rect(0, 0, 350, 220);
        Xlsx window = (Xlsx)EditorWindow.GetWindowWithRect(typeof(Xlsx), wr, false, "Export Xlsx");
        window.Show();

    }

    public List<string> nameArray = new List<string>();

    private string defaultPath;
    private bool shouldDelete = true, ignoreSameVersion = true;
    private bool isSuccess;
    private string text;
    private List<string> idArr;
    private Dictionary<string, string> md5Dict;

    void Awake()
    {
        defaultPath = Application.dataPath + @"/XlsxSource";
        if (!Directory.Exists(defaultPath))
            Directory.CreateDirectory(defaultPath);
        GetObjectNameToArray<string>(defaultPath, "xlsx");
    }

    void OnGUI()
    {
        EditorGUI.LabelField(new Rect(90, 50, 200, 16), new GUIContent("导出所有xlsx文件到xml目录"));

        shouldDelete = EditorGUI.Toggle(new Rect(90, 80, 200, 16), new GUIContent("覆盖已有文件"), shouldDelete);

        ignoreSameVersion = EditorGUI.Toggle(new Rect(90, 100, 200, 16), new GUIContent("忽略相同版本"), ignoreSameVersion);

        EditorGUI.LabelField(new Rect(2, 200, 350, 16), new GUIContent("Chongqing Challeng Tech. Co.,Ltd, gsgundam, v0.1.0"));

        if (GUI.Button(new Rect(50, 135, 250, 40), "立即导出"))
            CreateAllXml();

    }

    /// <summary>
    /// Return all files' name in target path in Assets//
    /// </summary>
    /// <returns>File name in array</returns>
    /// <param name="path">Assets sublevel path</param>
    /// <param name="pattern">File type filter</param>
    /// <typeparam name="T">Class name</typeparam>
    void GetObjectNameToArray<T>(string path, string pattern, string subDirectory = "")
    {
        try
        {
            //return file name by array in target folder & subfolder, it can be null
            string[] files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                string p = files[i];

                //file
                int index = p.LastIndexOf("\\");
                string folder = p.Substring(0, index + 1);
                string fileName = p.Substring(index + 1);

                //if directoryEntries is not null, tempPaths cannot be null after splited
                if (fileName.EndsWith(".meta"))
                    continue;

                string[] pathSplit = StringExtention.SplitWithString(fileName, ".");

                if (pathSplit.Length > 1)
                {
                    nameArray.Add(subDirectory + "\\" + pathSplit[0]);
                }
            }

            //recursion
            string[] folders = Directory.GetDirectories(path);
            for (int i = 0; i < folders.Length; i++)
            {
                string p = folders[i];
                GetObjectNameToArray<T>(p, pattern, p.Substring(defaultPath.Length));
            }
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Debuger.Log("The path encapsulated in the " + path + "Directory object does not exist.");
        }
    }

    /// <summary>
    /// custom split string function
    /// </summary>
    private class StringExtention
    {

        public static string[] SplitWithString(string sourceString, string splitString)
        {
            string tempSourceString = sourceString;
            List<string> arrayList = new List<string>();
            string s = string.Empty;
            while (sourceString.IndexOf(splitString) > -1)  //split
            {
                s = sourceString.Substring(0, sourceString.IndexOf(splitString));
                sourceString = sourceString.Substring(sourceString.IndexOf(splitString) + splitString.Length);
                arrayList.Add(s);
            }
            arrayList.Add(sourceString);
            return arrayList.ToArray();
        }
    }

    private void CreateAllXml()
    {
        foreach (string str in nameArray)
        {
            if (str.Contains("xlsx_md5"))
                continue;
            if (ignoreSameVersion)
            {
                GetMd5Xml(str);
                if (!CheckVersion(str))
                {
                    CreateXml(str);
                }
            }
            else
            {
                CreateXml(str);
            }
        }

        if (isSuccess)
        {
            ShowNotification(new GUIContent( "已成功导出!"));
            DirectoryInfo di = new DirectoryInfo(defaultPath);
            DirectoryInfo[] diArr = di.GetDirectories();
            for (int i = 0; i < diArr.Length; i++)
                CreateMd5XML(diArr[i].ToString() + "/");
        }
        else
            ShowNotification(new GUIContent("文件有错误！"));
    }

    private void CreateXml(string fileName)
    {
        idArr = new List<string>();

//        string filepath = Application.dataPath + @"/Resources/XML/Config" + fileName + ".xml";
		string filepath = Application.dataPath + @"/Resources" + fileName + ".xml";
        text = "";

        filepath = filepath.Replace("\\", "/");
        string[] pathArr = filepath.Split('/');
        string tempPath = "";
        for(int i = 0; i < pathArr.Length; i++)
        {
            tempPath += pathArr[i] + "/";
            if (i > 1 && i < pathArr.Length - 1)
            {
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
            }
        }

        if ((!File.Exists(filepath) && !shouldDelete) || shouldDelete)
        {
            List<string> labels = new List<string>(), comments = new List<string>();

            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                FileStream stream = File.Open(Application.dataPath + @"/XlsxSource" + fileName + ".xlsx", FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                text += "\nexcelReader.ResultsCount is" + excelReader.ResultsCount + "\n";

                text += "start excelReader. \n";

                DataSet result = excelReader.AsDataSet();

                text += "get result successful? result[" + result + "]";

                text += "result columns count is " + result.Tables[0].Columns.Count;

                int columns = result.Tables[0].Columns.Count;
                int rows = result.Tables[0].Rows.Count;

                //start create xml
                XmlElement root = xmlDoc.CreateElement("data");
                XmlElement comment = xmlDoc.CreateElement("comment");
                for (int i = 0; i < rows; i++)
                {
                    XmlElement item = xmlDoc.CreateElement("item");
                    if (i == 0)
                    {
                        continue;
                    }

                    for (int j = 0; j < columns; j++)
                    {
                        string nvalue = result.Tables[0].Rows[i][j].ToString();

                        if (i == 1)
                        {
                            if (nvalue != null && nvalue != "")
                                labels.Add(nvalue);
                        }
                        else if (i == 2)
                        {
                            if (j < labels.Count)
                            {
                                XmlElement commentItem = xmlDoc.CreateElement(labels[j]);
                                commentItem.InnerText = "\n" + nvalue + "\n";
                                comment.AppendChild(commentItem);
                            }
                        }
                        else if (j < labels.Count)
                        {
                            if (fileName.Contains("shop_config"))
                                nvalue = nvalue.Replace("\n", "");
                            item.SetAttribute(labels[j], nvalue);

                            if(j == 0 && !StringUtil.Empty(nvalue))
                            {
                                //check duplicate
                                CheckDuplicate(fileName, nvalue);
                                idArr.Add(nvalue);
                            }

                            //Debuger.Log("labels[j] is " + labels[j] + ", nvalue is " + nvalue);
                        }
                        //Debuger.Log(nvalue);
                    }

                    if (i > 2 && item.GetAttribute("id") != "")
                    {
                        root.AppendChild(item);
                    }

                }

                root.AppendChild(comment);
                xmlDoc.AppendChild(root);
				xmlDoc.Save(filepath);
				AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
//				AssetDatabase.ImportAsset(@"Assets/Resources/XML/Config" + fileName + ".xml", ImportAssetOptions.ForceUpdate);
                //Debuger.Log(fileName + ".xml is saved to " + filepath + ", count is " + idArr.Count);

                isSuccess = true;
            }
            catch (Exception e)
            {
                text += "Exception " + e.Message;
                Debuger.Log("Exception " + e.Message);
            }
        }
    }

    private void CheckDuplicate(string fileName, string id)
    {
        if (idArr.Count < 1)
            return;

        for (int i = 0; i < idArr.Count; i++)
        {
            if (idArr[i] == id)
                Debuger.LogError(id + " in " + fileName + " is a duplicate id.");
        }
    }

    private void HideNotification()
    {
        this.RemoveNotification();
    }

    private void CreateMd5XML(string sourcePath)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
        List<string> pathList = DGFileUtil.GetAllFiles(directoryInfo, ".meta");
        XmlDocument xml = CreateMd5XmlDocument(pathList, sourcePath, null, null);
        string xmlSavePath = sourcePath + "xlsx_md5.xml";
        xml.Save(xmlSavePath);
        Debuger.Log("Create xlsx xml : " + xmlSavePath);

        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
    }


    private XmlDocument CreateMd5XmlDocument(List<string> pathList, string pathRoot, List<string> exceptList, string exceptRoot)
    {
        XmlDocument xml = new XmlDocument();

        XmlElement root = xml.CreateElement("xlsx");
        xml.AppendChild(root);

        for (int i = 0; i < pathList.Count; i++)
        {
            string assetPath = pathList[i];
            string md5 = MD5Util.GetFileHash(assetPath);
            string p = assetPath.Substring(pathRoot.Length);

            pathList[i] = p;

            XmlElement e = xml.CreateElement("a");
            XmlAttribute attr = xml.CreateAttribute("p");
            attr.Value = p;
            e.Attributes.Append(attr);

            attr = xml.CreateAttribute("m");
            attr.Value = md5;
            e.Attributes.Append(attr);

            root.AppendChild(e);
        }
        return xml;
    }

    private bool CheckVersion(string fileName)
    {
        if (md5Dict == null || md5Dict.Count < 1)
            return false;
        else
        {
            string[] pathArr = StringExtention.SplitWithString(fileName, "\\");
            string str = pathArr[2] + ".xlsx";
            string md5 = MD5Util.GetFileHash(defaultPath + fileName + ".xlsx");
            if (md5Dict.ContainsKey(str) && md5Dict[str] == md5)
            {
                Debuger.Log(pathArr[2] + ".xlsx" + " has same version, ignored");
                return true;
            }
            else
            {
                if(md5Dict.ContainsKey(str))
                    Debuger.Log(fileName + ": [xml]" + md5Dict[str] + ", [xlsx]" + md5);
                else
                    Debuger.Log(fileName + "is new xlsx file, [xlsx]" + md5);
            }

            return false;
        }
    }

    private void GetMd5Xml(string fileName)
    {
        string[] pathArr = StringExtention.SplitWithString(fileName, "\\");
        string parent = pathArr[1];
        string xmlPath = defaultPath + "/" + parent + "/xlsx_md5.xml";
        if (!File.Exists(xmlPath))
        {
            return;
        }

        StreamReader sr = File.OpenText(xmlPath);
        string data = sr.ReadToEnd();
        sr.Close();
        sr.Dispose();

        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        md5Dict = new Dictionary<string, string>();
        XmlNode mapNode = xml.SelectSingleNode("xlsx");
        XmlNodeList nodeList = mapNode.SelectNodes("a");
        for (int i = 0; i < nodeList.Count; i++)
        {
            XmlNode node = nodeList[i];
            string path = node.Attributes["p"].Value;
            string md5 = node.Attributes["m"].Value;
            md5Dict.Add(path, md5);
        }
    }

    void OnInspectorUpdate()
    {
        this.Repaint();
    }

    void OnDestory()
    {
        EditorUtility.UnloadUnusedAssetsImmediate();
    }

}
