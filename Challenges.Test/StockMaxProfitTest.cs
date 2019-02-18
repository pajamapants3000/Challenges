using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class StockMaxProfitTest
    {
        [Test]
        public void Test1()
        {
            int[] input = new int[] { 45, 24, 35, 31, 40, 38, 11 };
            int expected = 16;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test2()
        {
            int[] input = new int[] { 11, 11, 11, 11, 11, 11, 11 };
            int expected = -1;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test3()
        {
            int[] input = new int[] { 45, 46, 27, 88, 26, 27, 32 };
            int expected = 61;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test4()
        {
            int[] input = new int[] { 45, 24, 35, 31, 40, 38, 11, 45, 46, 27, 88, 26, 27, 32, 1, 57 };
            int expected = 77;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test5()
        {
            int[] input = new int[] { 87, 88, 89, 86, 83, 22, 49, 50, 49, 50, 49, 48, 55, 11, 78 };
            int expected = 67;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test6()
        {
            int[] input = new int[] { 55, 11, 78, 87, 88, 89, 86, 83, 22, 49, 50, 49, 50, 49, 48 };
            int expected = 78;

            ApplyTest(input, expected);
        }

        private void ApplyTest(int[] input, int expected)
        {
            StockMaxProfit calculator = new StockMaxProfit(input);
            int result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }
    }
}
