using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class EasyAR_ImageTargetBehaviourWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateEasyAR_ImageTargetBehaviour),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "EasyAR.ImageTargetBehaviour", typeof(EasyAR.ImageTargetBehaviour), regs, fields, typeof(EasyAR.ImageTargetBaseBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateEasyAR_ImageTargetBehaviour(IntPtr L)
	{
		LuaDLL.luaL_error(L, "EasyAR.ImageTargetBehaviour class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(EasyAR.ImageTargetBehaviour);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
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

