namespace Algorithms_Assn1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }

        public int ConstantGetLastElement(int[] ElList) 
        {
            return ElList[ElList.Length-1];
        }

        //This is an example of Constant time, since this method does not depend on the size of the Array at all it all happens
        //at run time, the only thing that happens is returning the last element of the Array ElList

        public int LinearAddElements(int[] LinList)
        {
            int sum = 0;

            for(int i = 0; i < LinList.Length; i++)
            {
                sum += LinList[i]; // there is one operation that is taking place for each iteration of this for loop
            }
            return sum;
        }
        //this is linear because the amount of operations that take place is directly tied to the amount of elements
        // in the array LinList. It is forced to iterate through the entire Array once

        public int QuadraticPairCount(int[] QuadList) // counting every pair of distinct elements
        {
            int Pcount = 0;
            for(int i = 0; i < QuadList.Length; i++)
            {
                for(int j =0; j < QuadList.Length; j++)
                {
                    if (i != j)
                    {
                        Pcount++; // adding count to the Pair Count for a distinct pair of numbers
                    }
                }
            }
            return Pcount;
        }
        //This is Quadratic O(n^2) because for every index of i, the method is forced to loop through the entirity of 
        //j, making n*n comparisons which would be n^2

    }
}

