
namespace Practice.Utilities
{
    using System;
    using System.Collections.Generic;

    internal static class ArrayReader
    {
        internal delegate T FromString<T>(string input);

        internal static T[] ReadArray<T>(FromString<T> parser, string prompt = null) 
        {
            if (prompt == null)
            {
                prompt = "Enter collection";
            }

            T[] output = null;

            do
            {

                string input = null;

                do
                {
                    Console.WriteLine(prompt);
                    input = Console.ReadLine();

                } while (string.IsNullOrEmpty(input));

                string[] tokens = input.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if ((tokens != null) && (tokens.Length > 0))
                {
                    List<T> list = new List<T>(tokens.Length);

                    try
                    {
                        foreach(string token in tokens)
                        {
                            uint count = 1;
                            string val = token;
                            int colonIdx = token.IndexOf(':');
                            if (colonIdx >= 0)
                            {
                                count = uint.Parse(token.Substring(colonIdx + 1));
                                val = token.Substring(0, colonIdx);
                            }

                            T entry = parser(val);

                            for (uint i = 0; i < count; ++i)
                            {
                                list.Add(entry);
                            }
                        }

                        output = list.ToArray();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error:{0}", ex.Message);
                    }
                }

            } while (output == null);

            
            return output;
        }
    }
}
