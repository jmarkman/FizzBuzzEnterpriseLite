﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzOutput
{
    public class ItemYielder<T> : IOutput<T>
    {
        public T Output(T input)
        {
            return input;
        }
    }
}
