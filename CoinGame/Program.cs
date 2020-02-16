using System;

namespace CoinGame
{
    class Program
    {
        // Returns optimal value possible that a player  
        // can collect from an array of coins of size n.  
        // Note than n must be even  
        static int OptimalStrategyOfGame(int[] arr)
        {
            // Create a table to store solutions of subproblems  
            var table = new int[arr.Length, arr.Length];
            int i, j, x, y, z;

            // Fill table using above recursive formula.  
            // Note that the tableis filled in diagonal  
            // fashion (similar to http://goo.gl/PQqoS),  
            // from diagonal elements to table[0][n-1]  
            // which is the result.  
            for (var gap = 0; gap < arr.Length; ++gap)
            {
                for (i = 0, j = gap; j < arr.Length; ++i, ++j)
                {

                    // Here x is value of F(i+2, j),  
                    // y is F(i+1, j-1) and z is  
                    // F(i, j-2) in above recursive formula  
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0;
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0;
                    z = (i <= (j - 2)) ? table[i, j - 2] : 0;

                    table[i, j] = Math.Max(arr[i] + Math.Min(x, y),
                        arr[j] + Math.Min(y, z));
                }
            }

            return table[0, arr.Length - 1];
        }

        // Driver program  

        public static void Main()
        {
            int[] arr1 = { 8, 15, 3, 7 };
            Console.WriteLine("" + OptimalStrategyOfGame(arr1));

            int[] arr2 = { 2, 2, 2, 2 };
            Console.WriteLine("" + OptimalStrategyOfGame(arr2));

            int[] arr3 = { 20, 30, 2, 2, 2, 10 };
            Console.WriteLine("" + OptimalStrategyOfGame(arr3));
        }
    }
}
