using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Extensions;

namespace Challenges
{
    public class BinaryTreeContains
    {
        BinaryNode root;
        BinaryNode toMatchRoot;

        public BinaryTreeContains(BinaryNode root, BinaryNode toMatchRoot)
        {
            this.root = root;
            this.toMatchRoot = toMatchRoot;
        }

        public bool GetResult()
        {
            return GetResultViaInOrderAndPrefixCompare();
        }

        public bool GetResultViaStringRepresentation()
        {
            return EncodeBinaryTree(root).Contains(EncodeBinaryTree(toMatchRoot));
        }

        public bool GetResultViaInOrderAndPrefixCompare()
        {
            int[] rootInOrder = new int[0];
            GetInOrderArray(root, ref rootInOrder);
            int[] rootPrefix = new int[0];
            GetPrefixArray(root, ref rootPrefix);

            int[] toMatchInOrder = new int[0];
            GetInOrderArray(toMatchRoot, ref toMatchInOrder);
            int[] toMatchPrefix = new int[0];
            GetPrefixArray(toMatchRoot, ref toMatchPrefix);

            return rootInOrder.StartingIndex(toMatchInOrder).Any() && rootPrefix.StartingIndex(toMatchPrefix).Any();
        }

        private void GetInOrderArray(BinaryNode root, ref int[] inOrder)
        {
            if (root == null)
                throw new ArgumentException("root node cannot be null.");

            if (root.left != null)
                GetInOrderArray(root.left, ref inOrder);

            inOrder.Concat(new int[] { root.value });

            if (root.right != null)
                GetInOrderArray(root.right, ref inOrder);
        }

        private void GetPrefixArray(BinaryNode root, ref int[] prefix)
        {
            if (root == null)
                throw new ArgumentException("root node cannot be null.");

            prefix.Concat(new int[] { root.value });

            if (root.left != null)
                GetInOrderArray(root.left, ref prefix);

            if (root.right != null)
                GetInOrderArray(root.right, ref prefix);
        }

        // this is tough! format: "15((16, 23(15, 11(,43))), 98(33,))"; i.e. ROOT(LEFT,RIGHT)
        public void DecodeBinaryTree(string encodedTree, ref BinaryNode root)
        {
            // if encodedTree == "", return; else root = new BinaryNode()
            // strip number from front and parse to root.value
            // strip surrounding parents -> left with "LEFT,RIGHT"
            // find correct comma; should be preceeded with equal number of open/close parens
            //  at each comma, check number of open/close for match
            //  will always be at least one comma
            // everything before comma (LEFT) -> DecodeBinaryTree(LEFT, root.left)
            // everything after comma (RIGHT) ->  DecodeBinaryTree(RIGHT, root.right)
        }

        public string EncodeBinaryTree(BinaryNode root)
        {
            if (root == null)
                return "";

            return $"{root.value}({EncodeBinaryTree(root.left)}, {EncodeBinaryTree(root.right)})";
        }

        public class BinaryNode
        {
            public int value;
            public BinaryNode left;
            public BinaryNode right;

            public BinaryNode(int value = 0, BinaryNode left = null, BinaryNode right = null)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }
    }
}
