namespace RobotSpiders.Tests.SpecificationTests
{
    using NUnit.Framework;

    using RobotSpiders.Specifications;

    internal class GridSizeSpecificationAcceptanceTests
    {
        private GridSizeSpecification _gridsizeSpecification;

        [SetUp]
        public void Init()
        {
            this._gridsizeSpecification = new GridSizeSpecification();
        }

        [Test]
        public void IsSatisfiedBy_NullParameter_ArgumentNullExceptionThrown()
        {
            Assert.That(() => this._gridsizeSpecification.IsSatisfiedBy(null), Throws.ArgumentNullException);
        }
    }
}