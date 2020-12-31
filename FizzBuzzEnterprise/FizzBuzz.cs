using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzEnterprise
{
    public class FizzBuzz
    {
        private List<ModuloStatement> _statements;

        public FizzBuzz() { }

        public FizzBuzz(List<ModuloStatement> statements)
        {
            _statements = statements;
        }

        /// <summary>
        /// Performs a normal FizzBuzz calculation using hardcoded conditions
        /// </summary>
        /// <param name="upperBound">Where the FizzBuzz iteration should stop</param>
        /// <returns></returns>
        public IEnumerable<string> RunHardcoded(int upperBound)
        {
            if (upperBound <= 1)
            {
                throw new ArgumentException("Supplied value less than starting position, FizzBuzz will not occur");
            }

            for (int i = 1; i <= upperBound; i++)
            {
                bool divisibleByThree = i % 3 == 0;
                bool divisibleByFive = i % 5 == 0;

                if (divisibleByThree && divisibleByFive)
                {
                    yield return "FizzBuzz";
                }
                else if (divisibleByThree)
                {
                    yield return "Fizz";
                }
                else if (divisibleByFive)
                {
                    yield return "Buzz";
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }

        /// <summary>
        /// Performs a normal FizzBuzz calculation
        /// </summary>
        /// <param name="upperBound">The number where the FizzBuzz calculation should stop</param>
        /// <returns>Yield returns a string with the result of the operation</returns>
        public IEnumerable<string> Run(int upperBound)
        {
            if (!_statements.Any())
            {
                throw new InvalidOperationException("There are no statements for FizzBuzz to evaluate");
            }

            if (upperBound <= 1)
            {
                throw new ArgumentException("Supplied value is less than the starting position, FizzBuzz will not occur");
            }

            for (int i = 1; i <= upperBound; i++)
            {
                var successfulModuloOperations = _statements.Where(op => op.Logic(i)).ToList();

                if (successfulModuloOperations.Count > 1)
                {
                    var trueOperationWithMostModuli = successfulModuloOperations.OrderByDescending(op => op.NumberOfModuli)
                                                                                .FirstOrDefault();

                    yield return trueOperationWithMostModuli.Result;
                }
                else if (successfulModuloOperations.Count == 1)
                {
                    yield return successfulModuloOperations.First().Result;
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }
    }
}
