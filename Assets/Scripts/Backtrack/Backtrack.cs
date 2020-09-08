using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backtrack : MonoBehaviour
{
    int err = 0;
    void Start()
    {
        //List<List<int>> result = new List<List<int>>();
        int[] arr = new int[] { 1, 2, 3 };
        List<int> track = new List<int>();
        BacktrackArray(arr, track);

        for (int i = 0; i < _resultArr.Count; i++)
        {
            string s = "";
            for (int j = 0; j < _resultArr[i].Count; j++)
            {
                s += _resultArr[i][j] + ",";
            }
            Debug.LogError(s);
        }
    }

    List<List<int>> _resultArr = new List<List<int>>();
    //全排列回溯
    void BacktrackArray(int[] arr, List<int> track)
    {
        //结束条件
        if(track.Count == arr.Length)
        {
            List<int> result = new List<int>();
            result.AddRange(track);
            _resultArr.Add(result);
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            //选择
            if (track.Contains(arr[i]))
            {
                continue;
            }
            track.Add(arr[i]);
            //回溯
            BacktrackArray(arr, track);
            //撤销
            track.RemoveAt(track.Count - 1);
        }
    }

    //TODO N皇后

}
