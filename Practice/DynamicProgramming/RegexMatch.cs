
namespace Practice.DynamicProgramming
{
    using System;
    using System.Text;

    internal class RegexMatch : IRunnable
    {

        static bool DoRegexMatch(string pattern, string input)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            string myPattern = pattern.Replace("+", "?*");
            bool[] m1 = new bool[myPattern.Length + 1];
            bool[] m2 = new bool[myPattern.Length + 1];
            m1[myPattern.Length] = true;

            for (int i = input.Length - 1; i >= 0; --i)
            {
                m2[myPattern.Length] = false;
                for (int j = myPattern.Length -1; j >= 0; --j)
                {
                    switch(myPattern[j])
                    {
                        case '?' :
                            m2[j] = m1[j + 1];
                            break;
                        case '*':
                            m2[j] = (m1[j] || m2[j + 1]);
                            break;
                        default:
                            m2[j] = ((input[i] == myPattern[j]) && m1[j + 1]);
                            break;


                    }
                }

                bool[] temp = m1;
                m1 = m2;
                m2 = temp;
            }

            return m1[0];
        }

        public void Run()
        {
            Console.Write("Enter pattern :");
            string pattern = Console.ReadLine();

            Console.Write("\tEnter input :");
            string input = Console.ReadLine();
            while(!string.IsNullOrEmpty(input))
            {
                if (DoRegexMatch(pattern, input))
                {
                    Console.WriteLine("\t{0} matches pattern {1}", input, pattern);
                }
                else
                {
                    Console.WriteLine("\t{0} does not match pattern {1}", input, pattern);
                }

                Console.Write("\tEnter input :");
                input = Console.ReadLine();
            }
        }
    }
}
