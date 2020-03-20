using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// 二进制工具类
/// </summary>
public class BinaryUtils
{
    //是否为偶数 (even number)   
    public static bool IsEven(int number)
    {
        return (number & 1) == 0;//等价 number % 2 == 0
    }

    //判断二进制的第n位为 1 或 0
    public static bool IsOneInCurBit(int number, int bit)
    {
        return (number & (1 << bit - 1)) != 0;
    }

    //将二进制的第 n 位设置为 1
    public static int SetCurBitToOne(int number, int bit)
    {
        return number | 1 << bit - 1;
    }

    //将二进制的第 n 位设置为 0
    public static int SetCurBitToZero(int number, int bit)
    {
        return number & ~(1 << bit - 1);
    }

    //交换两个数的值 
    public static void SwitchNumberAB(int a, int b)
    {
        // a ^ 0 = a，a ^ a = 0
        Debug.LogError(a + " " + b);
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
        Debug.LogError(a + " " + b);
    }

    //找出不重复的一个数(只有一个数不重复,且重复的数最多只有一次重复)
    public static int FindNotRepeatOne(int[] arr)
    {
        int x = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            x ^= arr[i];
        }

        return x;
    }

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

    //判断一个正整数是否为2的倍数
    public static bool IsPowerOfTwo(int n)
    {
        return (n & (n - 1)) == 0;
    }

    public static int NextPowerOfTwo(int n)
    {
        //左移一位，并把除了最左边的那个1以外的其他位全设为0
        //n = n << 1;
        //可是问题来了，这个想法从计算机的角度来看好像不怎么好实现（本人暂时也没有想到）
        //反过来想，那就想办法从左边第一个1开始后面的所有位都变为1，然后加1，就全部进位操作，只剩下最高位是1

        //一个int型 4个字节， 32位，如果是个比较小的整数，比如11 （1011），
        n--; //1010   减一是为了保证输入的已经是2的n次方的数输出也是自己本身，否则就得到2^(n+1)
        n |= n >> 1; //  1010 | 101   =》  1111  //已经达到目的，后面的操作都是与一串0做|，但是为了保证32位能够充足的操作完所以需要接下来的重复性操作
        n |= n >> 2;
        n |= n >> 4;
        n |= n >> 8;
        n |= n >> 16;
        n++;

        return n;
    }


    public static int PrevPowerOfTwo(int n)
    {
        n = n >> 1;
        n |= n >> 1; 
        n |= n >> 2;
        n |= n >> 4;
        n |= n >> 8;
        n |= n >> 16;
        n++;

        return n;
    }

    public static int ClosestPowerOfTwo(int n)
    {
        //有了上面的基础，直接获取到前后两个值，然后和当前输入值做差，就能获取到最接近的一个，但是这个比较不是二进制操作，不符合这个主题，暂时不考虑
        //

        return 0;
    }

    //判断有多少个1

}
