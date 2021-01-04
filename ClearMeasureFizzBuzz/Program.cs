using System;
using System.Collections.Generic;
using FizzBuzzEnterprise;
using FizzBuzzOutput;

namespace ClearMeasureFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running with injected ConsoleWriter");
            Console.WriteLine();

            FizzBuzzDI fizzBuzzConsole = new FizzBuzzDI(new ConsoleWriter());

            fizzBuzzConsole.Run(100);
        }
    }
}
