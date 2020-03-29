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
        Node cur = head.next;
        int i = 0;
        while (cur != null && i < index)
        {
            cur = cur.next;
            i++;
        }

        if (i == index)
        {
            Debug.Log("Get value:" + cur.value.ToString());
            return cur;
        }
        else
        {
            throw new Exception("index is lager than list length!");
        }
    }

    public bool InsertAtHead(T value)
    {
        Node n = new Node();
        n.value = value;
        n.next = head.next;
        head.next = n;
        Debug.LogError("insert "+value.ToString()+" at head success!");
        return true;
    }

    public bool InsertAt(T node, int i)
    {
        //找到指定位置的前后节点
        Node prevNode = GetNodeAt(i);
        Node nextNode = prevNode.next;

        //创建新节点 插入操作
        Node newNode = new Node();
        newNode.next = nextNode;
        prevNode.next = newNode;
        Debug.Log("Insert " + node.ToString() + " at " + i + " success!");
        return true;
    }

    public void DisplayList()
    {
        StringBuilder sb = new StringBuilder();
        Node node = head.next;
        while(node != null)
        {
            sb.Append(node.value.ToString());
            sb.Append(",");
            node = node.next;
        }

        Debug.LogError(sb.ToString());
    }

}
