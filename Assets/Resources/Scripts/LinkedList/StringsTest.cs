using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringsTest
{
    bool BF(string input, string subStr)
    {
        int i = 0, j = 0;
        while(i<input.Length && j < subStr.Length)
        {
            if (input[i] == subStr[j])
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

        return j == subStr.Length;
    }
    //https://blog.csdn.net/rainchxy/article/details/78130155?depth_1-utm_source=distribute.pc_relevant_right.none-task-blog-OPENSEARCH-16&utm_source=distribute.pc_relevant_right.none-task-blog-OPENSEARCH-16
}
