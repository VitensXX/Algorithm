using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 循环双向链表 尾巴next指向头结点
/// </summary>
/// <typeparam name="T"></typeparam>
public class DoubleLinkedList<T> : IListOperation<T>
{

    private class Node
    {
        public T value;
        public Node prev;//上一个节点
        public Node next;//下一个节点

        public Node() { }

        public Node(T value)
        {
            this.value = value;
            next = null;
            prev = null;
        }
    }

    Node _head;
    Node _rear;

    public DoubleLinkedList()
    {
        _head = new Node();
        _head.next = _head;
        _rear = _head;
    }

    public int Count => throw new System.NotImplementedException();

    public void Add(T element)
    {
        Node n = new Node(element);
        n.prev = _rear;
        n.next = _head;
        _rear = n;
    }

    public void Clear()
    {
        _head.next = _head;
        _rear = _head;
    }

    public bool Contains(T element)
    {
        throw new System.NotImplementedException();
    }

    public bool Delete(T element, bool all = false)
    {
        Node n = _head;
        while(n.next != _head)
        {
            n = n.next;
            if (n.value.Equals(element))
            {
                //delete
                n.prev.next = n.next;
                n.next.prev = n.prev;

                //如果是尾巴 需要重新设置尾巴指针
                if(n == _rear)
                {
                    _rear = n.prev;
                }

                n.prev = null;
                n.next = null;

                return true;
            }
        }

        return false;
    }

    public int IndexOf(T element)
    {
        throw new System.NotImplementedException();
    }

    public void Insert(int i, T element)
    {
        throw new System.NotImplementedException();
    }

}
