using System;

namespace FizzBuzzOutput
{
    public class ConsoleWriter
    {
        public ConsoleWriter() { }

        public void Output(object input)
        {
            Console.WriteLine(input.ToString());
        }
    }
}
