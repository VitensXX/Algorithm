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
        //string pattern = "^[1]+[3,5]+\\d{9}$";// "1\\d{10}";
        //string pattern =  "^[0-9]{11,11}$";
        string pattern = "^1\\d{10}$";

        return Regex.IsMatch(input, pattern);
    }


    public static void Compare()
    {
        //https://mp.weixin.qq.com/s/X7QnWwzgi6SZ0cRgJBE9eQ
        //https://www.runoob.com/csharp/csharp-regular-expressions.html
        //  . 匹配任意字符；* 匹配任意次，包括 0 次；+ 号匹配至少 1 次，? 匹配 0 次或 1 次。
        //  表示次数的匹配符后面加个 ? 表示尽可能少的匹配   比如  *?  匹配任意吃但次数尽可能少   非贪婪匹配
        //  \d 表示数值     \D	匹配不是十进制数的任意字符。
        //  \w  与任何单词字符匹配。       \W 与任何非单词字符匹配。
        //  ^ 和 $ 包围起来代表是整个字符串完全匹配,不是有满足的就为true
        //  [0-17-8]   =   [0178] 因为这个区间中间没有数值  字母也可以 比如 [0-9a-zA-Z]

        //Debug.LogError(Regex.IsMatch("007", "00\\d"));//true
        //Debug.LogError(Regex.IsMatch("0078", "00\\d\\d"));//true
        //Debug.LogError(Regex.IsMatch("1234", "\\d{1,5}"));//true 1~5个
        //Debug.LogError(Regex.IsMatch("1234", "\\d{4}"));//true 刚好4个
        //Debug.LogError(Regex.IsMatch("1234", "\\d{3,}"));//true 至少3个  逗号后面不能有空格
        //Debug.LogError(Regex.IsMatch("123456", "^\\d{0,5}$"));//false 至多5个  ^ 和 $ 包围起来代表是整个字符串完全匹配,不是有满足的就为true
        //Debug.LogError(Regex.IsMatch("test_123", "^\\w{0,5}\\d+$"));//true \w  word表示字符(字母数字下划线)
        //Debug.LogError(Regex.IsMatch("017", "[0-7]*"));//true
        //Debug.LogError(Regex.IsMatch("017", "^.{2,2}$"));//false  任意字符两个

        //Debug.LogError(Regex.IsMatch("017", "[0-7]+"));//true
        //Debug.LogError(Regex.IsMatch("017", "^[0-7]?$"));//false  0-7中的字符0个或一个
        //Debug.LogError(Regex.IsMatch("0", "^[0-17-8]?$"));//true  0-1 7-8中的字符0个或一个
        //Debug.LogError(Regex.IsMatch("", "^[0-17-8]?$"));//true  0-1 7-8中的字符0个或一个
        //Debug.LogError(Regex.IsMatch("7", "^[0178]?$"));//true  0178中的字符0个或一个
        //Debug.LogError(Regex.IsMatch("9", "^[0-17-8]?$"));//false  0-1 7-8中的字符0个或一个
        //Debug.LogError(Regex.IsMatch("c8", "^[0-9a-f]+$"));//true  0-9 a-f中的字符匹配至少 1 次

        Debug.LogError(Regex.IsMatch("017", "^[0|7|1]+$"));//true
        Debug.LogError(Regex.IsMatch("0", "\\d*"));//true
        Debug.LogError(Regex.IsMatch("012", "[^01]"));//true   非0,1  但是里面有2,匹配成功

        //MatchCollection mc = Regex.Matches("012", "[^01]");
        //foreach(Match m in mc)
        //{
        //    Debug.LogError(m.Value); //2
        //}


        //MatchCollection mc = Regex.Matches("3.999", "\\d\\.\\d{1,2}?"); // 3.99
        ////MatchCollection mc = Regex.Matches("193024", "\\d{3,5}");
        //foreach (Match m in mc)
        //{
        //    Debug.LogError(m.Value);
        //}

        //  \1反向匹配, 1表示第一组 () 在第一个匹配结果下再匹配同样的内容,适合找重复的字符
        MatchCollection mc = Regex.Matches("seeek 122355536666666666 _____trellis llama webbing dresser swagger", "(\\w)\\1{2,5}?");
        foreach (Match m in mc)
        {
            Debug.LogError(m.Value);
        }

        Debug.LogError(Regex.Replace("马aaa荣aaaaaaa现代aaa社会潘aaa金a莲", "a+", "A"));


    }


}
