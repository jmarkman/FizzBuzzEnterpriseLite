using FizzBuzzEnterprise;
using NUnit.Framework;
using System;
using System.Linq;

namespace FizzBuzzEnterpriseTest
{
    [TestFixture]
    public class FizzBuzzShould
    {
        private FizzBuzz _fizzBuzzUnderTest;
        private const int NumberDivisibleByThree = 3;
        private const int NumberDivisibleByFive = 5;
        private const int NumberDivisibleByThreeAndFive = 30;
        
        [SetUp]
        public void Setup()
        {
            _fizzBuzzUnderTest = new FizzBuzz();
        }

        [Test]
        public void ReturnFizzBuzz_IfDivisibleByThreeAndFive()
        {
            var lastElement = _fizzBuzzUnderTest.YieldFizzBuzz(NumberDivisibleByThreeAndFive).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void ReturnFizz_IfDivisibleByThree()
        {
            var lastElement = _fizzBuzzUnderTest.YieldFizzBuzz(NumberDivisibleByThree).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo("Fizz"));
        }

        [Test]
        public void ReturnBuzz_IfDivisibleByFive()
        {
            var lastElement = _fizzBuzzUnderTest.YieldFizzBuzz(NumberDivisibleByFive).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo("Buzz"));
        }

        [Test]
        public void ThrowArgumentException_IfSuppliedUpperBound_IsLessThanOrEqualToOne()
        {
            Assert.That(() => _fizzBuzzUnderTest.YieldFizzBuzz(1).ToList(), Throws.TypeOf<ArgumentException>());
            Assert.That(() => _fizzBuzzUnderTest.YieldFizzBuzz(0).ToList(), Throws.TypeOf<ArgumentException>());
        }
    }
}