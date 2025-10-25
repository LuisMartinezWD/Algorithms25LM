using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListHanoiGame
{
    public class QueueOfDOOM<T> : LinksOfDoom.LinkList<T>
    {
        public void Enqueue(T item)
        {
            Append(item);
        }

        public T Dequeue()
        {
            if (IsEmpty()) return default;
            T value = Head.Value;
            RemoveAt(0);
            return value;
        }

        public T Peek()
        {
            return IsEmpty() ? default : Head.Value;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Size()
        {
            return base.Size();
        }




    }
}
