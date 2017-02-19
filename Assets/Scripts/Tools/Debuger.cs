
using UnityEngine;
using System.Diagnostics;
using UnityEngine.Internal;
using System;


public class Debuger
{
    public static bool IsDebug = true;

    public static void Log(object message)
    {
        if (IsDebug)
            UnityEngine. Debug.Log(message);
    }

    public static void Log(object message, UnityEngine.Object context)
    {
        if (IsDebug)
            UnityEngine. Debug.Log(message, context);
    }


    public static void LogError(object message)
    {
        if (IsDebug)
            UnityEngine.Debug.LogError(message);
    }

    public static void LogError(object message, UnityEngine.Object context)
    {
        if (IsDebug)
            UnityEngine.Debug.LogError(message, context);
    }

    public static void LogErrorFormat(string format, params object[] args)
    {
        if (IsDebug)
            UnityEngine.Debug.LogErrorFormat(format, args);
    }

    public static void LogFormat(string format, params object[] args)
    {
        if (IsDebug)
            UnityEngine.Debug.LogFormat(format, args);
    }

    public static void LogFormat(UnityEngine.Object context, string format, params object[] args)
    {
        if (IsDebug)
            UnityEngine.Debug.LogFormat(format, args);
    }

    public static void LogWarning(object message)
    {
        if (IsDebug)
            UnityEngine.Debug.LogWarning(message);
    }

    public static void LogWarning(object message, UnityEngine.Object context)
    {
        if (IsDebug)
            UnityEngine.Debug.LogWarning(message, context);
    }

    public static void LogWarningFormat(string format, params object[] args)
    {
        if (IsDebug)
            UnityEngine.Debug.LogWarningFormat(format, args);
    }

    public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args)
    {
        if (IsDebug)
            UnityEngine.Debug.LogWarningFormat(format, args);
    }

    public static void DrawLine(Vector3 start, Vector3 end)
    {
        if (IsDebug)
            UnityEngine.Debug.DrawLine(start, end);
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        if (IsDebug)
            UnityEngine.Debug.DrawLine(start, end, color);
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
    {
        if (IsDebug)
            UnityEngine.Debug.DrawLine(start, end, color, duration);
    }

    public static void DrawRay(Vector3 start, Vector3 dir)
    {
        if (IsDebug)
            UnityEngine.Debug.DrawRay(start, dir);
    }

    public static void DrawRay(Vector3 start, Vector3 dir, Color color)
    {
        if (IsDebug)
            UnityEngine.Debug.DrawRay(start, dir, color);
    }

    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
    {
        if (IsDebug)
            UnityEngine.Debug.DrawRay(start, dir, color, duration);
    }

    public static void LogException(Exception exception)
    {
        if (IsDebug)
            UnityEngine.Debug.LogException(exception);
    }

    public static void LogException(Exception exception, UnityEngine.Object context)
    {
        if (IsDebug)
            UnityEngine.Debug.LogException(exception, context);
    }

}
