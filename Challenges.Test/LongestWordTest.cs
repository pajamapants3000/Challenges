using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class LongestWordTest
    {
        [Test]
        public void Test1()
        {
            string sen = "This is the greatest!";
            string expected = "greatest";

            ApplyTest(sen, expected);
        }

        [Test]
        public void Test2()
        {
            string sen = "Where are we!?!?!?!?!";
            string expected = "Where";

            ApplyTest(sen, expected);
        }

        [Test]
        public void Test3()
        {
            string sen = "did done does dust!.";
            string expected = "done";

            ApplyTest(sen, expected);
        }

        [Test]
        public void Test4()
        {
            string sen = "All around!!! Then we see what's what.";
            string expected = "around";

            ApplyTest(sen, expected);
        }

        private void ApplyTest(string sen, string expected)
        {
            LongestWord calculator = new LongestWord(sen);

            Assert.AreEqual(expected, calculator.GetResult());
        }
    }
}
