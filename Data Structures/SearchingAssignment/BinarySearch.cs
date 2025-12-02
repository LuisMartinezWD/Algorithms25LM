using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAssignment
{
    public class BinarySearch
    {
        public static int Search(List<int> data, int target)
        {
            int left = 0;
            int right = data.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (data[mid] == target)
                    return mid;

                if (data[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public static void RunSearch(List<int> data, int target)
        {
            var stopwatch = Stopwatch.StartNew();
            int index = Search(data, target);
            stopwatch.Stop();

            Console.WriteLine("Binary Search:");
            Console.WriteLine($"  Result Index: {index}");
            Console.WriteLine($"  Time: {stopwatch.ElapsedTicks} ticks\n");
        }



    }
}
