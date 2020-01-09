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
            //ZTransform();
            //ZTransform2();
            //IntReverse();

            Debug.LogError( reverse(-123456789));
        }
    }

    

    #region 6.Z字变换
    //执行用时 :152 ms, 在所有 C# 提交中击败了39.83%的用户
    //内存消耗 :43 MB, 在所有 C# 提交中击败了5.68%的用户
    void ZTransform()
    {
        string input = "123456789";
        int numRows = 3;
        char[] result = new char[input.Length];
        char[,] temp = new char[numRows, input.Length + 1];
        int[] count = new int[numRows];//辅助记录每个数值中有效的长度
        int flag = 1;
        int curRow = 0;

        int p = 0;
        //遍历一次记录到二维数组中
        while(p < input.Length)
        {
            count[curRow]++;

            temp[curRow, count[curRow] - 1] = input[p++];

            curRow += flag;
            if (curRow == 0 || curRow == numRows - 1)
            {
                flag = -flag;
            }
        }

        p = 0;
        string s = "";
        //从二维数组中取出数据
        for (int i = 0; i < numRows; i++)
        {
            int j = 0;
            while(j < count[i])
            {
                //result[p++] = temp[i, j++];
                s += temp[i, j++];
            }
        }

        Debug.LogError(s);
    }

    //执行用时 :104  ms, 在所有 C# 提交中击败了96.56%的用户
    //内存消耗 :25.5 MB, 在所有 C# 提交中击败了15.91%的用户
    void ZTransform2()
    {
        string s = "123456789";
        int numRows = 3;
        System.Text.StringBuilder result = new System.Text.StringBuilder();

        int subLength = (numRows - 1) << 1;

        int p;
        for (int i = 0; i < numRows; i++)
        {
            p = i;
            //第一次只取每个分组的第一个元素
            if(i == 0)
            {
                while(p < s.Length)
                {
                    result.Append(s[p]);
                    p += subLength;
                }
            }
            //每个分组中取剩下的第一个和最后一个
            else
            {
                while (p < s.Length)
                {
                    result.Append(s[p]);
                    int p2 = subLength * (p / subLength + 1) - i;

                    if(p2 < p)
                    {
                        Debug.LogError("break");
                        break;
                    }
                    else if(p2 > p && p2 < s.Length)
                    {
                        result.Append(s[p2]);
                    }

                    p += subLength;
                }
            }
        }

        Debug.LogError(result.ToString());
    }

    //class Solution
    //{
    //    public string convert(string s, int numRows)
    //    {
    //        vector<string> temp(numRows);
    //        string res;
    //        if (s.empty() || numRows < 1) return res;
    //        if (numRows == 1) return s;
    //        for (int i = 0; i < s.size(); i++)
    //        {
    //            int ans = i / (numRows - 1);
    //            int cur = i % (numRows - 1);
    //            if (ans % 2 == 0)
    //            {  //结果为偶数或0
    //                temp[cur].push_back(s[i]); //按余数正序保存
    //            }
    //            if (ans % 2 != 0)
    //            {  //结果为奇数
    //                temp[numRows - cur - 1].push_back(s[i]); //按余数倒序保存
    //            }
    //        }
    //        for (int i = 0; i < temp.size(); i++)
    //        {
    //            res += temp[i];
    //        }
    //        return res;
    //    }
    //};

    #endregion

    #region 7.整数翻转

    //假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−2^31,  2^31 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。
    //执行用时 :36 ms, 在所有 C# 提交中击败了99.91%的用户
    //内存消耗 :14.2 MB, 在所有 C# 提交中击败了6.99%的用户
    void IntReverse()
    {
        int input = 1534236469;
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

        double result = 0;
        for (int i = inputStr.Length - 1; i >= 0; i--)
        {
            double cur = int.Parse(inputStr[i].ToString()) * Pow(10, i);
            result += cur;

            if (result > Pow(2, 31) - 1)
            {

                break;
            }

        }

        if (negetive)
        {
            result = -result;
        }

        Debug.LogError(input);
        Debug.LogError(result);
    }

    double Pow(int radix, int count)
    {
        //0次方为1
        if (count == 0)
        {
            return 1;
        }
        double result = radix;

        for (int i = 1; i < count; i++)
        {
            result *= radix;
        }
        return result;
    }

    public int reverse(int x)
    {
        int ans = 0;
        while (x != 0)
        {
            if ((ans * 10) / 10 != ans)
            {
                ans = 0;
                break;
            }
            ans = ans * 10 + x % 10;
            x = x / 10;
        }
        return ans;
    }

    #endregion
}
