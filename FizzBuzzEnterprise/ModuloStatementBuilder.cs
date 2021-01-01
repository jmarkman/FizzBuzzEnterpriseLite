using System;
using System.Linq;

namespace FizzBuzzEnterprise
{
    /// <summary>
    /// Handles the creation of <see cref="ModuloStatement"/>, including
    /// creating the modulo math logic
    /// </summary>
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
            ValidateBuildParameters(resultToDisplay, moduli);

            return new ModuloStatement(BuildModuloLogic(moduli), resultToDisplay, moduli.Length);
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
                return moduli.All(m => i % m == 0);
            };

            return divisible;
        }

        /// <summary>
        /// Ensures that the input supplied to <see cref="Build(string, int[])"/>
        /// will create a usable modulo statement
        /// </summary>
        /// <param name="result">The text to be used if the modulo operation is successful</param>
        /// <param name="moduli">The number or numbers to use for modulo calculation</param>
        private void ValidateBuildParameters(string result, int[] moduli)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                throw new ArgumentException("No custom output was specified");
            }

            if (!moduli.Any())
            {
                throw new ArgumentException("No numbers for modulo calculation were provided");
            }
        }
    }
}
