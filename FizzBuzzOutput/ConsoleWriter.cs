using System;

namespace FizzBuzzOutput
{
    public class ConsoleWriter : IOutput
    {
        public ConsoleWriter() { }

        public void Output(object input)
        {
            Console.WriteLine(input.ToString());
        }
    }
}
