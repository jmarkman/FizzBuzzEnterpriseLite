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
                statementBuilder.Build("FizzBuzz", 3, 5),
                statementBuilder.Build("Fizz", 3),
                statementBuilder.Build("Buzz", 5)
            };

            FizzBuzz fb = new FizzBuzz(statements);

            foreach (var item in fb.CustomFizzBuzz(100))
            {
                Console.WriteLine(item);
            }

        }
    }
}
