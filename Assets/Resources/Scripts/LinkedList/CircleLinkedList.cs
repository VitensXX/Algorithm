using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 循环链表
/// 初始状态 头指针和尾指针的next都指向头节点
/// 有元素时,头结点的next指向第一个元素,尾指针指向最后一个元素,且最后一个元素的next指向第一个元素
/// </summary>
/// <typeparam name="T"></typeparam>
public class CircleLinkedList<T> : IListOperation<T>
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

    public CircleLinkedList()
    {
        _head = new Node();
        _head.next = _head;
        _rear = _head;
    }

    public void Add(T element)
    {
        Node n = new Node(element);

        //空链表的情况
        if(_rear.next == _head)
        {
            _head.next = n;
            n.next = n;
            _rear = n;
        }
        //非空链表
        else
        {
            //插入到末尾
            _rear.next = n;
            //新元素指向第一个元素
            n.next = _head.next;
            //尾节点指向新元素
            _rear = n;
        }
    }

    public void Clear()
    {
        _head.next = _head;
        _rear = _head;
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

        Node p = _head.next;
        //如果删除的是第一个元素 需要吧最后一个元素指向第二个元素
        if(p.value.Equals(element))
        {
            _head.next = p.next;
            _rear.next = _rear;
            return true;
        }

        Node prev = p;
        p = p.next;
        while (p != _head.next)
        {
            //找到改元素
            if (p.value.Equals(element))
            {
                prev.next = p.next;
                //如果删除的是尾节点
                if(p.next == _head.next)
                {
                    //修改尾指针
                    _rear = prev;
                }

                return true;
            }
            //改变前一个记录
            prev = p;
            //指针往后移动
            p = p.next;
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
        Node p = _head.next;
        while(p != _rear)
        {
            count++;
        }

        return count;
    }
}
