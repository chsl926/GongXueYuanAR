using UnityEngine;
using System.Collections;
using LuaInterface;
namespace SimpleFramework
{
    public class ControllObj : MonoBehaviour
    {
        // Use this for initialization
        public static string hello = "Hello World!";
        public static GameObject instance;
        void Start()
        {
            instance = this.gameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }
        //模型移动速度
       public  static  float TranslateSpeed = 10;
        //模型旋转速度
        public static  float RotateSpeed = 1000;

        public static void LeftRota()
        {
            //向左旋转
            instance.transform.Rotate(Vector3.up * Time.deltaTime * (-RotateSpeed));
        }
        public static void ForwordMove()
        {
            //向前移动
            instance.transform.Translate(Vector3.forward * Time.deltaTime * TranslateSpeed);
        }
        public static void RightRota()
        {
            //向右旋转
            instance.transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
        }
        public static void BackMove()
        {
            //向后移动
            instance.transform.Translate(Vector3.forward * Time.deltaTime * (-TranslateSpeed));
        }
        public static void LeftMove()
        {
            //向左移动
            instance.transform.Translate(Vector3.right * Time.deltaTime * (-TranslateSpeed));
        }
        public static void RightMove()
        {
            //向右移动
            instance.transform.Translate(Vector3.right * Time.deltaTime * TranslateSpeed);
        }

    }
}
