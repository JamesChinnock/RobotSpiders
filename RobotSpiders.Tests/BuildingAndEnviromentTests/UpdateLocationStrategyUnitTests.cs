namespace RobotSpiders.Tests.BuildingAndEnviromentTests
{
    using System.Drawing;

    using NUnit.Framework;

    using Patterns.State;

    using RobotSpiders.Factories;
    using RobotSpiders.Movement;

    internal class UpdateLocationStrategyUnitTests
    {
        private TestRobot _testRobot;

        private const int Four = 4;

        private UpdateLocationStrategy _updateLocationStrategy;
        
        [SetUp]
        public void Init()
        {
            this._testRobot = new TestRobot { CurrentLocation = new Point(Four, Four) };
            this._updateLocationStrategy = new UpdateLocationStrategy();
        }

        [Test]
        public void Update_Down_ReturnsPointDownOneSquare()
        {
            this._updateLocationStrategy.Update(this._testRobot, Orientation.Down);
            Assert.That(this._testRobot.CurrentLocation.X == Four);
            Assert.That(this._testRobot.CurrentLocation.Y == Four - 1);
        }

        [Test]
        public void Update_Up_ReturnsPointUpOneSquare()
        {
            this._updateLocationStrategy.Update(this._testRobot, Orientation.Up);
            Assert.That(this._testRobot.CurrentLocation.X == Four);
            Assert.That(this._testRobot.CurrentLocation.Y == Four + 1);
        }

        [Test]
        public void Update_Left_ReturnsPointLeftOneSquare()
        {
            this._updateLocationStrategy.Update(this._testRobot, Orientation.Left);
            Assert.That(this._testRobot.CurrentLocation.X == Four - 1);
            Assert.That(this._testRobot.CurrentLocation.Y == Four);
        }

        [Test]
        public void Update_Right_ReturnsPointRightOneSquare()
        {
            this._updateLocationStrategy.Update(this._testRobot, Orientation.Right);
            Assert.That(this._testRobot.CurrentLocation.X == Four + 1);
            Assert.That(this._testRobot.CurrentLocation.Y == Four);
        }
    }
}