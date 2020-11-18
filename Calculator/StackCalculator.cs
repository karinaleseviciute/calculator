using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator
{
    class StackCalculator
    {
        public Stack<int> result = new Stack<int>();

        public void getCommand(string command)
        {
            if (command.ToLower().Contains("push"))
            {
                string data = Regex.Match(command, @"\d+").Value;
                if (!string.IsNullOrEmpty(data))
                {
                    if (result.Count < 5)
                    {
                        result.Push(Int32.Parse(data));
                    }
                    else
                    {
                        Console.WriteLine("The maximum capacity of stack is 5");
                    }
                }
                else
                {
                    Console.WriteLine("Only numbers are allowed to be pushed to the stack");
                }
            }

            if (command.ToLower().Contains("pop") && result.Count>0)
            {
                result.Pop();
            }

            if (command.ToLower() == "add")
            {
                try {
                    result.Push(result.Pop() + result.Pop());

                    Console.WriteLine("\nResult: {0}", result.Peek());

                } catch (Exception e)
                {
                    Console.WriteLine("Not enough numbers on the stack to perform addition");
                }
            }

            if (command.ToLower() == "sub")
            {
                try
                {
                    int res = result.Pop() - result.Pop();

                    if (res < 0)
                    {
                        result.Push(1024 + res);
                    }
                    else {
                        result.Push(res);
                    }

                    Console.WriteLine("\nResult: {0}", result.Peek());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not enough numbers on the stack to perform substraction");
                }
            }
        }           
    }
}