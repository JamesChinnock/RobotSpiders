namespace RobotSpiders.Tests.BuildingAndEnviromentTests
{
    using NUnit.Framework;

    using RobotSpiders.FractureDetection;

    internal class GridSizeUnitTests
    {
        private const int _vertical = 10;

        private const int _horizontal = 20;

        private GridSize _gridSize;

        [SetUp]
        public void Init()
        {
            this._gridSize = new GridSize(_horizontal, _vertical);
        }

        [Test]
        public void Vertical_Returns_VerticalCtorParameter()
        {
            Assert.That(this._gridSize.VerticalCells == _vertical);
        }

        [Test]
        public void Vertical_Returns_HorizontalCtorParameter()
        {
            Assert.That(this._gridSize.HorizontalCells == _horizontal);
        }
    }
}