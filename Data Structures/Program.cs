using System;
using System.IO;

namespace Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string filePath = "data.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: data.txt not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

           
            var arrayStorage = new ArrayStorage(lines);
            var mapStorage = new MapStorage(lines);
            var stackStorage = new StackStorage(lines);
            var queueStorage = new QueueStorage(lines);

            // Array vs. Map
            Console.WriteLine("=== Array ===");
            arrayStorage.Print();
            arrayStorage.Explain();

            Console.WriteLine("\n=== Map (Dictionary) ===");
            mapStorage.Print();
            mapStorage.Explain();

            // Stack vs. Queue
            Console.WriteLine("\n=== Stack ===");
            stackStorage.Print();
            stackStorage.Explain();

            Console.WriteLine("\n=== Queue ===");
            queueStorage.Print();
            queueStorage.Explain();

            Console.WriteLine("\n Comparison complete.");
        }
    }
}


