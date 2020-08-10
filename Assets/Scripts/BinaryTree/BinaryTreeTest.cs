using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vitens.BinaryTree;

public class BinaryTreeTest : MonoBehaviour
{
    public bool Pre;
    public bool In;
    public bool Post;
    public bool Level;

    BinaryTree<string> bt;
    // Start is called before the first frame update
    void Start()
    {
        BinaryTreeNode<string> root = new BinaryTreeNode<string>("-");
        bt = new BinaryTree<string>(root);
        root.LeftChild = new BinaryTreeNode<string>("*");
        root.RightChild = new BinaryTreeNode<string>("c");
        root.LeftChild.LeftChild = new BinaryTreeNode<string>("a");
        root.LeftChild.RightChild = new BinaryTreeNode<string>("b");
        root.LeftChild.LeftChild.RightChild = new BinaryTreeNode<string>("?");
        root.LeftChild.LeftChild.RightChild.LeftChild = new BinaryTreeNode<string>("1");
        root.LeftChild.LeftChild.RightChild.RightChild = new BinaryTreeNode<string>("2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Pre)
        {
            Pre = false;
            bt.PreOrderTraverse(bt.root);
        }

        if (Input.GetKey(KeyCode.I))
        {
            bt.InOrderTraverseWithStack();
        }

        if (In)
        {
            In = false;
            bt.InOrderTraverse(bt.root);
        }

        if (Post)
        {
            Post = false;
            bt.PostOrderTraverse(bt.root);
        }

        if (Level)
        {
            Level = false;
            bt.LevelOrderTraverse(bt.root);
        }
    }
}
