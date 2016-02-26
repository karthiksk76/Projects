

namespace Practice.StacksAndQueues
{
    using System;

    internal class TestMaxStack : IRunnable
    {
        public void Run()
        {
            MaxStack<int> stack = new MaxStack<int>();
            string command = null;
            Console.Write("Enter a command:");
            while (!string.IsNullOrEmpty(command = Console.ReadLine()))
            {
                string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (tokens[0] == "p")
                    {
                        stack.Push(int.Parse(tokens[1]));
                    }
                    else if (tokens[0] == "x")
                    {
                        if (stack.Count == 0) Console.WriteLine("Stack empty");
                        else Console.WriteLine("Popped {0}", stack.Pop());
                    }
                    else if (tokens[0] == "m")
                    {
                        if (stack.Count == 0) Console.WriteLine("Stack empty");
                        else Console.WriteLine("Max is {0}", stack.Max);
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Bad Command");
                }
                Console.Write("Enter a command:");
            }
        }
    }
}
