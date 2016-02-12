

namespace Practice
{
    using System;

    class Program
    {
        static void Run(IRunnable run)
        {
            string s = "y";
            while (s.StartsWith("y", StringComparison.OrdinalIgnoreCase))
            {
                run.Run();

                Console.Write("Enter y to continue:");

                s = Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            //Run(new Sorting.InsertionSort());
            //Run(new Sorting.BubbleSort());
            Run(new Sorting.HeapSort());
        }
    }
}
