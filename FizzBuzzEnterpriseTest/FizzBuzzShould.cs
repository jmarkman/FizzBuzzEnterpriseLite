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
        private int _numberDivisibleByThree = 3;
        private int _numberDivisibleByFive = 5;
        private int _numberDivisibleByThreeAndFive = 30;
        
        [SetUp]
        public void Setup()
        {
            _fizzBuzzUnderTest = new FizzBuzz();
        }

        [Test]
        public void ReturnFizzBuzz_IfDivisibleByThreeAndFive()
        {
            var lastElement = _fizzBuzzUnderTest.YieldFizzBuzz(_numberDivisibleByThreeAndFive).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void ReturnFizz_IfDivisibleByThree()
        {
            var lastElement = _fizzBuzzUnderTest.YieldFizzBuzz(_numberDivisibleByThree).LastOrDefault();

            Assert.That(lastElement, Is.EqualTo("Fizz"));
        }

        [Test]
        public void ReturnBuzz_IfDivisibleByFive()
        {
            var lastElement = _fizzBuzzUnderTest.YieldFizzBuzz(_numberDivisibleByFive).LastOrDefault();

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