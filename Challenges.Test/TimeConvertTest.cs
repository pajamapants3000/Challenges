using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class TimeConvertTest
    {
        [Test]
        public void Test1()
        {
            int input = 126;
            string expected = "2:6";

            ApplyTest(input, expected);
        }

        [Test]
        public void Test2()
        {
            int input = 45;
            string expected = "20:45";

            ApplyTest(input, expected);
        }

        [Test]
        public void Test3()
        {
            int input = 387;
            string expected = "6:27";

            ApplyTest(input, expected);
        }

        [Test]
        public void Test4()
        {
            int input = 0;
            string expected = "0:0";

            ApplyTest(input, expected);
        }

        [Test]
        public void Test5()
        {
            int input = 13;
            string expected = "0:13";

            ApplyTest(input, expected);
        }

        private void ApplyTest(int input, string expected)
        {
            TimeConvert calculator = new TimeConvert(input);
            string result = calculator.GetResult();

            //Assert.Fail();
        }

    }
}
