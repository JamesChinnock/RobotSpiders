namespace RobotSpiders.Tests
{
    using System.Drawing;

    using NUnit.Framework;

    using Patterns.State;

    using RobotSpiders.FractureDetection;

    internal class EndToEndAcceptanceTests
    {
        private EnvironmentSettings _environmentSettings;

        [SetUp]
        public void Init()
        {
            this._environmentSettings = new EnvironmentSettings
                                            {
                                                GridSize = new GridSize(7, 15),
                                                Location = new Point(2, 4),
                                                Orientation = Orientation.Down,
                                                InstructionSet = "FLFLFRFFLF"
                                            };
        }

        [Test]
        public void RunTest()
        {

        }
    }
}