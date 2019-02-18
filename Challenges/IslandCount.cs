using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    // Consider an nxn square array of 1s and 0s, where 1 represents land and 0 represents water. Adjacent 1s
    // can be considered as joined together to form a sort of island in water.
    // Count the number of islands.
    // Discuss complexity.
    // Additional assumptions/ambiguities:
    //      1) "Adjacent" means up/down/left/right (not diagonal).
    //      2) A single '1' with no adjacent 1s counts as an island.
    //
    // Approach:
    //      2D-iterate looking for 1s. Each iteration, add (i, j) to list of examined cells if not already added.
    //      When a 1 is found that is not in the "already scanned" list, increment count and enter `IslandScan`
    //      `IslandScan` recursively looks at the current 1 and its up, down, left, and right cells, adding to
    //      the already scanned list but not incrementing the count
    //      Once a call to `IslandScan` is complete, return to the main iteration, calling continue when hitting a cell
    //      already scanned.
    //      Without `IslandScan`, situations like the following would over-count:
    //  001000110
    //  011111110
    //  010011000
    //
    //      Here we have a single island that would likely be counted 3 times!
    //
    public class IslandCount
    {
        string input;

        public string GetResult()
        {
            return "";
        }
    }
}
