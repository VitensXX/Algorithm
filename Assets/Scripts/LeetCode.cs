using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode : MonoBehaviour
{
    //给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 50), "test"))
        {
            Test();
        }
    }

    void Test()
    {
        int input = 120;
        bool negetive = input < 0;
        string inputStr;
        //如果有负号需要去掉
        if (negetive)
        {
            inputStr = input.ToString().TrimStart('-');
        }
        else
        {
            inputStr = input.ToString();
        }
        
        int result = 0;
        for (int i = inputStr.Length - 1; i >= 0; i--)
        {
            result += int.Parse(inputStr[i].ToString()) * (int)Mathf.Pow(10, i);
        }

        if (negetive)
        {
            result = -result;
        }

        Debug.LogError(result);
    }

}
