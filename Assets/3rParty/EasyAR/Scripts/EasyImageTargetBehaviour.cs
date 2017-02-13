/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using UnityEngine;

namespace EasyAR
{
    public class EasyImageTargetBehaviour : ImageTargetBehaviour
    {
        protected override void Awake()
        {
           // GameObject obj = GameObject.Instantiate(Resources.Load("Tank/tank") as GameObject);
          //  obj.gameObject
            //obj.transform.parent = this.transform;
            //obj.transform.localPosition = new Vector3(0, 0, 0);
            //obj.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            //base.Awake();
            //Path = Application.persistentDataPath + "/namecard.jpg";
            //Name = "namecard";

            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
            TargetLoad += OnTargetLoad;
            TargetUnload += OnTargetUnload;
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
            Debug.Log("Found: " + Target.Id);
        }

        void OnTargetLost(ImageTargetBaseBehaviour behaviour)
        {
            HideObjects(transform);
            Debug.Log("Lost: " + Target.Id);
        }

        void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }

        void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }
    }
}
