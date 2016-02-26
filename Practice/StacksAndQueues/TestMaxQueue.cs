

namespace Practice.StacksAndQueues
{
    using System;

    internal class TestMaxQueue : IRunnable
    {
        public void Run()
        {
            MaxQueue<int> queue = new MaxQueue<int>();
            string command = null;
            Console.Write("Enter a command:");
            while (!string.IsNullOrEmpty(command = Console.ReadLine()))
            {
                string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (tokens[0] == "e")
                    {
                        queue.Enqueue(int.Parse(tokens[1]));
                    }
                    else if (tokens[0] == "d")
                    {
                        if (queue.Count == 0) Console.WriteLine("Queue empty");
                        else Console.WriteLine("Popped {0}", queue.Dequeue());
                    }
                    else if (tokens[0] == "m")
                    {
                        if (queue.Count == 0) Console.WriteLine("Queue empty");
                        else Console.WriteLine("Max is {0}", queue.Max);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad Command");
                }
                Console.Write("Enter a command:");
            }
        }
    }
}
