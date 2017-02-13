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
    public class ARMain : LuaBehaviour
    {
        private bool initResed = false;
        public string SceneName;

        // public string SceneName="Tank";
        void Awake()
        {
           
           
        }
        // Use this for initialization
        void  Start()
        {
            this.name = "Scene";
            LuaManager.Start();
            string file = AppConst.CurSceneName + "/Scene" ;
            LuaManager.DoFile(file);
            initResed = true;
            ResourceManager.Instance.InitEndEvent = OnResInitEnd;
            ResManager.Initialize();

           // GameObject.Find("ARMain").GetComponent("GUIDebug");
        }
      

        void OnResInitEnd(bool state)
        {
            GUIDebug.info+="\nARMain------->Start";
            CallMethod("Start");
            
        }

        // Update is called once per frame
        void Update()
        {
            //if (initResed == false && GameManager.initialize)
            //{
            //    LuaManager.Start();
            //    string file = AppConst.CurSceneName + "/" + AppConst.CurSceneName;
            //    LuaManager.DoFile(file);
            //    initResed = true;
            //    ResourceManager.Instance.InitEndEvent += OnResInitEnd;
            //}

        }

    }
}
