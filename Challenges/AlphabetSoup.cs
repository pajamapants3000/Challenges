using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    public class AlphabetSoup
    {
        string input;

        public AlphabetSoup(string input)
        {
            this.input = input;
        }

        public string GetResult()
        {
            return String.Concat(input.OrderBy(c => c));
        }
    }
}
