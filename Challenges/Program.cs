using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            //SubsetSum calculator = new SubsetSum(13, new int[] { 1, 3, 13, 10, 7, 4, 8 });
            //Console.WriteLine(calculator.GetResult());
            Console.WriteLine(PrintListInt(BinaryTree.InOrderRecursive(BinaryTree.testTree_symmetric())));
            Console.WriteLine(PrintListInt(BinaryTree.MirrorInOrderRecursive(BinaryTree.testTree_symmetric())));
            Console.WriteLine(PrintListInt(BinaryTree.PostOrderRecursive(BinaryTree.testTree_symmetric())));
            Console.WriteLine(PrintListInt(BinaryTree.MirrorPostOrderRecursive(BinaryTree.testTree_symmetric())));

            stopwatch.Stop();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }


        static string PrintListInt(IList<int> nums)
        {
            StringBuilder outputBuild = new StringBuilder();
            outputBuild.Append("[");
            foreach (int num in nums)
            {
                outputBuild.Append(num.ToString() + ", ");
            }
            outputBuild.Append("]");

            return outputBuild.ToString();
        }
        static string PrintListListInt(IList<IList<int>> listListNums)
        {
            StringBuilder outputBuild = new StringBuilder("{" + Environment.NewLine);
            foreach (List<int> listNums in listListNums)
            {
                outputBuild.AppendLine($"{PrintListInt(listNums)}, ");
            }
            outputBuild.AppendLine(Environment.NewLine + "}");

            return outputBuild.ToString();
        }
    }
}