using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class EasyAR_ImageTargetBaseBehaviourWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Bind", Bind),
			new LuaMethod("SetupWithTarget", SetupWithTarget),
			new LuaMethod("SetupWithJsonFile", SetupWithJsonFile),
			new LuaMethod("SetupWithJsonString", SetupWithJsonString),
			new LuaMethod("SetupWithImage", SetupWithImage),
			new LuaMethod("New", _CreateEasyAR_ImageTargetBaseBehaviour),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Storage", get_Storage, set_Storage),
			new LuaField("Path", get_Path, set_Path),
			new LuaField("Name", get_Name, set_Name),
			new LuaField("Size", get_Size, set_Size),
			new LuaField("ActiveTargetOnStart", get_ActiveTargetOnStart, set_ActiveTargetOnStart),
			new LuaField("Target", get_Target, set_Target),
			new LuaField("Loaders", get_Loaders, null),
		};

		LuaScriptMgr.RegisterLib(L, "EasyAR.ImageTargetBaseBehaviour", typeof(EasyAR.ImageTargetBaseBehaviour), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateEasyAR_ImageTargetBaseBehaviour(IntPtr L)
	{
		LuaDLL.luaL_error(L, "EasyAR.ImageTargetBaseBehaviour class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(EasyAR.ImageTargetBaseBehaviour);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Storage(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Storage");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Storage on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Storage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Path(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Path");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Path on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Name on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Size(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Size");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Size on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Size);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ActiveTargetOnStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ActiveTargetOnStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ActiveTargetOnStart on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ActiveTargetOnStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Target on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.Target);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Loaders(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Loaders");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Loaders on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.Loaders);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Storage(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Storage");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Storage on a nil value");
			}
		}

		obj.Storage = (EasyAR.StorageType)LuaScriptMgr.GetNetObject(L, 3, typeof(EasyAR.StorageType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Path(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Path");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Path on a nil value");
			}
		}

		obj.Path = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Name on a nil value");
			}
		}

		obj.Name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Size(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Size");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Size on a nil value");
			}
		}

		obj.Size = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ActiveTargetOnStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ActiveTargetOnStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ActiveTargetOnStart on a nil value");
			}
		}

		obj.ActiveTargetOnStart = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Target on a nil value");
			}
		}

		obj.Target = (EasyAR.ImageTarget)LuaScriptMgr.GetNetObject(L, 3, typeof(EasyAR.ImageTarget));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Bind(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "EasyAR.ImageTargetBaseBehaviour");
		EasyAR.ImageTrackerBaseBehaviour arg0 = (EasyAR.ImageTrackerBaseBehaviour)LuaScriptMgr.GetUnityObject(L, 2, typeof(EasyAR.ImageTrackerBaseBehaviour));
		obj.Bind(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupWithTarget(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "EasyAR.ImageTargetBaseBehaviour");
		EasyAR.ImageTarget arg0 = (EasyAR.ImageTarget)LuaScriptMgr.GetNetObject(L, 2, typeof(EasyAR.ImageTarget));
		bool o = obj.SetupWithTarget(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupWithJsonFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "EasyAR.ImageTargetBaseBehaviour");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		EasyAR.StorageType arg1 = (EasyAR.StorageType)LuaScriptMgr.GetNetObject(L, 3, typeof(EasyAR.StorageType));
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		bool o = obj.SetupWithJsonFile(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupWithJsonString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "EasyAR.ImageTargetBaseBehaviour");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		EasyAR.StorageType arg1 = (EasyAR.StorageType)LuaScriptMgr.GetNetObject(L, 3, typeof(EasyAR.StorageType));
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		bool o = obj.SetupWithJsonString(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupWithImage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		EasyAR.ImageTargetBaseBehaviour obj = (EasyAR.ImageTargetBaseBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "EasyAR.ImageTargetBaseBehaviour");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		EasyAR.StorageType arg1 = (EasyAR.StorageType)LuaScriptMgr.GetNetObject(L, 3, typeof(EasyAR.StorageType));
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		Vector2 arg3 = LuaScriptMgr.GetVector2(L, 5);
		bool o = obj.SetupWithImage(arg0,arg1,arg2,arg3);
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

