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
        //Node head = CreateList(new int[] { 4, 6, 9, 11 }, true);
        //Node head2 = CreateList(new int[] { 1, 3, 6, 8, 12 }, true);

        ////Debug.LogError(GetLength(null)+" "+GetLength2(null));
        ////Debug.LogError(GetLength(head) +" "+GetLength2(head));

        ////Node n = Fanzhuan(head);
        ////Log(n);

        //Log(Merge(head, head2));

        //Debug.Log(GetMinHeight());

        Debug.Log(Mima("0202"));
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

    #region 滑动窗口
    string MinWindow(string s, string t)
    {
        Dictionary<char, int> window = new Dictionary<char, int>();
        Dictionary<char, int> need = new Dictionary<char, int>();
        for (int i = 0; i < t.Length; i++)
        {
            if (need.ContainsKey(t[i]))
            {
                need[t[i]]++;
            }
            else
            {
                need[t[i]] = 1;
            }
        }

        int left = 0;
        int right = 0;
        int valid = 0;
        int start = 0;
        int len = int.MaxValue;
        while(right < s.Length)
        {
            char c = s[right];
            right++;
            
            if (need.ContainsKey(c))
            {
                window[c] = window.ContainsKey(c) ? window[c] + 1 : 1;
                if(window[c] == need[c])
                {
                    valid++;
                }
            }

            //所有字符满足条件,窗口开始缩小,找更优解
            while(valid == t.Length)
            {
                //记录最小
                if(right - left < len)
                {
                    len = right - left;
                    start = left;
                }

                char r = s[left];
                left++;
                if (need.ContainsKey(r))
                {
                    if (window[r] == need[r])
                    {
                        valid--;
                    }
                    window[r]--;
                }
            }

            return len == int.MaxValue ? "" : s.Substring(start, len);
        }

        return "";
    }
    #endregion

    #region BFS 双向BFS优化

    #region 二叉树的最小高度
    /*
     * [3,9,20,null,null,15,7]
     */
    class TNode
    {
        public TNode L;
        public TNode R;
        public int val;

        public TNode(int v)
        {
            val = v;
        }
    }

    // 二叉树的最小高度
    public static int GetMinHeight()
    {
        //构造二叉树
        TNode node9 = new TNode(9);
        TNode node15 = new TNode(15);
        TNode node7 = new TNode(7);
        TNode node20 = new TNode(20);
        TNode root = new TNode(3);
        root.L = node9;
        root.R = node20;
        node20.L = node15;
        node20.R = node7;

        //开始
        Queue<TNode> q = new Queue<TNode>();
        q.Enqueue(root);
        int step = 1;
        while(q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                TNode cur = q.Dequeue();
                if(cur.L == null && cur.R == null)
                {
                    return step;
                }

                //找到当前节点的左右子节点并添加进queue
                if(cur.L != null)
                {
                    q.Enqueue(cur.L);
                }
                if(cur.R != null)
                {
                    q.Enqueue(cur.R);
                }
            }
            step++;
        }

        return step;
    }
    #endregion

    #region 密码锁

    //i的位置加1
    string PlusOne(string s, int i)
    {
        char[] arr = s.ToCharArray();
        if(arr[i] == '9')
        {
            arr[i] = '0';
        }
        else
        {
            arr[i]++;
        }

        return new string(arr);
    }
    //i的位置减1
    string MinusOne(string s, int i)
    {
        char[] arr = s.ToCharArray();
        if (arr[i] == '0')
        {
            arr[i] = '9';
        }
        else
        {
            arr[i]--;
        }

        return new string(arr);
    }

    int Mima(string target)
    {
        List<string> deadends = new List<string>() { "0201", "0101", "0102", "1212", "2002" };
        Queue<string> q = new Queue<string>();
        List<string> visited = new List<string>();
        q.Enqueue("0000");
        visited.Add("0000");
        int step = 0;
        while(q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                string cur = q.Dequeue();

                //遇到不能用的直接继续
                if (deadends.Contains(cur))
                {
                    continue;
                }
                //达成目标
                if(cur == target)
                {
                    return step;
                }
                else
                {
                    //将该位置后面的可能性(八个)加入
                    for (int j = 0; j < 4; j++)
                    {
                        string plus = PlusOne(cur, j);
                        string minus = MinusOne(cur, j);

                        //已经访问过的 不能走回头路
                        if (!visited.Contains(plus))
                        {
                            q.Enqueue(plus);
                            visited.Add(plus);
                        }
                        if (!visited.Contains(minus))
                        {
                            q.Enqueue(minus);
                            visited.Add(minus);
                        }
                    }
                }
            }
            step++;
        }

        return -1;
    }


    #endregion

    #endregion
}
