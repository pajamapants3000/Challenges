using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class KaprekarsConstantTest
    {
        [Test]
        public void Test1()
        {
            int input = 2111;
            int expected = 5;

            /* 2111; 1: 1112-2111=999 2: 0999-9990=8991 3: 1899-9981=8082 4: 0288-8820=8532 5: 2358-8532=6174 */

            ApplyTest(input, expected);
        }

        [Test]
        public void Test2()
        {
            int input = 9831;
            int expected = 7;

            /* 9831; 1: 1389-9831=8442 2: 2448-8442=5994 3: 4599-9954=5355 4: 3555-5553=1998 5: 1899-9981=8082 6: 0288-8820=8532 7: 2358-8532=6174 */

            ApplyTest(input, expected);
        }

        [Test]
        public void Test3()
        {
            int input = 1010;
            int expected = 4;

            /* 1010; 1: 0011-1100=1089 2: 0189-9810=9621 3: 1269-9621=8352 4: 2358-8532=6174 */

            ApplyTest(input, expected);
        }

        [Test]
        public void Test4()
        {
            int input = 9989;
            int expected = 5;

            /* 9989; 1: 8999-9998=999 2: 0999-9990=8991 3: 1899-9981=8082 4: 0288-8820=8532 5: 2358-8532=6174 */

            ApplyTest(input, expected);
        }

        [Test]
        public void Test5()
        {
            int input = 1234;
            int expected = 3;

            /* 1234; 1: 1234-4321=3087 2: 0378-8730=8352 3: 2358-8532=6174 */

            ApplyTest(input, expected);
        }

        [Test]
        public void Test6()
        {
            int input = 2468;
            int expected = 1;

            /* 2468; 1: 2468-8642=6174 */

            ApplyTest(input, expected);
        }

        [Test]
        public void Test7()
        {
            int input = 1842;
            int expected = 5;

            /* 1842; 1: 1248-8421=7173 2: 1377-7731=6354 3: 3456-6543=3087 4: 0378-8730=8352 5: 2358-8532=6174 */

            ApplyTest(input, expected);
        }

        private void ApplyTest(int input, int expected)
        {
            KaprekarsConstant calculator = new KaprekarsConstant(input);
            calculator.debug = false;
            int result = calculator.GetResult();

            Assert.AreEqual(result, expected);
        }

    }
}
