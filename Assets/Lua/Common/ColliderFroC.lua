----region *.lua
require 'System.Event'


ColliderFroC = {

}

TriggerEnteBeat = Event(" ColliderFroC.OnTriggerEnter", true)
TriggerExitBeat = Event(" ColliderFroC.OnTriggerExit", true)
TriggerStayBeat = Event(" ColliderFroC.OnTriggerStay", true)
TriggerEnte2DBeat = Event(" ColliderFroC.OnTriggerEnter2D", true)
TriggerExit2DBeat = Event(" ColliderFroC.OnTriggerExit2D", true)
TriggerStay2DBeat = Event(" ColliderFroC.OnTriggerStay2D", true)
CollisionEnteBeat = Event(" ColliderFroC.OnCollisionEnter", true)
CollisionExitBeat = Event(" ColliderFroC.OnCollisionExit", true)
CollisionStayBeat = Event(" ColliderFroC.OnCollisionStay", true)

OnMouseOverBeat = Event(" ColliderFroC.OnMouseOver", true)
OnMouseEnterBeat = Event(" ColliderFroC.OnMouseEnter", true)
OnMouseDownBeat = Event(" ColliderFroC.OnMouseDown", true)
OnMouseDragBeat = Event(" ColliderFroC.OnMouseDrag", true)
OnMouseExitBeat = Event(" ColliderFroC.OnMouseExit", true)
OnMouseUpBeat = Event(" ColliderFroC.OnMouseUp", true)
OnEnableBeat = Event(" ColliderFroC.OnEnable", true)
OnDisableBeat = Event(" ColliderFroC.OnDisable", true)
OnDestroyBeat = Event(" ColliderFroC.OnDestroy", true)
OnBeCameInvisibleBeat=Event(" ColliderFroC.OnBeCameInvisible", true)
this = ColliderFroC;
function ColliderFroC.Awake()
end
function ColliderFroC.Start()
end

function ColliderFroC.OnTriggerEnter(my, obj)

    TriggerEnteBeat(my, obj);
end
function ColliderFroC.OnTriggerExit(my, obj)

    TriggerExitBeat(my, obj);
end
function ColliderFroC.OnTriggerStay(my, obj)

    TriggerStayBeat(my, obj);
end
function ColliderFroC.OnTriggerEnter2D(my, obj)
    TriggerEnte2DBeat(my, obj);

end
function ColliderFroC.OnTriggerExit2D(my, obj)

    TriggerExit2DBeat(my, obj);
end
function ColliderFroC.OnTriggerStay2D(my, obj)

    TriggerStay2DBeat(my, obj);
end
function ColliderFroC.OnCollisionEnter(my, obj)

    CollisionEnteBeat(my, obj);
end
function ColliderFroC.OnCollisionExit(my, obj)
    CollisionExitBeat(my, obj);

end
function ColliderFroC.OnCollisionStay(my, obj)

    CollisionStayBeat(my, obj);
end

function ColliderFroC.OnMouseOver(my)

    OnMouseOverBeat(my);
end
function ColliderFroC.OnMouseEnter(my)

    OnMouseEnterBeat(my);
end
function ColliderFroC.OnMouseDown(my)

    OnMouseDownBeat(my)
end
function ColliderFroC.OnMouseDrag(my)

    OnMouseDragBeat(my);
end
function ColliderFroC.OnMouseUp(my)

    OnMouseUpBeat(my)
end
function ColliderFroC.OnMouseExit(my)

    OnMouseExitBeat(my);
end
function ColliderFroC.OnDisable(my)

    OnDisableBeat(my);
end
function ColliderFroC.OnEnable(my)

    OnEnableBeat(my);
end
function ColliderFroC.OnDestroy(my)

    OnDestroyBeat(my);
end
function ColliderFroC.OnBeCameInvisible(my)

    OnBeCameInvisibleBeat(my);
end



-- endregion
