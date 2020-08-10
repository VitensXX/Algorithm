using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class BinaryTree<T>
    {
        //是否为空
        public bool IsEmpty => root == null;
        public BinaryTreeNode<T> root;

        public BinaryTree(BinaryTreeNode<T> root)
        {
            this.root = root;
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

        //TODO 树的深度
        public int TreedDepth()
        {
            return 0;
        }

        //TODO 访问
        public T Visit(BinaryTreeNode<T> node)
        {
            return node.Visit();
        }

        //TODO 修改
        public bool Assign(BinaryTreeNode<T> node, T t)
        {
            return false;
        }

        //TODO 返回双亲结点
        public BinaryTreeNode<T> Parent(BinaryTreeNode<T> node)
        {
            return null;
        }

        //TODO 如果node非叶子节点，返回他的最左孩子
        public BinaryTreeNode<T> LeftChild(BinaryTreeNode<T> node)
        {
            return null;
        }

        //TODO 返回node的右兄弟
        public BinaryTreeNode<T> RightSibling(BinaryTreeNode<T> node)
        {
            return null;
        }

        //public bool InsertChild()

        //遍历
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

        //先序遍历 递归实现
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

        //中序遍历 递归实现
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

        //后序遍历 递归实现
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

        //层序遍历 递归实现
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

        //非递归实现的中序遍历
        public void InOrderTraverseWithStack()
        {
            //BinaryTreeNode<T> p = root;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(root);
            int err = 0;
            while(stack.Count > 0)
            {
                if (err++ > 20)
                {
                    Debug.LogError("Error");
                    break;
                }
                //栈顶元素
                BinaryTreeNode<T> top = stack.Peek();
                //有左孩子，继续入栈
                while(top.LeftChild != null)
                {
                    Debug.LogError("push lc");
                    stack.Push(top.LeftChild);
                }

                //出栈操作
                //没有左孩子，出栈
                if(stack.Count > 0)
                {
                    stack.Pop();
                    top.Visit();
                    //校验是否有右孩子
                    if(top.RightChild != null)
                    {
                        Debug.LogError("push rc");

                        stack.Push(top.RightChild);
                    }
                }
            }
        }
    }


}
