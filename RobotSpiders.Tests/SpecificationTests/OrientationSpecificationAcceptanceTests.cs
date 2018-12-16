namespace RobotSpiders.Tests.SpecificationTests
{
    using NUnit.Framework;

    using RobotSpiders.Specifications;

    internal class OrientationSpecificationAcceptanceTests
    {
        private OrientationSpecification _specification;

        [SetUp]
        public void Init()
        {
            this._specification = new OrientationSpecification();
        }

        [Test]
        public void Ctor_NoParameters_NoExceptionThrown()
        {
            this._specification = new OrientationSpecification();
        }

        [Test]
        public void IsSatisfiedBy_EmptyStringParameter_ArgumentExceptionThrown()
        {
            Assert.That(() => this._specification.IsSatisfiedBy(string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void IsSatisfiedBy_NullStringParameter_ArgumentExceptionThrown()
        {
            Assert.That(() => this._specification.IsSatisfiedBy(null), Throws.ArgumentException);
        }
    }
}