using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SortUtils
{   
    //冒泡排序
    public static void BubSort(int[] arr)
    {
        TimeSystem.TickStart();
        int changeTimes = 0;
        int loopCount = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                loopCount++;
                if (arr[j] > arr[j + 1])
                {
                    arr[j] = arr[j] ^ arr[j + 1];
                    arr[j + 1] = arr[j] ^ arr[j + 1];
                    arr[j] = arr[j] ^ arr[j + 1];
                    changeTimes++;
                }
            }
        }
        TimeSystem.TickEnd();
        //LogArr(arr);
        Debug.LogError("changeTimes : "+changeTimes + " loopCount:"+loopCount);
    }

    //冒泡排序
    public static void BubSortV2(int[] arr)
    {
        TimeSystem.TickStart();
        int changeTimes = 0;
        bool chageFlag;
        int loopCount = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            chageFlag = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                loopCount++;
                if (arr[j] > arr[j + 1])
                {
                    arr[j] = arr[j] ^ arr[j + 1];
                    arr[j + 1] = arr[j] ^ arr[j + 1];
                    arr[j] = arr[j] ^ arr[j + 1];
                    changeTimes++;
                    chageFlag = true;
                }
            }
            if(!chageFlag)
            {
                break;
            }
        }
        TimeSystem.TickEnd();
        //LogArr(arr);
        Debug.LogError("changeTimes : " + changeTimes + " loopCount:" + loopCount);
    }

    //选择排序
    public static void SelSort(int[] arr)
    {
        TimeSystem.TickStart();
        int changeTimes = 0;
        int min = 0;
        int loopCount = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            //将第一个未排序的下标记录
            min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                loopCount++;
                //如果当前元素小于最小值,则将当前元素设为最小值
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            //如果min有修改过,则说明第一个未排序的数不是最小的,需要和最小的交换位置
            if(min != i)
            {
                arr[i] = arr[i] ^ arr[min];
                arr[min] = arr[i] ^ arr[min];
                arr[i] = arr[i] ^ arr[min];
                changeTimes++;
            }
        }
        TimeSystem.TickEnd();
        //LogArr(arr);
        Debug.LogError("changeTimes : " + changeTimes + " loopCount:" + loopCount);
    }

    //插入排序
    public static void InsSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {

        }
    }


    static void LogArr(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[ ");
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]);
            sb.Append(" ");
        }
        sb.Append("]");
        Debug.LogError(sb.ToString());
    }

    public static int[] GenerateRandomArr(int length)
    {
        int[] arr = new int[length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(1, 100);
        }
        //LogArr(arr);
        return arr;
    }

    public static int[] CopyArr(int[] arr)
    {
        int[] arrCopy = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arrCopy[i] = arr[i];
        }
        return arrCopy;
    }

}
