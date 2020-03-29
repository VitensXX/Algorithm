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
    }

    private string insertValuse = "0";
    private string GetAtIndex = "0";
    //private string textFieldString = "0";
    private void OnGUI()
    {
        insertValuse = GUI.TextField(new Rect(110, 40, 80, 50), insertValuse);
        if (GUI.Button(new Rect(20, 40, 80, 50), "头插"))
        {
            _singleList.InsertAtHead(insertValuse);
            //Debug.LogError(textFieldString);
        }

        GetAtIndex = GUI.TextField(new Rect(110, 140, 80, 50), GetAtIndex);
        if (GUI.Button(new Rect(20, 140, 80, 50), "获取"))
        {
            _singleList.GetAt(int.Parse(GetAtIndex));
        }


        if (GUI.Button(new Rect(20, 540, 80, 50), "打印"))
        {
            _singleList.DisplayList();
        }
    }
}
