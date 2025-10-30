using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class StackStorage
    {
        private Stack<string> stack;

        public StackStorage(string[] data)
        {
            stack = new Stack<string>();
            foreach (var item in data)
                stack.Push(item);
        }

        public void Print()
        {
            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }

        public void Explain()
        {
            Console.WriteLine("\n Stack:");
            Console.WriteLine("- Last-In-First-Out (LIFO) structure.");
            Console.WriteLine("- Push adds to the top; Pop removes from the top.");
            Console.WriteLine("- Best for undo operations, recursion, and backtracking.");


            Console.WriteLine("\n Comparison for Stack and Queue:");
            Console.WriteLine("- Stack reverses order; Queue preserves order.");
            Console.WriteLine("- Stack is efficient for nested or reversed tasks.");
            Console.WriteLine("- Queue is efficient for fair, ordered processing.");

        }

    }
}
