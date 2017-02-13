using UnityEngine;
using System.Collections;

public class LightAnim : MonoBehaviour {
    Light lights;
    void Start()
    {
		lights = this.GetComponent<Light>();
        StartCoroutine(LightIE());
    }

    IEnumerator LightIE()
    {
        while (true)
        {
			lights.intensity += Random.Range(-1f, 2f);
			if (lights.intensity > 5)
            {
				lights.intensity = 5;
            }
			else if (lights.intensity < 1)
            {
				lights.intensity = 1;
            }
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }
    }
}
