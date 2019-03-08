using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class BinaryTree
    {
        TreeNode input;

        public BinaryTree(TreeNode input)
        {
            this.input = input;
        }

        public List<int> GetResult()
        {
            List<int> result = new List<int>();

            return result;
        }

        public static IList<int> PreOrderRecursive(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            result.Add(root.val);
            result.AddRange(PreOrderRecursive(root.left));
            result.AddRange(PreOrderRecursive(root.right));

            return result;
        }

        public static IList<int> MirrorPreOrderRecursive(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            result.Add(root.val);
            result.AddRange(MirrorPreOrderRecursive(root.right));
            result.AddRange(MirrorPreOrderRecursive(root.left));

            return result;
        }

        public static IList<int> InOrderRecursive(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            if (root.left != null)
                result.AddRange(InOrderRecursive(root.left));
            result.Add(root.val);
            if (root.right != null)
                result.AddRange(InOrderRecursive(root.right));

            return result;
        }

        public static IList<int> MirrorInOrderRecursive(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            if (root.right != null)
                result.AddRange(MirrorInOrderRecursive(root.right));
            result.Add(root.val);
            if (root.left != null)
                result.AddRange(MirrorInOrderRecursive(root.left));

            return result;
        }

        public static IList<int> PostOrderRecursive(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            if (root.left != null)
                result.AddRange(PostOrderRecursive(root.left));
            if (root.right != null)
                result.AddRange(PostOrderRecursive(root.right));
            result.Add(root.val);

            return result;
        }

        public static IList<int> MirrorPostOrderRecursive(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            if (root.right != null)
                result.AddRange(MirrorPostOrderRecursive(root.right));
            if (root.left != null)
                result.AddRange(MirrorPostOrderRecursive(root.left));
            result.Add(root.val);

            return result;
        }

        public static IList<int> PreorderIterative(TreeNode root)
        {
            List<int> result = new List<int>();

            List<NodeProcessingState> nodeList = new List<NodeProcessingState>();
            nodeList.Add(new NodeProcessingState(root));
            int currentNodeInList = 0;

            result.Add(nodeList[currentNodeInList].node.val);

            while (nodeList.Count != 0)
            {
                if (!(nodeList[currentNodeInList].isLeftNodeProcessed || nodeList[currentNodeInList].node.left == null))
                {
                    nodeList.Add(new NodeProcessingState(nodeList[currentNodeInList].node.left));
                    NodeProcessingState toUpdate = nodeList[currentNodeInList];
                    toUpdate.isLeftNodeProcessed = true;
                    nodeList[currentNodeInList] = toUpdate;
                    currentNodeInList++;
                    result.Add(nodeList[currentNodeInList].node.val);
                }
                else if (!(nodeList[currentNodeInList].isRightNodeProcessed || nodeList[currentNodeInList].node.right == null))
                {
                    nodeList.Add(new NodeProcessingState(nodeList[currentNodeInList].node.right));
                    NodeProcessingState toUpdate = nodeList[currentNodeInList];
                    toUpdate.isRightNodeProcessed = true;
                    nodeList[currentNodeInList] = toUpdate;
                    currentNodeInList++;
                    result.Add(nodeList[currentNodeInList].node.val);
                }
                else
                {
                    nodeList.RemoveAt(currentNodeInList);
                    currentNodeInList--;
                }
            }

            return result;
        }

        public static IList<int> MirrorPreorderIterative(TreeNode root)
        {
            List<int> result = new List<int>();

            List<NodeProcessingState> nodeList = new List<NodeProcessingState>();
            nodeList.Add(new NodeProcessingState(root));
            int currentNodeInList = 0;

            result.Add(nodeList[currentNodeInList].node.val);

            while (nodeList.Count != 0)
            {
                if (!(nodeList[currentNodeInList].isRightNodeProcessed || nodeList[currentNodeInList].node.right == null))
                {
                    nodeList.Add(new NodeProcessingState(nodeList[currentNodeInList].node.right));
                    NodeProcessingState toUpdate = nodeList[currentNodeInList];
                    toUpdate.isRightNodeProcessed = true;
                    nodeList[currentNodeInList] = toUpdate;
                    currentNodeInList++;
                    result.Add(nodeList[currentNodeInList].node.val);
                }
                else if (!(nodeList[currentNodeInList].isLeftNodeProcessed || nodeList[currentNodeInList].node.left == null))
                {
                    nodeList.Add(new NodeProcessingState(nodeList[currentNodeInList].node.left));
                    NodeProcessingState toUpdate = nodeList[currentNodeInList];
                    toUpdate.isLeftNodeProcessed = true;
                    nodeList[currentNodeInList] = toUpdate;
                    currentNodeInList++;
                    result.Add(nodeList[currentNodeInList].node.val);
                }
                else
                {
                    nodeList.RemoveAt(currentNodeInList);
                    currentNodeInList--;
                }
            }

            return result;
        }

        public static IList<int> PreorderIterative_BestMemory1(TreeNode root)
        {
            if (root == null) { return new List<int>(); }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();

            result.Add(root.val);
            if (root.right != null) stack.Push(root.right);
            if (root.left != null) stack.Push(root.left);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);
                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);

            }

            return result;
        }

        public static IList<int> InorderIterative(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<NodeProcessingState> nodes = new Stack<NodeProcessingState>();
            nodes.Push(new NodeProcessingState(root));
            NodeProcessingState temp;

            while (nodes.TryPop(out temp))
            {
                if (!(temp.isLeftNodeProcessed || temp.node.left == null))
                {
                    temp.isLeftNodeProcessed = true;
                    nodes.Push(temp);
                    nodes.Push(new NodeProcessingState(temp.node.left));
                }
                else
                {
                    if (!temp.isRightNodeProcessed)
                    {
                        result.Add(temp.node.val);
                    }

                    if (!(temp.isRightNodeProcessed || temp.node.right == null))
                    {
                        temp.isRightNodeProcessed = true;
                        nodes.Push(temp);
                        nodes.Push(new NodeProcessingState(temp.node.right));
                    }
                }
            }

            return result;
        }
        public static IList<int> MirrorInorderIterative(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<NodeProcessingState> nodes = new Stack<NodeProcessingState>();
            nodes.Push(new NodeProcessingState(root));
            NodeProcessingState temp;

            while (nodes.TryPop(out temp))
            {
                if (!(temp.isRightNodeProcessed || temp.node.right == null))
                {
                    temp.isRightNodeProcessed = true;
                    nodes.Push(temp);
                    nodes.Push(new NodeProcessingState(temp.node.right));
                }
                else
                {
                    if (!temp.isLeftNodeProcessed)
                    {
                        result.Add(temp.node.val);
                    }

                    if (!(temp.isLeftNodeProcessed || temp.node.left == null))
                    {
                        temp.isLeftNodeProcessed = true;
                        nodes.Push(temp);
                        nodes.Push(new NodeProcessingState(temp.node.left));
                    }
                }
            }

            return result;
        }

        public static IList<int> InOrder_BestMemory1(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }
            var s = new Stack<TreeNode>();
            s.Push(root);
            while (root.left != null)
            {
                s.Push(root.left);
                root = root.left;
            }
            while (s.Count > 0)
            {
                var node = s.Pop();
                result.Add(node.val);
                if (node.right != null)
                {
                    result.AddRange(InOrder_BestMemory1(node.right));
                }
            }
            return result;
        }

        public static IList<int> PostOrderIterative(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<NodeProcessingState> nodes = new Stack<NodeProcessingState>();
            nodes.Push(new NodeProcessingState(root));
            NodeProcessingState temp;

            while (nodes.TryPop(out temp))
            {
                if (!(temp.isLeftNodeProcessed || temp.node.left == null))
                {
                    temp.isLeftNodeProcessed = true;
                    nodes.Push(temp);
                    nodes.Push(new NodeProcessingState(temp.node.left));
                }
                else if (!(temp.isRightNodeProcessed || temp.node.right == null))
                {
                    temp.isRightNodeProcessed = true;
                    nodes.Push(temp);
                    nodes.Push(new NodeProcessingState(temp.node.right));
                }
                else
                {
                    result.Add(temp.node.val);
                }
            }

            return result;
        }

        public static IList<int> MirrorPostOrderIterative(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<NodeProcessingState> nodes = new Stack<NodeProcessingState>();
            nodes.Push(new NodeProcessingState(root));
            NodeProcessingState temp;

            while (nodes.TryPop(out temp))
            {
                if (!(temp.isRightNodeProcessed || temp.node.right == null))
                {
                    temp.isRightNodeProcessed = true;
                    nodes.Push(temp);
                    nodes.Push(new NodeProcessingState(temp.node.right));
                }
                else if (!(temp.isLeftNodeProcessed || temp.node.left == null))
                {
                    temp.isLeftNodeProcessed = true;
                    nodes.Push(temp);
                    nodes.Push(new NodeProcessingState(temp.node.left));
                }
                else
                {
                    result.Add(temp.node.val);
                }
            }

            return result;
        }

        public static IList<IList<int>> LevelOrderTraversal(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int currentLevel = 1;

            if (root == null) return result;

            Stack<NodeProcessingState> nodes = new Stack<NodeProcessingState>();
            nodes.Push(new NodeProcessingState(root));
            result.Add(new List<int>());
            NodeProcessingState temp;

            while (nodes.TryPop(out temp))
            {
                currentLevel--;
                if (!(temp.isLeftNodeProcessed || temp.node.left == null))
                {
                    temp.isLeftNodeProcessed = true;
                    nodes.Push(temp);
                    nodes.Push(new NodeProcessingState(temp.node.left));
                    currentLevel += 2;
                    if (result.Count < currentLevel) result.Add(new List<int>());
                }
                else
                {
                    if (!temp.isRightNodeProcessed)
                    {
                        result[currentLevel].Add(temp.node.val);
                    }

                    if (!(temp.isRightNodeProcessed || temp.node.right == null))
                    {
                        temp.isRightNodeProcessed = true;
                        nodes.Push(temp);
                        nodes.Push(new NodeProcessingState(temp.node.right));
                        currentLevel += 2;
                        if (result.Count < currentLevel) result.Add(new List<int>());
                    }
                }
            }

            return result;
        }

        public static IList<IList<int>> LevelOrderTraversal_BestMemory(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                IList<int> currentLevel = new List<int>();
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    currentLevel.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(currentLevel);
            }
            return result;
        }

        public static int MaxDepth(TreeNode root)
        {
            int result = 0;
            if (root == null)
                return result;
            else
                result++;

            result += Math.Max(MaxDepth(root.left),
                               MaxDepth(root.right));

            return result;
        }

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            IList<int> inOrder = InOrderRecursive(root.left);
            IList<int> mirrorInOrder = MirrorInOrderRecursive(root.right);
            if (inOrder.Count != mirrorInOrder.Count) return false;
            for (int i = 0; i < inOrder.Count; i++)
                if (inOrder[i] != mirrorInOrder[i]) return false;

            IList<int> postOrder = PostOrderRecursive(root.left);
            IList<int> mirrorPostOrder = MirrorPostOrderRecursive(root.right);
            if (postOrder.Count != mirrorPostOrder.Count) return false;
            for (int i = 0; i < postOrder.Count; i++)
                if (postOrder[i] != mirrorPostOrder[i]) return false;

            return true;
        }

        public static bool IsSymmetric_BestMemory1(TreeNode root)
        {
            if (root == null) return true;
            return IsSymmetric_BestMemory1_Helper(root.left, root.right);
        }

        public static bool IsSymmetric_BestMemory1_Helper(TreeNode left, TreeNode right)
        {
            if (left == null || right == null) return left == right;
            if (left.val != right.val) return false;
            return IsSymmetric_BestMemory1_Helper(left.left, right.right) &&
                IsSymmetric_BestMemory1_Helper(left.right, right.left);
        }

        public static bool IsLeafNode(TreeNode root)
        {
            return (root.left == null && root.right == null);
        }
        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return sum == 0;

            if (IsLeafNode(root)) return (sum == root.val);

            return HasPathSum(root.left, sum - root.val) ||
                HasPathSum(root.right, sum - root.val);
        }

        // Root{left, right}: {1{2{4{,8}, 5}, 3{6{9, 10}, 7{11, 12}}}}
        // PreOrder: {1, 2, 4, 8, 5, 3, 6, 9, 10, 7, 11, 12}
        // InOrder: {4, 8, 2, 5, 1, 9, 6, 10, 3, 11, 7, 12}
        // PostOrder: {8, 4, 5, 2, 9, 10, 6, 11, 12, 7, 3, 1}
        // LevelOrder: {{1}, {2, 3}, {4, 5, 6, 7}, {8, 9, 10, 11, 12}}
        public static BinaryTree.TreeNode testTree1()
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

        // Root{left, right}: {1{2{3, 4}, 2{4, 3}}}
        // PreOrder: {1, 2, 3, 4, 2, 4, 3}
        // MirrorPreOrder: {1, 2, 3, 4, 2, 4, 3}
        // InOrder: {3, 2, 4, 1, 4, 2, 3}
        // MirrorInOrder: {3, 2, 4, 1, 4, 2, 3}
        // PostOrder: {3, 4, 2, 4, 3, 2, 1}
        // MirrorPostOrder: {3, 4, 2, 4, 3, 2, 1}
        public static BinaryTree.TreeNode testTree_symmetric()
        {
            BinaryTree.TreeNode root = new BinaryTree.TreeNode(1);

            root.left = new BinaryTree.TreeNode(2);
            root.right = new BinaryTree.TreeNode(2);

            root.left.left = new BinaryTree.TreeNode(3);
            root.left.right = new BinaryTree.TreeNode(4);
            root.right.left = new BinaryTree.TreeNode(4);
            root.right.right = new BinaryTree.TreeNode(3);

            return root;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public struct NodeProcessingState
        {
            public TreeNode node { get; set; }
            public bool isLeftNodeProcessed { get; set; }
            public bool isRightNodeProcessed { get; set; }

            public NodeProcessingState(TreeNode node)
            {
                this.node = node;
                this.isLeftNodeProcessed = false;
                this.isRightNodeProcessed = false;
            }
        }
    }
}
