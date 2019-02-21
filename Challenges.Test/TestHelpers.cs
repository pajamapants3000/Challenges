using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges.Test
{
    public class TestHelpers
    {
        public static bool AreArraySetsEqual<T>(T[][] a, T[][] b) where T : IEquatable<T>
        {
            if (a == null && b == null) return true;

            if ((a == null) != (b == null))
            {
                return false;
            }

            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++)
            {
                bool matchFound = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (AreArraysEqual(a[i], b[j])) matchFound = true;
                }
                if (!matchFound) return false;
            }

            return true;
        }

        public static bool DoesArrayContainSameArrays<T>(T[,] a, T[,] b) where T : IEquatable<T>
        {
            if (a == null && b == null) return true;

            if ((a == null) != (b == null))
            {
                return false;
            }

            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++)
            {
                bool matchFound = false;

                T[] arrayAi = new T[a.GetLength(1)];
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    arrayAi[j] = a[i, j];
                }

                for (int j = 0; j < a.GetLength(1); j++)
                {
                    T[] arrayBj = new T[b.GetLength(1)];
                    for (int k = 0; k < b.GetLength(1); k++)
                    {
                        arrayBj[k] = b[j, k];
                    }

                    if (AreArraysEqual(arrayAi, arrayBj)) matchFound = true;
                }
                if (!matchFound) return false;
            }

            return true;
        }

        public static bool DoesListContainSameLists<T>(List<List<T>> a, List<List<T>> b) where T: IEquatable<T>
        {
            if (a == null && b == null) return true;

            if ((a == null) != (b == null))
            {
                return false;
            }

            if (a.Count != b.Count) return false;

            for (int i = 0; i < a.Count; i++)
            {
                bool matchFound = false;

                List<T> listAi = new List<T>();
                for (int j = 0; j < a[0].Count; j++)
                {
                    listAi.Add(a[i][j]);
                }

                for (int j = 0; j < b.Count; j++)
                {
                    List<T> listBj = new List<T>();
                    for (int k = 0; k < b[0].Count; k++)
                    {
                        listBj.Add(b[j][k]);
                    }


                    if (AreListsEqual(listAi, listBj)) matchFound = true;
                }
                if (!matchFound) return false;
            }

            return true;

        }

        public static bool Are2DArraysEqual<T>(T[,] a, T[,] b) where T : IEquatable<T>
        {
            if (a == null && b == null) return true;

            if ((a == null) != (b == null))
            {
                return false;
            }

            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (!a[i, j].Equals(b[i, j])) return false;
                }
            }

            return true;
        }
        public static bool Are2DListsEqual<T>(List<List<T>> a, List<List<T>> b) where T : IEquatable<T>
        {
            if (a == null && b == null) return true;

            if ((a == null) != (b == null))
            {
                return false;
            }

            if (a.Count != b.Count) return false;

            for (int i = 0; i < a.Count; i++)
            {
                bool matchFound = false;
                for (int j = 0; j < b.Count; j++)
                {
                    if (AreListsEqual(a[i], b[j])) matchFound = true;
                }
                if (!matchFound) return false;
            }

            return true;
        }

        public static bool AreArraysEqual<T>(T[] a, T[] b) where T : IEquatable<T>
        {
            if (a == null && b == null) return true;

            if ((a == null) != (b == null))
            {
                return false;
            }

            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(b[i])) return false;
            }

            return true;
        }

        public static bool AreListsEqual<T>(List<T> a, List<T> b) where T : IEquatable<T>
        {
            if (a == null && b == null) return true;

            if ((a == null) != (b == null))
            {
                return false;
            }

            if (a.Count != b.Count) return false;

            for (int i = 0; i < a.Count; i++)
            {
                if (!a[i].Equals(b[i])) return false;
            }

            return true;
        }
    }
}
