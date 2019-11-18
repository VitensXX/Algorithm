using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class BinaryTree
    {
        public BinaryTreeNode<int> head;

        public BinaryTree(int[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                //构造一个节点
                BinaryTreeNode<int> temp = new BinaryTreeNode<int>(nodes[i]);

                //如果是第一个,作为根节点
                if (i == 0)
                {
                    head = temp;
                }



                
            }
        }


    }


}
