using System;
using System.Collections.Generic;
using NUnit.Framework;
using Challenges;

namespace Challenges.Test
{
    class DeliveryTruckTest
    {
        [Test]
        public void GetResult_Test1()
        {
            int locationsCount = 0;
            int[,] locations = new int[,] { };
            int stopsCount = 0;
            List<List<int>> expected = new List<List<int>>();

            ApplyGetResultTest(locationsCount, locations, stopsCount, expected);
        }

        [Test]
        public void GetResult_Test2()
        {
            int locationsCount = 4;
            int[,] locations = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            int stopsCount = 0;
            List<List<int>> expected = new List<List<int>>();

            ApplyGetResultTest(locationsCount, locations, stopsCount, expected);
        }

        [Test]
        public void GetResult_Test3()
        {
            int locationsCount = 4;
            int[,] locations = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            int stopsCount = 3;
            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>(){1, 2},
                new List<int>(){3, 4},
                new List<int>(){5, 6},
            };

            ApplyGetResultTest(locationsCount, locations, stopsCount, expected);
        }

        [Test]
        public void GetResult_Test4()
        {
            int locationsCount = 4;
            int[,] locations = new int[,] { { 1, 2 }, { -1, -1 }, { -2, 3 }, { 12, 8 } };
            int stopsCount = 4;
            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>(){-1, -1},
                new List<int>(){-2, 3},
                new List<int>(){1, 2},
                new List<int>(){12, 8},
            };

            ApplyGetResultTest(locationsCount, locations, stopsCount, expected);
        }

        [Test]
        public void GetResult_Test5()
        {
            int locationsCount = 4;
            int[,] locations = new int[,] { { 1, 2 }, { -1, -1 }, { -2, 3 }, { 12, 8 } };
            int stopsCount = 3;
            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>(){-1, -1},
                new List<int>(){1, 2},
                new List<int>(){-2, 3},
            };

            ApplyGetResultTest(locationsCount, locations, stopsCount, expected);
        }

        [Test]
        public void GetResult_Test6()
        {
            int locationsCount = 4;
            int[,] locations = new int[,] { { 1, 2 }, { -1, -1 }, { -2, 3 }, { 12, 8 } };
            int stopsCount = 2;
            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>(){-1, -1},
                new List<int>(){1, 2},
            };

            ApplyGetResultTest(locationsCount, locations, stopsCount, expected);
        }

        [Test]
        public void GetCombinations_SmallTest()
        {
            int N = 3;
            int M = 2;
            List<List<int>> expected = new List<List<int>>() {
                new List<int>(){ 0, 1 },
                new List<int>(){ 0, 2 },
                new List<int>(){ 1, 0 },
                new List<int>(){ 1, 2 },
                new List<int>(){ 2, 0 },
                new List<int>(){ 2, 1 }
            };

            Assert.IsTrue(TestHelpers.DoesListContainSameLists(expected, DeliveryTruck.GetOrderedCombinations(N, M)));
        }

        [Test]
        public void GetCombinations_LargeTest()
        {
            int N = 6;
            int M = 3;
            List<List<int>> expected = new List<List<int>>() {
                new List<int>(){ 0, 1, 2 },
                new List<int>(){ 0, 1, 3 },
                new List<int>(){ 0, 1, 4 },
                new List<int>(){ 0, 1, 5 },
                new List<int>(){ 0, 2, 1 },
                new List<int>(){ 0, 2, 3 },
                new List<int>(){ 0, 2, 4 },
                new List<int>(){ 0, 2, 5 },
                new List<int>(){ 0, 3, 1 },
                new List<int>(){ 0, 3, 2 },
                new List<int>(){ 0, 3, 4 },
                new List<int>(){ 0, 3, 5 },
                new List<int>(){ 0, 4, 1 },
                new List<int>(){ 0, 4, 2 },
                new List<int>(){ 0, 4, 3 },
                new List<int>(){ 0, 4, 5 },
                new List<int>(){ 0, 5, 1 },
                new List<int>(){ 0, 5, 2 },
                new List<int>(){ 0, 5, 3 },
                new List<int>(){ 0, 5, 4 },
                new List<int>(){ 1, 0, 2 },
                new List<int>(){ 1, 0, 3 },
                new List<int>(){ 1, 0, 4 },
                new List<int>(){ 1, 0, 5 },
                new List<int>(){ 1, 2, 0 },
                new List<int>(){ 1, 2, 3 },
                new List<int>(){ 1, 2, 4 },
                new List<int>(){ 1, 2, 5 },
                new List<int>(){ 1, 3, 0 },
                new List<int>(){ 1, 3, 2 },
                new List<int>(){ 1, 3, 4 },
                new List<int>(){ 1, 3, 5 },
                new List<int>(){ 1, 4, 0 },
                new List<int>(){ 1, 4, 2 },
                new List<int>(){ 1, 4, 3 },
                new List<int>(){ 1, 4, 5 },
                new List<int>(){ 1, 5, 0 },
                new List<int>(){ 1, 5, 2 },
                new List<int>(){ 1, 5, 3 },
                new List<int>(){ 1, 5, 4 },
                new List<int>(){ 2, 0, 1 },
                new List<int>(){ 2, 0, 3 },
                new List<int>(){ 2, 0, 4 },
                new List<int>(){ 2, 0, 5 },
                new List<int>(){ 2, 1, 0 },
                new List<int>(){ 2, 1, 3 },
                new List<int>(){ 2, 1, 4 },
                new List<int>(){ 2, 1, 5 },
                new List<int>(){ 2, 3, 0 },
                new List<int>(){ 2, 3, 1 },
                new List<int>(){ 2, 3, 4 },
                new List<int>(){ 2, 3, 5 },
                new List<int>(){ 2, 4, 0 },
                new List<int>(){ 2, 4, 1 },
                new List<int>(){ 2, 4, 3 },
                new List<int>(){ 2, 4, 5 },
                new List<int>(){ 2, 5, 0 },
                new List<int>(){ 2, 5, 1 },
                new List<int>(){ 2, 5, 3 },
                new List<int>(){ 2, 5, 4 },
                new List<int>(){ 3, 0, 1 },
                new List<int>(){ 3, 0, 2 },
                new List<int>(){ 3, 0, 4 },
                new List<int>(){ 3, 0, 5 },
                new List<int>(){ 3, 1, 0 },
                new List<int>(){ 3, 1, 2 },
                new List<int>(){ 3, 1, 4 },
                new List<int>(){ 3, 1, 5 },
                new List<int>(){ 3, 2, 0 },
                new List<int>(){ 3, 2, 1 },
                new List<int>(){ 3, 2, 4 },
                new List<int>(){ 3, 2, 5 },
                new List<int>(){ 3, 4, 0 },
                new List<int>(){ 3, 4, 1 },
                new List<int>(){ 3, 4, 2 },
                new List<int>(){ 3, 4, 5 },
                new List<int>(){ 3, 5, 0 },
                new List<int>(){ 3, 5, 1 },
                new List<int>(){ 3, 5, 2 },
                new List<int>(){ 3, 5, 4 },
                new List<int>(){ 4, 0, 1 },
                new List<int>(){ 4, 0, 2 },
                new List<int>(){ 4, 0, 3 },
                new List<int>(){ 4, 0, 5 },
                new List<int>(){ 4, 1, 0 },
                new List<int>(){ 4, 1, 2 },
                new List<int>(){ 4, 1, 3 },
                new List<int>(){ 4, 1, 5 },
                new List<int>(){ 4, 2, 0 },
                new List<int>(){ 4, 2, 1 },
                new List<int>(){ 4, 2, 3 },
                new List<int>(){ 4, 2, 5 },
                new List<int>(){ 4, 3, 0 },
                new List<int>(){ 4, 3, 1 },
                new List<int>(){ 4, 3, 2 },
                new List<int>(){ 4, 3, 5 },
                new List<int>(){ 4, 5, 0 },
                new List<int>(){ 4, 5, 1 },
                new List<int>(){ 4, 5, 2 },
                new List<int>(){ 4, 5, 3 },
                new List<int>(){ 5, 0, 1 },
                new List<int>(){ 5, 0, 2 },
                new List<int>(){ 5, 0, 3 },
                new List<int>(){ 5, 0, 4 },
                new List<int>(){ 5, 1, 0 },
                new List<int>(){ 5, 1, 2 },
                new List<int>(){ 5, 1, 3 },
                new List<int>(){ 5, 1, 4 },
                new List<int>(){ 5, 2, 0 },
                new List<int>(){ 5, 2, 1 },
                new List<int>(){ 5, 2, 3 },
                new List<int>(){ 5, 2, 4 },
                new List<int>(){ 5, 3, 0 },
                new List<int>(){ 5, 3, 1 },
                new List<int>(){ 5, 3, 2 },
                new List<int>(){ 5, 3, 4 },
                new List<int>(){ 5, 4, 0 },
                new List<int>(){ 5, 4, 1 },
                new List<int>(){ 5, 4, 2 },
                new List<int>(){ 5, 4, 3 },
            };

            Assert.IsTrue(TestHelpers.DoesListContainSameLists(expected, DeliveryTruck.GetOrderedCombinations(N, M)));
        }

        [Test]
        public void GetLocationsIncludingOrigin_SmallTest()
        {
            int[,] locations = new int[,] { };
            int locationsCount = 0;
            int[,] expected = new int[,] { { 0, 0 } }; ;

            Assert.IsTrue(TestHelpers.Are2DArraysEqual<int>(expected, DeliveryTruck.GetLocationsIncludingOrigin(locations, locationsCount)));

        }

        [Test]
        public void GetLocationsIncludingOrigin_LargeTest()
        {
            int[,] locations = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, };
            int locationsCount = 4;
            int[,] expected = new int[,] { { 0, 0 }, { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, }; ;

            Assert.IsTrue(TestHelpers.Are2DArraysEqual<int>(expected, DeliveryTruck.GetLocationsIncludingOrigin(locations, locationsCount)));
        }

        private void ApplyGetResultTest(int locationsCount, int[,] locations, int stopsCount, List<List<int>> expected)
        {
            DeliveryTruck calculator = new DeliveryTruck(locationsCount, locations, stopsCount);
            List<List<int>> result = calculator.GetResult();

            Assert.AreEqual(expected, result);
        }

    }
}
