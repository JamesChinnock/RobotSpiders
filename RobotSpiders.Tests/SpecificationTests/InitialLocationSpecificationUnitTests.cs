namespace RobotSpiders.Tests.SpecificationTests
{
    using System.Drawing;

    using NUnit.Framework;

    using RobotSpiders.Specifications;

    internal class InitialLocationSpecificationUnitTests
    {
        private InitialLocationSpecification _specification;

        [SetUp]
        public void Init()
        {
            this._specification = new InitialLocationSpecification();
        }

        [Test]
        public void IsSatisfiedBy_NegativeXAxisValue_ReturnsFalse()
        {
            var point = new Point(-1, 2);
            var result = this._specification.IsSatisfiedBy(point);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsSatisfiedBy_NegativeYAxisValue_ReturnsFalse()
        {
            var point = new Point(2, -2);
            var result = this._specification.IsSatisfiedBy(point);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsSatisfiedBy_PositiveValues_ReturnsFalse()
        {
            var point = new Point(2, 7);
            var result = this._specification.IsSatisfiedBy(point);
            Assert.IsTrue(result);
        }
    }
}