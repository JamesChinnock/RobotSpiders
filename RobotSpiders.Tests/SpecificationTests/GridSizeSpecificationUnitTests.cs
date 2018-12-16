namespace RobotSpiders.Tests.SpecificationTests
{
    using NUnit.Framework;

    using RobotSpiders.FractureDetection;
    using RobotSpiders.Specifications;

    internal class GridSizeSpecificationUnitTests
    {
        private GridSizeSpecification _gridsizeSpecification;

        [SetUp]
        public void Init()
        {
            this._gridsizeSpecification = new GridSizeSpecification();
        }

        [Test]
        public void Ctor_NoParameters_NoExceptionThrown()
        {
            this._gridsizeSpecification = new GridSizeSpecification();
        }

        [Test]
        public void IsSatisfiedBy_GridsizeVerticalLessThanZero_ReturnsFalse()
        {
            var gridsize = new GridSize(-1, 2);
            var result = this._gridsizeSpecification.IsSatisfiedBy(gridsize);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsSatisfiedBy_GridsizeHorizontalLessThanZero_ReturnsFalse()
        {
            var gridsize = new GridSize(2, -2);
            var result = this._gridsizeSpecification.IsSatisfiedBy(gridsize);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsSatisfiedBy_GridsizePositiveIntegers_ReturnsTrue()
        {
            var gridsize = new GridSize(2, 7);
            var result = this._gridsizeSpecification.IsSatisfiedBy(gridsize);
            Assert.IsTrue(result);
        }
    }
}