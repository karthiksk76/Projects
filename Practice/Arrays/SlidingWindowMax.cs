
namespace Practice.Arrays
{
    using System;

    internal class SlidingWindowMax : IRunnable
    {

        public void Run()
        {
            int[] input = Utilities.ArrayReader.ReadArray<int>(int.Parse, "Enter array:");

            Console.WriteLine("Enter window size:");
            string line = null;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                try
                {
                    int k = int.Parse(line);

                    if ((k > 0) && (k <= input.Length))
                    {
                        StacksAndQueues.MaxQueue<int> q = new StacksAndQueues.MaxQueue<int>();

                        for (int i = 0; i < k; ++i)
                        {
                            q.Enqueue(input[i]);
                        }

                        Console.Write("\t Max in windows of size {0} :", k);

                        for (int i = k; i < input.Length; ++i)
                        {
                            Console.Write("{0} ", q.Max);
                            q.Dequeue();
                            q.Enqueue(input[i]);
                        }


                        Console.WriteLine("{0} ", q.Max);
                    }
                    else
                    {
                        Console.WriteLine("\tBad window size");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("\tBad window size");
                }
                Console.WriteLine("Enter window size:");
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
