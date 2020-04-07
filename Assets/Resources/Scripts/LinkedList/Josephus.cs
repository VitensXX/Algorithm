using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 约瑟夫环
/// </summary>
public class Josephus : MonoBehaviour
{
    const int TOTAL = 10;
    const int INTERVAL = 5;

    private void Start()
    {
        Show();
        Josephus2();

        //MagicPoker();
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

    void Josephus2()
    {
        //从1到100编号 形成循环链表
        CircleLinkedList<int> people = new CircleLinkedList<int>();
        int count = 0;
        while(count < TOTAL)
        {
            people.Add(++count);
        }

        count = 0;

        int safeCount = 0;
        string s = "";
        int outCout = 0;
        //从第一个人开始计数，每INTERVAL次则淘汰这个节点并继续从0开始计数 直到全部淘汰
        while (!people.IsEmpty())
        //while (outCout < TOTAL)
        {
            if(safeCount++ > 10000)
            {
                Debug.LogError("Dead");
                return;
            }
            count++;
            people.Move();
            if(count == INTERVAL)
            {
                count = 0;
                outCout++;
                int outId = people.RemoveAtIterator();
                s += outId + " ,";
            }
        }

        Debug.LogError(s);
    }

    //魔术师发牌
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
        //扑克点数 从1开始 每次加一
        int pokerNumber = 1;

        int iterationCount = 0;
        while(putCount < poker.Length)
        {
            if(iterationCount++ > 1000)
            {
                Debug.LogError("Dead");
                return;
            }

            //未放牌
            if (!putList[index] && ++number == pokerNumber)
            {
                //指定位置放牌
                poker[index] = pokerNumber;
                //设置已放置标志
                putList[index] = true;
                //放牌计数加一
                putCount++;
                //牌的点数加一
                pokerNumber++;
                //
                number=0;
            }

            index = (index + 1) % poker.Length;
        }

        string s = "";
        for (int i = 0; i < poker.Length; i++)
        {
            s += poker[i] + ",";
        }
        Debug.LogError(s);

    }
}
