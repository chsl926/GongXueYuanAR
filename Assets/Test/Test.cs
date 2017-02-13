using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    private Vector3 world;

    private float speed = 0;//物体移动的速度  
    public  GameObject obj;
    // Use this for initialization  
    void Start()
    {
        world.x = -2;
        world.y = 0;
        world.z = 6;
    }

    // Update is called once per frame  
    void Update()
    {
        Vector2 screenpos = Camera.main.WorldToScreenPoint(transform.position);//物体的世界坐标转化成屏幕坐标  
        Vector3 e = Input.mousePosition;//鼠标的位置  


        //当点击鼠标中键时  

        if (Input.GetMouseButtonDown(2))
        {
            //e.z=screenpos.z;//1.因为鼠标的屏幕 Z 坐标的默认值是0，所以需要一个z坐标  
            //e.z=1;//将鼠标  
            //摄像机要垂直于x-z平面  
            //world=Camera.main.ScreenToWorldPoint(e);  
            world = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 10f);
            Vector3 world1 = Camera.main.ViewportToWorldPoint(new Vector3(world.x, world.y, 10f));
            //world.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;  
            //world.z = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;  
            //world.y = transform.position.y;  

            print("new x:" + world.x);
            print("new y:" + world.y);
            print("new z:" + world.z);
            obj.transform.position = world;
            //创建物体  
            //GameObject goNew = GameObject.CreatePrimitive(PrimitiveType.Sphere);  
            //goNew.transform.position = world1;  
           // transform.LookAt(world1);
        }
    }
}
