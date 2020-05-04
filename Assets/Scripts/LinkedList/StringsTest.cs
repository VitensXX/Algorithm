using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringsTest
{
    //Brute Force
    int BF(string S, string T)
    {
        int i = 0, j = 0;
        while(i<S.Length && j < T.Length)
        {
            if (S[i] == T[j])
            {
                i++;
                j++;
            }
            else
            {
                //i回到这一趟的初始位置加1
                i = i - j + 1;
                j = 0;
            }
        }
        if(j == T.Length)
        {
            return i - j;
        }
        else
        {
            return -1;
        }
    }
    //https://blog.csdn.net/rainchxy/article/details/78130155?depth_1-utm_source=distribute.pc_relevant_right.none-task-blog-OPENSEARCH-16&utm_source=distribute.pc_relevant_right.none-task-blog-OPENSEARCH-16

    int KMP(string S, string T)
    {
        return -1;
    }

}
