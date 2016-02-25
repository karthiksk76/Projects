
namespace Practice.Sorting
{
    using System;

    internal class QuickSort : IRunnable
    {
        internal static int Partition(int[] numbers, int s, int e, int k)
        {
            int i = s;
            int j = e;

            while (i <= j)
            {

                if (numbers[i] <= k)
                {
                    ++i;

                    // This toggling is to optimize obscene case of all array elements being equal
                    if (numbers[j] >= k)
                    {
                        --j;
                    }
                }

                else if (numbers[j] >= k)
                {
                    --j;
                    // This toggling is to optimize obscene case of all array elements being equal
                    if (numbers[i] <= k)
                    {
                        --i;
                    }
                }
                else
                {
                    int temp = numbers[i];
                    numbers[i++] = numbers[j];
                    numbers[j--] = temp;
                }
            }

            return i;
        }

        static void DoQuickSort(int[] numbers, int s, int e, Random r)
        {
            if (s < e)
            {
                int sw = r.Next(s, e + 1);
                int temp = numbers[s];
                numbers[s] = numbers[sw];
                numbers[sw] = temp;

                int p = Partition(numbers, s, e, numbers[s]);

                temp = numbers[p - 1];
                numbers[p - 1] = numbers[s];
                numbers[s] = temp;               

                
                DoQuickSort(numbers, s, p - 2, r);
                DoQuickSort(numbers, p , e, r);
            }
        }

        static void ExecuteQuickSort(int[] numbers)
        {
            if ((numbers == null) || (numbers.Length < 2)) return;

            DoQuickSort(numbers, 0, numbers.Length - 1, new Random());
        }

        public void Run()
        {
            int[] input = Utilities.ArrayReader.ReadArray<int>(int.Parse, "Enter numbers to sort:");
            ExecuteQuickSort(input);
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
