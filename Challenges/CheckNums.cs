using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class CheckNums
    {
        int input1 = 0;
        int input2 = 0;
        public CheckNums(int input1, int input2)
        {
            this.input1 = input1;
            this.input2 = input2;
        }

        public string GetResult()
        {
            return (input1 == input2) ? "-1" :
                (input1 <= input2) ? "true" :
                "false";
        }
    }
}
