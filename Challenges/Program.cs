using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "done?";
            LetterChanges calculator = new LetterChanges(str);
            
            Console.WriteLine(calculator.GetResult());

            Console.ReadKey();
        }

        static void PrintSubsetSumResult(List<List<int>> result)
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

            Console.WriteLine($"result is {outputBuild.ToString()}");
        }
    }
}
