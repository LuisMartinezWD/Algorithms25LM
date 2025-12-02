using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAssignment
{
    public class InterpolationSearch
    {
        public static int Search(List<int> data, int target)
        {
            int low = 0;
            int high = data.Count - 1;

            while (low <= high && target >= data[low] && target <= data[high])
            {
                if (low == high)
                {
                    if (data[low] == target) return low;
                    return -1;
                }

                
                int pos = low + ((target - data[low]) * (high - low)) /
                          (data[high] - data[low]);

                if (data[pos] == target)
                    return pos;

                if (data[pos] < target)
                    low = pos + 1;
                else
                    high = pos - 1;
            }

            return -1;
        }

        public static void RunSearch(List<int> data, int target)
        {
            var stopwatch = Stopwatch.StartNew();
            int index = Search(data, target);
            stopwatch.Stop();

            Console.WriteLine("Interpolation Search:");
            Console.WriteLine($"  Result Index: {index}");
            Console.WriteLine($"  Time: {stopwatch.ElapsedTicks} ticks\n");
        }


    }
}
