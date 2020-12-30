using System;
using System.Collections.Generic;

namespace FizzBuzzEnterprise
{
    public class FizzBuzz
    {
        public FizzBuzz()
        {
                
        }

        // upperBound is int for however far you want to calculate
        public void PerformFizzBuzz(int upperBound)
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
                    Console.WriteLine("FizzBuzz");
                }
                else if (divisibleByThree)
                {
                    Console.WriteLine("Fizz");
                }
                else if (divisibleByFive)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
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
    }
}
