using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class BinaryTree
    {
        public BinaryTreeNode<int> head;

        public List<BinaryTreeNode<int>> treeNodes = new List<BinaryTreeNode<int>>();
        //leftChild = 2 * i + 1;
        //rightChild = 2 * i + 2;
        //parent = (i - 1) / 2
        public BinaryTree(int[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                treeNodes.Add(new BinaryTreeNode<int>(nodes[i]));
            }
            head = treeNodes[0];

            //建立节点关联
            for (int i = 0; i < nodes.Length; i++)
            {
                int leftChildIndex = 2 * i + 1;
                int rightChildIndex = 2 * i + 2;
                treeNodes[i].LeftChildNode = leftChildIndex < nodes.Length ? treeNodes[leftChildIndex] : null;
                treeNodes[i].RightChildNode = rightChildIndex < nodes.Length ? treeNodes[rightChildIndex] : null;
            }
        }

        public BinaryTree(int rootVal = 0)
        {
            head = new BinaryTreeNode<int>(rootVal);
        }

        public void Traverse(BinaryTreeNode<int> node)
        {
            
            if(node.LeftChildNode != null)
            {
                Traverse(node.LeftChildNode);
            }
            Debug.LogError(node.Data);
            if (node.RightChildNode != null)
            {
                Traverse(node.RightChildNode);
            }

            if(node.LeftChildNode == null && node.RightChildNode == null)
            {
                Debug.LogError("this id a leaf node : " + node.Data);
            }
        }

    }


}
