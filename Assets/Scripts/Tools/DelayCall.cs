using UnityEngine;
using System.Collections;

public class DelayCall : MonoBehaviour
{

	public DelayCallDelegate callFunc;
	public float delay;
	private float startTime;

	// Use this for initialization
	void Start ()
	{
		startTime = GameTime.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(GameTime.time - startTime >= delay)
		{
			try
			{
				callFunc();
			}
			catch(System.Exception e)
			{
				Debuger.LogException(e);
			}
            callFunc = null;
			Destroy(this.gameObject);
		}
	}

	public delegate void DelayCallDelegate();
	public static void Call(DelayCallDelegate callFunc, float delay)
	{
		GameObject gameObj = new GameObject("DelayCall");
		DelayCall delayCall = gameObj.AddComponent<DelayCall>();
		delayCall.delay = delay;
		delayCall.callFunc = callFunc;
	}
}

