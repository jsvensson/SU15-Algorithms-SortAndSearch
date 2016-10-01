using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class Sort
    {
        public static int[] BubbleSort(int[] items)
        {
            for (int outer = 0; outer < items.Length; outer++)
            {
                for (int inner = 0; inner < items.Length - 1; inner++)
                {
                    int first = items[inner];
                    int second = items[inner + 1];

                    if (first > second)
                    {
                        items[inner] = second;
                        items[inner + 1] = first;
                    }
                }
            }

            return items;
        }
    }
}
