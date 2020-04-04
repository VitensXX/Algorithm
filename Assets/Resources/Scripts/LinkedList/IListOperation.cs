using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListOperation<T>
{
    int Count { get; }

    /// <summary>
    /// 添加元素
    /// </summary>
    /// <param name="element"></param>
    void Add(T element);

    /// <summary>
    /// 指定位置插入元素
    /// </summary>
    /// <param name="i"></param>
    /// <param name="element"></param>
    void Insert(int i, T element);

    /// <summary>
    /// 移除元素
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    bool Delete(T element, bool all = false);

    /// <summary>
    /// 获取元素的索引
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    int IndexOf(T element);

    /// <summary>
    /// 清空
    /// </summary>
    void Clear();

    bool Contains(T element);
}
