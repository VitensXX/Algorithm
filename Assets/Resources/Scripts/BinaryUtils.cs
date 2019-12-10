using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// 二进制工具类
/// </summary>
public class BinaryUtils
{
    //将十进制转换成二进制
    public static string Int2Binary(int number)
    {
        char[] binaryStr = new char[sizeof(int) * 8];
        for (int i = binaryStr.Length - 1; i >= 0; i--)
        {
            binaryStr[i] = (number & 1) == 1 ? '1' : '0';
            number = number >> 1;
        }

        return Array2String(binaryStr, true);
    }

    //格式化显示二进制计算
    public static void BinaryCalcFormat(int a, int b, int result, char oper)
    {
        StringBuilder formatSB = new StringBuilder();
        formatSB.Append("   ");
        formatSB.Append(Int2Binary(a));
        formatSB.Append('\n');
        formatSB.Append(oper);
        formatSB.Append(" ");
        formatSB.Append(Int2Binary(b));
        formatSB.Append("\n  ---------\n  ");
        formatSB.Append(Int2Binary(result));
        Debug.LogError(formatSB.ToString());
    }

    //将数组拼接成字符串输出
    static string Array2String(char[] arr, bool displayBinary)
    {
        if (arr == null || arr.Length == 0)
        {
            return "";
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]);
            if ((i + 1) % 8 == 0)
            {
                sb.Append(" ");
            }
        }

        return sb.ToString();
    }
}
