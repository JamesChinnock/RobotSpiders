namespace RobotSpiders.Tests.SpecificationTests
{
    using NUnit.Framework;

    using RobotSpiders.Specifications;

    internal class OrientationSpecificationUnitTests
    {
        private OrientationSpecification _specification;

        [SetUp]
        public void Init()
        {
            this._specification = new OrientationSpecification();
        }

        [Test]
        public void IsSatisfiedBy_UppercaseDownValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("DOWN");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_LowercaseDownValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("down");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_UppercaseUpValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("UP");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_LowercaseUpValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("up");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_UppercaseLeftValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("LEFT");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_LowercaseLeftValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("left");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_UppercaseRightValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("RIGHT");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_LowercaseRightValue_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("right");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_InvalidOrientation_ReturnsFalse()
        {
            var result = this._specification.IsSatisfiedBy("North");
            Assert.IsFalse(result);
        }
    }
}