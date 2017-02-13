using UnityEngine;
using System.Collections;

public class LightAnimation : MonoBehaviour {
    public float speed = 0.1f;
    public float min = 0.1f;
    public float max = 4.25f;
	// Use this for initialization
	void Start () {
        StartCoroutine(LightAnimationIE());
	}
	
	// Update is called once per frame
	IEnumerator LightAnimationIE () {
        yield return new WaitForSeconds(Random.Range(0, 5));
        bool forward = true;
        while (true)
        {
            Material ma = this.GetComponent<MeshRenderer>().material;
            float a = ma.GetColor("_EmissionColor").r;
            if (forward)
            {
                a += 0.1f;
            }
            else
            {
                a -= 0.1f;
            }
            if (a > max)
            {
                forward = false;
            }
            else if (a < min)
            {
                forward = true;
            }
            ma.SetColor("_EmissionColor", new Color(a, a, a));
            yield return new WaitForSeconds(speed);
        }
	}
}
