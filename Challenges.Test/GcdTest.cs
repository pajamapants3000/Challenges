using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class GcdTest
    {
        [Test]
        public void Test1()
        {
            int num = 3;
            int[] arr = new int[]{ 3, 6, 9, 54 };
            int expected = 3;

            ApplyTest(num, arr, expected);
        }

        private void ApplyTest(int num, int[] arr, int expected)
        {
            Gcd calculator = new Gcd(num, arr);
            int result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }

    }
}
