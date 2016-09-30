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
        private const int Loops = 100000;
        private readonly int[] arraySizes = {1024, 2048, 4096, 8192, 16384, 32768};
        private readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            var searchMethods = new List<Func<int[], int, bool>>
            {
                Search.Linear
            };

            var tests = new Program();
            Console.WriteLine($"{Loops} iterations per search");

            foreach (var search in searchMethods)
            {
                foreach (var testSize in tests.arraySizes)
                {
                    int[] testArray = GenerateSortedArray(testSize);
                    Stopwatch stopWatch = Stopwatch.StartNew();

                    for (int i = 0; i < Loops; i++)
                    {
                        int target = tests.rnd.Next(testArray.Length);
                        search(testArray, target);
                    }
                    stopWatch.Stop();
                    Console.WriteLine($"{search.Method.Name}, size {testSize}: {stopWatch.ElapsedMilliseconds}ms");
                }
            }

        }

        private static int[] GenerateSortedArray(int length)
        {
            return Enumerable.Range(0, length).ToArray();
        }
    }
}
