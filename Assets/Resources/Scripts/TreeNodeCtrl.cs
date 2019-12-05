using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeNodeCtrl : MonoBehaviour
{
    public Text dataText;

    public static void Show(Transform parent, int data)
    {
        GameObject go = Instantiate<GameObject>(Resources.Load("Tree/Prefabs/TreeNode") as GameObject);
        go.transform.parent = parent;
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<TreeNodeCtrl>().dataText.text = data.ToString();
    }
}
