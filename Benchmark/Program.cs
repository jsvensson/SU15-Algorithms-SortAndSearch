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
        private readonly int[] intArray = GenerateSortedArray(Loops);
        private readonly int[] arraySizes = {1024, 2048, 4096, 16384, 32768};
        private readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            var searchMethods = new List<Func<int[], int, bool>>
            {
                Search.Linear
            };

            var tests = new Program();

            foreach (var search in searchMethods)
            {
                foreach (var testSize in tests.arraySizes)
                {
                    Stopwatch stopWatch = Stopwatch.StartNew();

                    for (int i = 0; i < Loops; i++)
                    {
                        int target = tests.rnd.Next(Loops);
                        search(tests.intArray, target);
                    }
                    stopWatch.Stop();
                    Console.WriteLine($"Size {testSize}: {stopWatch.ElapsedMilliseconds}ms");
                }
            }

        }

        private static int[] GenerateSortedArray(int length)
        {
            return Enumerable.Range(0, length).ToArray();
        }

        public static void BenchmarkSearch(Func<int[], int, bool> searchMethod)
        {
            
        }
    }
}
