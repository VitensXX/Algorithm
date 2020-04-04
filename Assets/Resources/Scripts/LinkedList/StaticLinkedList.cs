using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 静态链表
/// 数组实现,不用指针,第一个元素的索引值表示数组元素个数
/// 比起数组可以减少删除操作的开销,但是查找需要遍历
/// </summary>
/// <typeparam name="T"></typeparam>
public class StaticLinkedList<T> : IListOperation<T>
{
    int DEFAULT_LENGTH = 128;//默认长度,如果长度不够则会进行扩容操作

    class Node
    {
        public int index;
        public T element;

        public Node(T element)
        {
            this.element = element;
        }
    }

    public StaticLinkedList()
    {
        _list = new Node[DEFAULT_LENGTH];
        _list[0].index = 0;
        //尾巴的游标指向第一个真实元素的下标
        _list[_list.Length - 1].index = 0;
        //倒数第二个的元素游标指向真实元素的尾巴下标
        //_list[_list.Length - 2].index = 0;
    }

    Node[] _list;

    /// <summary>
    /// 当前链表中第一个有效元素的下标
    /// </summary>
    int _headIndex
    {
        get => _list[_list.Length - 1].index;
        set => _list[_list.Length - 1].index = value;
    }
    //int _tailIndex => _list[_list.Length - 2].index;


    public T this[int index]
    {
        get => Get(index).element;
        set => Get(index).element = value;
    }

    public int Count => _list[0].index;


    public void Add(T element)
    {
        //如果超出上限 需要扩容

        //添加到尾部
        Node n = new Node(element);

        //新元素在数组中的下标
        int newTailArrIndex = Count + 1;

        _list[newTailArrIndex] = n;
        //游标为0表示结束
        n.index = 0;

        int tailArrIndex = GetTailArrIndex();
        //获取到的尾巴节点就是头节点表示这是添加的第一个元素
        if(tailArrIndex == 0)
        {
            //数组最后一个元素需要指向第一个有效元素
            _list[_list.Length - 1].index = newTailArrIndex;
        }
        //修改前一个元素的游标指向新加的元素
        else
        {
            _list[tailArrIndex].index = newTailArrIndex;
        }

        //元素个数加一
        _list[0].index++;
    }

    //获取尾巴节点在数组中的下标
    int GetTailArrIndex()
    {
        //还没有元素
        if(_list[0].index == 0)
        {
            return 0;
        }
        else
        {
            int i = 1;
            while(_list[i].index != 0)
            {
                //通过游标找到下一个元素的数组索引
                i = _list[i].index;
            }

            return i;
        }
    }

    public void Clear()
    {
        _list[0].index = 0;
    }

    public bool Delete(T element, bool all = false)
    {
        //空链表
        if(_list[0].index == 0)
        {
            return false;
        }

        //链表起始位置
        int i = _list[_list.Length - 1].index;
        do
        {
            if (_list[i].element.Equals(element))
            {
                //删除操作

                //前一个元素指向下一个元素

                

                return true;
            }
        }
        while (_list[i].index != 0);

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

    private Node Get(int index)
    {
        if (index >= Count)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        int p = _list[DEFAULT_LENGTH - 1].index;
        int count = 0;
        while (count != index)
        {
            count++;
            p = _list[p].index;
        }

        return _list[p];
    }

    public bool Contains(T e)
    {
        throw new System.NotImplementedException();
    }
}
