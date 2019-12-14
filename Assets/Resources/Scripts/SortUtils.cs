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
                    Sweap(ref arr[j], ref arr[j + 1]);
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
                    Sweap(ref arr[j], ref arr[j + 1]);
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

    //选择排序 不稳定的
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
                Sweap(ref arr[i], ref arr[min]);
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
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if(arr[j] < arr[j - 1])
                {
                    Sweap(ref arr[j], ref arr[j - 1]);
                    LogArr(arr);
                }
                else
                {
                    Debug.LogError(arr[j-1]+" "+arr[j]+" break");
                    break;
                }
            }
        }
    }

    #region 归并排序

    //临时数组
    static int[] tempArr;
    public static void MergeSort(int[] arr)
    {
        tempArr = new int[arr.Length];

        Sort(arr, 0, arr.Length - 1);
    }

    static void Sort(int[] arr, int l, int r)
    {
        //递归退出条件是子数组的长度为0
        if(l == r)
            return;

        int m = (l + r) >> 1;
        Sort(arr, l, m);
        Sort(arr, m + 1, r);
        Merge(arr, l, m, r);
    }

    static void Merge(int[] arr, int l, int m, int r)
    {
        Debug.LogError(l+" "+m+" "+r);
        //当前临时数组的有效长度
        int tempArrLength = r - l + 1;
        int i = l;
        int lp = l;
        int rp = m + 1;

        //两部分中,小的先放入临时数组
        while(lp <= m && rp <= r)
        {
            tempArr[i++] = arr[lp] < arr[rp] ? arr[lp++] : arr[rp++];
        }
        LogArr(tempArr, "temp : ");

        //循环结束,说明其中一部分已经完全放入临时数组,然后将另一部分剩下的放入临时数组
        while (lp <= m)
        {
            tempArr[i++] = arr[lp++];
        }
        //LogArr(tempArr, "temp 2: ");

        while (rp <= r)
        {
            tempArr[i++] = arr[rp++];
        }
        //LogArr(tempArr, "temp 3: ");

        //将临时数组中的数据拷贝会原始数组
        for (int j = l; j < r + 1; j++)
        {
            arr[j] = tempArr[j];
        }

        LogArr(arr, "arr : ");
    }


    #endregion

    #region 快速排序

    public static void QuickSort(int[] arr)
    {

    }

    #endregion

    static void Sweap(ref int a, ref int b)
    {
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
    }

    public static void LogArr(int[] arr, string tag = "")
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[ ");
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]);
            sb.Append(" ");
        }
        sb.Append("]");
        Debug.LogError(tag + sb.ToString());
    }

    public static int[] GenerateRandomArr(int length)
    {
        int[] arr = new int[length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(1, 20);
        }
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
