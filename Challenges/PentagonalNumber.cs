using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    // we will be determining the number of dots in a pentagon of a given size
    // consider a pentagon that starts with a single dot (N=1), and is surrounded
    // by the five corners (N=2), then surrounded by dots to make the next larger
    // pentagon (N=3), and so on. See https://www.coderbyte.com/editor/Pentagonal%20Number:Csharp
    // N=1 has one dot, N=2 has six dots, N=3 has 16 dots, N=4 has 31 dots, N=5 has 51 dots
    // How many dots are there at any given N?
    //
    // Some things to note:
    //  1) each successive pentagon has sides one-larger than the previous
    //  2) the number of dots in a pentagon is 5*(sideLength-1) = 5sideLength-5
    //      the exception is for N=1, where dotCount = 1;
    //  3) sideLength == N
    //
    // This leads to: dotCount = 1 + Sum(i=1, i=N) 5i-5 = (1 - 5N) + Sum(i=1, i=N) 5i
    public class PentagonalNumber
    {
        int input;

        public PentagonalNumber(int input)
        {
            this.input = input;
        }

        public int GetResult()
        {
            int result = 1 - (5 * input);

            for (int i = 1; i <= input; i++)
            {
                result += (5 * input);
            }

            return result;
        }
    }
}
