using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 单链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleLinkedList<T> : IListOperation<T>
{
    private class Node
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

    public SingleLinkedList()
    {
        _head = new Node();
        _head.next = null;
        _rear = _head;
    }

    public T this[int index]
    {
        get => GetNodeAt(index).value;
        set => GetNodeAt(index).value = value;
    }

    private Node _head;
    private Node _rear;

    public int Count => GetLength();

    public void Add(T value)
    {
        Node newNode = new Node(value);
        _rear.next = newNode;
        _rear = newNode;
    }

    public void Insert(int i, T value)
    {
        //找到指定位置的前后节点
        Node prevNode = GetNodeAt(i - 1);
        Node nextNode = prevNode.next;

        //创建新节点 插入操作
        Node newNode = new Node(value);
        newNode.next = nextNode;
        prevNode.next = newNode;

        if(prevNode == _rear)
        {
            Debug.Log("Change rear at InsertAt");
            _rear = newNode;
        }

        Debug.Log("Insert " + value.ToString() + " at " + i + " success!");
        //return true;
    }

    public bool RemoveAt(int index)
    {
        int i = 0;
        Node p = _head.next;
        Node prev = _head;

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

    public bool Delete(T value, bool all = false)
    {
        Node p = _head.next;
        Node prev = _head;

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

    public void Clear()
    {
        //Node p = _head;
        ////是否要断掉所有关联？
        //while (p.next != null)
        //{
        //    Node temp = p;
        //    p.next = null;

        //}
        _head.next = null;
        _rear = _head;
    }

    public int IndexOf(T element)
    {
        Node p = _head;
        int index = 0;
        while(p.next != null)
        {
            p = p.next;
            if(p.value.Equals(element))
            {
                return index;
            }

            index++;
        }

        return -1;
    }

    public void LogList()
    {
        StringBuilder sb = new StringBuilder();
        Node p = _head.next;
        while (p != null)
        {
            sb.Append(p.value.ToString());
            sb.Append(",");
            p = p.next;
        }

        Debug.Log(sb.ToString().TrimEnd(',') + "  len:" + Count);
    }

    private Node GetNodeAt(int index)
    {
        //-1表示头结点
        if (index == -1)
        {
            return _head;
        }

        Node p = _head.next;
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

    private int GetLength()
    {
        int len = 0;
        Node p = _head;
        while (p.next != null)
        {
            len++;
            p = p.next;
        }

        return len;
    }

    public bool Contains(T e)
    {
        Node p = _head;
        while (p.next != null)
        {
            if(p.next.value.Equals(e))
            {
                return true;
            }

            p = p.next;
        }

        return false;
    }

    //sort?

}
