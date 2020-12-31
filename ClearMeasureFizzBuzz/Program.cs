using System;
using System.Collections.Generic;
using FizzBuzzEnterprise;

namespace ClearMeasureFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
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

            FizzBuzz fb = new FizzBuzz(statements);

            foreach (var item in fb.Run(100))
            {
                Console.WriteLine(item);
            }

        }
    }
}
