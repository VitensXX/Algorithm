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

        for (int i = 0; i < 5; i++)
        {
            _singleList.InsertAtHead(i.ToString());
        }
    }

    private string insertValuse = "";
    private string insertIndex = "";
    private string GetAtIndex = "";

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

        GetAtIndex = GUI.TextField(new Rect(110, 240, 80, 50), GetAtIndex);
        if (GUI.Button(new Rect(20, 240, 80, 50), "获取"))
        {
            _singleList.GetAt(int.Parse(GetAtIndex));
            GetAtIndex = "";
        }

        GetAtIndex = GUI.TextField(new Rect(110, 340, 80, 50), GetAtIndex);
        if (GUI.Button(new Rect(20, 340, 80, 50), "移除"))
        {
            _singleList.RemoveAt(int.Parse(GetAtIndex));
            GetAtIndex = "";
        }

        if (GUI.Button(new Rect(400, 140, 80, 50), "打印"))
        {
            _singleList.LogList();
        }
    }
}
