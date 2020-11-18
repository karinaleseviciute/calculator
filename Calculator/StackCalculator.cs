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
                int pushedNumber = Int32.Parse(data);
                if (!string.IsNullOrEmpty(data) && pushedNumber < 1024)
                {
                    if (result.Count < 5)
                    {
                        result.Push(pushedNumber);
                    }
                    else
                    {
                        Console.WriteLine("The maximum capacity of stack is 5");
                    }
                }
                else
                {
                    Console.WriteLine("Input is not valid");
                }
            }

            if (command.ToLower()=="pop" && result.Count>0)
            {
                result.Pop();
            }

            if (command.ToLower() == "add")
            {
                try {

                    int sum = result.Pop() + result.Pop();
                    if (sum > 1023)
                    {
                        sum = sum - 1023;
                        result.Push(sum);
                    }
                    else
                    {
                        result.Push(sum);
                    }
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
                        result.Push(1023 + res);
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