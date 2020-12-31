using FizzBuzzEnterprise;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzEnterpriseTest
{
    [TestFixture]
    public class FizzBuzzShould
    {
        private const int NumberDivisibleByThree = 3;
        private const int NumberDivisibleByFive = 5;
        private const int NumberDivisibleByThreeAndFive = 30;
        private const string DivisibleByBothOutput = "FizzBuzz";
        private const string DivisibleByThreeOutput = "Fizz";
        private const string DivisibleByFiveOutput = "Buzz";

        private FizzBuzz _hardcodedFizzBuzzUnderTest;
        private FizzBuzz _fizzBuzzWithCustomConditionsUnderTest;

        [SetUp]
        public void Setup()
        {
            _hardcodedFizzBuzzUnderTest = new FizzBuzz();

            ModuloStatementBuilder builder = new ModuloStatementBuilder();
            List<ModuloStatement> moduloStatements = new List<ModuloStatement>()
            {
                builder.Build("Foo", 2),
                builder.Build("Bar", 4),
                builder.Build("FooBar", 2, 4),
                builder.Build("FizzBuzz", 3, 5),
                builder.Build("Fizz", 3),
                builder.Build("Buzz", 5)
            };

            _fizzBuzzWithCustomConditionsUnderTest = new FizzBuzz(moduloStatements);
        }

        [Test]
        public void ReturnFizzBuzz_IfDivisibleByThreeAndFive()
        {
            var lastElement = _hardcodedFizzBuzzUnderTest.RunHardcoded(NumberDivisibleByThreeAndFive).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo(DivisibleByBothOutput));
        }

        [Test]
        public void ReturnFizz_IfDivisibleByThree()
        {
            var lastElement = _hardcodedFizzBuzzUnderTest.RunHardcoded(NumberDivisibleByThree).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo(DivisibleByThreeOutput));
        }

        [Test]
        public void ReturnBuzz_IfDivisibleByFive()
        {
            var lastElement = _hardcodedFizzBuzzUnderTest.RunHardcoded(NumberDivisibleByFive).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo(DivisibleByFiveOutput));
        }

        [Test]
        public void ThrowArgumentException_IfNoCustomModuloStatementsProvided()
        {

        }

        [Test]
        public void ThrowArgumentException_IfSuppliedUpperBound_IsLessThanOrEqualToOne()
        {
            Assert.That(() => _hardcodedFizzBuzzUnderTest.RunHardcoded(1).ToList(), Throws.TypeOf<ArgumentException>());
            Assert.That(() => _hardcodedFizzBuzzUnderTest.RunHardcoded(0).ToList(), Throws.TypeOf<ArgumentException>());
            Assert.That(() => _hardcodedFizzBuzzUnderTest.Run(1).ToList(), Throws.TypeOf<ArgumentException>());
            Assert.That(() => _hardcodedFizzBuzzUnderTest.Run(0).ToList(), Throws.TypeOf<ArgumentException>());
        }
    }
}