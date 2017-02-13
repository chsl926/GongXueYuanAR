using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class GUIDebugWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateGUIDebug),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("info", get_info, set_info),
			new LuaField("Instance", get_Instance, set_Instance),
			new LuaField("isDebugMode", get_isDebugMode, set_isDebugMode),
		};

		LuaScriptMgr.RegisterLib(L, "GUIDebug", typeof(GUIDebug), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGUIDebug(IntPtr L)
	{
		LuaDLL.luaL_error(L, "GUIDebug class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(GUIDebug);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_info(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUIDebug.info);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUIDebug.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isDebugMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GUIDebug obj = (GUIDebug)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isDebugMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isDebugMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isDebugMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_info(IntPtr L)
	{
		GUIDebug.info = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Instance(IntPtr L)
	{
		GUIDebug.Instance = (GUIDebug)LuaScriptMgr.GetUnityObject(L, 3, typeof(GUIDebug));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isDebugMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GUIDebug obj = (GUIDebug)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isDebugMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isDebugMode on a nil value");
			}
		}

		obj.isDebugMode = LuaScriptMgr.GetBoolean(L, 3);
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

