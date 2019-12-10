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
        //Debug.LogError(Int2Binary(input));
        Debug.LogError(SetCurBitToZero(127, 3));
        BinaryUtils.BinaryCalcFormat(127, ~(1<<2), 127 & ~(1<<2), '&');
    }

    //是否为偶数 (even number)   
    public bool IsEven(int number)
    {
        return (number & 1) == 0;//等价 number % 2 == 0
    }

    //判断二进制的第n位为 1 或 0
    public bool IsOneInCurBit(int number, int bit)
    {
        return (number & (1 << bit - 1)) != 0;
    }

    //将二进制的第 n 位设置为 1
    public int SetCurBitToOne(int number, int bit)
    {
        return number | 1 << bit - 1;
    }

    //将二进制的第 n 位设置为 0
    public int SetCurBitToZero(int number, int bit)
    {
        return number & ~(1 << bit - 1);
    }


}
