using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAssignment
{
    public class LinearSearch
    {
        public static int Search(List<int> data, int target)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == target)
                {
                    return i; 
                }
            }
            return -1; 
        }

        public static void RunSearch(List<int> data, int target)
        {
            var stopwatch = Stopwatch.StartNew();
            int index = Search(data, target);
            stopwatch.Stop();

            Console.WriteLine("Linear Search:");
            Console.WriteLine($"  Result Index: {index}");
            Console.WriteLine($"  Time: {stopwatch.ElapsedTicks} ticks\n");
        }

    }
}
