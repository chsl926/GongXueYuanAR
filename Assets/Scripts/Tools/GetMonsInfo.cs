using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
//using OfficeOpenXml;


public class GetMonsInfo : MonoBehaviour {

    public List<KeyValuePair<int, Vector3>> monsList = new List<KeyValuePair<int, Vector3>>();
    string file ;
    string fileName = "LevelData";
	string names;
    string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"//";
	bool isfrist = false;
    // Use this for initialization
    void Start () {
		isfrist = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj= transform.GetChild(i).gameObject;
			if (!obj.activeSelf) {
				continue;
			}
            //Dictionary<int, Vector3> pos = new Dictionary<int, Vector3>(1, obj.transform.position);
           /* if (obj.name.Contains(MonsManager.TypeName.lackey.ToString()))
            {
                id = 1;
            }
            if (obj.name.Contains(MonsManager.TypeName.goblin.ToString()))
            {
                id = 2;
            }
            if (obj.name.Contains(MonsManager.TypeName.bigLackey.ToString()))
            {
                id = 3;
            }
            if (obj.name.Contains(MonsManager.TypeName.eye.ToString()))
            {
                id = 4;
            }
            if (obj.name.Contains(MonsManager.TypeName.dog.ToString()))
            {
                id = 5;
            }
            if (obj.name.Contains(MonsManager.TypeName.skeArcher.ToString()))
            {
                id = 7;
            }*/

			if (obj.name.Contains("fresh")) {
				names = "fresh";
				if (obj.transform.position.y < 0.3) {
					file += names + "\t" + obj.transform.position.x + "," + 0.15 + "," + obj.transform.position.z + "\n";
				} else {
					file += names + "\t" + obj.transform.position.x + "," + obj.transform.position.y  + "," + obj.transform.position.z + "\n";
				}
			} else if(obj.name.Contains("target")){
				names = "target";
				if (obj.transform.position.y < 0.3) {
					file += names + "\t" + obj.transform.position.x + "," + 0.15 + "," + obj.transform.position.z + "\n";
				} else {
					file += names + "\t" + obj.transform.position.x + "," + obj.transform.position.y  + "," + obj.transform.position.z + "\n";
				}
			}else{
				
				if (!isfrist) {
					names = "player";
					isfrist = true;
					if (obj.transform.position.y < 0.3) {
						file += names + "\t" + obj.transform.position.x + "," + 0.15 + "," + obj.transform.position.z + "\n";
					} else {
						file += names + "\t" + obj.transform.position.x + "," + obj.transform.position.y  + "," + obj.transform.position.z + "\n";
					}
				}else{
					if (obj.transform.position.y < 0.3) {
						file += ";"+obj.transform.position.x + "," + 0.15 + "," + obj.transform.position.z;
					} else {
						file += ";"+obj.transform.position.x + "," + obj.transform.position.y + "," + obj.transform.position.z;
					}

				}



			}

        }
		Debug.Log(file);
        WriteFile();
    }

    public void  WriteFile()
    {
        if (File.Exists(savePath + "LevelData.txt"))
        {
            File.Delete(savePath + "LevelData.txt");
        }
        FileStream myFs = new FileStream(savePath + "LevelData.txt", FileMode.Create);
        StreamWriter mySw = new StreamWriter(myFs);
        mySw.Write(file);
        mySw.Close();
        myFs.Close();

    }

    //public  void ReadExcel(string fileName)
    //{
    //    FileStream stream = File.Open(Application.dataPath + @"/XlsxSource" + fileName + ".xlsx", FileMode.Open, FileAccess.Read);
    //    file = Application.dataPath + @"/XlsxSource" + fileName + ".xlsx";
    //    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

    //}

    //public static void WriteExcel(string outputDir, List<KeyValuePair<int, Vector3>> monsList)
    //{
    //    //string outputDir = EditorUtility.SaveFilePanel("Save Excel", "", "New Resource", "xlsx");  
    //    FileInfo newFile = new FileInfo(outputDir);
    //    if (newFile.Exists)
    //    {
    //      //  newFile.Delete();  // ensures we create a new workbook  
    //        newFile = new FileInfo(outputDir);
    //    }

    //    using (ExcelPackage package = new ExcelPackage(newFile))
    //    {
    //        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

    //        for (int i = 0; i < monsList.Count; i++)
    //        {
    //            int len = worksheet.Cells.Rows;
    //            worksheet.Cells["C" + len].Value = monsList[i].Key.ToString();
    //            worksheet.Cells["D" + len].Value = monsList[i].Value.ToString();
    //        }

    //            //// add a new worksheet to the empty workbook  
    //            //ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
    //            ////Add the headers  
    //            //worksheet.Cells[1, 1].Value = "ID";
    //            //worksheet.Cells[1, 2].Value = "Product";
    //            //worksheet.Cells[1, 3].Value = "Quantity";
    //            //worksheet.Cells[1, 4].Value = "Price";
    //            //worksheet.Cells[1, 5].Value = "Value";

    //            ////Add some items...  
    //            //worksheet.Cells["A2"].Value = 12001;
    //            //worksheet.Cells["B2"].Value = "Nails";
    //            //worksheet.Cells["C2"].Value = 37;
    //            //worksheet.Cells["D2"].Value = 3.99;

    //            //worksheet.Cells["A3"].Value = 12002;
    //            //worksheet.Cells["B3"].Value = "Hammer";
    //            //worksheet.Cells["C3"].Value = 5;
    //            //worksheet.Cells["D3"].Value = 12.10;

    //            //worksheet.Cells["A4"].Value = 12003;
    //            //worksheet.Cells["B4"].Value = "Saw";
    //            //worksheet.Cells["C4"].Value = 12;
    //            //worksheet.Cells["D4"].Value = 15.37;

    //            //save our new workbook and we are done!  
    //            package.Save();
    //    }
    //}
}
