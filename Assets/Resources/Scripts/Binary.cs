using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Binary : MonoBehaviour
{
    public int input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Test()
    {
        Debug.LogError(Int2Binary(input));
        BinaryCalcFormat(1, 2, 1 | 2, '|');
    }

    string Int2Binary(int number)
    {
        char[] binaryStr = new char[sizeof(int) * 8];
        for (int i = binaryStr.Length - 1; i >= 0; i--)
        {
            binaryStr[i] = (number & 1) == 1 ? '1' : '0';
            number = number >> 1;
        }

        return Array2String(binaryStr, true);
    }

    string Array2String(char[] arr, bool displayBinary)
    {
        if(arr == null || arr.Length == 0)
        {
            return "";
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]);
            if((i+1) % 8 == 0)
            {
                sb.Append(" ");
            }
        }

        return sb.ToString();
    }

    //格式化显示二进制计算
    void BinaryCalcFormat(int a, int b, int result, char oper)
    {
        StringBuilder formatSB = new StringBuilder();
        formatSB.Append("  ");
        formatSB.Append(Int2Binary(a));
        formatSB.Append('\n');
        formatSB.Append(oper);
        formatSB.Append(" ");
        formatSB.Append(Int2Binary(b));
        formatSB.Append("\n  ---------\n  ");
        formatSB.Append(Int2Binary(result));
        Debug.LogError(formatSB.ToString());
    }
    
}
