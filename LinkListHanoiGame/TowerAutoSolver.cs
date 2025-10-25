using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListHanoiGame
{
    public class TowerAutoSolver
    {
        private StackOfAnguish<int> towerA = new StackOfAnguish<int>();
        private StackOfAnguish<int> towerB = new StackOfAnguish<int>();
        private StackOfAnguish<int> towerC = new StackOfAnguish<int>();
        private QueueOfDOOM<(string from, string to)> moveQueue = new QueueOfDOOM<(string from, string to)>();
        private int ringCount;
        private int moveCount = 0;

        public void Start()
        {
            Console.Write("Enter number of rings (3 recommended): ");
            if (!int.TryParse(Console.ReadLine(), out ringCount) || ringCount < 1)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            for (int i = ringCount; i >= 1; i--)
                towerA.Push(i);

            EnqueueMoves(ringCount);

            while (!moveQueue.IsEmpty())
            {
                Console.Clear();
                DisplayTowers();

                var (from, to) = moveQueue.Dequeue();
                StackOfAnguish<int> source = GetTower(from);
                StackOfAnguish<int> destination = GetTower(to);

                if (IsValidMove(source, destination))
                {
                    int ring = source.Pop();
                    destination.Push(ring);
                    moveCount++;
                }


                Thread.Sleep(500);
            }
            Console.Clear();
            DisplayTowers(); 
            

            Console.WriteLine($"Auto-solver completed in {moveCount} moves.");
        }

        private void EnqueueMoves(int count)
        {
            if (count == 3)
            {
                moveQueue.Enqueue(("A", "C"));
                moveQueue.Enqueue(("A", "B"));
                moveQueue.Enqueue(("C", "B"));
                moveQueue.Enqueue(("A", "C"));
                moveQueue.Enqueue(("B", "A"));
                moveQueue.Enqueue(("B", "C"));
                moveQueue.Enqueue(("A", "C"));
            }
            else
            {
                Console.WriteLine("Dumb solver only supports 3 rings for now.");
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

        private bool IsValidMove(StackOfAnguish<int> source, StackOfAnguish<int> destination)
        {
            if (source.IsEmpty()) return false;
            int movingRing = source.Peek();
            int targetRing = destination.Peek();
            return destination.IsEmpty() || movingRing < targetRing;
        }

        private void DisplayTowers()
        {
            Console.WriteLine($"\nMove #{moveCount}");
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
