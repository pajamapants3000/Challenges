using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Challenges.Test
{
    class TestHelpersTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 2, 3 }, false)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, true)]
        public void AreArraysEqual_int(int[] a, int[] b, bool areEqual)
        {
            Assert.AreEqual(areEqual, TestHelpers.AreArraysEqual<int>(a, b));
        }

        [Test]
        public void Are2DArraysEqual_int_1()
        {
            int[][] a = { new int[]{ 2, 3 }, new int[] { 3, 5 } };
            int[][] b = { new int[]{ 3, 5 }, new int[] { 2, 3 } };

            Assert.IsTrue(TestHelpers.Are2DArraysEqual<int>(a, b));
        }
    }
}
