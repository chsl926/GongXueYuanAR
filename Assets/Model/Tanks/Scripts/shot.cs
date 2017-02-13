using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class shot : MonoBehaviour {
    public Transform init;
    public Transform end;
    float x;
    float z;
    // Use this for initialization
    void Start () {
		GetComponent<Rigidbody> ().useGravity = false;
		transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
        x = init.position.x - end.transform.position.x;
        z = init.position.z - end.transform.position.z;
        //print("x" + x + "y" + z);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-x*Time.deltaTime, 0,-z*Time.deltaTime,Space.World);
    }
}
