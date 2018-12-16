namespace RobotSpiders.Tests.SpecificationTests
{
    using NUnit.Framework;

    using RobotSpiders.Specifications;

    internal class InstructionSetSpecificationUnitTests
    {
        private InstructionSetSpecification _specification;

        [SetUp]
        public void Init()
        {
            var validCharacters = new[] { 'F', 'L', 'R' };
            this._specification = new InstructionSetSpecification(validCharacters);
        }

        [Test]
        public void IsSatisfiedBy_AllValidCharacters_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("LFRR");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSatisfiedBy_LowerCaseCharacters_ReturnsFalse()
        {
            var result = this._specification.IsSatisfiedBy("lfrr");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsSatisfiedBy_ContainsInvalidCharacter_ReturnsFalse()
        {
            var result = this._specification.IsSatisfiedBy("LFRRZ");
            Assert.That(result == false);
        }

        [Test]
        public void IsSatisfiedBy_ContainsAllInvalidCharacter_ReturnsFalse()
        {
            var result = this._specification.IsSatisfiedBy("ZAP");
            Assert.That(result == false);
        }

        [Test]
        public void IsSatisfiedBy_SingleValidCharacter_ReturnsTrue()
        {
            var result = this._specification.IsSatisfiedBy("L");
            Assert.That(result == true);
        }

        [Test]
        public void IsSatisfiedBy_NullString_ThrowsArgumentException()
        {
            Assert.That(() => this._specification.IsSatisfiedBy(null), Throws.ArgumentException);
        }

        [Test]
        public void IsSatisfiedBy_EmptyString_ThrowsArgumentException()
        {
            Assert.That(() => this._specification.IsSatisfiedBy(string.Empty), Throws.ArgumentException);
        }
    }
}