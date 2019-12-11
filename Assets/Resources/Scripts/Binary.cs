using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Binary : MonoBehaviour
{
    public int input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Test()
    {
        //Debug.LogError(Int2Binary(input));
        //Debug.LogError(SetCurBitToZero(127, 3));
        //BinaryUtils.BinaryCalcFormat(127, ~(1<<2), 127 & ~(1<<2), '&');
        BinaryUtils.SwitchNumberAB(-7, 8);
    }


}
