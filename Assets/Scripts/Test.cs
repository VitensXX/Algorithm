using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string input;
    public string pattern;

    public void test()
    {
        //RegularExpression.PreciseCompare();

        RegularExpression.Compare();
        //Debug.LogError(input  + " "+pattern);
        //Debug.LogError("cur "+System.Text.RegularExpressions.Regex.IsMatch(input, pattern));
        //Debug.LogError("phonenum "+RegularExpression.IsValidPhoneNum("12345678911"));
    }
}
