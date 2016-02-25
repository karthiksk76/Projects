
namespace Practice.DynamicProgramming
{
    using System;
    using System.Text;

    internal class LongestCommonSubsequence : IRunnable
    {
        enum Direction
        {
            Up,
            Right,
            Cross
        }

        static string FindLongestCommonSubsequence(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return string.Empty;
            }

            Direction[,] table = new Direction[a.Length, b.Length];
            int[] l1 = new int[b.Length + 1];
            int[] l2 = new int[b.Length + 1];

            for (int i = a.Length - 1; i >= 0; --i)
            {
                for (int j = b.Length - 1; j >= 0; --j)
                {
                    if (a[i] == b[j])
                    {
                        table[i, j] = Direction.Cross;
                        l2[j] = l1[j + 1] + 1;
                    }
                    else if (l1[j] > l2[j + 1])
                    {
                        table[i, j] = Direction.Up;
                        l2[j] = l1[j];
                    }
                    else
                    {
                        table[i, j] = Direction.Right;
                        l2[j] = l2[j + 1];
                    }

                }

                int[] temp = l1;
                l1 = l2;
                l2 = temp;
            }

            StringBuilder sb = new StringBuilder();

            int m = 0;
            int n = 0;

            while ((m < a.Length) && (n < b.Length))
            {
                switch (table[m, n])
                {
                    case Direction.Up:
                        ++m;
                        break;
                    case Direction.Right:
                        ++n;
                        break;
                    default:
                        sb.Append(a[m]);
                        ++m;
                        ++n;
                        break;
                }
            }

            return sb.ToString();
        }

        public void Run()
        {
            Console.Write("Enter string 1 :");
            string a = Console.ReadLine();
            Console.Write("Enter string 2 :");
            string b = Console.ReadLine();
            Console.WriteLine("Longest common subsequence of {0} and {1} is {2}", a, b, FindLongestCommonSubsequence(a, b));
        }
    }
}
