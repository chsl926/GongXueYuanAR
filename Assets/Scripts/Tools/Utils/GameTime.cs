using System;
using UnityEngine;

public class GameTime
{
	public GameTime ()
	{
	}
	
	//private static float time = 0.0f;
	
	public static float time
	{
		get
		{
			return Time.time;
		}
	}
	
	public static float deltaTime
	{
		get
		{
			return Time.deltaTime;
		}
	}

	public static float timeScale
	{
		set
		{
			Time.timeScale = value;
		}
		get
		{
			return Time.timeScale;
		}
	}

	public static double dateTime
	{
		get
		{
			return DateTime.Now.Ticks / 10000000.0;
		}
	}

    public static DateTime strToTime(string str)
    {
        DateTime dt = DateTime.ParseExact(str, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
        return dt;
    }
}

