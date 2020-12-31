using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzEnterprise
{
    /// <summary>
    /// Represents a modulo statement that will determine whether
    /// or not a provided number is divisible by the numbers in
    /// the <see cref="Func{int, bool}"/> within this class
    /// </summary>
    public class ModuloStatement
    {
        /// <summary>
        /// The mathematical logic to perform for the conditional
        /// </summary>
        public Func<int, bool> Logic { get; private set; }

        /// <summary>
        /// The text to use for the output if the condition in <see cref="Logic"/> is true
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// The number of moduli being checked in one operation (i.e., is the input
        /// for the logic being checked for divisibility against a single number or
        /// is it being checked against multiple numbers)
        /// </summary>
        public int NumberOfModuli { get; set; }

        public ModuloStatement() { }

        public ModuloStatement(Func<int, bool> logic, string result, int numModuli)
        {
            Logic = logic;
            Result = result;
            NumberOfModuli = numModuli;
        }
    }
}
