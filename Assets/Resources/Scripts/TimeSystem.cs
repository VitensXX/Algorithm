using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeSystem
{
    //获取运行时间
    private static DateTime _start = DateTime.Now;
    
    private static int _begin = 0;
    private static int _end = 0;

    static Stopwatch _sw = new Stopwatch();

    public static int Tick
    {
        get
        {
            TimeSpan span = DateTime.Now - _start;
            return (int)span.TotalMilliseconds;
        }
    }

    public static void TickStart()
    {
        _sw.Restart();
    }

    public static void TickEnd()
    {
        //_end = Tick;
        _sw.Stop();

        //UnityEngine.Debug.LogError(_sw.Elapsed.TotalMilliseconds.ToString());
    }
}
