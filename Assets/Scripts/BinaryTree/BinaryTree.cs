using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> root;

        public BinaryTree(BinaryTreeNode<T> root)
        {
            this.root = root;
        }

        bool IsEmpty()
        {
            return root == null;
        }



        //public List<BinaryTreeNode<T>> treeNodes = new List<BinaryTreeNode<T>>();
        //leftChild = 2 * i + 1;
        //rightChild = 2 * i + 2;
        //parent = (i - 1) / 2
        //public BinaryTree(int[] nodes)
        //{
        //    for (int i = 0; i < nodes.Length; i++)
        //    {
        //        treeNodes.Add(new BinaryTreeNode<int>(nodes[i]));
        //    }
        //    head = treeNodes[0];

        //    //建立节点关联
        //    for (int i = 0; i < nodes.Length; i++)
        //    {
        //        int leftChildIndex = 2 * i + 1;
        //        int rightChildIndex = 2 * i + 2;
        //        treeNodes[i].LeftChild = leftChildIndex < nodes.Length ? treeNodes[leftChildIndex] : null;
        //        treeNodes[i].RightChild = rightChildIndex < nodes.Length ? treeNodes[rightChildIndex] : null;
        //    }
        //}

        //public BinaryTree(int rootVal = 0)
        //{
        //    head = new BinaryTreeNode<int>(rootVal);
        //}

        public void Traverse(BinaryTreeNode<T> node)
        {
            
            if(node.LeftChild != null)
            {
                Traverse(node.LeftChild);
            }
            Debug.LogError(node.Data);
            if (node.RightChild != null)
            {
                Traverse(node.RightChild);
            }

            if(node.LeftChild == null && node.RightChild == null)
            {
                Debug.LogError("this id a leaf node : " + node.Data);
            }
        }


        public void PreOrderTraverse(BinaryTreeNode<T> node)
        {
            if(node == null)
            {
                return;
            }

            node.Visit();
            PreOrderTraverse(node.LeftChild);
            PreOrderTraverse(node.RightChild);
        }

        public void InOrderTraverse(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraverse(node.LeftChild);
            node.Visit();
            InOrderTraverse(node.RightChild);
        }

        public void PostOrderTraverse(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PostOrderTraverse(node.LeftChild);
            PostOrderTraverse(node.RightChild);
            node.Visit();
        }

        public void LevelOrderTraverse(BinaryTreeNode<T> node)
        {
            Queue<BinaryTreeNode<T>> nodeQueue = new Queue<BinaryTreeNode<T>>();

            nodeQueue.Enqueue(node);

            while (nodeQueue.Count > 0)
            {
                BinaryTreeNode<T> temp = nodeQueue.Dequeue();
                temp.Visit();
                if (temp.LeftChild != null)
                {
                    nodeQueue.Enqueue(temp.LeftChild);
                }
                if (temp.RightChild != null)
                {
                    nodeQueue.Enqueue(temp.RightChild);
                }
            }
        }
    }


}
