﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 3;
            int[] set = { 1, 1, 1, 1, 1 };
            SubsetSum calculator = new SubsetSum(sum, set);
            
            List<List<int>> result = calculator.GetSubsetSum();

            StringBuilder outputBuild = new StringBuilder("{" + Environment.NewLine);
            foreach (List<int> addendList in result)
            {
                outputBuild.Append("[");
                foreach(int addend in addendList)
                {
                    outputBuild.Append(addend.ToString() + ", ");
                }
                outputBuild.AppendLine("],");
            }
            outputBuild.AppendLine(Environment.NewLine + "}");

            Console.WriteLine($"result is {outputBuild.ToString()}");
            Console.ReadKey();
        }
    }
}
