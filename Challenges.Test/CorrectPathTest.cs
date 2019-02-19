using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class CorrectPathTest
    {
        [Test]
        public void Test1()
        {
            string input = "???rrurdr?";
            string expected = "dddrrurdrd";

            ApplyTest(input, expected);
        }

        [Test]
        public void Test2()
        {
            string input = "drdr??rrddd?";
            string expected = "drdruurrdddd";

            ApplyTest(input, expected);
        }

        private void ApplyTest(string input, string expected)
        {
            CorrectPath calculator = new CorrectPath(input);
            string result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }

    }
}
