using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SingleLinkedList<T>
{
    public class Node
    {
        public T value;
        public Node next;
    }

    public Node head;

    /// <summary>
    /// 获取指定位置的元素
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T GetAt(int index)
    {
        return GetNodeAt(index).value;
    }

    Node GetNodeAt(int index)
    {
        //-1表示头结点
        if(index == -1)
        {
            return head;
        }

        Node p = head.next;
        int i = 0;
        while (p != null && i < index)
        {
            p = p.next;
            i++;
        }

        if (i == index && p != null)
        {
            Debug.Log("Get value:" + p.value.ToString());
            return p;
        }
        else
        {
            throw new Exception("index is lager than list length!");
        }
    }

    /// <summary>
    /// 头部插入
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool InsertAtHead(T value)
    {
        Node n = new Node();
        n.value = value;
        n.next = head.next;
        head.next = n;
        Debug.Log("insert "+value.ToString()+" at head success!");
        return true;
    }

    /// <summary>
    /// 在指定位置插入元素
    /// </summary>
    /// <param name="value"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public bool InsertAt(T value, int i)
    {
        //找到指定位置的前后节点
        Node prevNode = GetNodeAt(i - 1);
        Node nextNode = prevNode.next;

        //创建新节点 插入操作
        Node newNode = new Node();
        newNode.value = value;
        newNode.next = nextNode;
        prevNode.next = newNode;
        Debug.Log("Insert " + value.ToString() + " at " + i + " success!");
        return true;
    }

    /// <summary>
    /// 打印链表数据
    /// </summary>
    public void LogList()
    {
        StringBuilder sb = new StringBuilder();
        Node p = head.next;
        while(p != null)
        {
            sb.Append(p.value.ToString());
            sb.Append(",");
            p = p.next;
        }

        Debug.Log(sb.ToString().TrimEnd(',') +"  len:"+GetLength());
    }

    public int GetLength()
    {
        int len = 0;
        Node p = head;
        while(p.next != null)
        {
            len++;
            p = p.next;
        }

        return len;
    }

    public bool RemoveAt(int index)
    {
        int i = 0;
        Node p = head.next;
        Node prev = head;

        while(p != null && i <= index)
        {
            //找到目标位置 进行移除操作
            if(i == index)
            {
                prev.next = p.next;
                Debug.LogError("remove success!");
                return true;
            }
            prev = p;
            p = p.next;
            i++;
        }

        Debug.LogError("remove failed!");
        return false;
    }

    public bool Remove(T value)
    {
        Node p = head.next;
        Node prev = head;

        while (p != null)
        {
            //找到目标位置 进行移除操作
            //if (p.value == value)
            //{
            //    prev.next = p.next;
            //    Debug.LogError("remove success!");
            //    return true;
            //}
            prev = p;
            p = p.next;
        }

        Debug.LogError("remove failed!");
        return false;
    }

}
