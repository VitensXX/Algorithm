using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTest : MonoBehaviour
{
    private void Start()
    {
        //ChangeNum(1348, 8);
        //ChangeNum(255, 2);
        InitHanoi(3);
    }

    //数制转换
    void ChangeNum(int input, int rule)
    {
        MyStack<int> stack = new MyStack<int>();
        while(input > 0)
        {
            stack.Push(input % rule);
            input /= rule;
        }

        string s = "";
        while(stack.Count > 0)
        {
            s += stack.Pop();
        }

        Debug.LogError(s);
    }

    #region hanoi

    MyStack<int> _a = new MyStack<int>();
    MyStack<int> _b = new MyStack<int>();
    MyStack<int> _c = new MyStack<int>();

    void InitHanoi(int n)
    {
        
        for (int i = n; i > 0; i--)
        {
            _a.Push(i);
        }
        PrintHanoi();
        Hanoi(n, _a, _b, _c);
    }


    void Hanoi(int n, MyStack<int> a, MyStack<int> b, MyStack<int> c)
    {
        if(n == 1)
        {
            HanoiMove(1, a, c);
        }
        else
        {
            Hanoi(n - 1, a, c, b);
            HanoiMove(n, a, c);
            Hanoi(n - 1, b, a, c);
        }
    }

    //将n 从 a->b
    void HanoiMove(int n, MyStack<int> a, MyStack<int> b)
    {
        b.Push(a.Pop());
        PrintHanoi();
    }

    void PrintHanoi()
    {
        Debug.LogError("-------------------");
        _a.LogStack();
        _b.LogStack();
        _c.LogStack();
    }

    #endregion

}
