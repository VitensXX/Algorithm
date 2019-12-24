using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RegularExpression
{
    public string input;
    public string pattern;

    public static void PreciseCompare()
    {
        string input = "abs";
        string pattern1 = "ab";
        string pattern2 = "abc";

        Debug.LogError(Regex.IsMatch(input, pattern1) + " " + Regex.IsMatch(input, pattern2));
    }

    //是否为电话号码判断
    public static bool IsValidPhoneNum(string input)
    {
        string pattern = "^[1]+[3,5]+\\d{9}$";// "1\\d{10}";

        return Regex.IsMatch(input, pattern);
    }


    public static void Compare()
    {
        //Debug.LogError(Regex.IsMatch("007", "00\\d"));//true
        //Debug.LogError(Regex.IsMatch("0078", "00\\d\\d"));//true
        Debug.LogError(Regex.IsMatch("1234", "\\d{1,5}"));//true 1~5个
        //Debug.LogError(Regex.IsMatch("1234", "\\d{3,}"));//true 至少3个  逗号后面不能有空格
        Debug.LogError(Regex.IsMatch("123456", "\\d{0,5}"));//true 至多5个
        Debug.LogError(Regex.IsMatch("test_123", "\\w{0,3}"));//true \w  word表示字符(字母数字下划线)


    }


}
