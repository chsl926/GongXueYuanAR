using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour {
	public float speed = 2;
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (this.transform.forward, speed);
	}
}
