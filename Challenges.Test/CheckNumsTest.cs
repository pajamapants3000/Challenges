using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class CheckNumsTest
    {
        [Test]
        public void Test1()
        {
            int input1 = 3;
            int input2 = 122;
            string expected = "true";

            ApplyTest(input1, input2, expected);
        }

        [Test]
        public void Test2()
        {
            int input1 = 67;
            int input2 = 67;
            string expected = "-1";

            ApplyTest(input1, input2, expected);
        }

        [Test]
        public void Test3()
        {
            int input1 = 99;
            int input2 = 0;
            string expected = "false";

            ApplyTest(input1, input2, expected);
        }

        [Test]
        public void Test4()
        {
            int input1 = 0;
            int input2 = 99;
            string expected = "true";

            ApplyTest(input1, input2, expected);
        }

        [Test]
        public void Test5()
        {
            int input1 = 0;
            int input2 = 0;
            string expected = "-1";

            ApplyTest(input1, input2, expected);
        }

        private void ApplyTest(int input1, int input2, string expected)
        {
            CheckNums calculator = new CheckNums(input1, input2);
            string result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }

    }
}
