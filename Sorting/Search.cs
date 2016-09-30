using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class Search
    {
        public static bool Linear(int[] array, int target)
        {
            foreach (int t in array)
            {
                if (t == target)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Binary(int[] array, int target)
        {
            int min = 0;
            int max = array.Length - 1;
            while (min <= max)
            {
                int center = (min + max) / 2;

                if (array[center] == target) return true;
                if (array[center] > target) max = center - 1;
                else min = center + 1;
            }

            return false;
        }
    }
}
