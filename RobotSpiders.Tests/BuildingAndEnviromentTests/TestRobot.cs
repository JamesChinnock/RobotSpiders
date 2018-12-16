namespace RobotSpiders.Tests.BuildingAndEnviromentTests
{
    using System.Collections.Generic;
    using System.Drawing;

    using Patterns.State;

    using RobotSpiders.Interfaces;
    using RobotSpiders.Movement;

    internal class TestRobot : IRobot
    {
        public bool IsMethodInvoked { get; set; }

        public int InstructionNumber { get; set; }

        public Point CurrentLocation { get; set; }

        public Orientation CurrentOrientation { get; set; }

        public List<char> InstructionSet { get; }

        public Status Status { get; set; }

        public void Move()
        {
            this.IsMethodInvoked = true;
        }
    }
}