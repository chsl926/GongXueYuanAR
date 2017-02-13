using UnityEngine;
using System;
using System.Collections;
using SimpleFramework;
using SimpleFramework.Manager;
using UnityEngine.UI;
using UnityEngine.Events;
using EasyAR;

namespace SimpleFramework
{
    public class ColliderToLua : LuaBehaviour
    {
        bool initResed = false;
        // Use this for initialization
        void Start()
        {
            

            LuaManager.Start();
            string file = "Common/ColliderFroC";
            LuaManager.DoFile(file);
        }
        public void ColliderEvent(string name,GameObject my=null, GameObject obj=null)
        {
            CallMethod(name, my, obj);
        }

        void OnResInitEnd(bool state)
        {
            CallMethod("Start");
        }

        // Update is called once per frame
        void Update()
        {
            //if (initResed == false && GameManager.initialize)
            //{
            //    ResourceManager.Instance.InitEndEvent += OnResInitEnd;
            //    initResed = true;
            //}

        }
    }
}
