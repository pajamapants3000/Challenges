using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class BinaryTreeTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void PreOrderRecursive_Test1()
        {
            BinaryTree.TreeNode input = testTree1();
            List<int> expected = new List<int>() { 1, 2, 4, 8, 5, 3, 6, 9, 10, 7, 11, 12 };

            Assert.AreEqual(expected, BinaryTree.PreOrderRecursive(input));
        }

        [Test]
        public void PreOrderIterative_Test1()
        {
            BinaryTree.TreeNode input = testTree1();
            List<int> expected = new List<int>() { 1, 2, 4, 8, 5, 3, 6, 9, 10, 7, 11, 12 };

            Assert.AreEqual(expected, BinaryTree.PreorderIterative(input));
        }

        [Test]
        public void InOrderRecursive_Test1()
        {
            BinaryTree.TreeNode input = testTree1();
            List<int> expected = new List<int>() { 4, 8, 2, 5, 1, 9, 6, 10, 3, 11, 7, 12 };

            Assert.AreEqual(expected, BinaryTree.InOrderRecursive(input));
        }

        [Test]
        public void InOrderIterative_Test1()
        {
            BinaryTree.TreeNode input = testTree1();
            List<int> expected = new List<int>() { 4, 8, 2, 5, 1, 9, 6, 10, 3, 11, 7, 12 };

            Assert.AreEqual(expected, BinaryTree.InOrderRecursive(input));
        }

        [Test]
        public void PostOrderRecursive_Test1()
        {
            BinaryTree.TreeNode input = testTree1();
            List<int> expected = new List<int>() { 8, 4, 5, 2, 9, 10, 6, 11, 12, 7, 3, 1 };

            Assert.AreEqual(expected, BinaryTree.PostOrderRecursive(input));
        }

        [Test]
        public void PostOrderIterative_Test1()
        {
            BinaryTree.TreeNode input = testTree1();
            List<int> expected = new List<int>() { 8, 4, 5, 2, 9, 10, 6, 11, 12, 7, 3, 1 };

            Assert.AreEqual(expected, BinaryTree.PostOrderRecursive(input));
        }

        [Test]
        public void LevelOrder_Test1()
        {
            BinaryTree.TreeNode input = testTree1();
            IList<List<int>> expected = new List<List<int>>()
            {
                new List<int>(){ 1},
                new List<int>(){ 2, 3},
                new List<int>(){ 4, 5, 6, 7},
                new List<int>(){ 8, 9, 10, 11, 12}
            };
            Assert.AreEqual(expected, BinaryTree.LevelOrderTraversal(input));
        }

        private void ApplyTest(BinaryTree.TreeNode input, List<int> expected)
        {
            BinaryTree calculator = new BinaryTree(input);
            List<int> result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }

        // Root{left, right}: {1{2{4{,8}, 5}, 3{6{9, 10}, 7{11, 12}}}}
        // PreOrder: {1, 2, 4, 8, 5, 3, 6, 9, 10, 7, 11, 12}
        // InOrder: {4, 8, 2, 5, 1, 9, 6, 10, 3, 11, 7, 12}
        // PostOrder: {8, 4, 5, 2, 9, 10, 6, 11, 12, 7, 3, 1}
        // LevelOrder: {{1}, {2, 3}, {4, 5, 6, 7}, {8, 9, 10, 11, 12}}
        public BinaryTree.TreeNode testTree1()
        {
            int currentVal = 1;
            BinaryTree.TreeNode root = new BinaryTree.TreeNode(currentVal++);

            root.left = new BinaryTree.TreeNode(currentVal++);
            root.right = new BinaryTree.TreeNode(currentVal++);

            root.left.left = new BinaryTree.TreeNode(currentVal++);
            root.left.right = new BinaryTree.TreeNode(currentVal++);
            root.right.left = new BinaryTree.TreeNode(currentVal++);
            root.right.right = new BinaryTree.TreeNode(currentVal++);
            root.left.left.right = new BinaryTree.TreeNode(currentVal++);
            root.right.left.left = new BinaryTree.TreeNode(currentVal++);
            root.right.left.right = new BinaryTree.TreeNode(currentVal++);
            root.right.right.left = new BinaryTree.TreeNode(currentVal++);
            root.right.right.right = new BinaryTree.TreeNode(currentVal++);

            return root;
        }
    }
}
