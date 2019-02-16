using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] set = { 0 };
            int sum = 0;

            SubsetSum calculator = new SubsetSum(sum, set);
            
            Console.WriteLine(SubsetSumResultOutput(calculator.GetResult()));

            Console.ReadKey();
        }

        static string SubsetSumResultOutput(List<List<int>> result)
        {
            StringBuilder outputBuild = new StringBuilder("{" + Environment.NewLine);
            foreach (List<int> addendList in result)
            {
                outputBuild.Append("[");
                foreach (int addend in addendList)
                {
                    outputBuild.Append(addend.ToString() + ", ");
                }
                outputBuild.AppendLine("],");
            }
            outputBuild.AppendLine(Environment.NewLine + "}");

            return $"result is {outputBuild.ToString()}";
        }
    }
}
