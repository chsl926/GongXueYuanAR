using UnityEngine;
using System.Collections;
namespace EasyAR
{
    public class EasyImageTarget : EasyImageTargetBehaviour
    {
        void Awake()
        {
            base.Awake();
           Path = Application.persistentDataPath+ "/namecard.jpg";
           
        }
        // Use this for initialization
        void Start()
        {
            base.Start();
           // GUIDebug.info = Path;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
