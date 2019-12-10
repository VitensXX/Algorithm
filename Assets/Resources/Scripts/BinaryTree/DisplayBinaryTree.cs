using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class DisplayBinaryTree : MonoBehaviour
    {
        public Transform panel;

        // Start is called before the first frame update
        void Start()
        {
            int[] test = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            BinaryTree tree = new BinaryTree(test);
            tree.Traverse(tree.head);

            for (int i = 0; i < tree.treeNodes.Count; i++)
            {
                //TreeNodeCtrl.Show(panel, tree.treeNodes[i].Data);
            }
        }

    }
}
