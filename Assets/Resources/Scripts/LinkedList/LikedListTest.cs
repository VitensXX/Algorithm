using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikedListTest : MonoBehaviour
{
    SingleLinkedList<string> _singleList;

    private void Start()
    {
        _singleList = new SingleLinkedList<string>();
        _singleList.head = new SingleLinkedList<string>.Node();
        _singleList.head.next = null;

        _singleList.rear = _singleList.head;

        for (int i = 0; i < 5; i++)
        {
            _singleList.InsertAtHead(i.ToString());
        }
    }

    private string insertValuse = "";
    private string insertIndex = "";
    private string indexValue = "";

    private void OnGUI()
    {
        insertValuse = GUI.TextField(new Rect(110, 40, 80, 50), insertValuse);
        if (GUI.Button(new Rect(20, 40, 80, 50), "头插"))
        {
            _singleList.InsertAtHead(insertValuse);
            insertValuse = "";
        }

        insertIndex = GUI.TextField(new Rect(110, 140, 80, 50), insertIndex);
        if (GUI.Button(new Rect(20, 140, 80, 50), "指定插入"))
        {
            _singleList.InsertAt(insertValuse, int.Parse(insertIndex));
            insertIndex = "";
        }

        indexValue = GUI.TextField(new Rect(110, 240, 80, 50), indexValue);
        if (GUI.Button(new Rect(20, 240, 80, 50), "获取"))
        {
            _singleList.GetAt(int.Parse(indexValue));
            indexValue = "";
        }

        //indexValue = GUI.TextField(new Rect(110, 340, 80, 50), indexValue);
        if (GUI.Button(new Rect(20, 340, 80, 50), "移除"))
        {
            _singleList.RemoveAt(int.Parse(indexValue));
            indexValue = "";
        }

        if (GUI.Button(new Rect(20, 440, 80, 50), "移除元素"))
        {
            _singleList.Remove(insertValuse);
            indexValue = "";
        }

        if (GUI.Button(new Rect(110, 440, 80, 50), "尾插"))
        {
            _singleList.AddV2(insertValuse);
            indexValue = "";
        }

        if (GUI.Button(new Rect(110, 340, 80, 50), "修改元素"))
        {
            _singleList.Modify(insertValuse, insertIndex);
            indexValue = "";
        }

        if (GUI.Button(new Rect(200, 440, 80, 50), "修改"))
        {
            _singleList.Modify(int.Parse(indexValue) , insertValuse);
            indexValue = "";
        }

        

        if (GUI.Button(new Rect(400, 140, 80, 50), "打印"))
        {
            _singleList.LogList();
        }
    }
}
