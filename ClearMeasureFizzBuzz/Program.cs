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
            FizzBuzzDI fizzBuzzDI = new FizzBuzzDI(new ConsoleWriter());

            fizzBuzzDI.Run(100);

            Console.WriteLine();
            Console.WriteLine("Now running with custom modulo statements");
            Console.WriteLine();

            ModuloStatementBuilder statementBuilder = new ModuloStatementBuilder();

            List<ModuloStatement> statements = new List<ModuloStatement>()
            {
                statementBuilder.Build("Foo", 2),
                statementBuilder.Build("Bar", 4),
                statementBuilder.Build("FooBar", 2, 4),
                statementBuilder.Build("FizzBuzz", 3, 5),
                statementBuilder.Build("Fizz", 3),
                statementBuilder.Build("Buzz", 5)
            };

            FizzBuzz fb = new FizzBuzz();

            foreach (var item in fb.Run(100, statements))
            {
                Console.WriteLine(item);
            }
        }
    }
}
