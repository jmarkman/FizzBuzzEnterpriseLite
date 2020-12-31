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
        public IEnumerable<string> YieldFizzBuzz(int upperBound)
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

        public IEnumerable<string> CustomFizzBuzz(int upperBound)
        {
            if (upperBound <= 1)
            {
                throw new ArgumentException("Supplied value is less than the starting position, FizzBuzz will not occur");
            }

            for (int i = 1; i <= upperBound; i++)
            {
                var trueModuloOperations = _statements.Where(op => op.Logic(i)).ToList();

                if (trueModuloOperations.Count == 1)
                {
                    yield return trueModuloOperations.First().Result;
                }
                else
                {
                    yield return i.ToString();
                }

                //foreach (var modulo in _statements)
                //{
                //    if (modulo.Logic(i))
                //    {
                //        yield return modulo.Result;
                //    }
                //    else
                //    {
                //        yield return i.ToString();
                //    }
                //}
            }
        }
    }
}
