using System;

namespace MergeSort
{
    class Program
    {
        static void Merge(int[] arr, int startIndex, int middle, int lastIndex)
        {
            // Find sizes of two sub-arrays to be merged 
            var firstArrSize = middle - startIndex + 1;
            var secondArrSize = lastIndex - middle;

            /* Create temp arrays */
            var firstArr = new int[firstArrSize];
            var secondArr = new int[secondArrSize];

            /*Copy data to temp arrays*/
            for (var i = 0; i < firstArrSize; ++i)
            {
                firstArr[i] = arr[startIndex + i];
            }

            for (var j = 0; j < secondArrSize; ++j)
            {
                secondArr[j] = arr[middle + 1 + j];
            }


            /* Merge the temp arrays */

            // Initial indexes of first and second subarrays 
            int firstIndex = 0, secondIndex = 0;

            // Initial index of merged subarry array 
            int k = startIndex;
            while (firstIndex < firstArrSize && secondIndex < secondArrSize)
            {
                if (firstArr[firstIndex] <= secondArr[secondIndex])
                {
                    arr[k] = firstArr[firstIndex];
                    firstIndex++;
                }
                else
                {
                    arr[k] = secondArr[secondIndex];
                    secondIndex++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (firstIndex < firstArrSize)
            {
                arr[k] = firstArr[firstIndex];
                firstIndex++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (secondIndex < secondArrSize)
            {
                arr[k] = secondArr[secondIndex];
                secondIndex++;
                k++;
            }
        }

        // Main function that sorts arr[firstIndex..lastIndex] using 
        // Merge() 
        static void Sort(int[] arr, int firstIndex, int lastIndex)
        {
            if (firstIndex < lastIndex)
            {
                // Find the middle point 
                var middle = (firstIndex + lastIndex) / 2;

                // Sort first and second halves 
                Sort(arr, firstIndex, middle);
                Sort(arr, middle + 1, lastIndex);

                // Merge the sorted halves 
                Merge(arr, firstIndex, middle, lastIndex);
            }
        }

        /* A utility function to print array of size n */
        static void PrintArray(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };

            Console.WriteLine("Given Array");
            PrintArray(arr);

            Sort(arr, 0, arr.Length - 1);

            Console.WriteLine("\nSorted array");
            PrintArray(arr);
            Console.ReadKey(true);
        }
    }
}
