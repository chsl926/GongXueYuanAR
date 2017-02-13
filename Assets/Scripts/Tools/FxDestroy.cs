using UnityEngine;
using System.Collections;

public class FxDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("CheckIfAlive");
	}
	
	IEnumerator CheckIfAlive ()
	{
		while(true)
		{
			yield return new WaitForSeconds(1.5f);
			this.gameObject.SetActive (false);
		}
	}
}
