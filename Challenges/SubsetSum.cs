using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    // https://www.coderbyte.com/algorithm/subset-sum-problem-revised
    // https://coderbyte.com/algorithm/subset-sum-problem?stay=true
    // NOTE: I need to go through these solutions an understand them

    public class SubsetSum
    {
        private static bool debug = true;

        private int sum;
        private int[] set;

        public SubsetSum(int sum, int[] set)
        {
            this.sum = sum;
            this.set = set;
        }

        public List<List<int>> GetSubsetSum()
        {
            List<List<int>> result = new List<List<int>>();
            Dictionary<int, List<List<int>>> sumsToSubsets = new Dictionary<int, List<List<int>>>();
            // seed the dictionary
            sumsToSubsets[0] = new List<List<int>>() { new List<int>() { } };

            Array.Sort(set);

            {/* Debugging */
                ConsoleDebug(IntListString(new List<int>(set)));
            }

            // iterate over integers in set
            foreach (int addend in set)
            {
                int sumMinusAddend = sum - addend; // interested in key == sumMinusAddend on this pass

                if (sumsToSubsets.ContainsKey(sumMinusAddend))
                {
                    UpdateWorkingResult(sumsToSubsets[sumMinusAddend], addend, ref result);
                }

                UpdateSumsToSubsets(addend, sumMinusAddend, ref sumsToSubsets);
            }

            return result;
        }

        private static void UpdateWorkingResult(List<List<int>> subsetsWithRequestedSum, int addend, ref List<List<int>> workingResult)
        {
            foreach (List<int> subset in subsetsWithRequestedSum)
            {
                int[] subsetCopy = new int[subset.Count];
                subset.CopyTo(subsetCopy);
                // addend==0 throws things off!
                if (addend == 0)
                {
                    workingResult.Add(new List<int>(subsetCopy));
                }

                List<int> subsetCopyList = new List<int>(subsetCopy);
                subsetCopyList.Add(addend);
                workingResult.Add(subsetCopyList);
            }

            {/* Debugging */
                ConsoleDebug("Result is now:");
                ConsoleDebugIntListList(workingResult);
            }
        }

        private static void UpdateSumsToSubsets(int addend, int sumMinusAddend, ref Dictionary<int, List<List<int>>> sumsToSubsets)
        {
            Dictionary<int, List<List<int>>> newSumsToSubsets = new Dictionary<int, List<List<int>>>();

            List<int> keys = new List<int>(sumsToSubsets.Keys);
            foreach (int key in keys)
            {
                {/* Debugging */
                    ConsoleDebug($"Updating key={key}.");
                }

                // use '>', not '>=' since we may have duplicate addends in set
                if (key > sumMinusAddend)
                {
                    RemoveKeyFromSumsToSubsets(sumsToSubsets, key);
                }
                else
                {
                    List<List<int>> newSubsets = GetSubsetCopiesWithNewAddend(sumsToSubsets[key], addend);

                    int newSum = key + addend;
                    if (newSumsToSubsets.ContainsKey(newSum))
                    {
                        newSumsToSubsets[newSum].AddRange(newSubsets);
                    }
                    else
                    {
                        newSumsToSubsets[newSum] = newSubsets;
                    }
                }
            }

            foreach (int key in newSumsToSubsets.Keys)
            {
                if (sumsToSubsets.ContainsKey(key))
                {
                    sumsToSubsets[key].AddRange(newSumsToSubsets[key]);
                }
                else
                {
                    sumsToSubsets[key] = newSumsToSubsets[key];
                }
            }

            {/* Debugging */
                ConsoleDebug($"SumsToSubsets now:");
                foreach (int key in sumsToSubsets.Keys)
                {
                    ConsoleDebug($"key={key}");
                    ConsoleDebugIntListList(sumsToSubsets[key]);
                }
            }
        }

        private static void RemoveKeyFromSumsToSubsets(Dictionary<int, List<List<int>>> sumsToSubsets, int keyToRemove)
        {
            sumsToSubsets.Remove(keyToRemove);
            ConsoleDebug($"Removed key={keyToRemove}.");
        }

        private static List<List<int>> GetSubsetCopiesWithNewAddend(List<List<int>> subsetsToCopyAndAugment, int addend)
        {
            List<List<int>> result = new List<List<int>>();

            foreach (List<int> subsetToCopyAndAugment in subsetsToCopyAndAugment)
            {
                List<int> newSubset = CloneAndAddToList(subsetToCopyAndAugment, addend);
                result.Add(newSubset);
            }

            return result;
        }

        #region Helpers
        private static List<int> CloneAndAddToList(List<int> listToCloneAndAugment, int addend)
        {
            int[] listCopy = new int[listToCloneAndAugment.Count];
            listToCloneAndAugment.CopyTo(listCopy);
            List<int> newList = new List<int>(listCopy);
            newList.Add(addend);

            return newList;
        }
        #endregion

        #region Debugging
        private static void ConsoleDebugIntListList(List<List<int>> intListList)
        {
            if (debug)
            {
                ConsoleDebug($"{IntListListString(intListList)}");
            }
        }

        private static void ConsoleDebug(string message)
        {
            if (debug)
            {
                Console.WriteLine(message);
            }
        }

        private static void ConsoleDebugInitialConditions(Dictionary<int, List<List<int>>> sumsToAddends)
        {
            if (debug)
            {
                ConsoleDebug($"initial SumsToAddends:");
                foreach (int key in sumsToAddends.Keys)
                {
                    ConsoleDebug($"key={key}");
                    ConsoleDebugIntListList(sumsToAddends[key]);
                }

            }
        }

        private static string IntListString(List<int> intList)
        {
            StringBuilder result = new StringBuilder("[ ");
            foreach (int addend in intList)
            {
                result.Append(addend.ToString() + ", ");
            }
            result.AppendLine("]");

            return result.ToString();
        }

        private static string IntListListString(List<List<int>> intList)
        {
            StringBuilder result = new StringBuilder("{" + Environment.NewLine);
            foreach (List<int> addendList in intList)
            {
                result.AppendLine(IntListString(addendList));
            }
            result.AppendLine(Environment.NewLine + "}");

            return result.ToString();
        }
        #endregion
    }
}
