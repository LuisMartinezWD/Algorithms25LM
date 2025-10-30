using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class MapStorage
    {
        private Dictionary<int, string> map;

        public MapStorage(string[] data)
        {
            map = new Dictionary<int, string>();
            for (int i = 0; i < data.Length; i++)
                map[i] = data[i];
        }

        public void Print()
        {
            foreach (var kvp in map)
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        public void Explain()
        {
            Console.WriteLine("\n Map (Dictionary):");
            Console.WriteLine("- Stores key-value pairs using a hash table.");
            Console.WriteLine("- Lookup by key is fast (average O(1)), regardless of position.");
            Console.WriteLine("- Best when you need fast access by identifier, not position.");


            Console.WriteLine("\n Comparison for Array and Map:");
            Console.WriteLine("- Arrays are ideal for ordered data and iteration.");
            Console.WriteLine("- Maps are ideal for associative data and fast lookups.");
            Console.WriteLine("- Use arrays when index matters; use maps when keys matter.");
        

    }
}


}
