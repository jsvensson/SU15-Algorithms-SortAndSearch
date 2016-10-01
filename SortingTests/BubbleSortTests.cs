using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace SortingTests
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void Sorts_Array()
        {
            int[] input = {5, 4, 3, 2, 1};
            int[] expected = {1, 2, 3, 4, 5};

            int[] actual = Sort.BubbleSort(input);

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
