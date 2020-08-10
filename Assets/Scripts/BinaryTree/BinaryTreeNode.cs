using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vitens.BinaryTree
{
    public class BinaryTreeNode<T>
    {
        private T _data;
        private BinaryTreeNode<T> _leftChild;
        private BinaryTreeNode<T> _rightChild;

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public BinaryTreeNode<T> LeftChild
        {
            get { return _leftChild; }
            set { _leftChild = value; }
        }

        public BinaryTreeNode<T> RightChild
        {
            get { return _rightChild; }
            set { _rightChild = value; }
        }

        public BinaryTreeNode()
        {
            CreateTreeNode(default(T), null, null);
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
            _leftChild = left;
            _rightChild = right;
        }

        public T Visit()
        {
            Debug.Log(_data.ToString());
            return _data;
        }

        public void Assign(T val)
        {
            _data = val;
        }
    }
}
