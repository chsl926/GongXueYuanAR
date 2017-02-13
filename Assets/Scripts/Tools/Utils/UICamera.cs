using UnityEngine;
using System.Collections;

public class UICamera : MonoBehaviour
{

	public static Camera camera;

	// Use this for initialization
	void Awake ()
	{
		camera = GetComponent<Camera>();
	}

	void OnDestroy()
	{
		camera = null;
	}

}

