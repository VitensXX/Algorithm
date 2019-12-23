using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RegularExpression
{
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
        string pattern = "1\\d{10}";

        return Regex.IsMatch(input, pattern);
    }

}
