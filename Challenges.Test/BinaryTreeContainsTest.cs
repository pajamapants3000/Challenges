using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class BinaryTreeContainsTest
    {
        [Test]
        public void Test1()
        {
            BinaryTreeContains.BinaryNode root = null;
            BinaryTreeContains.BinaryNode toMatchRoot = null;

            bool expected = false;

            ApplyTest(root, toMatchRoot, expected);
        }

        private void ApplyTest(BinaryTreeContains.BinaryNode root,
            BinaryTreeContains.BinaryNode toMatchRoot,
            bool expected)
        {
            //BinaryTreeContains calculator = new BinaryTreeContains(root, toMatchRoot);
            //bool result = calculator.GetResult();

            //Assert.AreEqual(result, expected);
        }
    }
}
