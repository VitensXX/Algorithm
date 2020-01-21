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

            //Debug.LogError( reverse(-123456789));
            //Debug.LogError( IntToRoman(3));
            //Debug.LogError( IntToRoman(4));
            //Debug.LogError( IntToRoman(9));
            //Debug.LogError( IntToRoman(58));
            //Debug.LogError( IntToRoman(1994));

            //Debug.LogError(RomanToIntV2("III"));
            //Debug.LogError(RomanToIntV2("IV"));
            //Debug.LogError(RomanToIntV2("IX"));
            //Debug.LogError(RomanToIntV2("LVIII"));
            //Debug.LogError(RomanToIntV2("MCMXCIV"));
            //string[] strs = new string[] { "flower", "flow", "flight", "dog", "racecar", "car"};
            //Debug.LogError(LongestCommonPrefixV2(strs));

            Debug.LogError(IsValid("([)]"));
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

    #region 9.判断整数是否为回文数

    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }

        int inverse = 0;
        int temp = x;

        while (temp > 0)
        {
            inverse = inverse * 10 + temp % 10;
            temp /= 10;
        }

        return x == inverse;
    }

    #endregion

    #region 12.整数转罗马数字

    string IntToRoman(int num)
    {
        //string[] romanSign = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        //int[] intVal = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

        string[] romanSign = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        int[] intVal = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

        //4 9 40 90 400 900
        //string[] specialRomanSign = new string[] { "IV", "IX", "XL", "XC", "CD", "CM"};
        //int[] specialIntVal = new int[] { 4, 9, 40, 90, 400, 900 };

        string romanStr = "";
        //int[] signCount = new int[romanSign.Length];
        for (int i = romanSign.Length - 1; i >= 0; i--)
        {
            int signCount = num / intVal[i];
            num %= intVal[i];

            while (signCount > 0)
            {
                romanStr += romanSign[i];
                signCount--;
            }
        }

        return romanStr;
    }

    #endregion

    #region 13.罗马数字转整数

    public int RomanToInt(string s)
    {
        string[] romanSign = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        int[] intVal = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

        int i = 0;
        int result = 0;
        while(i < s.Length - 1)
        {
            //尝试匹配两位
            string doubleSign = s[i].ToString() + s[++i].ToString();

            bool mathFlag = false;
            for (int j = 0; j < romanSign.Length; j++)
            {
                if(doubleSign == romanSign[j])
                {
                    result += intVal[j];
                    i++;//再向后移动一位
                    mathFlag = true;
                    break;
                }
            }

            //如果两位的没有匹配成功 匹配一位
            string singleSign = s[i - 1].ToString();
            if (!mathFlag)
            {
                for (int j = 0; j < romanSign.Length; j++)
                {
                    if (singleSign == romanSign[j])
                    {
                        result += intVal[j];
                        break;
                    }
                }
            }
        }

        if(i == s.Length - 1)
        {
            for (int j = 0; j < romanSign.Length; j++)
            {
                if (s[s.Length - 1].ToString() == romanSign[j])
                {
                    result += intVal[j];
                    break;
                }
            }
        }

        return result;
    }

    //1.前面的比后面的小 减去前面的
    //2.加上后面的
    //3.最后一个加上
    public int RomanToIntV2(string s)
    {
        int result = 0;
        int i = 0;
        while(i < s.Length - 1)
        {
            int curValue = GetValueByRoman(s.Substring(i, 1));
            int nextValue = GetValueByRoman(s.Substring(++i, 1));
            result += curValue >= nextValue ? curValue : -curValue;
        }

        result += GetValueByRoman(s.Substring(i, 1));

        return result;
    }

    int GetValueByRoman(string romanSign)
    {
        switch (romanSign)
        {
            case "I":return 1;
            case "V":return 5;
            case "X":return 10;
            case "L":return 50;
            case "C":return 100;
            case "D":return 500;
            case "M":return 1000;
            default: return 0;
        }
    }

    #endregion

    #region 14.最长公共前缀
    public string LongestCommonPrefix(string[] strs)
    {
        string commonPrefix = "";
        if(strs.Length == 0)
        {
            return "";
        }
        else if(strs.Length == 1)
        {
            return strs[0];
        }
        else
        {
            for (int i = 0; i < strs.Length - 1; i++)
            {
                commonPrefix = LongestCommonPrefixForTwoStr(strs[i], strs[i + 1]);
                if(commonPrefix == "")
                {
                    return "";
                }
                else
                {
                    strs[i + 1] = commonPrefix;
                }
            }
        }

        return commonPrefix;
    }

    //获取两个字符串的最长公共子串
    string LongestCommonPrefixForTwoStr(string a, string b)
    {
        string commonPrefix = "";
        int i = 0;
        while (i < a.Length && i < b.Length)
        {
            if (a.Substring(i, 1) == b.Substring(i, 1))
            {
                commonPrefix += a.Substring(i++, 1);
            }
            else
            {
                break;
            }
        }

        return commonPrefix;
    }

    public string LongestCommonPrefixV2(string[] strs)
    {
        if(strs.Length == 0)
        {
            return "";
        }
        else
        {
            string commonPrefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(commonPrefix) != 0)
                {
                    commonPrefix = commonPrefix.Substring(0, commonPrefix.Length - 1);
                }
                //如果已经没有公共子串了 则退出
                if (commonPrefix.Length == 0)
                {
                    break;
                }
            }

            return commonPrefix;
        }
    }

    #endregion

    #region 20.有效的括号
    public bool IsValid(string s)
    { 
        Stack<string> stack = new Stack<string>();

        for (int i = 0; i < s.Length; i++)
        {
            string temp = s.Substring(i, 1);
            switch (temp)
            {
                case "(":
                    stack.Push("(");
                    break;
                case "[":
                    stack.Push("[");
                    break;
                case "{":
                    stack.Push("{");
                    break;
                case ")":
                    if( !PeakAndPop(stack, "("))
                    {
                        return false;
                    }
                    break;
                case "]":
                    if (!PeakAndPop(stack, "["))
                    {
                        return false;
                    }
                    break;
                case "}":
                    if (!PeakAndPop(stack, "{"))
                    {
                        return false;
                    }
                    break;
            }
        }
        return stack.Count == 0;
    }

    bool PeakAndPop(Stack<string> stack, string s)
    {
        if (stack.Count == 0 || stack.Peek() != s)
        {
            return false;
        }
        else
        {
            stack.Pop();
            return true;
        }
    }


    public bool IsValidV2(string s)
    {
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
        {
            s = s.Replace("()", "");
            s = s.Replace("[]", "");
            s = s.Replace("{}", "");
        }

        return s.Length == 0;
    }
    #endregion

    #region 21.合并两个有序链表

    #endregion
}
