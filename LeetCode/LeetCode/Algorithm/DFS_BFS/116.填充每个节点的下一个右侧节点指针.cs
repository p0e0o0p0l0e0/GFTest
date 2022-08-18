namespace _116 // 116. 填充每个节点的下一个右侧节点指针
{// 二叉树
    using System;
    using System.Collections.Generic;

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node()
        { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class Solution
    {
        // BFS 92ms 42.7MB
        public Node Connect(Node root)
        {
            if (root != null)
            {
                int i = 0, count = 0;
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    Node temp = queue.Dequeue();
                    count++;
                    if (count == Math.Pow(2, i))
                    {
                        temp.next = null;
                        count = 0;
                        i++;
                    }
                    else
                    {
                        temp.next = queue.Peek();
                    }
                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                        queue.Enqueue(temp.right);
                    }
                }
            }
            return root;
        }

        // DFS 88ms 42.3MB
        public Node Connect1(Node root)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    root.left.next = root.right;
                    if (root.next != null)
                    {
                        root.right.next = root.next.left;
                    }
                    root.left = Connect1(root.left);
                    root.right = Connect1(root.right);
                }
            }
            return root;
        }
    }
}