using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueExp
{
    internal class MaxPQHeap<T>
    {
        private class Node
        {
            public PQNode<T> Data;
            public Node Left, Right, Parent;

            public Node(int priority, T value)
            {
                Data = new PQNode<T>(priority, value);
            }
        }

        private Node root;
        private int size;

        public void Enqueue(int priority, T value)
        {
            Node newNode = new Node(priority, value);
            size++;

            if (root == null)
            {
                root = newNode;
                return;
            }


            Node parent = GetNode(size / 2);
            newNode.Parent = parent;

            if (size % 2 == 0)
                parent.Left = newNode;
            else
                parent.Right = newNode;

            Swim(newNode);
        }

        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException("QUEUE EMPTY");

            T maxValue = root.Data.Value;

            if (size == 1)
            {
                root = null;
                size = 0;
                return maxValue;
            }

            Node last = GetNode(size);


            root.Data = last.Data;


            if (last.Parent.Left == last)
                last.Parent.Left = null;
            else
                last.Parent.Right = null;

            size--;
            Sink(root);

            return maxValue;
        }

        private void Swim(Node cur)
        {
            while (cur.Parent != null && cur.Data.Key > cur.Parent.Data.Key)
            {
                SwapData(cur, cur.Parent);
                cur = cur.Parent;
            }
        }

        private void Sink(Node cur)
        {
            while (true)
            {
                Node largest = cur;

                if (cur.Left != null && cur.Left.Data.Key > largest.Data.Key)
                    largest = cur.Left;

                if (cur.Right != null && cur.Right.Data.Key > largest.Data.Key)
                    largest = cur.Right;

                if (largest == cur)
                    break;

                SwapData(cur, largest);
                cur = largest;
            }
        }

        private void SwapData(Node a, Node b)
        {
            PQNode<T> temp = a.Data;
            a.Data = b.Data;
            b.Data = temp;
        }


        private Node GetNode(int index)
        {
            string bits = Convert.ToString(index, 2).Substring(1);
            Node cur = root;

            foreach (char bit in bits)
            {
                cur = (bit == '0') ? cur.Left : cur.Right;
            }

            return cur;
        }
    }
}
