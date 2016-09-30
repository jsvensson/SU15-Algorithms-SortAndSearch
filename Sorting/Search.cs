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
    }
}
