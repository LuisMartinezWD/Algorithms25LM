namespace SearchingAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scores = new List<int>();
            foreach (var line in File.ReadAllLines("../../../scores.txt"))
            {
                if (int.TryParse(line, out int score))
                    scores.Add(score);
            }

            scores.Sort(); 

            int target = 56;

            Console.WriteLine($"Searching for {target}...\n");

            LinearSearch.RunSearch(scores, target);
            BinarySearch.RunSearch(scores, target);
            InterpolationSearch.RunSearch(scores, target);

            Console.WriteLine("\nSummary:");
            Console.WriteLine("Linear is the slowest because it checks EVERY SINGLE ELEMENT sequentually");
            Console.WriteLine("Binary halves the search space from step to step");
            Console.WriteLine("Interpolation estimates position off value distribution, needs to be sorted to be as efficient as possible");
        


    }
}
}
