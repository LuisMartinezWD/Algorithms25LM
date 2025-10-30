using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class ArrayStorage
    {
        private string[] array;

        public ArrayStorage(string[] data)
        {
            array = new string[data.Length];
            data.CopyTo(array, 0);
        }

        public void Print()
        {
            foreach (var item in array)
                Console.WriteLine(item);
        }

        public void Explain()
        {
            Console.WriteLine("\n Array:");
            Console.WriteLine("- Stores elements in a fixed-size, ordered list.");
            Console.WriteLine("- Access by index is fast (O(1)), but searching is linear (O(n)).");
            Console.WriteLine("- Best when you need predictable order and fast random access.");

        }
    }

}

