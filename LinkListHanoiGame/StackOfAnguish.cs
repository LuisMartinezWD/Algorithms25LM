using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListHanoiGame
{
    public class StackOfAnguish<T> : LinksOfDoom.LinkList<T>
    {

        public void Push(T item)
        {
            Prepend(item);
        }

        public T Pop()
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
