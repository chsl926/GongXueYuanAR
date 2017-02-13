using UnityEngine;
using System.Collections;

public class RectTransUtil : MonoBehaviour
{

	public static Vector3 GetCenterPosition(RectTransform rectTrans)
	{
		Vector3[] corners = new Vector3[4];
		rectTrans.GetWorldCorners(corners);

		Vector3 pos = new Vector3();
		pos.x = (corners[1].x + corners[2].x)/2f;
		pos.y = (corners[0].y + corners[1].y)/2f;
		pos.z = corners[0].z;
		return pos;
	}
}

