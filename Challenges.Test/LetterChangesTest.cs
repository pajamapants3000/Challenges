using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class LetterChangesTest
    {
        [Test]
        public void Test1()
        {
            string str = "hello!";
            string expected = "Ifmmp!";

            ApplyTest(str, expected);
        }

        [Test]
        public void Test2()
        {
            string str = "zap!";
            string expected = "Abq!";

            ApplyTest(str, expected);
        }

        [Test]
        public void Test3()
        {
            string str = "Zap!";
            string expected = "Abq!";

            ApplyTest(str, expected);
        }

        [Test]
        public void Test4()
        {
            string str = "@gmail.com";
            string expected = "@hnbjm.dpn";

            ApplyTest(str, expected);
        }
        
        [Test]
        public void Test5()
        {
            string str = "done?";
            string expected = "EpOf?";

            ApplyTest(str, expected);
        }

        private void ApplyTest(string str, string expected)
        {
            LetterChanges calculator = new LetterChanges(str);

            Assert.AreEqual(expected, calculator.GetResult());
        }
    }
}
