using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzEnterprise
{
    public class ModuloStatementBuilder
    {
        public ModuloStatementBuilder() { }

        /// <summary>
        /// Creates a new modulo statement to use for "FizzBuzz" operations
        /// </summary>
        /// <param name="resultToDisplay"></param>
        /// <param name="moduli"></param>
        /// <returns></returns>
        public ModuloStatement Build(string resultToDisplay, params int[] moduli)
        {
            return new ModuloStatement(BuildModuloLogic(moduli), resultToDisplay);
        }

        /// <summary>
        /// Generates the mathematical logic for the modulo operation
        /// </summary>
        /// <param name="moduli">The input for the <see cref="Func{int, bool}"/>
        /// will be checked against these numbers to see if it will result
        /// in clean division without a remainder</param>
        /// <returns>A <see cref="Func{int, bool}"/> that houses the modulo operation</returns>
        private Func<int, bool> BuildModuloLogic(params int[] moduli)
        {
            Func<int, bool> divisible = (i) =>
            {
                bool isDivisible = false;

                foreach (var number in moduli)
                {
                    if (i % number == 0)
                    {
                        isDivisible = true;
                    }
                    else
                    {
                        isDivisible = false;
                    }
                }

                return isDivisible;
            };

            return divisible;
        }
    }
}
