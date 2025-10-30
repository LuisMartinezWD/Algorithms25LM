using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class QueueStorage
    {
        private Queue<string> queue;

        public QueueStorage(string[] data)
        {
            queue = new Queue<string>();
            foreach (var item in data)
                queue.Enqueue(item);
        }

        public void Print()
        {
            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());
        }

        public void Explain()
        {
            Console.WriteLine("\n Queue:");
            Console.WriteLine("- First-In-First-Out (FIFO) structure.");
            Console.WriteLine("- Enqueue adds to the end; Dequeue removes from the front.");
            Console.WriteLine("- Best for task scheduling, buffering, and breadth-first search.");

        }

    }
}
