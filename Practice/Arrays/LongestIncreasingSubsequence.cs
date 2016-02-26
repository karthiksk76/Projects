
namespace Practice.Arrays
{
    using System;
    using System.Collections.Generic;

    internal class LongestIncreasingSubsequence : IRunnable
    {
        static IEnumerable<int> FindLongestIncreasingSubsequence(int[] numbers)
        {
            if ((numbers == null) || (numbers.Length == 0)) yield break;

            int[] parents = new int[numbers.Length];
            int[] endings = new int[numbers.Length];

            parents[0] = -1;
            endings[0] = 0;
            int length = 1;
            for (int i = 1; i < numbers.Length; ++i)
            {
                int idx = BinarySearch.FindMaxLessThan<int>(i, endings, 0, length - 1, (x, y) => { return numbers[x].CompareTo(numbers[y]); });

                if (idx < 0)
                {
                    parents[i] = -1;
                }
                else
                {
                    parents[i] = endings[idx];
                }

                if (idx == length - 1)
                {
                    endings[idx + 1] = i;
                    ++length;
                }
                else if (numbers[endings[idx + 1]] > numbers[i])
                {
                    endings[idx + 1] = i;
                }
            }

            Stack<int> path = new Stack<int>();
            int index = endings[length - 1];
            path.Push(endings[length - 1]);
            while (parents[index] >= 0)
            {
                path.Push(parents[index]);
                index = parents[index];
            }

            while(path.Count > 0)
            {
                yield return numbers[path.Pop()];
            }
        }

        public void Run()
        {
            int[] input = Utilities.ArrayReader.ReadArray<int>(int.Parse, "Enter array :");
            
            Console.WriteLine("Longest increasing subsequence is {0}", string.Join(" ", FindLongestIncreasingSubsequence(input)));
        }
    }
}
