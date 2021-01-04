using FizzBuzzOutput;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzEnterprise
{
    public class FizzBuzz
    {
        public FizzBuzz() { }

        /// <summary>
        /// Performs a normal FizzBuzz calculation using hardcoded conditions
        /// </summary>
        /// <param name="upperBound">Where the FizzBuzz iteration should stop</param>
        /// <returns></returns>
        public IEnumerable<string> Run(int upperBound)
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
        /// <param name="moduloStatements">A list of <see cref="ModuloStatement"/> objects containing
        /// custom modulo expressions to be validated and the output to return if the expression is
        /// correct</param>
        /// <returns>Yield returns a string with the result of the operation</returns>
        public IEnumerable<string> Run(int upperBound, List<ModuloStatement> moduloStatements)
        {
            ValidateFizzBuzzParameters(upperBound, moduloStatements);

            for (int i = 1; i <= upperBound; i++)
            {
                var successfulModuloOperation = OrderAndEvaluateStatements(moduloStatements, i);

                if (successfulModuloOperation != null)
                {
                    yield return successfulModuloOperation.Result;
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }

        /// <summary>
        /// Orders the list of <see cref="ModuloStatement"/> by number of moduli being evaluated and 
        /// returns the first <see cref="ModuloStatement"/> that evaluates to true
        /// </summary>
        /// <param name="statements">The list of <see cref="ModuloStatement"/></param>
        /// <param name="currentLoopIteration">The integer representing the current step in the FizzBuzz loop</param>
        /// <returns>If the statement evaluates to true, returns the <see cref="ModuloStatement"/> object. Otherwise,
        /// this method will return <b>null</b>.</returns>
        private ModuloStatement OrderAndEvaluateStatements(List<ModuloStatement> statements, int currentLoopIteration)
        {
            var sortedStatements = statements.OrderByDescending(op => op.NumberOfModuli);

            foreach (var moduloStatement in sortedStatements)
            {
                if (moduloStatement.Logic(currentLoopIteration))
                {
                    return moduloStatement;
                }
            }

            return null;
        }

        /// <summary>
        /// Ensures that the upper-bound limit and the custom modulo statements are valid
        /// </summary>
        /// <param name="upperBound">Where the FizzBuzz operation should stop</param>
        /// <param name="statements">A list of <see cref="ModuloStatement"/> objects containing
        /// custom modulo expressions to be validated and the output to return if the expression is
        /// correct</param>
        private void ValidateFizzBuzzParameters(int upperBound, List<ModuloStatement> statements)
        {
            if (upperBound <= 1)
            {
                throw new ArgumentException("Supplied value is less than the starting position, FizzBuzz will not occur");
            }

            if (!statements.Any())
            {
                throw new ArgumentException("There are no statements for FizzBuzz to evaluate");
            }
        }
    }
}
