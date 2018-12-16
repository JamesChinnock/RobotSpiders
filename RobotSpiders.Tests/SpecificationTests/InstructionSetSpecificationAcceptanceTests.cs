namespace RobotSpiders.Tests.SpecificationTests
{
    using NUnit.Framework;

    using RobotSpiders.Specifications;

    internal class InstructionSetSpecificationAcceptanceTests
    {
        private InstructionSetSpecification _specification;

        [SetUp]
        public void Init()
        {
            var validCharacters = new[] { 'F', 'L', 'R' };
            this._specification = new InstructionSetSpecification(validCharacters);
        }

        [Test]
        public void Ctor_NoParameters_ThrowsArgumentNullException()
        {
            Assert.That(() => this._specification = new InstructionSetSpecification(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Ctor_EmptyCharacterList_ThrowsArgumentException()
        {
            var emptyList = new char[] { };
            Assert.That(() => this._specification = new InstructionSetSpecification(emptyList), 
                Throws.ArgumentException);
        }
    }
}