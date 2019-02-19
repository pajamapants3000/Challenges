using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    // This question was marked as "Easy" but is ridiculously hard! All the other problems I've solved have had a huge list of
    // people with perfect scores. This one has only a handful, and I'm guessing most, if not all, of them are like me and got
    // the perfect score by "redo"ing the problem.
    public class CorrectPath
    {
        const bool debug = false;

        string input;

        int gridSize = 5;
        int[][] cellsTravelled = new int[][]
        {
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
        };

        public CorrectPath(string input)
        {
            this.input = input;
        }

        public string GetResult()
        {
            string result = input;

            int[][] cellsTravelled = new int[][]
            {
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0},
            };

            result = GetSubResult(0, 0, cellsTravelled, result);
            if (result != null)
            {
                return result;
            }
            else
            {
                return "Improper input - no result possible.";
            }
        }

        private string GetSubResult(int currentRight, int currentDown, int[][] cellsTravelled, string input)
        {
            ConsoleDebug($"calling GetSubResult with input={input}; right={currentRight}; down={currentDown}");
            int rightStepsCount = currentRight;
            int downStepsCount = currentDown;

            StringBuilder workingResult = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                ConsoleDebug($"char = {input[i].ToString()}");
                char nextChar = '?';

                switch (input[i])
                {
                    case 'r':
                        rightStepsCount++;
                        nextChar = 'r';
                        break;
                    case 'l':
                        rightStepsCount--;
                        nextChar = 'l';
                        break;
                    case 'u':
                        downStepsCount--;
                        nextChar = 'u';
                        break;
                    case 'd':
                        downStepsCount++;
                        nextChar = 'd';
                        break;
                    case '?':
                        ConsoleDebug("? encountered.");
                        int questionMarkCount = 1;
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            if (input[j] == '?')
                                questionMarkCount++;
                            else
                                break;
                        }
                        foreach (char c in "lrud")
                        {
                            int _rightStepsCount = rightStepsCount;
                            int _downStepsCount = downStepsCount;
                            switch (input[i])
                            {
                                case 'r':
                                    _rightStepsCount += questionMarkCount;
                                    break;
                                case 'l':
                                    _rightStepsCount -= questionMarkCount;
                                    break;
                                case 'u':
                                    _downStepsCount -= questionMarkCount;
                                    break;
                                case 'd':
                                    _downStepsCount += questionMarkCount;
                                    break;
                            }

                            string temp = String.Concat(new String(c, questionMarkCount), input.Substring(i + questionMarkCount));
                            int[][] tempCellsTravelled = new int[][]
                            {
                                new int[]{0, 0, 0, 0, 0},
                                new int[]{0, 0, 0, 0, 0},
                                new int[]{0, 0, 0, 0, 0},
                                new int[]{0, 0, 0, 0, 0},
                                new int[]{0, 0, 0, 0, 0},
                            };
                            for (int l = 0; l < gridSize; l++)
                            {
                                for (int m = 0; m < gridSize; m++)
                                {
                                    tempCellsTravelled[l][m] = cellsTravelled[l][m];
                                }
                            }
                            temp = GetSubResult(_rightStepsCount, _downStepsCount, tempCellsTravelled, temp);
                            if (temp != null)
                            {
                                workingResult.Append(temp);
                                cellsTravelled = tempCellsTravelled;
                                ConsoleDebug($"TRUE with {workingResult.ToString()}; right={_rightStepsCount}; down={_downStepsCount}");
                                return workingResult.ToString();
                            }
                            else
                            {
                                if (c == 'd') return null;
                            }
                        }
                        break;
                }


                if (rightStepsCount < 0 || gridSize <= rightStepsCount) return null;
                if (downStepsCount < 0 || gridSize <= downStepsCount) return null;

                if (cellsTravelled[rightStepsCount][downStepsCount] == 1)
                {
                    ConsoleDebug($"repeat cell {rightStepsCount}, {downStepsCount}");
                    return null;
                }
                else
                {
                    ConsoleDebug($"travelled cell {rightStepsCount}, {downStepsCount}");
                    cellsTravelled[rightStepsCount][downStepsCount] = 1;
                }

                workingResult.Append(nextChar.ToString());
            }

            if (rightStepsCount == (gridSize - 1) && downStepsCount == (gridSize - 1))
            {
                ConsoleDebug($"TRUE with {input}; right={currentRight}; down={currentDown}");
                return workingResult.ToString();
            }
            ConsoleDebug($"FALSE with {input}; right={currentRight}; down={currentDown}");
            return null;
        }

        private void ConsoleDebug(string message)
        {
            if (debug)
            {
                Console.WriteLine(message);
            }
        }
    }
}
