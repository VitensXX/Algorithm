using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 单链表
/// 1.插入：头插，尾插，指定位置插入
/// 2.删除：指定元素删除，指定位置删除
/// 3.修改：指定位置元素修改
/// 4.查找：通过索引查找
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleLinkedList<T>
{
    public class Node
    {
        public T value;
        public Node next;

        public Node() { }

        public Node(T value)
        {
            this.value = value;
            next = null;
        }
    }

    public Node head;
    public Node rear;

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
            return null;
            throw new Exception("index is lager than list length!");
        }
    }

    Node GetNode(T value)
    {
        Node p = head.next;
        while(p != null)
        {
            if (p.value.Equals(value))
            {
                return p;
            }
            p = p.next;
        }
        Debug.Log("not find node where value = " + value.ToString());
        return null;
    }

    /// <summary>
    /// 头部插入
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool InsertAtHead(T value)
    {
        Node n = new Node(value);
        n.next = head.next;
        head.next = n;

        if (rear == head)
        {
            Debug.Log("Change rear at InsertAtHead");
            rear = n;
        }

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
        Node newNode = new Node(value);
        newNode.next = nextNode;
        prevNode.next = newNode;

        if(prevNode == rear)
        {
            Debug.Log("Change rear at InsertAt");
            rear = newNode;
        }

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
            if (p.value.Equals(value))
            {
                prev.next = p.next;
                Debug.Log("remove success!" + value.ToString());
                return true;
            }
            prev = p;
            p = p.next;
        }

        Debug.Log("remove failed!");
        return false;
    }

    public void AddV2(T value)
    {
        Node newNode = new Node(value);
        rear.next = newNode;
        Debug.Log("Change rear at AddV2");
        rear = newNode;
        Debug.Log("add " + value.ToString());
    }

    public bool Modify(int index, T value)
    {
        Node p = GetNodeAt(index);
        if(p != null)
        {
            p.value = value;
            return true;
        }
        return false;
    }

    public bool Modify(T old, T now)
    {
        Node p = GetNode(old);
        if (p != null)
        {
            p.value = now;
            return true;
        }
        return false;
    }

    public void Clear()
    {
        
        Node p = head;
        //是否要断掉所有关联？
        while (p.next != null)
        {
            Node temp = p;
            p.next = null;

        }

        head.next = null;
        rear = head;
    }
}
