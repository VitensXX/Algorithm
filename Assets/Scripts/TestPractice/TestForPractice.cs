using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForPractice : MonoBehaviour
{
    class Node
    {
        public int s;
        public Node next;

        public Node(int val)
        {
            s = val;
        }
    }

    private void Start()
    {
        Node head = CreateList(new int[] { 4, 6, 9, 11 }, true);
        Node head2 = CreateList(new int[] { 1, 3, 6, 8, 12 }, true);

        //Debug.LogError(GetLength(null)+" "+GetLength2(null));
        //Debug.LogError(GetLength(head) +" "+GetLength2(head));

        //Node n = Fanzhuan(head);
        //Log(n);

        Log(Merge(head, head2));
    }

    Node CreateList(int[] arr, bool log = false)
    {
        if (arr.Length == 0) return null;

        Node head = new Node(arr[0]);
        Node p = head;

        for (int i = 1; i < arr.Length; i++)
        {
            Node n = new Node(arr[i]);
            p.next = n;
            p = n;
        }

        if(log)
        {
            Log(head);
        }

        return head;
    }

    void Log(Node n)
    {
        Node p = n;
        string str = "list:";

        int dead = 0;
        while (p != null)
        {
            if(dead++ > 100)
            {
                Debug.LogError("dead");
                break;
            }
            str += p.s + ",";
            p = p.next;
        }

        Debug.LogError(str);
    }

    //遍历求链表的长度
    int GetLength(Node list)
    {
        Node p = list;
        int len = 0;
        
        while(p != null)
        {
            len++;
            p = p.next;
        }

        return len;
    }

    //递归求链表的长度
    int GetLength2(Node n)
    {
        if (n == null) return 0;
        return GetLength2(n.next) + 1;
    }

    //TODO 递归翻转
    Node Fanzhuan(Node n)
    {
        Node cur = n;
        Node pre = null;
        int dead = 0;
        while (cur != null)
        {
            if(dead++ > 100)
            {
                Debug.LogError("Dead");
                break;
            }

            Node next = cur.next;
            cur.next = pre;
            pre = cur;
            cur = next;
        }

        return pre;
    }

    //TODO 递归实现
    Node Merge(Node a, Node b)
    {
        if(a == null || b == null)
        {
            return a == null ? b : a;
        }

        Node head = new Node(0);
        Node p = head;

        Node pa = a;
        Node pb = b;
        while(pa != null && pb != null)
        {
            if (pa.s < pb.s)
            {
                p.next = pa;
                pa = pa.next;
                p = p.next;
            }
            else
            {
                p.next = pb;
                pb = pb.next;
                p = p.next;
            }
        }
        
        if(pa == null)
        {
            p.next = pb;
        }
        else
        {
            p.next = pa;
        }

        return head.next;
    }
}
