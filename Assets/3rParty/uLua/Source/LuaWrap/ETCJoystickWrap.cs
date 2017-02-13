using System;
using UnityEngine;
using UnityEngine.EventSystems;
using LuaInterface;
using Object = UnityEngine.Object;

public class ETCJoystickWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Start", Start),
			new LuaMethod("Update", Update),
			new LuaMethod("LateUpdate", LateUpdate),
			new LuaMethod("OnPointerEnter", OnPointerEnter),
			new LuaMethod("OnPointerDown", OnPointerDown),
			new LuaMethod("OnBeginDrag", OnBeginDrag),
			new LuaMethod("OnDrag", OnDrag),
			new LuaMethod("OnPointerUp", OnPointerUp),
			new LuaMethod("GetRadius", GetRadius),
			new LuaMethod("InitCurve", InitCurve),
			new LuaMethod("InitTurnMoveCurve", InitTurnMoveCurve),
			new LuaMethod("New", _CreateETCJoystick),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("onMoveStart", get_onMoveStart, set_onMoveStart),
			new LuaField("onMove", get_onMove, set_onMove),
			new LuaField("onMoveSpeed", get_onMoveSpeed, set_onMoveSpeed),
			new LuaField("onMoveEnd", get_onMoveEnd, set_onMoveEnd),
			new LuaField("onTouchStart", get_onTouchStart, set_onTouchStart),
			new LuaField("onTouchUp", get_onTouchUp, set_onTouchUp),
			new LuaField("OnDownUp", get_OnDownUp, set_OnDownUp),
			new LuaField("OnDownDown", get_OnDownDown, set_OnDownDown),
			new LuaField("OnDownLeft", get_OnDownLeft, set_OnDownLeft),
			new LuaField("OnDownRight", get_OnDownRight, set_OnDownRight),
			new LuaField("OnPressUp", get_OnPressUp, set_OnPressUp),
			new LuaField("OnPressDown", get_OnPressDown, set_OnPressDown),
			new LuaField("OnPressLeft", get_OnPressLeft, set_OnPressLeft),
			new LuaField("OnPressRight", get_OnPressRight, set_OnPressRight),
			new LuaField("joystickType", get_joystickType, set_joystickType),
			new LuaField("allowJoystickOverTouchPad", get_allowJoystickOverTouchPad, set_allowJoystickOverTouchPad),
			new LuaField("radiusBase", get_radiusBase, set_radiusBase),
			new LuaField("radiusBaseValue", get_radiusBaseValue, set_radiusBaseValue),
			new LuaField("axisX", get_axisX, set_axisX),
			new LuaField("axisY", get_axisY, set_axisY),
			new LuaField("thumb", get_thumb, set_thumb),
			new LuaField("joystickArea", get_joystickArea, set_joystickArea),
			new LuaField("userArea", get_userArea, set_userArea),
			new LuaField("isTurnAndMove", get_isTurnAndMove, set_isTurnAndMove),
			new LuaField("tmSpeed", get_tmSpeed, set_tmSpeed),
			new LuaField("tmAdditionnalRotation", get_tmAdditionnalRotation, set_tmAdditionnalRotation),
			new LuaField("tmMoveCurve", get_tmMoveCurve, set_tmMoveCurve),
			new LuaField("tmLockInJump", get_tmLockInJump, set_tmLockInJump),
			new LuaField("IsNoReturnThumb", get_IsNoReturnThumb, set_IsNoReturnThumb),
			new LuaField("IsNoOffsetThumb", get_IsNoOffsetThumb, set_IsNoOffsetThumb),
		};

		LuaScriptMgr.RegisterLib(L, "ETCJoystick", typeof(ETCJoystick), regs, fields, typeof(ETCBase));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateETCJoystick(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ETCJoystick class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ETCJoystick);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onMoveStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMoveStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMoveStart on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onMoveStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onMove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMove on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onMove);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onMoveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMoveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMoveSpeed on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onMoveSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onMoveEnd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMoveEnd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMoveEnd on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onMoveEnd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onTouchStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onTouchStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onTouchStart on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onTouchStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onTouchUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onTouchUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onTouchUp on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onTouchUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnDownUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownUp on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnDownUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnDownDown(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownDown");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownDown on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnDownDown);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnDownLeft(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownLeft");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownLeft on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnDownLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnDownRight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownRight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownRight on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnDownRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnPressUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressUp on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnPressUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnPressDown(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressDown");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressDown on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnPressDown);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnPressLeft(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressLeft");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressLeft on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnPressLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnPressRight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressRight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressRight on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.OnPressRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_joystickType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name joystickType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index joystickType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.joystickType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allowJoystickOverTouchPad(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowJoystickOverTouchPad");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowJoystickOverTouchPad on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.allowJoystickOverTouchPad);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_radiusBase(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name radiusBase");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index radiusBase on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.radiusBase);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_radiusBaseValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name radiusBaseValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index radiusBaseValue on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.radiusBaseValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_axisX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name axisX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index axisX on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.axisX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_axisY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name axisY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index axisY on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.axisY);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_thumb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name thumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index thumb on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.thumb);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_joystickArea(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name joystickArea");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index joystickArea on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.joystickArea);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_userArea(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name userArea");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index userArea on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.userArea);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isTurnAndMove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isTurnAndMove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isTurnAndMove on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isTurnAndMove);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tmSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tmSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tmAdditionnalRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmAdditionnalRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmAdditionnalRotation on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tmAdditionnalRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tmMoveCurve(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmMoveCurve");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmMoveCurve on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.tmMoveCurve);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tmLockInJump(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmLockInJump");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmLockInJump on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tmLockInJump);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNoReturnThumb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsNoReturnThumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsNoReturnThumb on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsNoReturnThumb);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNoOffsetThumb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsNoOffsetThumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsNoOffsetThumb on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsNoOffsetThumb);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onMoveStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMoveStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMoveStart on a nil value");
			}
		}

		obj.onMoveStart = (ETCJoystick.OnMoveStartHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnMoveStartHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onMove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMove on a nil value");
			}
		}

		obj.onMove = (ETCJoystick.OnMoveHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnMoveHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onMoveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMoveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMoveSpeed on a nil value");
			}
		}

		obj.onMoveSpeed = (ETCJoystick.OnMoveSpeedHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnMoveSpeedHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onMoveEnd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onMoveEnd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onMoveEnd on a nil value");
			}
		}

		obj.onMoveEnd = (ETCJoystick.OnMoveEndHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnMoveEndHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onTouchStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onTouchStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onTouchStart on a nil value");
			}
		}

		obj.onTouchStart = (ETCJoystick.OnTouchStartHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnTouchStartHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onTouchUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onTouchUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onTouchUp on a nil value");
			}
		}

		obj.onTouchUp = (ETCJoystick.OnTouchUpHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnTouchUpHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnDownUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownUp on a nil value");
			}
		}

		obj.OnDownUp = (ETCJoystick.OnDownUpHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownUpHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnDownDown(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownDown");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownDown on a nil value");
			}
		}

		obj.OnDownDown = (ETCJoystick.OnDownDownHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownDownHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnDownLeft(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownLeft");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownLeft on a nil value");
			}
		}

		obj.OnDownLeft = (ETCJoystick.OnDownLeftHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownLeftHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnDownRight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnDownRight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnDownRight on a nil value");
			}
		}

		obj.OnDownRight = (ETCJoystick.OnDownRightHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownRightHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnPressUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressUp on a nil value");
			}
		}

		obj.OnPressUp = (ETCJoystick.OnDownUpHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownUpHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnPressDown(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressDown");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressDown on a nil value");
			}
		}

		obj.OnPressDown = (ETCJoystick.OnDownDownHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownDownHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnPressLeft(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressLeft");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressLeft on a nil value");
			}
		}

		obj.OnPressLeft = (ETCJoystick.OnDownLeftHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownLeftHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnPressRight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnPressRight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnPressRight on a nil value");
			}
		}

		obj.OnPressRight = (ETCJoystick.OnDownRightHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.OnDownRightHandler));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_joystickType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name joystickType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index joystickType on a nil value");
			}
		}

		obj.joystickType = (ETCJoystick.JoystickType)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.JoystickType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_allowJoystickOverTouchPad(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowJoystickOverTouchPad");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowJoystickOverTouchPad on a nil value");
			}
		}

		obj.allowJoystickOverTouchPad = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_radiusBase(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name radiusBase");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index radiusBase on a nil value");
			}
		}

		obj.radiusBase = (ETCJoystick.RadiusBase)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.RadiusBase));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_radiusBaseValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name radiusBaseValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index radiusBaseValue on a nil value");
			}
		}

		obj.radiusBaseValue = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_axisX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name axisX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index axisX on a nil value");
			}
		}

		obj.axisX = (ETCAxis)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCAxis));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_axisY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name axisY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index axisY on a nil value");
			}
		}

		obj.axisY = (ETCAxis)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCAxis));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_thumb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name thumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index thumb on a nil value");
			}
		}

		obj.thumb = (RectTransform)LuaScriptMgr.GetUnityObject(L, 3, typeof(RectTransform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_joystickArea(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name joystickArea");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index joystickArea on a nil value");
			}
		}

		obj.joystickArea = (ETCJoystick.JoystickArea)LuaScriptMgr.GetNetObject(L, 3, typeof(ETCJoystick.JoystickArea));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_userArea(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name userArea");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index userArea on a nil value");
			}
		}

		obj.userArea = (RectTransform)LuaScriptMgr.GetUnityObject(L, 3, typeof(RectTransform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isTurnAndMove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isTurnAndMove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isTurnAndMove on a nil value");
			}
		}

		obj.isTurnAndMove = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tmSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmSpeed on a nil value");
			}
		}

		obj.tmSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tmAdditionnalRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmAdditionnalRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmAdditionnalRotation on a nil value");
			}
		}

		obj.tmAdditionnalRotation = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tmMoveCurve(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmMoveCurve");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmMoveCurve on a nil value");
			}
		}

		obj.tmMoveCurve = (AnimationCurve)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationCurve));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tmLockInJump(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tmLockInJump");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tmLockInJump on a nil value");
			}
		}

		obj.tmLockInJump = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsNoReturnThumb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsNoReturnThumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsNoReturnThumb on a nil value");
			}
		}

		obj.IsNoReturnThumb = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsNoOffsetThumb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ETCJoystick obj = (ETCJoystick)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsNoOffsetThumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsNoOffsetThumb on a nil value");
			}
		}

		obj.IsNoOffsetThumb = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		obj.Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LateUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		obj.LateUpdate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerEnter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnPointerEnter(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnPointerDown(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBeginDrag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnBeginDrag(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDrag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnDrag(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnPointerUp(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRadius(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		float o = obj.GetRadius();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitCurve(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		obj.InitCurve();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitTurnMoveCurve(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ETCJoystick obj = (ETCJoystick)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ETCJoystick");
		obj.InitTurnMoveCurve();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

