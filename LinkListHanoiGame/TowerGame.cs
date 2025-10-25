using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListHanoiGame
{
    public class TowerGame
    {
        private StackOfAnguish<int> towerA = new StackOfAnguish<int>();
        private StackOfAnguish<int> towerB = new StackOfAnguish<int>();
        private StackOfAnguish<int> towerC = new StackOfAnguish<int>();
        private int ringCount;
        private int moveCount = 0;


        public void Start()
        {
            Console.Write("Enter number of rings: ");
            if (!int.TryParse(Console.ReadLine(), out ringCount) || ringCount < 1)
            {
                Console.WriteLine("Invalid input. Must be a positive integer.");
                return;
            }

            for (int i = ringCount; i >= 1; i--)
                towerA.Push(i);

            while (towerC.Size() != ringCount)
            {
                DisplayTowers();
                string from = PromptForTower("Choose source tower (A, B, C): ");
                string to = PromptForTower("Choose destination tower (A, B, C): ");


                if (!IsValidMove(from, to))
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }

                StackOfAnguish<int> source = GetTower(from);
                StackOfAnguish<int> destination = GetTower(to);

                int ring = source.Pop();
                destination.Push(ring);
                moveCount++;
                Console.Clear();
            }

            Console.WriteLine($"Congratulations! You solved the Tower of Hanoi in {moveCount} moves.") ;
        }

        private bool IsValidMove(string from, string to)
        {
            if (from == to) return false;

            StackOfAnguish<int> source = GetTower(from);
            StackOfAnguish<int> destination = GetTower(to);

            if (source.IsEmpty()) return false;

            int movingRing = source.Peek();
            int targetRing = destination.Peek();

            return destination.IsEmpty() || movingRing < targetRing;
        }
        private string PromptForTower(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "A" || input == "B" || input == "C")
                    return input;

                Console.WriteLine("Invalid input. Please enter A, B, or C.");
            }
        }


        private StackOfAnguish<int> GetTower(string name)
        {
            return name switch
            {
                "A" => towerA,
                "B" => towerB,
                "C" => towerC,
                _ => null
            };
        }

        private void DisplayTowers()
        {
            Console.WriteLine("\nTowers:");
            Console.WriteLine($"A: {FormatTower(towerA)}");
            Console.WriteLine($"B: {FormatTower(towerB)}");
            Console.WriteLine($"C: {FormatTower(towerC)}\n");
        }

        private string FormatTower(StackOfAnguish<int> tower)
        {
            List<int> rings = new List<int>();
            StackOfAnguish<int> temp = new StackOfAnguish<int>();

            while (!tower.IsEmpty())
            {
                int ring = tower.Pop();
                rings.Add(ring);
                temp.Push(ring);
            }

            while (!temp.IsEmpty())
                tower.Push(temp.Pop());

            rings.Reverse();
            return string.Join(", ", rings);
        }

    }
}
