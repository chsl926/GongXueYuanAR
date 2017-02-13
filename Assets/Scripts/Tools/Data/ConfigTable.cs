using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConfigTableCell
{
    private string m_Info;
    private string m_ConfigTableName;
    private string m_RowId;
    private string m_ColumnName;


    public ConfigTableCell(string value, string configTableName, string rowId, string columnName)
    {
        m_Info = value;
        m_ConfigTableName = configTableName;
        m_RowId = rowId;
        m_ColumnName = columnName;
    }

    public string Str()
    {
        return m_Info;
    }

    
    public int Int()
    {
        int value = 0;

        string str = m_Info.Trim();
        if (!string.IsNullOrEmpty(str))
        {
            try
            {
                value = int.Parse(str);
            }
            catch
            {
                //Debuger.LogError("ConfigTable Type Conversion (int) Error : ConfigTable[" + m_ConfigTableName + "] -- ID[" + m_RowId + "] -- columnName[" + m_ColumnName + "]");
            }
        }
		////Debuger.Log("Int() = " + value);
        return value;
    }

    public float Float()
    {
        float value = 0.0f;

        string str = m_Info.Trim();
        if (!string.IsNullOrEmpty(str))
        {
            try
            {
                value = float.Parse(str);
            }
            catch
            {
                //Debuger.LogError("ConfigTable Type Conversion (float) Error : ConfigTable[" + m_ConfigTableName + "] -- ID[" + m_RowId + "] -- columnName[" + m_ColumnName + "]");
            }
        }

        return value;
    }

    public bool Bool()
    {
        bool value = false;

        string str = m_Info.Trim();
        if (!string.IsNullOrEmpty(str))
        {
            try
            {
                value = int.Parse(str) != 0;
            }
            catch
            {
                //Debuger.LogError("ConfigTable Type Conversion (bool) Error : ConfigTable[" + m_ConfigTableName + "] -- ID[" + m_RowId + "] -- columnName[" + m_ColumnName + "]");
            }
        }

        return value;
    }

    public double Double()
    {
        double value = 0.0f;

        string str = m_Info.Trim();
        if (!string.IsNullOrEmpty(str))
        {
            try
            {
                value = double.Parse(str);
            }
            catch
            {
                //Debuger.LogError("ConfigTable Type Conversion (double) Error : ConfigTable[" + m_ConfigTableName + "] -- ID[" + m_RowId + "] -- columnName[" + m_ColumnName + "]");
            }
        }

        return value;
    }

    public long Long()
    {
        long value = 0;

        string str = m_Info.Trim();
        if (!string.IsNullOrEmpty(str))
        {
            try
            {
                value = long.Parse(str);
            }
            catch
            {
                //Debuger.LogError("ConfigTable Type Conversion (long) Error : ConfigTable[" + m_ConfigTableName + "] -- ID[" + m_RowId + "] -- columnName[" + m_ColumnName + "]");
            }
        }

        return value;
    }

    //public Object ObjectAssetForWWW(AssetBundle assetBundle)
    //{
    //    Object value = null;

    //    string str = m_Info.Trim();
    //    if (!string.IsNullOrEmpty(str))
    //    {
    //        value = assetBundle.Load(str);
    //    }

    //    return value;
    //}

    //public static Object ObjectAssetForWWW(string info, AssetBundle assetBundle)
    //{
    //    Object value = null;

    //    string str = info.Trim();
    //    if (!string.IsNullOrEmpty(str))
    //    {
    //        value = assetBundle.Load(str);
    //    }

    //    return value;
    //}
}

public class ConfigTableRow : Dictionary<string, ConfigTableCell>
{
    private string m_ConfigTableName;
    private string m_RowId;

    public ConfigTableRow(string configTableName, string rowId)
        : base()
    {
        m_ConfigTableName = configTableName;
        m_RowId = rowId;
    }

    public new ConfigTableCell this[string columnName]
    {
        get
        {
			////Debuger.Log("columnName: " + columnName);

            try
            {
                return base[columnName];
            }
            catch
            {
                //Debuger.LogError("ConfigTable Error : The Error Message Is ConfigTable[" + m_ConfigTableName + "] -- ID[" + m_RowId + "] -- columnName[" + columnName + "]");
            }
            return null;
        }
    }
}


public class ConfigTable
{
    private string m_ConfigTableName;
    private string m_CurRowId;
    private ConfigTableCell[,] m_ConfigValueTable;
    private List<string> m_RowIdList;
    private List<string> m_ColumnNameList;


    public ConfigTableRow GetRow(int index)
    {
        ConfigTableRow row = new ConfigTableRow(m_ConfigTableName, m_CurRowId);
        foreach (string columnName in m_ColumnNameList)
        {
			try
			{
            	row.Add(columnName, m_ConfigValueTable[index, m_ColumnNameList.IndexOf(columnName)]);
			}
			catch
			{
				//Debuger.LogError("ConfigTable Error : The Error Message Is ConfigTable[" + m_ConfigTableName + "] -- ID[" + m_CurRowId + "] -- columnName[" + columnName + "] Index["+index+"]");
			}
        }
        return row;
    }

    public ConfigTableRow GetRow(string Id)
    {
        int index = m_RowIdList.IndexOf(Id);
        return this.GetRow(index);
    }


    public ConfigTableRow this[int index]
    {
        get
        {
            return this.GetRow(index);
        }
    }

    public ConfigTableRow this[string rowId]
    {
        get
        {
            m_CurRowId = rowId;
            return this.GetRow(rowId);
        }
    }


    private string ConvertString(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        if (str[0] == '"')
        {
            str = str.Substring(1, str.Length - 2);
            str = str.Replace("\"\"", "\"");
        }

        return str;
    }

    public bool LoadFromText(string text, string tableName)
    {
        ////Debuger.Log(text);

        bool isFind = false;

        m_ConfigTableName = tableName;

        Dictionary<string, List<ConfigTableCell>> hashMap = new Dictionary<string, List<ConfigTableCell>>();
        
        string[] csv_line_array = text.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);

        List<string> csv_key_array = new List<string>();

        int line = 0;
        int col = 0;
        foreach (string str in csv_line_array)
        {
            if (string.IsNullOrEmpty(str)) continue;

            string[] csv_onecol_array = str.Split('\t');

            if (isFind)
            {
                if (!string.IsNullOrEmpty(csv_onecol_array[col]))
                {
                    int key_index = 0;

                    m_RowIdList.Add(csv_onecol_array[col]);

                    for (int j = col; j < csv_onecol_array.Length && j < col + csv_key_array.Count; ++j)
                    {

                        ConfigTableCell csv = new ConfigTableCell(ConvertString(csv_onecol_array[j]), m_ConfigTableName, csv_onecol_array[col], csv_key_array[key_index]);

                        hashMap[csv_key_array[key_index]].Add(csv);
                        key_index++;
                    }
                }
                //break;
            }
            else
            {
                for (int i = 0; i < csv_onecol_array.Length; ++i)
                {
                    if (csv_onecol_array[i] == "id")
                    {
                        isFind = true;
                        col = i;
                    }

                    if (isFind)
                    {
                        if (string.IsNullOrEmpty(csv_onecol_array[i]))
                        {
                            break;
                        }

                        csv_key_array.Add(ConvertString(csv_onecol_array[i]));
                    }
                }

                if (isFind)
                {
                    foreach (string key in csv_key_array)
                    {
                        List<ConfigTableCell> info = new List<ConfigTableCell>();

                        ////Debuger.Log(key);
                        hashMap.Add(key, info);
                    }

                    m_RowIdList = new List<string>();
                    m_ColumnNameList = csv_key_array; 
                }
            }

            ++line;
        }

        m_ConfigValueTable = new ConfigTableCell[hashMap["id"].Count, hashMap.Count];

        int newLine = 0;
        int newCol = 0;

        foreach (string strKey in hashMap.Keys)
        {
            newLine = 0;
            foreach (ConfigTableCell configValue in hashMap[strKey])
            {
                m_ConfigValueTable[newLine, newCol] = configValue;
                newLine++;
            }
            newCol++;
        }

        return isFind;
    }

    //public List<ConfigValue> Find(string key)
    //{
    //    return hashMap[key];
    //}

    public int GetLength()
    {
        return m_ConfigValueTable.GetLength(0);
    }
}
