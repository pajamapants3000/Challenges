using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    // https://www.coderbyte.com/algorithm/subset-sum-problem-revised
    // https://coderbyte.com/algorithm/subset-sum-problem?stay=true
    // NOTE: I need to go through these solutions an understand them

    // I sort of threw this together and played with it until it worked (realized the importance of a few weird test cases to
    // really reveal bugs).
    // How should I have done this?

    /* Algorithm/Data Structures: */
    // 0. Start with a set of integers (`set`) and an integer (`sum`) to be the desired sum;
    //  create a mapping of sums to integer subsets (`mapping`) for working data,
    //  and an additional list of subsets (`result`) to be the result (subset-)set.
    //  Seed `mapping` with a single key, 0, to an empty subset (set `mapping[0] = {{}}`)
    // 1. Sort set, smallest to largest (ascending order)
    // 2. Set `i = 0`
    // 3. Take the integer `addend = set[i]`, in the set
    // 4. Determine `diff = sum - addend`
    // 5. Drop all keys in `mapping` that are greater than diff
    // 6. Take `newResultSubset = mapping[diff]`
    // 7. For each `subset` in `newResultSubset`:
    //      7.1. append `addend` to `subset`
    //      7.2. append `subset` to `result`
    // 8. Create `tempMapping` of sums->subsets; For each key `key` in `mapping` s.t. `key+addend <= sum-addend => key <= sum - 2*addend` (we know next addend will be >= addend):
    //      8.1. For each `subset` in `mapping[key]`:
    //          8.1.1. clone `subset` into `newSubset`
    //          8.1.2. append `addend` to `newSubset`
    //          8.1.3. If `key+addend` is not a key in `tempMapping`, set `tempMapping[key+addend] = new List<List<int>>()`
    //          8.1.4. append `newSubset` to `tempMapping[key+addend]`
    // 9. For each key `key` in tempMapping:
    //      9.1. If `key` is not a key in `mapping`, set `mapping[key] = new List<List<int>>()`
    //      9.2. append range in `tempMapping[key]` to `mapping[key]`
    // 10. Increment `i`; If `i` < set.Count, return to (3); else return `result`.

    public class SubsetSum
    {
        private static bool debug = true;

        private int sum;
        private int[] set;

        private Dictionary<int, List<List<int>>> mapping = new Dictionary<int, List<List<int>>>() { { 0, new List<List<int>>() { new List<int>() { } } } };
        private List<List<int>> result = new List<List<int>>();

        public SubsetSum(int sum, int[] set)
        {
            this.sum = sum;
            this.set = set;
        }

        public List<List<int>> GetResult()
        {
            // 1
            Array.Sort(set);

            {/* Debugging */
                ConsoleDebug($"Calculating subsets of {IntListString(new List<int>(set))} which add to {sum}");
            }

            // iterate over integers in set (2 - 9)
            foreach (int addend in set) // 2, 3
            {
                int diff = sum - addend; // 4

                mapping = GetStillUsefulMappings(diff);    // 5

                // 6, 7
                if (mapping.ContainsKey(diff))
                {
                    // add all subsets with sum == sumMinusAddend, with addend appended to each subset
                    result.AddRange(GetSubsetsCopiedWithNewAddend(mapping[diff], addend));

                    {/* Debugging */
                        ConsoleDebug("Result is now:");
                        ConsoleDebugIntListList(result);
                    }
                }

                // 8, 9
                UpdateMapping(addend);
            }

            // 9
            return result;
        }

        private Dictionary<int, List<List<int>>> GetStillUsefulMappings(int maxKey)
        {
            Dictionary<int, List<List<int>>> result = new Dictionary<int, List<List<int>>>();
            foreach (int key in mapping.Keys)
                if (key <= maxKey)
                    result[key] = mapping[key];

            return result;
        }

        private void UpdateMapping(int addend)
        {
            // 8
            Dictionary<int, List<List<int>>> tempMapping = GetMappingCopiesWithNewAddend(addend);

            // 9
            foreach (int key in tempMapping.Keys)
            {
                // 9.1
                if (!mapping.ContainsKey(key))
                    mapping[key] = new List<List<int>>();
                // 9.2
                mapping[key].AddRange(tempMapping[key]);
            }

            {/* Debugging */
                ConsoleDebug($"SumsToSubsets now:");
                ConsoleDebugSumsToSubsets(mapping);
            }
        }

        private Dictionary<int, List<List<int>>> GetMappingCopiesWithNewAddend(int addend)
        {
            Dictionary<int, List<List<int>>> result = new Dictionary<int, List<List<int>>>();

            // 8.1
            foreach (int key in mapping.Keys)
            {
                int newSum = key + addend;
                // subsequent addends will be >= current addend; no use if (newSum + addend) > sum
                if ((newSum + addend) > sum)
                    continue;

                // 8.1.1, 8.1.2
                List<List<int>> newSubsets = GetSubsetsCopiedWithNewAddend(mapping[key], addend);

                // 8.1.3
                if (!result.ContainsKey(newSum))
                    result[newSum] = new List<List<int>>();

                // 8.1.4
                result[newSum].AddRange(newSubsets);
            }

            return result;
        }

        private static List<List<int>> GetSubsetsCopiedWithNewAddend(List<List<int>> subsets, int addend)
        {
            List<List<int>> result = new List<List<int>>();

            foreach (List<int> subset in subsets)
            {
                // 8.1.1, 8.1.2
                List<int> newSubset = GetSubsetCopiedWithNewAddend(subset, addend);
                result.Add(newSubset);
            }

            return result;
        }

        private static List<int> GetSubsetCopiedWithNewAddend(List<int> subset, int addend)
        {
            int[] subsetCopy = new int[subset.Count];
            // 8.1.1
            subset.CopyTo(subsetCopy);
            List<int> result = new List<int>(subsetCopy);
            // 8.1.2
            result.Add(addend);

            return result;
        }

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

        private static void ConsoleDebugSumsToSubsets(Dictionary<int, List<List<int>>> sumsToSubsets)
        {
            if (debug)
            {
                foreach (int key in sumsToSubsets.Keys)
                {
                    ConsoleDebug($"key={key}");
                    ConsoleDebugIntListList(sumsToSubsets[key]);
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
            result.Append("]");

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
