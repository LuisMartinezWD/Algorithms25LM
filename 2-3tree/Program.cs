namespace _2_3tree
{
    internal class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("scores.txt");
            TwoThreeTree tree = new TwoThreeTree();

            foreach (string line in lines)
            {
                if (int.TryParse(line, out int value))
                    tree.Insert(value);
            }

            tree.InOrderTraversal();
        }

    }
}
