
namespace Practice.DynamicProgramming
{
    using System;

    internal class LongestCommonSubstring : IRunnable
    {
        static string FindLongestCommonSubstring(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return string.Empty;
            }

            int maxIndex = 0;
            int maxLength = 0;

            int[] table1 = new int[b.Length + 1];
            int[] table2 = new int[b.Length + 1];

            for (int i = a.Length - 1; i >= 0; --i)
            {
                for (int j = b.Length - 1; j >= 0; --j)
                {
                    if (a[i] == b[j]) table2[j] = (a[i] == b[j]) ? (1 + table1[j + 1]) : 0;

                    if (maxLength < table2[j])
                    {
                        maxLength = table2[j];
                        maxIndex = i;
                    }
                }

                int[] temp = table1;
                table1 = table2;
                table2 = temp;
            }

            return a.Substring(maxIndex, maxLength);
        }

        public void Run()
        {
            Console.Write("Enter string 1 :");
            string a = Console.ReadLine();
            Console.Write("Enter string 2 :");
            string b = Console.ReadLine();
            Console.WriteLine("Longest common substring of {0} and {1} is {2}", a, b, FindLongestCommonSubstring(a, b));
        }
    }
}
