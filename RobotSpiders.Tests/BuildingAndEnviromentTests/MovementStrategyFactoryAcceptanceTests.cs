namespace RobotSpiders.Tests.BuildingAndEnviromentTests
{
    using Moq;

    using NUnit.Framework;

    using RobotSpiders.Factories;
    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;
    using RobotSpiders.Movement;

    internal class MovementStrategyFactoryAcceptanceTests
    {
        private Mock<IUpdateLocationStrategy> _mockLocationStrategy;

        private Mock<IInstructionParser> _instructionPaser;

        private MovementStrategyFactory _strategyFactory;

        [SetUp]
        public void Init()
        {
            this._mockLocationStrategy = new Mock<IUpdateLocationStrategy>();
            this._instructionPaser = new Mock<IInstructionParser>();

            this._strategyFactory = new MovementStrategyFactory(this._mockLocationStrategy.Object, this._instructionPaser.Object);
        }

        [Test]
        public void Ctor_NoParameters_NoExceptionThrown()
        {
            this._strategyFactory = new MovementStrategyFactory(this._mockLocationStrategy.Object, this._instructionPaser.Object);
        }

        [Test]
        public void CreateStrategy_NullParameter_ThrowsARgumentException()
        {
            Assert.That(() => this._strategyFactory.CreateStrategy(null), Throws.ArgumentNullException);
        }

        [Test]
        public void CreateStrategy_ReturnedType_IsSpiderMovementStrategy()
        {
            var envSettings = new EnvironmentSettings();
            var result = this._strategyFactory.CreateStrategy(envSettings);
            Assert.That(result.GetType() == typeof(SpiderMovementStrategy));
        }
    }
}