using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    public class SubsetSumTest
    {
        [Test]
        public void Test1()
        {
            int[] set = { 1, 2, 3, 4, 5 };
            int sum = 8;
            List<List<int>> expected = new List<List<int>>() { new List<int>() { 3, 5 }, new List<int>() { 1, 2, 5 }, new List<int>() { 1, 3, 4 } };

            ApplyTest(set, sum, expected);
        }

        [Test]
        public void Test_plusOrMinus()
        {
            int[] set = { -3, -2, -1, 0, 1, 2, 3, };
            int sum = 0;
            List<List<int>> expected = new List<List<int>>() {
                new List<int> {0, },
                new List<int> {-1, 1, },
                new List<int> {-1, 0, 1, },
                new List<int> {-2, 2, },
                new List<int> {-2, 0, 2, },
                new List<int> {-3, 1, 2, },
                new List<int> {-2, -1, 1, 2, },
                new List<int> {-3, 0, 1, 2, },
                new List<int> {-2, -1, 0, 1, 2, },
                new List<int> {-3, 3, },
                new List<int> {-2, -1, 3, },
                new List<int> {-3, 0, 3, },
                new List<int> {-2, -1, 0, 3, },
                new List<int> {-3, -1, 1, 3, },
                new List<int> {-3, -1, 0, 1, 3, },
                new List<int> {-3, -2, 2, 3, },
                new List<int> {-3, -2, 0, 2, 3, },
                new List<int> {-3, -2, -1, 1, 2, 3, },
                new List<int> {-3, -2, -1, 0, 1, 2, 3, },
            };

            ApplyTest(set, sum, expected);
        }

        [Test]
        public void Test_many1s()
        {
            int[] set = { 1, 1, 1, 1, 1 };
            int sum = 3;
            List<List<int>> expected = new List<List<int>>() {
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 1 },
            };

            ApplyTest(set, sum, expected);
        }
        [Test]
        public void Test_emptySet()
        {
            int[] set = { };
            int sum = 1;
            List<List<int>> expected = new List<List<int>>() { };

            ApplyTest(set, sum, expected);
        }

        [Test]
        public void Test_emptyResult()
        {
            int[] set = { 1, 2, 3, 4, 5 };
            int sum = 99;
            List<List<int>> expected = new List<List<int>>() { };

            ApplyTest(set, sum, expected);
        }

        [Test]
        public void Test_trivial_0()
        {
            int[] set = { 0 };
            int sum = 0;
            List<List<int>> expected = new List<List<int>>() { new List<int>() { 0 } };

            ApplyTest(set, sum, expected);
        }

        [Test]
        public void Test_trivial_1()
        {
            int[] set = { 1 };
            int sum = 1;
            List<List<int>> expected = new List<List<int>>() { new List<int>() { 1 } };

            ApplyTest(set, sum, expected);
        }

        [Test]
        public void Test_trivial_99()
        {
            int[] set = { 99 };
            int sum = 99;
            List<List<int>> expected = new List<List<int>>() { new List<int>() { 99 } };

            ApplyTest(set, sum, expected);
        }

        private void ApplyTest(int[] set, int sum, List<List<int>> expected)
        {
            SubsetSum calculator = new SubsetSum(sum, set);
            List<List<int>> result = calculator.GetResult();

            Assert.IsTrue(TestHelpers.Are2DListsEqual(expected, result));
        }

    }
}
