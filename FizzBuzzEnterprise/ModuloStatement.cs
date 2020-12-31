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

        public ModuloStatement(Func<int, bool> logic, string result)
        {
            Logic = logic;
            Result = result;
        }
    }
}
