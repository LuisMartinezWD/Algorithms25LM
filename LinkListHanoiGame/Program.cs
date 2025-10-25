// See https://aka.ms/new-console-template for more information
using LinkListHanoiGame;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Run auto-solver? (y/n): ");
        string choice = Console.ReadLine()?.Trim().ToLower();

        if (choice == "y")
        {
            TowerAutoSolver auto = new TowerAutoSolver();
            auto.Start();
        }
        else
        {
            TowerGame game = new TowerGame();
            game.Start();
        }

    }
}


