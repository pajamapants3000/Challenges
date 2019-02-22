using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class PentagonalNumberTest
    {
        [Test]
        public void Test1()
        {
            int input = 1;
            int expected = 1;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test2()
        {
            int input = 2;
            int expected = 6;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test3()
        {
            int input = 3;
            int expected = 16;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test4()
        {
            int input = 4;
            int expected = 31;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test5()
        {
            int input = 5;
            int expected = 51;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test6()
        {
            int input = 6;
            int expected = 76;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test7()
        {
            int input = 7;
            int expected = 106;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test8()
        {
            int input = 8;
            int expected = 141;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test9()
        {
            int input = 9;
            int expected = 181;

            ApplyTest(input, expected);
        }

        [Test]
        public void Test10()
        {
            int input = 10;
            int expected = 226;

            ApplyTest(input, expected);
        }

        private void ApplyTest(int input, int expected)
        {
            PentagonalNumber calculator = new PentagonalNumber(input);
            int result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }

    }
}
