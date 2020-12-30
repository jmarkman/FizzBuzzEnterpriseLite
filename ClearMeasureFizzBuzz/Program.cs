using System;
using FizzBuzzEnterprise;

namespace ClearMeasureFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz fb = new FizzBuzz();

            fb.PerformFizzBuzz(int.MaxValue);
        }
    }
}
