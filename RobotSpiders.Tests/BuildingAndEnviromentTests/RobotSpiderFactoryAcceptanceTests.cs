namespace RobotSpiders.Tests.BuildingAndEnviromentTests
{
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using RobotSpiders.Factories;
    using RobotSpiders.FractureDetection;

    internal class RobotSpiderFactoryAcceptanceTests
    {
        private Mock<MovementFactory> _mockFactory;

        private RobotSpiderFactory _spiderFactory;

        [SetUp]
        public void Init()
        {
            this._mockFactory = new Mock<MovementFactory>();
            this._spiderFactory = new RobotSpiderFactory(this._mockFactory.Object);
        }

        [Test]
        public void Ctor_ValidParameters_NoExceptionThrown()
        {
            this._spiderFactory = new RobotSpiderFactory(this._mockFactory.Object);
        }

        [Test]
        public void Ctor_NullFactoryParameter_ArgumentNullExceptionThrown()
        {
            Assert.That(() => this._spiderFactory = new RobotSpiderFactory(null), Throws.ArgumentNullException);
        }

        [Test]
        public void CreateRobots_NullEnvironmentParameter_ThrowsArgumentNullException()
        {
            Assert.That(() => this._spiderFactory.CreateRobots(null), Throws.ArgumentNullException);
        }

        [Test]
        public void CreateRobots_CreateStrategy_InvokedOnStrategyFactory()
        {
            this._mockFactory.Setup(x => x.CreateStrategy(It.IsAny<EnvironmentSettings>()))
                .Returns(new TestMovementStrategy());
            var envSettings = new EnvironmentSettings { InstructionSet = "F" };
            this._spiderFactory.CreateRobots(envSettings);
            this._mockFactory.Verify(x => x.CreateStrategy(It.IsAny<EnvironmentSettings>()), Times.Once);
        }

        [Test]
        public void CreateRobots_NullParameter_ThrowsException()
        {
            Assert.That(() => this._spiderFactory.CreateRobots(null), Throws.ArgumentNullException);
        }

        [Test]
        public void CreateRobots_ReturnedType_IsOfTypeSpiderRobot()
        {
            var envSettings = new EnvironmentSettings { InstructionSet = "F" };
            var result = this._spiderFactory.CreateRobots(envSettings).First();
            Assert.That(result.GetType() == typeof(SpiderRobot));
        }
    }
}