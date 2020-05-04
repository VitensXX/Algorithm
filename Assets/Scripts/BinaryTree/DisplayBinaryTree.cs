using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class DisplayBinaryTree : MonoBehaviour
    {
        //public Transform panel;

        //// Start is called before the first frame update
        //void Start()
        //{
        //    int[] test = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
        //    BinaryTree tree = new BinaryTree(test);
        //    tree.Traverse(tree.head);

        //    for (int i = 0; i < tree.treeNodes.Count; i++)
        //    {
        //        //TreeNodeCtrl.Show(panel, tree.treeNodes[i].Data);
        //    }
        //}

        private void Start()
        {
            BinaryTreeNode<char> B = new BinaryTreeNode<char>('B');
            BinaryTreeNode<char> D = new BinaryTreeNode<char>('D');
            BinaryTreeNode<char> C = new BinaryTreeNode<char>('C', B, D);
            BinaryTreeNode<char> A = new BinaryTreeNode<char>('A', null, C);
            BinaryTreeNode<char> F = new BinaryTreeNode<char>('F');
            BinaryTreeNode<char> G = new BinaryTreeNode<char>('G', null, F);
            BinaryTreeNode<char> root = new BinaryTreeNode<char>('E', A, G);
            BinaryTree<char> bt = new BinaryTree<char>(root);

            Debug.LogError("preOrderTraverse----------------");
            bt.PreOrderTraverse(bt.root);
            Debug.LogError("InOrderTraverse----------------");
            bt.InOrderTraverse(bt.root);
            Debug.LogError("PostOrderTraverse----------------");
            bt.PostOrderTraverse(bt.root);
            Debug.LogError("LevelOrderTraverse---------------");
            bt.LevelOrderTraverse(bt.root);
        }

    }
}
