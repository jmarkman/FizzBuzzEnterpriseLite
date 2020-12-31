using FizzBuzzEnterprise;
using NUnit.Framework;

namespace FizzBuzzEnterpriseTest
{
    [TestFixture]
    public class ModuloStatementBuilderShould
    {
        private ModuloStatementBuilder _statementBuilderUnderTest;

        [SetUp]
        public void Setup()
        {
            _statementBuilderUnderTest = new ModuloStatementBuilder();
        }
    }
}
