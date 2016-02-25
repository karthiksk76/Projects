
namespace Practice.DynamicProgramming
{
    using System;
    using System.Collections.Generic;

    internal class LongestArithmeticProgression : IRunnable
    {
        static IEnumerable<int> FindLongestArithmeticProgression(int[] numbers)
        {
            if ((numbers == null) || (numbers.Length < 2)) yield break;

            Array.Sort<int>(numbers);

            int[,] lengths = new int[numbers.Length, numbers.Length];
            for (int  i = 0; i < numbers.Length - 1; ++i)
            {
                lengths[i, i + 1] = 2;
            }

            int maxi = 0;
            int maxj = 1;
            int maxLength = 2;

            for (int i = numbers.Length - 2; i > 0; --i)
            {
                int j = i - 1;
                int k = i + 1;

                while ((j >=0) && (k < numbers.Length))
                {
                    int val1 = numbers[j] + numbers[k];
                    int val2 = 2 * numbers[i];

                    if (val2 == val1)
                    {
                        lengths[j, i] = lengths[i, k] + 1;

                        if (lengths[j,i] > maxLength)
                        {
                            maxLength = lengths[j, i];
                            maxi = j;
                            maxj = i;
                        }


                        ++k;
                        --j;
                    }
                    else if (val2 > val1)
                    {
                        ++k;
                    }
                    else
                    {
                        --j;
                    }
                }
            }

            yield return numbers[maxi];
            yield return numbers[maxj];
            int diff = numbers[maxj] - numbers[maxi];
            int next = numbers[maxj] + diff;
            for (int i = maxj + 1; i < numbers.Length; ++i)
            {
                if (numbers[i] == next)
                {
                    yield return numbers[i];
                    next = numbers[i] + diff;
                }
            }


            yield break;
        }

        public void Run()
        {
            int[] input = Utilities.ArrayReader.ReadArray<int>(int.Parse, "Enter sequence:");
            Console.WriteLine("\tLongest arithmetic progession is {0}", string.Join(" ", FindLongestArithmeticProgression(input)));
        }
    }
}
