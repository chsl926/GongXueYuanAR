using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    ////用于绑定参照物对象
    //   public Transform target;
    ////缩放系数
    float distance = 10.0f;
    //    //左右滑动移动速度
    //    float xSpeed = 250.0f;
    //    float ySpeed = 120.0f;
    //    //缩放限制系数
    //    float yMinLimit = -20f;
    //    float yMaxLimit = 80f;
    //    //摄像头的位置
    //    float x = 0.0f;
    //    float y = 0.0f;
    //记录上一次手机触摸位置判断用户是在左放大还是缩小手势
    private Vector2 oldPosition1;
    private Vector2 oldPosition2;
    //    private Rigidbody rigidbody;

    ////初始化游戏信息设置
    //    void  Start()
    //    {
    //        var angles = transform.eulerAngles;
    //        x = angles.y;
    //        y = angles.x;


    //        // Make the rigid body not change rotation
    //        if (GetComponent<Rigidbody>())
    //        {
    //            rigidbody = GetComponent<Rigidbody>();
    //            rigidbody.freezeRotation = true;
    //        }

    //    }

    //    void Update()
    //    {

    //        //判断触摸数量为单点触摸
    //        if (Input.touchCount == 1&& Input.GetTouch(0).phase == TouchPhase.Moved ||Input.GetMouseButtonDown(0))
    //        {
    //                //触摸类型为移动触摸
    //                //根据触摸点计算X与Y位置
    //                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
    //                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
    //        }

    //        //判断触摸数量为多点触摸
    //        if (Input.touchCount > 1)
    //        {
    //            //前两只手指触摸类型都为移动触摸
    //            if (Input.GetTouch(0).phase == TouchPhase.Moved||Input.GetTouch(1).phase == TouchPhase.Moved)
    //    	{
    //                //计算出当前两点触摸点的位置
    //                var tempPosition1 = Input.GetTouch(0).position;
    //                var tempPosition2 = Input.GetTouch(1).position;
    //                //函数返回真为放大，返回假为缩小
    //                if (isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
    //                {
    //                    //放大系数超过3以后不允许继续放大
    //                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
    //                    if (distance > 3)
    //                    {
    //                        distance -= 0.5f;
    //                    }
    //                }
    //                else
    //                {
    //                    //缩小洗漱返回18.5后不允许继续缩小
    //                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
    //                    if (distance < 18.5f)
    //                    {
    //                        distance += 0.5f;
    //                    }
    //                }
    //                //备份上一次触摸点的位置，用于对比
    //                oldPosition1 = tempPosition1;
    //                oldPosition2 = tempPosition2;
    //            }
    //        }

    //        if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //        {
    //            if (Camera.main.fieldOfView <= 100)
    //                Camera.main.fieldOfView += 2;
    //            if (Camera.main.orthographicSize <= 20)
    //                Camera.main.orthographicSize += 0.5F;
    //        }
    //        //Zoom in
    //        if (Input.GetAxis("Mouse ScrollWheel") > 0)
    //        {
    //            if (Camera.main.fieldOfView > 2)
    //                Camera.main.fieldOfView -= 2;
    //            if (Camera.main.orthographicSize >= 1)
    //                Camera.main.orthographicSize -= 0.5F;
    //        }
    //    }

    //函数返回真为放大，返回假为缩小
    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        //函数传入上一次触摸两点的位置与本次触摸两点的位置计算出用户的手势
        var leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        var leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (leng1 < leng2)
        {
            //放大手势
            return true;
        }
        else
        {
            //缩小手势
            return false;
        }
    }

    ////Update方法一旦调用结束以后进入这里算出重置摄像机的位置
    //void LateUpdate()
    //{

    //    //target为我们绑定的箱子变量，缩放旋转的参照物
    //    if (target)
    //    {

    //        //重置摄像机的位置
    //        y = ClampAngle(y, yMinLimit, yMaxLimit);
    //        var rotation = Quaternion.Euler(y, x, 0);
    //        var position = rotation *new  Vector3(0.0f, 0.0f, -distance) + target.position;

    //        transform.rotation = rotation;
    //        transform.position = position;
    //    }
    //}

    //static float   ClampAngle(float angle , float min , float max )
    //{
    //    if (angle < -360)
    //        angle += 360;
    //    if (angle > 360)
    //        angle -= 360;
    //    return Mathf.Clamp(angle, min, max);
    //}


    //观察目标
    public Transform Target;

    //观察距离  
    public float Distance = 1F;

    //旋转速度  
    private float SpeedX = 240;
    private float SpeedY = 120;

    //角度限制  
    private float MinLimitY = -180;
    private float MaxLimitY = 180;

    //旋转角度  
    private float mX = 0.0F;
    private float mY = 0.0F;

    //鼠标缩放距离最值  
    private float MaxDistance = 10;
    private float MinDistance = 0.6F;
    //鼠标缩放速率  
    private float ZoomSpeed = 2F;

    //是否启用差值  
    public bool isNeedDamping = true;
    //速度  
    public float Damping = 10F;

    //存储角度的四元数  
    private Quaternion mRotation;

    //定义鼠标按键枚举  
    private enum MouseButton
    {
        //鼠标左键  
        MouseButton_Left = 0,
        //鼠标右键  
        MouseButton_Right = 1,
        //鼠标中键  
        MouseButton_Midle = 2
    }

    //相机移动速度  
    private float MoveSpeed = 5.0F;
    //屏幕坐标  
    private Vector3 mScreenPoint;
    //坐标偏移  
    private Vector3 mOffset;
    void Start()
    {
        //初始化旋转角度  
        mX = transform.eulerAngles.x;
        mY = transform.eulerAngles.y;
        mRotation = Quaternion.Euler(mY, mX, 0);
        transform.rotation = mRotation;
    }
    void LateUpdate()
    {
        if (Target == null)
            return;
        //鼠标右键旋转  
        if (Target != null && Input.GetMouseButton((int)MouseButton.MouseButton_Left))
        {
            //获取鼠标输入  
            mX += Input.GetAxis("Mouse X") * SpeedX * 0.02F;
            mY -= Input.GetAxis("Mouse Y") * SpeedY * 0.02F;
            //范围限制  
            mY = ClampAngle(mY, MinLimitY, MaxLimitY);
            //计算旋转  
            mRotation = Quaternion.Euler(mY, mX, 0);
            //根据是否插值采取不同的角度计算方式  
            if (isNeedDamping)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, mRotation, Time.deltaTime * Damping);
            }
            else {
                transform.rotation = mRotation;
            }
        }

        //判断触摸数量为多点触摸
        if (Input.touchCount > 1)
        {
            //前两只手指触摸类型都为移动触摸
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                //计算出当前两点触摸点的位置
                var tempPosition1 = Input.GetTouch(0).position;
                var tempPosition2 = Input.GetTouch(1).position;
                //函数返回真为放大，返回假为缩小
                if (isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
                {
                    //放大系数超过3以后不允许继续放大
                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
                    if (Distance > 3)
                    {
                        Distance -= 0.5f;
                    }
                }
                else
                {
                    //缩小洗漱返回18.5后不允许继续缩小
                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
                    if (Distance < 18.5f)
                    {
                        Distance += 0.5f;
                    }
                }
                //备份上一次触摸点的位置，用于对比
                oldPosition1 = tempPosition1;
                oldPosition2 = tempPosition2;
            }
        }
        else
        {
            //鼠标中键平移  
            //鼠标滚轮缩放 
            Distance -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
            Distance = Mathf.Clamp(Distance, MinDistance, MaxDistance);
        }
        //重新计算位置  
        Vector3 mPosition = mRotation * new Vector3(0.0F, 0.0F, -Distance) + Target.position;
        //设置相机的位置  
        if (isNeedDamping)
        {
            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * Damping);
        }
        else {
            transform.position = mPosition;
        }
    }
    //角度限制  
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
