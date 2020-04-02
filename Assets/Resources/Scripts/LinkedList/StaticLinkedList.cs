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
        
        _list[Count] = n;
        //游标为0表示结束
        n.index = 0;
        //修改前一个元素的游标指向新加的元素
        Get(_list[_list.Length - 2].index).index = Count;
        //元素个数加一
        _list[0].index++;
    }

    public void Clear()
    {
        _list[0].index = 0;
    }

    public bool Delete(T element, bool all = false)
    {
        throw new System.NotImplementedException();
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

}
