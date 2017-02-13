using UnityEngine;
using System.Collections;
using EasyAR;

public class IntrroductionImageTarget : ImageTargetBaseBehaviour {
    private GameObject  targetObj;

	protected override void Awake()
	{

		base.Awake();
		TargetFound += OnTargetFound;
		TargetLost += OnTargetLost;
		TargetLoad += OnTargetLoad;
		TargetUnload += OnTargetUnload;
        targetObj = new GameObject();

    }
	protected override void Start()
	{
		base.Start();
		HideObjects(transform);
	}

	void HideObjects(Transform trans)
	{
		for (int i = 0; i < trans.childCount; ++i)
			HideObjects(trans.GetChild(i));
		if (transform != trans)
			gameObject.SetActive(false);
	}

	void ShowObjects(Transform trans)
	{
		for (int i = 0; i < trans.childCount; ++i)
			ShowObjects(trans.GetChild(i));
		if (transform != trans)
			gameObject.SetActive(true);
	}
	void OnTargetFound(ImageTargetBaseBehaviour behaviour)
	{
		ShowObjects(transform);
		//Debug.Log("Found: " + Target.Id);
	}
	void OnTargetLost(ImageTargetBaseBehaviour behaviour)
	{
		HideObjects(transform);
		//Debug.Log("Lost: " + Target.Id);
	}
	void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
	{
		Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
	}
	void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
	{
		Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowObjects(this.transform);
        }

       
    }
}
