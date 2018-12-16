namespace RobotSpiders.Tests.SpecificationTests
{
    using NUnit.Framework;

    using RobotSpiders.Specifications;

    internal class InitialLocationSpecificationAcceptanceTests
    {
        private InitialLocationSpecification _specification;

        [SetUp]
        public void Init()
        {
            this._specification = new InitialLocationSpecification();
        }

        [Test]
        public void Ctor_NoParameters_NoExceptionThrown()
        {
            this._specification = new InitialLocationSpecification();
        }
    }
}