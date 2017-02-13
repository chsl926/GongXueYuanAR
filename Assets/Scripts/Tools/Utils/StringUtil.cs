using UnityEngine;
using System.Collections;

public class StringUtil
{

	public static string[] Split(string str, char c)
	{
		if(Empty(str))
			return new string[0];

		return str.Split(new char[]{c});
	}

	public static int[] SplitToInt(string str, char c)
	{
		if(Empty(str))
			return new int[0];

		string[] strArr = Split(str, c);
		int[] intArr = new int[strArr.Length];
		for(int i=0; i<strArr.Length; i++)
		{
			intArr[i] = ToInt(strArr[i]);
		}
		return intArr;
	}

	public static float[] SplitToFloat(string str, char c)
	{
		if(Empty(str))
			return new float[0];

		string[] strArr = Split(str, c);
		float[] floatArr = new float[strArr.Length];
		for(int i=0; i<strArr.Length; i++)
		{
			floatArr[i] = ToFloat(strArr[i]);
		}
		return floatArr;
	}

	public static bool Empty(string str)
	{
		return str == null || str == "";
	}

	public static string FillZero(string str, int count)
	{
		str = "0000000000000000"+str;
		str = str.Substring(str.Length-count, count);
		return str;
	}

	public static string FillZero(int value, int count)
	{
		return FillZero(value.ToString(), count);
	}

	public static int ToInt(string str)
	{
		if(StringUtil.Empty(str))
		{
			return 0;
		}
		return int.Parse(str);
	}

	public static long ToLong(string str)
	{
		if(StringUtil.Empty(str))
		{
			return 0;
		}
		return long.Parse(str);
	}

	public static float ToFloat(string str)
	{
		if(StringUtil.Empty(str))
		{
			return 0;
		}
		return float.Parse(str);
	}

	public static bool ToBool(string str)
	{
		if(StringUtil.Empty(str))
		{
			return false;
		}
		return bool.Parse(str);
	}


	public static string Join(object[] objs, string separator)
	{
		string str = "";
		for(int i=0; i<objs.Length; i++)
		{
			str += objs[i].ToString();
			if(i < objs.Length-1)
				str += separator;
		}
		return str;
	}

	public static string Join(int[] objs, string separator)
	{
		string str = "";
		for(int i=0; i<objs.Length; i++)
		{
			str += objs[i].ToString();
			if(i < objs.Length-1)
				str += separator;
		}
		return str;
	}
    public static string Join(float[] objs, string separator)
    {
        string str = "";
        for (int i = 0; i < objs.Length; i++)
        {
            str += objs[i].ToString();
            if (i < objs.Length - 1)
                str += separator;
        }
        return str;
    }

    public static bool Contain(int[] datas, int data)
    {
        for (int i = 0; i<datas.Length;i++ )
        {
            if (datas[i] == data) return true;
        }
        return false;
    }

}


