using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SimpleFramework_Manager_ResourceManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Initialize", Initialize),
			new LuaMethod("InitCurSceneAsset", InitCurSceneAsset),
			new LuaMethod("LoadAsset", LoadAsset),
			new LuaMethod("LoadBundle", LoadBundle),
			new LuaMethod("New", _CreateSimpleFramework_Manager_ResourceManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("InitEndEvent", get_InitEndEvent, set_InitEndEvent),
			new LuaField("Instance", get_Instance, set_Instance),
		};

		LuaScriptMgr.RegisterLib(L, "SimpleFramework.Manager.ResourceManager", typeof(SimpleFramework.Manager.ResourceManager), regs, fields, typeof(View));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSimpleFramework_Manager_ResourceManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SimpleFramework.Manager.ResourceManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SimpleFramework.Manager.ResourceManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitEndEvent(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SimpleFramework.Manager.ResourceManager obj = (SimpleFramework.Manager.ResourceManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name InitEndEvent");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index InitEndEvent on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.InitEndEvent);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, SimpleFramework.Manager.ResourceManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitEndEvent(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SimpleFramework.Manager.ResourceManager obj = (SimpleFramework.Manager.ResourceManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name InitEndEvent");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index InitEndEvent on a nil value");
			}
		}

		LuaTypes funcType = LuaDLL.lua_type(L, 3);

		if (funcType != LuaTypes.LUA_TFUNCTION)
		{
			obj.InitEndEvent = (Action<bool>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<bool>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			obj.InitEndEvent = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Instance(IntPtr L)
	{
		SimpleFramework.Manager.ResourceManager.Instance = (SimpleFramework.Manager.ResourceManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(SimpleFramework.Manager.ResourceManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SimpleFramework.Manager.ResourceManager obj = (SimpleFramework.Manager.ResourceManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.Manager.ResourceManager");
		obj.Initialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitCurSceneAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SimpleFramework.Manager.ResourceManager obj = (SimpleFramework.Manager.ResourceManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.Manager.ResourceManager");
		obj.InitCurSceneAsset();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsset(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			SimpleFramework.Manager.ResourceManager obj = (SimpleFramework.Manager.ResourceManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.Manager.ResourceManager");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			GameObject o = obj.LoadAsset(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			SimpleFramework.Manager.ResourceManager obj = (SimpleFramework.Manager.ResourceManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.Manager.ResourceManager");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			obj.LoadAsset(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SimpleFramework.Manager.ResourceManager.LoadAsset");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadBundle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SimpleFramework.Manager.ResourceManager obj = (SimpleFramework.Manager.ResourceManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.Manager.ResourceManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		AssetBundle o = obj.LoadBundle(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
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

