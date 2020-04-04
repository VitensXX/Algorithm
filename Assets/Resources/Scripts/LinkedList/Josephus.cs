using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 约瑟夫环
/// </summary>
public class Josephus : MonoBehaviour
{
    const int TOTAL = 100;
    const int INTERVAL = 5;

    private void Start()
    {
        Show();
    }

    //数组实现
    public static void Show()
    {
        bool[] outCircle = new bool[TOTAL];
        int outCount = 0;
        int index = 0;
        int number = 0;

        int iterationCount = 0;
        string s = "";
        //如果淘汰的人数比总人数少，则继续
        while(outCount < TOTAL)
        {
            if(iterationCount++> 10000)
            {
                Debug.LogError("Dead");
                break;
            }
            //如果没有淘汰 则计数+1,
            if (!outCircle[index])
            {
                //数到计数的那个 淘汰
                if(++number == INTERVAL)
                {
                    outCount++;
                    outCircle[index] = true;
                    number = 0;
                    //Debug.LogError(index+1);
                    s += (index + 1) + " ,";
                }
            }

            index = (index + 1) % TOTAL;
        }

        Debug.LogError(s + "\n iteration count:"+iterationCount);
    }

    void MagicPoker()
    {
        int[] poker = new int[13];
        for (int i = 0; i < poker.Length; i++)
        {
            poker[i] = i + 1;
        }

        bool[] putList = new bool[13];
        int putCount = 0;
        int number = 0;
        int index = 0;

        int iterationCount = 0;
        while(putCount < poker.Length)
        {
            if(iterationCount++ > 1000)
            {
                Debug.LogError("Dead");
                return;
            }

            //未放牌
            if (!putList[index] && ++index == number)
            {
                //指定位置放牌
                poker[index] = number;
                
                number++;
                index = 0;
            }

        }
    }
}
