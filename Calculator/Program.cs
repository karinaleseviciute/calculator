using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        public static void Main()
        {
            StackCalculator cal = new StackCalculator();
            string x;
            while (true)
            {
                Console.WriteLine("\nWrite a command");
                    x = Console.ReadLine();
                    cal.getCommand(x);                  
            }
         }
     }
 }

