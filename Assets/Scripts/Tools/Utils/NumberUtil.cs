using System;
using UnityEngine;

public class NumberUtil
{

	public static float AngleToRadian(float angle)
	{
		return angle/180*Mathf.PI;
	}
	
	public static float RadianToAngle(float radian)
	{
		return radian/Mathf.PI*180;
	}

	public static float GetRadianByATan(float targetX, float targetY, float originX, float originY)
	{
		float dx = targetX-originX;
		float dy = targetY-originY;
		return Mathf.Atan2(dy, dx);
	}

	public static float ForceBetween(float origin, float min, float max, bool getOppValue = false)
	{
        if (getOppValue)
        {
            if (origin > max) return min;
            if (origin < min) return max;
        }

		if(origin < min) return min;
		if(origin > max) return max;
		return origin;
	}

	public static int ForceBetween(int origin, int min, int max)
	{
		if(origin < min) return min;
		if(origin > max) return max;
		return origin;
	}
	
	public static float GetCloseToTargetAngle(float origin, float target, float step)
	{
		origin = CorverAngleBetween(origin, -180f, 180f);
		target = CorverAngleBetween(target, -180f, 180f);
		float deltaAngle = Mathf.Abs(target - origin);
		if(deltaAngle<=step || deltaAngle >= (360f-step))
		{
			origin = target;
		}
		else if(target > origin)
		{
			if(target-origin > 180f)
			{
				origin -= step;
			}
			else
			{
				origin += step;
			}
		}
		else
		{
			if(origin-target > 180f)
			{
				origin += step;
			}
			else
			{
				origin -= step;
			}
		}
		return origin;
	}

	public static float CorverAngleBetween(float angle, float min, float max)
	{
		if(angle < min)
		{
			while(angle < min)
			{
				angle += 360f;
			}
		}
		else if(angle > max)
		{
			while(angle > max)
			{
				angle -= 360f;
			}
		}
		return angle;
	}

	public static float DistanceVector2(Vector2 origin, Vector2 target)
	{
		return Vector2.Distance(origin, target);
	}

	public static float DistanceVector3(Vector3 origin, Vector3 target)
	{
		return Vector3.Distance(origin, target);
	}

	public static string GetTimeString(float seconds, bool enableHour=true)
	{
		bool isNegative = false;
		if(seconds < 0)
		{
			isNegative = true;
			seconds = -seconds;
		}

		int sec = (int)seconds;

		int h = enableHour?sec/(60*60):0;
		int tempSec = enableHour?sec%(60*60):sec;
		int m = tempSec/60;
		tempSec = tempSec%60;
		int s = tempSec;

		string hStr = enableHour?("00"+h):"";
		string mStr = "00"+m;
		string sStr = "00"+s;

		string str = "";
		if(enableHour)
			str = hStr.Substring(hStr.Length-2, 2)+":"+mStr.Substring(mStr.Length-2, 2)+":"+sStr.Substring(sStr.Length-2, 2);
		else
			str = mStr.Substring(mStr.Length-2, 2)+":"+sStr.Substring(sStr.Length-2, 2);

		if(isNegative)
			str = "-"+str;
		return str;
	}



	public static string GetPercentText(double value, int digits)
	{
		string str = Math.Round((double)(value * 100), digits).ToString();
		return str + "%";
	}
}

