using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class AlphabetSoupTest
    {
        [Test]
        public void Test1()
        {
            string input = "coderbyte";
            string expected = "bcdeeorty";

            ApplyTest(input, expected);
        }

        [Test]
        public void Test2()
        {
            string input = "hooplah";
            string expected = "ahhloop";

            ApplyTest(input, expected);
        }

        private void ApplyTest(String input, string expected)
        {
            AlphabetSoup calculator = new AlphabetSoup(input);
            string result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }

    }
}
