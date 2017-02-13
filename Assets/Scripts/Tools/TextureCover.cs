using UnityEngine;
using System.Collections;

public class TextureCover : MonoBehaviour {
	// Use this for initialization
	void Start () {
        ChangeTexture(this.transform);
	}

    void ChangeTexture(Transform t)
    {
        if(t.GetComponent<MeshRenderer>() != null)
        {
            foreach(var m in t.GetComponent<MeshRenderer>().sharedMaterials)
            {
                string name = m.mainTexture.name;
                Texture mm = Resources.Load("ModeTexture/" + name) as Texture;
                m.mainTexture = mm;
            }
        }
        foreach (Transform tt in t)
        {
            ChangeTexture(tt);
        }
    }
}
