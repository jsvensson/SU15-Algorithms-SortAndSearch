using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sorting;

namespace Benchmark
{
    class Program
    {
        private const int SearchLoops = 100000;
        private const int SortLoops = 5;
        private readonly int[] arraySizes = {1024, 2048, 4096, 8192, 16384, 32768};
        private readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            var searchMethods = new List<Func<int[], int, bool>>
            {
                Search.Linear,
                Search.LinearLinq,
                Search.Binary
            };

            var sortMethods = new List<Func<int[], int[]>>
            {
                Sort.BubbleSort
            };

            BenchmarkSearching(searchMethods);
            BenchmarkSorting(sortMethods);

        }

        private static int[] GenerateSortedArray(int length)
        {
            return Enumerable.Range(0, length).ToArray();
        }

        private static int[] GenerateUnsortedArray(int length)
        {
            int[] array = GenerateSortedArray(length);
            Random rng = new Random();   // i.e., java.util.Random.
            int n = array.Length;        // The number of items left to shuffle (loop invariant).
            while (n > 1)
            {
                int k = rng.Next(n);  // 0 <= k < n.
                n--;                     // n is now the last pertinent index;
                int temp = array[n];     // swap array[n] with array[k] (does nothing if k == n).
                array[n] = array[k];
                array[k] = temp;
            }

            return array;
        }

        private static void BenchmarkSearching(IEnumerable<Func<int[], int, bool>> methods)
        {


            var tests = new Program();
            Console.WriteLine($"Search algorithms, {SearchLoops} iterations per search");
            Console.WriteLine();

            foreach (var search in methods)
            {
                foreach (var testSize in tests.arraySizes)
                {
                    int[] testArray = GenerateSortedArray(testSize);
                    Stopwatch stopWatch = Stopwatch.StartNew();

                    for (int i = 0; i < SearchLoops; i++)
                    {
                        int target = tests.rnd.Next(testArray.Length);
                        search(testArray, target);
                    }
                    stopWatch.Stop();
                    Console.WriteLine($"{search.Method.Name}, size {testSize}: {stopWatch.ElapsedMilliseconds}ms");
                }
                Console.WriteLine();
            }
        }

        private static void BenchmarkSorting(IEnumerable<Func<int[], int[]>> methods)
        {
            Console.WriteLine($"Sort algorithms, {SortLoops} iterations per sort");
            Console.WriteLine();

            var tests = new Program();

            foreach (Func<int[], int[]> sortMethod in methods)
            {
                foreach (int testSize in tests.arraySizes)
                {

                    Stopwatch stopWatch = Stopwatch.StartNew();
                    int[] testArray = GenerateUnsortedArray(testSize);
                    for (int i = 0; i < SortLoops; i++)
                    {
                        int[] sortedArray = sortMethod(testArray);
                    }

                    stopWatch.Stop();
                    Console.WriteLine($"{sortMethod.Method.Name}, size {testSize}: {stopWatch.ElapsedMilliseconds}ms");

                }
            }
        }
    }
}
