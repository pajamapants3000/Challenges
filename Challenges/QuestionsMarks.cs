using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    // NOTE: I solved the problem as stated, but I'm pretty sure they meant two _consecutive_ numbers that add up to ten.
    // As a result, I did not get all test cases correct, but my results are as I intended and as I interpreted the question.
    public class QuestionsMarks
    {
        string input;

        public QuestionsMarks(string input)
        {
            this.input = input;
        }

        public string GetResult()
        {
            int resultPassCount = 0;
            int resultFailCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    int firstNumber = int.Parse(input[i].ToString());
                    int questionMarksCount = 0;

                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == '?') questionMarksCount++;

                        if (Char.IsDigit(input[j]))
                        {
                            int secondNumber = int.Parse(input[j].ToString());
                            if ((firstNumber + secondNumber) == 10)
                            {
                                if (questionMarksCount == 3) resultPassCount++;
                                else resultFailCount++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(resultPassCount.ToString());
            Console.WriteLine(resultFailCount.ToString());
            if (resultFailCount == 0 && resultPassCount != 0)
            {
                return "true";
            }
            return "false";
        }

        public static bool RunTests()
        {
            bool areAllTestsPassing = true;

            string[] testCases = new string[]
            {
                "aa6?9",
                "acc?7??sss?3rr1??????5",
            };

            string[] expectedCases = new string[]
            {
                "false",
                "true",
            };

            for (int i = 0; i < testCases.Length; i++)
            {
                if (!Test(testCases[i], expectedCases[i])) areAllTestsPassing = false;
            }

            return areAllTestsPassing;
        }

        public static bool Test(string input, string expected)
        {
            Console.WriteLine($"Testing QuestionsMarks with input {input}:");
            QuestionsMarks testCase = new QuestionsMarks(input);

            string result = testCase.GetResult();

            if (result != expected)
            {
                Console.WriteLine($"Expected {expected}, got {result}.");
                return false;
            }

            Console.WriteLine("Success!.");
            return true;
        }
    }
}
