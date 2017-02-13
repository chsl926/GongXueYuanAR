using UnityEngine;
using System.Collections;
public class EnemyManager : MonoBehaviour {
    [SerializeField] float speed;
     
    // Use this for initialization
    void Start () {
		transform.Rotate (new Vector3 (0, 180, 0));
		transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, speed*Time.deltaTime);
	}


	void OnTriggerEnter(Collider other)
    {
		Destroy (other.gameObject);
		Destroy (this.gameObject);
    }

}
