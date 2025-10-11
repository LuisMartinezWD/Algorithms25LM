using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYatesShuffe
{
    internal class Program
    {
        public static void Shuffle<T>(T[] array)
        {
            Random rng = new Random();
            int n = array.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1); 
                                        
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Original array: " + string.Join(", ", numbers));

            Shuffle(numbers);
            Console.WriteLine("Shuffled array: " + string.Join(", ", numbers));
        }

    }
}
