--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

ColliderEvent={
gameObject;
MyList={};
}
this=ColliderEvent;
function ColliderEvent.Start()
      log('ColliderEvent StartUp');
      -- table.insert(Collider.ObjList,obj);
    end
function ColliderEvent.Add(my)
 table.insert(this.MyList,my);
end
function ColliderEvent.Remove(my)
 table.remove(this.MyList,my);
end

function ColliderEvent.OnTriggerEnter(my, obj)
log(my.name..'  '..obj.name)
--      for v in ipairs(this.MyList)  do
--      if v==my then

--      end
--      end
    end
  function ColliderEvent.OnTriggerExit(my, obj)
    

    end
  function ColliderEvent.OnTriggerStay(my, obj)
    

    end
   function ColliderEvent.OnTriggerEnter2D(my, obj)
    

    end
   function ColliderEvent.OnTriggerExit2D(my, obj)
    

    end
   function ColliderEvent.OnTriggerStay2D(my, obj)
    

    end
   function ColliderEvent.OnCollisionEnter(my, obj)
    

    end
   function ColliderEvent.OnCollisionExit(my, obj)
    

    end
   function ColliderEvent.OnCollisionStay(my, obj)
    

    end
      function ColliderEvent.OnDestory(my, obj)
   
    end

--endregion
