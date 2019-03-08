using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class Gcd
    {
        int num;
        int[] arr;

        public Gcd(int num, int[] arr)
        {
            this.num = num;
            this.arr = arr;
        }

        public int GetResult()
        {
            return generalizedGCD(num, arr);
        }

        // Expand the Euclid algorithm to N integers
        // sort integers smallest to largest
        // note that the GCDs of the smallest number with all other numbers
        // must contain the overall GCD
        //      none of the GCDs between the other numbers would apply to the 
        //      smallest number because they would necessarily be larger - if they
        //      weren't, then they would have appeared as the GCD with the smallest
        //      integer (being a larger factor that goes into the smallest number)
        // each pass produces (n-1) GCDs; repeat until n = 1;
        //
        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public static int generalizedGCD(int num, int[] arr)
        {
            int[] workingResult = new int[num];
            for (int i = 0; i < num; i++)
            {
                workingResult[i] = arr[i];
            }

            for (int n = num; n > 1; n--)
            {
                for (int i = 0; i < (n - 1); i++)
                {
                    workingResult[i] = Euclid(workingResult[i], workingResult[i + 1]);
                }
            }

            return workingResult[0];
        }

        private static int Euclid(int a, int b)
        {
            int r = a % b;

            int x = a;
            int y = b;

            while (r != 0)
            {
                //Console.WriteLine($"x={x}, y={y}, r={r}.");
                x = y;
                y = r;
                r = x % y;
            }

            return y;
        }
        // METHOD SIGNATURE ENDS
    }
}
