using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikedListTest : MonoBehaviour
{
    SingleLinkedList<string> _singleList;

    private void Start()
    {
        _singleList = new SingleLinkedList<string>();
        for (int i = 0; i < 5; i++)
        {
            _singleList.Insert(0, i.ToString());
        }
    }

    private string insertValue = "";
    private string indexValue = "";

    private void OnGUI()
    {
        insertValue = GUI.TextField(new Rect(110, 40, 80, 50), insertValue);
        //if (GUI.Button(new Rect(20, 40, 80, 50), "头插"))
        //{
        //    _singleList.InsertAtHead(insertValue);
        //    insertValue = "";
        //}

        indexValue = GUI.TextField(new Rect(110, 140, 80, 50), indexValue);
        if (GUI.Button(new Rect(20, 140, 80, 50), "指定插入"))
        {
            _singleList.Insert(int.Parse(indexValue), insertValue);
            indexValue = "";
        }

        if (GUI.Button(new Rect(20, 240, 80, 50), "获取"))
        {
            string s = _singleList[int.Parse(indexValue)];
            Debug.LogError(s);
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
            _singleList.Delete(insertValue);
            indexValue = "";
        }

        if (GUI.Button(new Rect(110, 440, 80, 50), "尾插"))
        {
            _singleList.Add(insertValue);
            indexValue = "";
        }

        //if (GUI.Button(new Rect(110, 340, 80, 50), "修改元素"))
        //{
        //    _singleList.Modify(insertValue, indexValue);
        //    indexValue = "";
        //}

        //if (GUI.Button(new Rect(200, 440, 80, 50), "修改"))
        //{
        //    _singleList.Modify(int.Parse(indexValue) , insertValue);
        //    indexValue = "";
        //}

        if (GUI.Button(new Rect(400, 140, 80, 50), "打印"))
        {
            _singleList.LogList();
        }
    }
}
