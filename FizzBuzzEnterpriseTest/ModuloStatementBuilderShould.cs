using FizzBuzzEnterprise;
using NUnit.Framework;
using System;

namespace FizzBuzzEnterpriseTest
{
    [TestFixture]
    public class ModuloStatementBuilderShould
    {
        private const string EmptyInput = "";
        private const string TestInput = "Test";
        private const int Moduli = 3;
        private const int NumberThatIsDivisibleByModuli = 6;
        private readonly int[] _emptyArray = { };

        private ModuloStatementBuilder _statementBuilderUnderTest;
        
        [SetUp]
        public void Setup()
        {
            _statementBuilderUnderTest = new ModuloStatementBuilder();
        }

        [Test]
        public void ThrowArgumentException_IfNoInputIsSupplied()
        {
            Assert.That(() => _statementBuilderUnderTest.Build(EmptyInput, _emptyArray), Throws.TypeOf<ArgumentException>());
        }        
        
        [Test]
        public void ThrowArgumentException_IfTextValueNotSupplied()
        {
            Assert.That(() => _statementBuilderUnderTest.Build(EmptyInput, Moduli), Throws.TypeOf<ArgumentException>());
        }        
        
        [Test]
        public void ThrowArgumentException_IfNumbersForModuloNotSupplied()
        {
            Assert.That(() => _statementBuilderUnderTest.Build(TestInput, _emptyArray), Throws.TypeOf<ArgumentException>());
        }
        
        [Test]
        public void GenerateCorrectModuloCalculation()
        {
            var moduloStatement = _statementBuilderUnderTest.Build(TestInput, Moduli);

            Assert.That(moduloStatement.Logic(NumberThatIsDivisibleByModuli), Is.True);
        }


    }
}
