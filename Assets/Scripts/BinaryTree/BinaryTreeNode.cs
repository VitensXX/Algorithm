using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class BinaryTreeNode<T>
    {
        private T _data;
        private BinaryTreeNode<T> _leftChildNode;
        private BinaryTreeNode<T> _rightChildNode;

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public BinaryTreeNode<T> LeftChildNode
        {
            get { return _leftChildNode; }
            set { _leftChildNode = value; }
        }

        public BinaryTreeNode<T> RightChildNode
        {
            get { return _rightChildNode; }
            set { _rightChildNode = value; }
        }

        public BinaryTreeNode()
        {
            CreateTreeNode(default, null, null);
        }

        public BinaryTreeNode(T var)
        {
            CreateTreeNode(var, null, null);
        }

        public BinaryTreeNode(T var, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            CreateTreeNode(var, left, right);
        }

        //构造一个节点
        void CreateTreeNode(T val, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            _data = val;
            _leftChildNode = null;
            _rightChildNode = null;
        }
    }
}
