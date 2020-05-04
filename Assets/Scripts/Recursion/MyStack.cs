using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStack<T>
{
    SingleLinkedList<T> datas;

    public MyStack()
    {
        datas = new SingleLinkedList<T>();
    }

    public int Count => datas.Count;

    public T Peak()
    {
        if(datas.Count == 0)
        {
            throw new Exception("data count is zero!");
        }

        return datas[datas.Count - 1];
    }

    public T Pop()
    {
        if(datas.Count == 0)
        {
            throw new Exception("data count is zero!");
        }
        T pop = Peak();
        datas.RemoveAt(datas.Count - 1);
        return pop;
    }

    public bool Push(T element)
    {
        if(datas == null)
        {
            return false;
        }

        datas.Add(element);
        return true;
    }

    public void Clear()
    {
        datas.Clear();
    }

    public void Destroy()
    {
        datas.Clear();
        datas = null;
    }

    public void LogStack()
    {
        datas.LogList();
    }

    public T[] ToArr()
    {
        T[] r = new T[datas.Count];

        for (int i = 0; i < datas.Count; i++)
        {
            r[i] = datas[i];
        }

        return r;
    }
    
}
