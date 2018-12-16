using System.Collections.Generic;

namespace RobotSpiders.Tests.BuildingAndEnviromentTests
{
    using System.Drawing;

    using Moq;

    using NUnit.Framework;

    using Patterns.State;

    using RobotSpiders.Factories;
    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;

    internal class BuildingAcceptanceTests
    {
        private Mock<RobotFactory> _mockFactory;

        private Mock<IRobotLogger> _mockLogger;
        
        private Building _building;

        [SetUp]
        public void Init()
        {
            this._mockFactory = new Mock<RobotFactory>();
            this._mockLogger = new Mock<IRobotLogger>();
            this._building = new Building(this._mockFactory.Object, this._mockLogger.Object);
        }

        [Test]
        public void Ctor_ValidParameters_NoExceptionThrown()
        {
            this._building = new Building(this._mockFactory.Object, this._mockLogger.Object);
        }

        [Test]
        public void Ctor_NullFactoryParameter_ArgumentNullExceptionThrown()
        {
            Assert.That(() => this._building = new Building(null, this._mockLogger.Object), Throws.ArgumentNullException);
        }

        [Test]
        public void Ctor_NullLoggerParameter_ArgumentNullExceptionThrown()
        {
            Assert.That(() => this._building = new Building(this._mockFactory.Object, null), Throws.ArgumentNullException);
        }

        [Test]
        public void Inspect_InvokesCreateRobots_OnRobotFactory()
        {
            this._mockFactory.Setup(x => x.CreateRobots(It.IsAny<EnvironmentSettings>()))
                .Returns(new List<IRobot>());
            var envSettings = new EnvironmentSettings();
            this._building.Inspect(envSettings);
            this._mockFactory.Verify(x => x.CreateRobots(It.IsAny<EnvironmentSettings>()), Times.Once);
        }

        [Test]
        public void Inspect_InvokesLog_OnLogger()
        {
            this._mockFactory.Setup(x => x.CreateRobots(It.IsAny<EnvironmentSettings>()))
                .Returns(new List<IRobot> {new TestRobot()});
            var envSettings = new EnvironmentSettings();
            this._building.Inspect(envSettings);
            this._mockLogger.Verify(x => x.Log(It.IsAny<Point>(), It.IsAny<Orientation>()), Times.Once);
        }

        [Test]
        public void Inspect_InvokesMove_OnRobot()
        {
            var testRobot = new TestRobot();

            this._mockFactory.Setup(x => x.CreateRobots(It.IsAny<EnvironmentSettings>()))
                .Returns(new List<IRobot> { testRobot });
            var envSettings = new EnvironmentSettings();
            this._building.Inspect(envSettings);
            Assert.IsTrue(testRobot.IsMethodInvoked);
        }
    }
}
