using UnityEngine;
using System.Collections;
using SimpleFramework.Manager;
using UnityEngine.Events;
using LuaInterface;
using EasyAR;

namespace SimpleFramework
{
    public class ColliderEvent : MonoBehaviour
    {
        ColliderToLua colliderToLua;
            void Start()
        {
            colliderToLua = GameObject.FindObjectOfType<ColliderToLua>();
           
        }

        void OnTriggerEnter(Collider obj)
        {
            colliderToLua.ColliderEvent("OnTriggerEnter",this.gameObject,obj.gameObject);
        }
        void OnTriggerExit(Collider obj)
        {
            colliderToLua.ColliderEvent("OnTriggerExit", this.gameObject, obj.gameObject);
        }
        void OnTriggerStay(Collider obj)
        {
            colliderToLua.ColliderEvent("OnTriggerStay", this.gameObject, obj.gameObject);
        }
        void OnTriggerEnter2D(Collider2D obj)
        {
            colliderToLua.ColliderEvent("OnTriggerEnter2D", this.gameObject, obj.gameObject);
        }
        void OnTriggerExit2D(Collider2D obj)
        {
            colliderToLua.ColliderEvent("OnTriggerExit2D", this.gameObject, obj.gameObject);
        }
        void OnTriggerStay2D(Collider2D obj)
        {
            colliderToLua.ColliderEvent("OnTriggerStay2D", this.gameObject, obj.gameObject);
        }
        void OnCollisionEnter(Collision obj)
        {
            colliderToLua.ColliderEvent("OnCollisionEnter", this.gameObject, obj.gameObject);
        }
        void OnCollisionExit(Collision obj)
        {
            colliderToLua.ColliderEvent("OnCollisionExit", this.gameObject, obj.gameObject);
        }
        void OnCollisionStay(Collision obj)
        {
            colliderToLua.ColliderEvent("OnCollisionStay", this.gameObject, obj.gameObject);

        }
        void OnMouseOver()
        {
            colliderToLua.ColliderEvent("OnMouseOver",this.gameObject);
        }
        void OnMouseEnter()
        {
            colliderToLua.ColliderEvent("OnMouseEnter", this.gameObject);
        }
        void OnMouseDown()
        {
            colliderToLua.ColliderEvent("OnMouseDown", this.gameObject);
        }
        void OnMouseDrag()
        {
            colliderToLua.ColliderEvent("OnMouseDrag", this.gameObject);
        }
        void OnMouseUp()
        {
            colliderToLua.ColliderEvent("OnMouseUp", this.gameObject);
        }
        void OnMouseExit()
        {
            colliderToLua.ColliderEvent("OnMouseExit", this.gameObject);
        }
        void OnDisable()
        {
            colliderToLua.ColliderEvent("OnDisable", this.gameObject);
        }
        void OnEnable()
        {
            if(!colliderToLua)
                colliderToLua = GameObject.FindObjectOfType<ColliderToLua>();
            colliderToLua.ColliderEvent("OnEnable", this.gameObject);
        }
        void OnDestroy()
        {
            
            colliderToLua.ColliderEvent("OnDestroy", this.gameObject);
        }

        void OnBecameInvisible()
        {
            colliderToLua.ColliderEvent("OnBeCameInvisible", this.gameObject);
        }

    }
}
