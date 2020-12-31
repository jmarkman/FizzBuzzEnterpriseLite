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
        private const int NumberDivisibleByTwo = 2;
        private const int NumberDivisibleByThreeAndFive = 30;
        private const int NumberDivisibleByTwoAndFour = 8;
        private const string DivisibleByThreeAndFiveOutput = "FizzBuzz";
        private const string DivisibleByThreeOutput = "Fizz";
        private const string DivisibleByFiveOutput = "Buzz";

        private readonly List<ModuloStatement> _emptyListOfModuloStatements = new List<ModuloStatement>();

        private FizzBuzz _fizzBuzzUnderTest;
        private List<ModuloStatement> _moduloStatements;
        

        [SetUp]
        public void Setup()
        {
            _fizzBuzzUnderTest = new FizzBuzz();

            ModuloStatementBuilder builder = new ModuloStatementBuilder();
            _moduloStatements = new List<ModuloStatement>()
            {
                builder.Build("Foo", 2),
                builder.Build("Bar", 4),
                builder.Build("FooBar", 2, 4),
                builder.Build("FizzBuzz", 3, 5),
                builder.Build("Fizz", 3),
                builder.Build("Buzz", 5)
            };
        }

        [Test]
        public void ReturnFizzBuzz_IfDivisibleByThreeAndFive()
        {
            var lastElement = _fizzBuzzUnderTest.RunHardcoded(NumberDivisibleByThreeAndFive).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo(DivisibleByThreeAndFiveOutput));
        }

        [Test]
        public void ReturnFizz_IfDivisibleByThree()
        {
            var lastElement = _fizzBuzzUnderTest.RunHardcoded(NumberDivisibleByThree).Last();

            Assert.That(lastElement, Is.EqualTo(DivisibleByThreeOutput));
        }

        [Test]
        public void ReturnBuzz_IfDivisibleByFive()
        {
            var lastElement = _fizzBuzzUnderTest.RunHardcoded(NumberDivisibleByFive).Last();

            Assert.That(lastElement, Is.EqualTo(DivisibleByFiveOutput));
        }

        [Test]
        public void ReturnUserSpecifiedReuslt_IfDivisibleBy_OneCustomModuli()
        {
            var userSpecifiedModuloStatement = _moduloStatements.Where(s => s.Result == "Foo" && s.NumberOfModuli == 1).First();

            var lastElement = _fizzBuzzUnderTest.Run(NumberDivisibleByTwo, _moduloStatements).Last();

            Assert.That(lastElement, Is.EqualTo(userSpecifiedModuloStatement.Result));
        }

        [Test]
        public void ReturnUserSpecifiedResult_IfDivisibleBy_TwoOrMoreCustomModuli()
        {
            var userSpecifiedModuloStatement = _moduloStatements.Where(s => s.Result == "FooBar" && s.NumberOfModuli > 1).First();

            var lastElement = _fizzBuzzUnderTest.Run(NumberDivisibleByTwoAndFour, _moduloStatements).Last();

            Assert.That(lastElement, Is.EqualTo(userSpecifiedModuloStatement.Result));
        }

        [Test]
        public void ThrowArgumentException_IfNoCustomModuloStatementsProvided()
        {
            Assert.That(() => _fizzBuzzUnderTest.Run(3, _emptyListOfModuloStatements).Last(), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ThrowArgumentException_IfSuppliedUpperBound_IsLessThanOrEqualToOne()
        {
            Assert.That(() => _fizzBuzzUnderTest.RunHardcoded(1).ToList(), Throws.TypeOf<ArgumentException>());
            Assert.That(() => _fizzBuzzUnderTest.RunHardcoded(0).ToList(), Throws.TypeOf<ArgumentException>());
            Assert.That(() => _fizzBuzzUnderTest.Run(1, _moduloStatements).ToList(), Throws.TypeOf<ArgumentException>());
            Assert.That(() => _fizzBuzzUnderTest.Run(0, _moduloStatements).ToList(), Throws.TypeOf<ArgumentException>());
        }
    }
}