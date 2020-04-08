using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 循环链表 Circular linked list
/// 初始状态 头指针和尾指针的next都指向头节点
/// 有元素时,头结点的next指向第一个元素,尾指针指向最后一个元素,且最后一个元素的next指向头节点
/// </summary>
/// <typeparam name="T"></typeparam>
public class CircularLinkedList<T> : IListOperation<T>
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

    public int Count => GetCount();

    Node _head;
    Node _rear;//指向最后一个元素
    Node _iterator;

    public CircularLinkedList()
    {
        _head = new Node();
        _head.next = _head;
        _rear = _head;
        _iterator = _head;
    }

    public void Add(T element)
    {
        Node n = new Node(element);

        //空链表的情况
        if(_head.next == _head)
        {
            _head.next = n;
            n.next = _head;
            _rear = n;
        }
        //非空链表
        else
        {
            //插入到末尾
            _rear.next = n;
            //新元素指向头节点
            n.next = _head;
            //尾节点指向新元素
            _rear = n;
        }
    }

    public void Clear()
    {
        _head.next = _head;
        _rear = _head;
        _iterator = _head;
    }

    public bool Contains(T element)
    {
        throw new NotImplementedException();
    }

    public bool Delete(T element, bool all = false)
    {
        //没有元素
        if(_head.next == _head)
        {
            return false;
        }

        //只有一个元素
        if(_head.next == _rear)
        {
            _head.next = _head;
            _rear = _head;
            return true;
        }

        Node p = _head;
        Node prev = p;
        while (p.next != _head)
        {
            p = p.next;
            //找到改元素
            if (p.value.Equals(element))
            {
                prev.next = p.next;
                //如果删除的是尾节点
                if(p.next == _head)
                {
                    //修改尾指针
                    _rear = prev;
                }

                return true;
            }
            //改变前一个记录
            prev = p;
        }

        return false;
    }

    public int IndexOf(T element)
    {
        throw new NotImplementedException();
    }

    public void Insert(int i, T element)
    {
        throw new NotImplementedException();
    }

    int GetCount()
    {
        int count = 0;
        Node p = _head;
        while(p.next != _head)
        {
            p = p.next;
            count++;
        }

        return count;
    }

    public void LogList()
    {
        StringBuilder sb = new StringBuilder();
        Node p = _head;
        while (p.next != _head)
        {
            p = p.next;
            sb.Append(p.value.ToString());
            sb.Append(",");
        }

        Debug.Log(sb.ToString().TrimEnd(',') + "  len:" + Count);
    }

    Node _prevIterator;
    public T Move()
    {
        _prevIterator = _iterator;
        if(_iterator.next != _head)
        {
            _iterator = _iterator.next;
        }
        else
        {
            _iterator = _head.next;
        }

        return _iterator.value;
    }

    public T RemoveAtIterator()
    {
        T data = _iterator.value;
        if(_prevIterator == _iterator)
        {
            _iterator = _head;
            _head.next = _head;
        }
        else if(_prevIterator.next == _head)
        {
            _head.next = _iterator.next;
        }
        else
        {
            _prevIterator.next = _iterator.next;
        }
        return data;
    }

    public T ReMove(int step)
    {
        _iterator = _head;
        int count = 0;
        T result = default(T);
        while(count < step)
        {
            result = Move();
        }

        return result;
    }

    public bool IsEmpty()
    {
        return _head.next == _head;
    }
}
