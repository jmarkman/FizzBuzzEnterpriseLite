using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzOutput
{
    public class ItemYielder<T> : IOutput
    {
        public T Output(T input)
        {
            return input;
        }
    }
}
