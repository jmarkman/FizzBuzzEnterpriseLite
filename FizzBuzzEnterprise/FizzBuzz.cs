using System;

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
    }
}
