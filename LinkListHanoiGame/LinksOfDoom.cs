using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListHanoiGame
{
    public class LinksOfDoom
    {
        public class LinkList<T>
        {
            protected class Node
            {
                public T Value { get; set; }
                public Node Next { get; set; }

                public Node(T value)
                {
                    Value = value;
                    Next = null;
                }
            }


            protected Node Head;
            protected int Count;

            public void Append(T data)
            {
                Node newNode = new Node(data);
                if (Head == null)
                {
                    Head = newNode;
                }
                else
                {
                    Node current = Head;
                    while (current.Next != null)
                        current = current.Next;
                    current.Next = newNode;
                }
                Count++;
            }

            public void Prepend(T data)
            {
                Node newNode = new Node(data)
                {
                    Next = Head
                };
                Head = newNode;
                Count++;
            }


            public T GetAt(int index)
            {
                if (index < 0 || index >= Count) return default;
                Node current = Head;
                for (int i = 0; i < index; i++)
                    current = current.Next;
                return current.Value;
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= Count) return;

                if (index == 0)
                {
                    Head = Head.Next;
                }
                else
                {
                    Node current = Head;
                    for (int i = 0; i < index - 1; i++)
                        current = current.Next;
                    current.Next = current.Next?.Next;
                }
                Count--;
            }

            public void Clear()
            {
                Head = null;
                Count = 0;
            }

            public int Size() => Count;

            public bool IsEmpty() => Count == 0;



        }
    }
}

