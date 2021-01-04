using FizzBuzzOutput;
using System; // Reliance on System for (Argument)Exception

namespace FizzBuzzEnterprise
{
    public class FizzBuzzDI
    {
        private ConsoleWriter _writer;

        public FizzBuzzDI(ConsoleWriter outputWriter)
        {
            _writer = outputWriter;
        }

        /// <summary>
        /// Performs a normal FizzBuzz calculation using hardcoded conditions
        /// </summary>
        /// <param name="upperBound">Where the FizzBuzz iteration should stop</param>
        /// <returns></returns>
        public void Run(int upperBound)
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
                    _writer.Output("FizzBuzz");
                }
                else if (divisibleByThree)
                {
                    _writer.Output("Fizz");
                }
                else if (divisibleByFive)
                {
                    _writer.Output("Buzz");
                }
                else
                {
                    _writer.Output(i.ToString());
                }
            }
        }
    }
}
