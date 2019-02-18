using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    public class KaprekarsConstant
    {
        public bool debug = false;
        const int kaprekarsConstant = 6174;

        // Can assume input is a 4-digit number with at least two distinct digits
        int input;
        // should finish in at most 8 iterations (ref: "https://en.wikipedia.org/wiki/6174_(number)")
        int failAtCount = 8;

        public KaprekarsConstant(int input)
        {
            this.input = input;
        }

        public int GetResult()
        {
            int count = 0;
            int workingResult = input;

            while ((workingResult != kaprekarsConstant) && (count < failAtCount))
            {
                count++;

                ConsoleDebug($"count = {count}:");

                int asc = GetAscendingNumber(workingResult);
                int desc = GetDescendingNumber(workingResult);

                workingResult = desc - asc;

                ConsoleDebug($"{desc.ToString()} - {asc.ToString()} = {workingResult.ToString()}");
                DebugStop();
            }
            return count;
        }

        private int GetAscendingNumber(int num)
        {
            ConsoleDebug($"Converting {num.ToString()} to ascending.");

            string asc = GetAscendingString(num);

            ConsoleDebug($"Ascending order: {asc}.");

            return int.Parse(asc);
        }

        private int GetDescendingNumber(int num)
        {
            ConsoleDebug($"Converting {num.ToString()} to descending.");

            string desc = GetAscendingString(num);
            desc = String.Concat(desc.Reverse());

            ConsoleDebug($"Descending order: {desc}.");

            return int.Parse(desc);
        }

        private string GetAscendingString(int num)
        {
            string asc = String.Concat(num.ToString().OrderBy(c => c));
            return PadStartToFour(asc);
        }

        private string PadStartToFour(string num)
        {
            ConsoleDebug($"Padding start of {num.ToString()} to four.");

            int zeroCountToAdd = ((4 - num.ToString().Length) > 0) ? (4 - num.ToString().Length) : 0;
            ConsoleDebug($"zeroCountToAdd = {zeroCountToAdd.ToString()}");

            string zeros = new string('0', zeroCountToAdd);
            ConsoleDebug($"zeros = {zeros}");

            ConsoleDebug($"PadToFour returning {zeros + num.ToString()}");
            return zeros + num.ToString();
        }

        private void ConsoleDebug(string message)
        {
            if (this.debug)
                Console.WriteLine(message);
        }

        private void DebugStop()
        {
            if (this.debug)
                Console.ReadKey();
        }
    }
}
