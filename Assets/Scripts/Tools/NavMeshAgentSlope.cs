using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentSlope : MonoBehaviour {

    public float slopeLenth = 0.5f;
    private NavMeshAgent agent;
	public float t;

    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    void LateUpdate()
    {
        Vector3 target = this.transform.position + this.transform.forward * 0.1f;
        NavMeshHit hit;
		if(NavMesh.SamplePosition(target, out hit, Mathf.Infinity, NavMesh.AllAreas))
        {
			Quaternion q = Quaternion.FromToRotation (this.transform.up, hit.normal);
			t = q.eulerAngles.magnitude;
			if (q.eulerAngles.magnitude > 0.1f) {
				this.transform.LookAt (hit.position);
			}
        }
    }
}
