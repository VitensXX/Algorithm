using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Binary : MonoBehaviour
{
    public int input;
    public string regularExpressionInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Test()
    {
        //Debug.LogError(Int2Binary(input));
        //Debug.LogError(SetCurBitToZero(127, 3));
        //BinaryUtils.BinaryCalcFormat(127, ~(1<<2), 127 & ~(1<<2), '&');
        //BinaryUtils.SwitchNumberAB(-7, 8);
        //int[] test = new int[] { 11,5,1,2,3,4,6,7,8,9,10};
        //int[] test = new int[] { 5,1,9,3,7,4,8,6,2};
        //Debug.LogError(BinaryUtils.FindNotRepeatOne(test));

        //int[] test = SortUtils.GenerateRandomArr(20, 1,2000);
        //SortUtils.BubSort(SortUtils.CopyArr(test));
        //SortUtils.BubSortV2(SortUtils.CopyArr(test));
        //SortUtils.BubSortV3(SortUtils.CopyArr(test));
        //SortUtils.SelSort(SortUtils.CopyArr(test));
        //SortUtils.LogArr(test, "Origin: ");
        //SortUtils.InsSort(test);

        //SortUtils.MergeSort(test);


        //SortUtils.RadixSort(test);

        Debug.LogError( RegularExpression.IsValidPhoneNum(regularExpressionInput));
    }


}
