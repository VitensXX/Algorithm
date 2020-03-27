using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 递归
/// </summary>
public class Recursion : MonoBehaviour
{
    private void Start()
    {
        //Debug.LogError(Fibonacci(8));
        //Debug.LogError(Fibonacci2(8));
        //Debug.LogError(Fibonacci3(8));
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
        Debug.LogError(BinarySearch(arr, 3, 0, 5));
    }

    public int Factorial(int n)
    {
        if(n == 1 || n == 0)
        {
            return 1;
        }
        else
        {
            return n * Factorial(n - 1);
        }
    }

    #region Fibonacci
    //递归实现Fibonacci
    public int Fibonacci(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        else
        {
            int v = Fibonacci(n - 1) + Fibonacci(n - 2);
            return v;
        }
    }

    //迭代实现(依赖一个数组)
    public int Fibonacci2(int n)
    {
        int[] arr = new int[n +1];
        for (int i = 1; i < n + 1; i++)
        {
            if (i == 1 || i == 2)
            {
                arr[i] = 1;
            }
            else
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
        }

        return arr[n];
    }

    //迭代实现V2
    public int Fibonacci3(int n)
    {
        if(n < 3)
        {
            return 1;
        }
        else
        {
            int prev1 = 1;//前一个
            int prev2 = 1;//前两个
            int temp;

            for (int i = 3; i < n; i++)
            {
                temp = prev2 + prev1;
                prev2 = prev1;
                prev1 = temp;
            }

            return prev2 + prev1;
        }
    }
    #endregion

    #region 二分查找的迭代和递归实现 
    //斐波那契查找算法 https://www.jianshu.com/p/cddfbdbc53c7

    int BinarySearch(int[] arr, int target, int low, int high)
    {
        if(high < low)
        {
            return -1;
        }
        else
        {
            int mid = (high + low) >> 2;
            
            //目标在左侧
            if(target < arr[mid])
            {
                return BinarySearch(arr, target, low, mid - 1);
            }
            //目标在右侧
            else if(target > arr[mid])
            {
                return BinarySearch(arr, target, mid + 1, high);
            }
            else
            {
                return mid;
            }
        }
    }

    #endregion
}
