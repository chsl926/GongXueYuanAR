using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DownTime : MonoBehaviour
{

    private bool isUp=true;
    private Image img;
    public System.Action<bool> DownEvent;
    public System.Action<bool> ClickEvent;
    private float time=0;
    void Start()
    {
        /*EventTriggerListener.Get(gameObject).onDown += (go) => { Debug.Log("按下！"); };
        EventTriggerListener.Get(gameObject).onUp += (go) => { Debug.Log("抬起！"); };
        EventTriggerListener.Get(gameObject).onSelect += (go) => { Debug.Log("选中！"); };
        EventTriggerListener.Get(gameObject).onEnter += (go) => { Debug.Log("进入！"); };
        EventTriggerListener.Get(gameObject).onExit += (go) => { Debug.Log("退出！"); };
         * */

        img = transform.FindChild("Time").GetComponent<Image>();
        EventTriggerListener.Get(gameObject).onDown += OnClickDown;
        EventTriggerListener.Get(gameObject).onUp += OnClickUp;

    }

    void Update()
    {
        if(isUp==false)
            time += Time.deltaTime;
    }
    void OnClickDown(GameObject go)
    {
        isUp = false;
        time = 0;
        StartCoroutine(grow());
    }

    void OnClickUp(GameObject go)
    {
        isUp = true;
        if (time < 1)
        {
            ClickEvent(true);
            time = 0;
            img.gameObject.SetActive(false);
            img.fillAmount = 0f;
        }
       
    }
  
    private IEnumerator grow()
    {
        while (true)
        {
            if (time > 1)
            {
                img.gameObject.SetActive(true);
                if (isUp)
                {
                    if (DownEvent != null)
                        DownEvent(false);
                    img.gameObject.SetActive(false);
                    img.fillAmount = 0f;
                    break;
                }
                img.fillAmount += 3f * Time.deltaTime;
                if (img.fillAmount == 1)
                {
                    if (DownEvent != null)
                        DownEvent(true);
                    img.gameObject.SetActive(false);
                    break;
                }
            }
            yield return null;
        }
    }

}
