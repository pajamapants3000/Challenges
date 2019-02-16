using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges.Test
{
    public class TestHelpers
    {
        public static bool Are2DArraysEqual<T>(T[][] a, T[][] b) where T : IEquatable<T>
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
