using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueExp
{
    internal class PQNode<T>
    {
        public int Key { get; }
        public T Value { get; }

        public PQNode(int key, T value)
        {
            Key = key;
            Value = value;
        }
    }

    internal class MaxPQArray<T>
    {
        private PQNode<T>[] tree;
        private int next;

        public MaxPQArray()
        {
            tree = new PQNode<T>[2];
            next = 1;
        }

        public void Enqueue(int prior, T E)
        {
            if (next >= tree.Length)
                Resize(tree.Length * 2);

            tree[next] = new PQNode<T>(prior, E);
            Swim(next);
            next++;
        }

        public T Dequeue()
        {
            if (next == 1)
                throw new InvalidOperationException("The Queue is empty!!!");

            PQNode<T> max = tree[1];

            next--;
            tree[1] = tree[next];
            tree[next] = null;

            Sink(1);


            if (next > 1 && next <= tree.Length / 4)
                Resize(tree.Length / 2);

            return max.Value;
        }

        private void Swim(int index)
        {
            while (index > 1 && tree[index].Key > tree[index / 2].Key)
            {
                Swap(index, index / 2);
                index /= 2;
            }
        }

        private void Sink(int index)
        {
            while (2 * index < next)
            {
                int left = 2 * index;
                int right = left + 1;
                int larger = left;

                if (right < next && tree[right].Key > tree[left].Key)
                    larger = right;

                if (tree[index].Key >= tree[larger].Key)
                    break;

                Swap(index, larger);
                index = larger;
            }
        }

        private void Swap(int a, int b)
        {
            PQNode<T> temp = tree[a];
            tree[a] = tree[b];
            tree[b] = temp;
        }

        private void Resize(int newSize)
        {
            PQNode<T>[] newArr = new PQNode<T>[newSize];
            for (int i = 1; i < next; i++)
                newArr[i] = tree[i];

            tree = newArr;
        }
    }
}
