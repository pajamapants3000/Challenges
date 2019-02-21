using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    // Given `locationsCount` locations specified in `locations`, what is the shortest route, starting
    // at (0, 0) to make `stopsCount` stops?
    public class DeliveryTruck
    {
        private bool debug = false;

        int locationsCount = 0;
        int[,] locations = null;
        int stopsCount = 0;

        public DeliveryTruck(int locationsCount, int[,] locations, int stopsCount)
        {
            this.locationsCount = locationsCount;
            this.locations = locations;
            this.stopsCount = stopsCount;
        }

        // Solution:
        // NOTE: we will call the origin "location 0" and location at row i of `locations` "location i+1"
        // 1) Create an array of distances from each stop, x to y
        //      this will be a hollow, symmetric matrix
        //      NOTE: we also want the distance from the origin (0, 0) to each location
        //          since the origin isn't included in `locations`, nor is it accounted for in `locationsCount`
        //          we will create a new `locationsIncludingOrigin` array to work with
        //          with our above-specified language, `distances[i, j]` will be the distance from "location i" to "location j"
        // 0) Preptask: create a list of `locationsIncludingOrigin`
        //      NOTE: now "location i" is the ith location in `locationsIncludingOrigin`
        // 2) Determine the list of all possible combinations of `stopsCount` non-negative integers < `locationsCount`
        // 3) Create list of all possible routes - convert from list of combinations by adding one to each value and inserting a 0 at the beginning
        //      That is, these will be a list of indexes into `locationsIncludingOrigin`
        // 4) Iterate over all possible routes, mapping their totalDistance to their representation in `routes`
        // 5) Find the smallest key in the mapping and use it to obtain the desired route
        // 6) Convert list of indexes into `locationsIncludingOrigin` into list of locations, and return it
        public List<List<int>> GetResult()
        {
            // 0) Preptask: create a list of `locationsIncludingOrigin`
            int[,] locationsIncludingOrigin = GetLocationsIncludingOrigin(locations, locationsCount);

            // 1) Create an array of distances from each stop, x to y, including the origin (0, 0))
            double[,] distances = GetDistances(locationsIncludingOrigin, locationsCount + 1);

            // 2) Determine the list of all possible combinations of `stopsCount` non-negative integers < `locationsCount`
            List<List<int>> combinations = GetOrderedCombinations(locationsCount, stopsCount);

            // 3) Create list of all possible routes - convert from list of combinations by adding one to each value and inserting a 0 at the beginning
            List<List<int>> routes = GetRoutesFromCombinations(combinations);

            // 4) Iterate over all possible routes, mapping their totalDistance to their representation in `routes`
            Dictionary<double, int[]> mapDistanceToCombo = MapDistances(distances, routes);

            // 5) Find the smallest key in the mapping and use it to obtain the desired route
            List<double> totalDistances = new List<double>(mapDistanceToCombo.Keys);
            totalDistances.Sort();
            ConsoleDebug($"Sorted distances: {String.Join(", ", totalDistances)}.");

            double shortestDistance = totalDistances[0];
            int[] shortestRoute = mapDistanceToCombo[shortestDistance];
            ConsoleDebug($"Shortest route: {String.Join(", ", shortestRoute)}.");

            // 6) Convert list of indexes into `locationsIncludingOrigin` into list of locations, and return it
            List<List<int>> result = GetRouteLocations(locationsIncludingOrigin, shortestRoute);
            // remove origin starting point
            if (result[0][0] == 0 && result[0][1] == 0)
            {
                result.RemoveAt(0);
            }

            return result;
        }

        // insert a (0, 0) element at the beginning of int[,] array
        public static int[,] GetLocationsIncludingOrigin(int[,] locations, int locationsCount)
        {
            int[,] result = new int[locationsCount + 1, 2];
            result[0, 0] = 0;
            result[0, 1] = 0;

            for (int i = 0; i < locationsCount; i++)
            {
                result[i + 1, 0] = locations[i, 0];
                result[i + 1, 1] = locations[i, 1];
            }

            return result;
        }
        // Obtain and return a 2D array of distances between each location in `locations`,
        // we can assume the array has at least 2 columns (x, y); we are looking at distances in 2D space
        public static double[,] GetDistances(int[,] locations, int locationsCount)
        {
            double[,] result = new double[locationsCount, locationsCount];

            for (int i = 0; i < locationsCount; i++)
            {
                for (int j = i; j < locationsCount; j++)
                {
                    double distance;
                    if (j == i)
                    {
                        distance = 0;
                        continue;
                    }

                    int[] begin = Get2DIntArrayRow(locations, i);
                    int[] end = Get2DIntArrayRow(locations, j);
                    distance = GetDistance(begin, end);

                    result[i, j] = distance;
                    result[j, i] = distance;
                }
            }
            return result;
        }

        // Obtain and return the ith row of a 2D array of ints
        public static int[] Get2DIntArrayRow(int[,] array, int rowIndex)
        {
            int rowLength = array.GetLength(1);
            int[] result = new int[rowLength];
            for (int i = 0; i < rowLength; i++)
            {
                result[i] = array[rowIndex, i];
            }

            return result;
        }

        // Obtain and return the distance from `begin` to `end`, each an int[2]
        public static double GetDistance(int[] begin, int[] end)
        {
            double result = 0D;

            int deltaX = end[0] - begin[0];
            int deltaY = end[1] - begin[1];

            int xSquared = deltaX * deltaX;
            int ySquared = deltaY * deltaY;

            result = Math.Sqrt(xSquared + ySquared);

            return result;
        }

        // Get all possible ordered (i.e. order matters) combinations of `count` non-negative integers < max
        public static List<List<int>> GetOrderedCombinations(int max, int count)
        {
            List<List<int>> result = new List<List<int>>();

            GetSubComboOrUpdate(max, count, 0, new List<int>(), ref result);

            return result;
        }

        private static void GetSubComboOrUpdate(int max, int count, int currentIndex, List<int> prefix, ref List<List<int>> result)
        {
            if (currentIndex == count)
            {
                result.Add(new List<int>(prefix));
                return;
            }

            for (int i = 0; i < max; i++)
            {
                if (prefix.Contains(i)) continue;

                List<int> newList = new List<int>(prefix);
                newList.Add(i);

                GetSubComboOrUpdate(max, count, currentIndex + 1, newList, ref result);
            }
        }

        // convert a list of combinations to a list of routes - increment each element and insert a 0 at the beginning of each combination
        public static List<List<int>> GetRoutesFromCombinations(List<List<int>> combinations)
        {
            List<List<int>> result = new List<List<int>>();

            // insert 0 at the beginning of each list to include the starting point
            for (int i = 0; i < combinations.Count; i++)
            {
                List<int> newRoute = new List<int>();
                newRoute.Add(0);
                for (int j = 0; j < combinations[i].Count; j++)
                {
                    newRoute.Add(combinations[i][j] + 1);
                }

                result.Add(newRoute);
            }

            return result;
        }

        // map the distance to travel each combination, in order, where each combination is represented
        // as indexes into the hollow, symmetric distances matrix;
        // That is, e.g., combination (0, 3, 7, 4) would represent list (i,j) = (0, 3), (3, 7), (7, 4)
        // we need not assume the list starts at 0, though for our purposes it always will.
        public Dictionary<double, int[]> MapDistances(double[,] distances, List<List<int>> routes)
        {
            Dictionary<double, int[]> result = new Dictionary<double, int[]>();
            foreach (List<int> route in routes)
            {
                double totalDistance = 0;
                for (int i = 1; i < route.Count; i++)
                {
                    int beginIndex = route[i - 1];
                    int endIndex = route[i];

                    totalDistance += distances[beginIndex, endIndex];
                }

                if (!result.ContainsKey(totalDistance))
                {
                    ConsoleDebug($"Adding route {String.Join(", ", route)}, distance = {totalDistance}.");
                    result.Add(totalDistance, route.ToArray());
                }
            }

            return result;
        }

        // obtain and return the (x, y) positions of stops on route, given their indexes into a list of locations
        // we assume locations has at least two columns; inner lists in result will have two integers
        public static List<List<int>> GetRouteLocations(int[,] locations, int[] shortestRoute)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < shortestRoute.Length; i++)
            {
                List<int> nextLocation = new List<int>();
                nextLocation.Add(locations[shortestRoute[i], 0]);
                nextLocation.Add(locations[shortestRoute[i], 1]);
                result.Add(nextLocation);
            }

            return result;
        }

        private void ConsoleDebug(string message)
        {
            if (debug)
            {
                Console.WriteLine(message);
            }
        }
    }
}
