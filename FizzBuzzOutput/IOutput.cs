using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzOutput
{
    public interface IOutput<T>
    {
        T Output(T input);
    }
}
