using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SortUtils
{
    #region 冒泡排序 稳定的排序
    //冒泡排序1
    public static void BubSort(int[] arr)
    {
        TimeSystem.TickStart();
        int sweapCount = 0;
        int compareCount = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                compareCount++;
                if (arr[j] > arr[j + 1])
                {
                    Sweap(arr, j, j + 1);
                    sweapCount++;
                }
            }
        }
        TimeSystem.TickEnd();
        LogArr(arr);
        Debug.LogError(compareCount + " " + sweapCount);
    }

    //冒泡排序2
    public static void BubSortV2(int[] arr)
    {
        TimeSystem.TickStart();
        int sweapCount = 0;
        bool chageFlag;
        int compareCount = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            chageFlag = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                compareCount++;
                if (arr[j] > arr[j + 1])
                {
                    Sweap(arr, j, j + 1);
                    sweapCount++;
                    chageFlag = true;
                }
            }
            if(!chageFlag)
            {
                break;
            }
        }
        TimeSystem.TickEnd();
        LogArr(arr);
        Debug.LogError(compareCount + " " + sweapCount);
    }

    //冒泡排序3
    public static void BubSortV3(int[] arr)
    {
        TimeSystem.TickStart();
        int sweapCount = 0;
        int compareCount = 0;
        int sweapIndex = 0;
        bool chageFlag;
        int len = arr.Length - 1;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            chageFlag = false;
            for (int j = 0; j < len; j++)
            {
                compareCount++;
                if (arr[j] > arr[j + 1])
                {
                    Sweap(arr, j, j + 1);
                    sweapCount++;
                    sweapIndex = j;
                    chageFlag = true;
                }
            }
            len = sweapIndex;

            if (!chageFlag)
            {
                break;
            }
        }
        TimeSystem.TickEnd();
        LogArr(arr);
        Debug.LogError(compareCount + " "+ sweapCount);
    }

    #endregion

    #region 选择排序 不稳定的
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
                Sweap(arr, i, min);
                changeTimes++;
            }
        }
        TimeSystem.TickEnd();
        //LogArr(arr);
        Debug.LogError("changeTimes : " + changeTimes + " loopCount:" + loopCount);
    }

    #endregion

    #region 插入排序
    //插入排序
    public static void InsSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if(arr[j] < arr[j - 1])
                {
                    Sweap(arr, j, j - 1);
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
    #endregion

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
    //普通排序
    public static void QuickSort(int[] arr)
    {
        quickSort(arr, 0, arr.Length - 1);

        LogArr(arr);
    }
    static void quickSort(int[] arr, int l, int r)
    {
        if (l >= r)
        {
            return;
        }
        int pivot = Partition(arr, l, r);
        quickSort(arr, l, pivot - 1);
        quickSort(arr, pivot + 1, r);
    }

    static int Partition(int[] arr, int l, int r)
    {
        int pivot = arr[l];
        int lp = l;
        bool hasLp = false;
        for (int i = l + 1; i < r + 1; i++)
        {
            if (arr[i] > pivot && !hasLp)
            {
                hasLp = true;
                lp = i;
            }
            else if (arr[i] < pivot && i > lp && hasLp)
            {
                Sweap(arr, i, lp);
                lp++;
            }
        }
        //
        if (hasLp)
        {
            Sweap(arr, l, lp - 1);
            return lp - 1;
        }
        else
        {
            Sweap(arr, l, r);
            return r;
        }
    }

    //随机普通排序

    //双路法

    //三路法

    #endregion

    #region 计数排序 Count Sort 非比较排序
    
    public static void CountSort(int[] arr)
    {
        LogArr(arr,"origin ");
        int i = 0;

        //找到最大最小值
        int min = arr[0];
        int max = arr[0];
        while (i < arr.Length)
        {
            if(arr[i] < min)
            {
                min = arr[i];
            }
            else if(arr[i] > max)
            {
                max = arr[i];
            }
            i++;
        }
        i = 0;

        int j = 0;
        int[] tempArr = new int[max - min + 1];
        //开始计数
        while(i < arr.Length)
        {
            tempArr[arr[i++] - min]++;
        }
        i = 0;

        //依次取出数据
        while(j < tempArr.Length)
        {
            if(tempArr[j] > 0)
            {
                arr[i++] = j + min;
                tempArr[j]--;
            }
            else
            {
                j++;
            }
        }

        LogArr(arr);
    }

    #endregion

    #region 基数排序 Radix Sort

    public static void RadixSort(int[] arr)
    {
        LogArr(arr,"origin ");
        int[,] bucket = new int[10, arr.Length + 1];

        //找到最长位数(代表需要排序的次数)
        int length = GetLoopCount(arr);
        int i = 0;

        while(length > 0)
        {
            Debug.LogError("~~~~ "+length);
            //将数据按当前基数填入到对应的桶中
            while(i < arr.Length)
            {
                int radix = GetRadixNum(arr[i], length);
                bucket[radix,0]++;
                bucket[radix, bucket[radix, 0]] = arr[i++];
            }
            i = 0;

            //从桶中挨着取出数据
            while(i < arr.Length)
            {
                for (int j = 0; j < 10; j++)
                {
                    int k = 0;
                    while (k < bucket[j, 0])
                    {
                        arr[i++] = bucket[j, k++];
                    }
                    //取完一个桶的数据后,将个数标识置0
                    bucket[j, 0] = 0;
                }
                ////int j = 0;
                //while(j < bucket.Length)
                //{

                //    j++;
                //}
                if(tick++ > 10000)
                {
                    Debug.LogError("!!!!!!!");
                    break;
                }
            }
            i = 0;

            length--;
        }

        LogArr(arr, "finish ");
    }

    static int GetLoopCount(int[] arr)
    {
        if(arr.Length == 0)
        {
            return 0;
        }

        int loopCount = 0;
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        while (max > 0)
        {
            max /= 10;
            loopCount++;
        }

        return loopCount;
    }

    static int tick = 0;

    static int GetRadixNum(int value, int radix)
    {
        int returnValue = value / (int)Mathf.Pow(10, radix - 1) % 10;
        //Debug.LogError(value + " " + radix + " " + returnValue);

        return returnValue;
    }

    #endregion

    #region 桶排序

    #endregion

    #region utils fun
    static void Sweap(int[] arr, int i, int j)
    {
        //同一个位子换结果都为0
        if(i == j)
        {
            return;
        }

        arr[i] = arr[i] ^ arr[j];
        arr[j] = arr[i] ^ arr[j];
        arr[i] = arr[i] ^ arr[j];
    }

    public static string LogArr(int[] arr, string tag = "", bool log = true)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[ ");
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]);
            sb.Append(" ");
        }
        sb.Append("]");
        string arrStr = sb.ToString();
        if (log)
        {
            Debug.LogError(tag + arrStr);
        }
        return arrStr;
    }

    public static void LogArr2(int[,] arr)
    {
        StringBuilder sb = new StringBuilder();
        int i = 0;
        //while(i < arr.GetLength(0))
        //{
        //    sb.Append(LogArr(arr.))
        //}
    }

    public static int[] GenerateRandomArr(int length, int min = 1, int max = 10)
    {
        int[] arr = new int[length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(min, max);
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

    #endregion
}
