using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class TimeConvert
    {
        int input;

        public TimeConvert(int input)
        {
            this.input = input;
        }

        public string GetResult()
        {
            TimeSpan workingResult = new TimeSpan(0, input, 0);

            return $"{workingResult.Hours}:{workingResult.Minutes}";
        }
    }
}
