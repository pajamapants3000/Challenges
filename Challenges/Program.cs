using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            //int num = 2111;

            //KaprekarsConstant calculator = new KaprekarsConstant(num);

            //Console.WriteLine($"result = {calculator.GetResult()}");

            QuestionsMarks.RunTests();
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
