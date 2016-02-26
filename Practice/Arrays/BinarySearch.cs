
namespace Practice.Arrays
{
    using System;
    using System.Collections.Generic;

    internal class BinarySearch
    {
        internal static int FindExact<T>(T key, T[] items, int start, int end, Comparison<T> comp) 
        {
            if (start > end) return -1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                int v = comp(key,items[mid]);
                if (v == 0) return mid;
                else if (v > 0) start = mid + 1;
                else end = mid - 1;

            }

            return -1;
        }

        internal static int FindMaxLessThan<T>(T key, T[] items, int start, int end, Comparison<T> comp)
        {
            if (start > end) return -1;

            int index = -1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                int v = comp(key, items[mid]);

                if (v > 0)
                {
                    index = mid;
                    start = mid + 1;
                }
                else end = mid - 1;
            }

            return index;
        }

        internal static int FindMinGreaterThan<T>(T key, T[] items, int start, int end, Comparison<T> comp)
        {
            if (start > end) return -1;

            int index = -1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                int v = comp(key, items[mid]);

                if (v < 0) 
                {
                    index = mid;
                    end = mid - 1;
                }
                else start = mid + 1;
            }

            return index;
        }
    }
}
