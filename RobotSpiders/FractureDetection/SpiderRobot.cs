namespace RobotSpiders.FractureDetection
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using Patterns.State;

    using RobotSpiders.Interfaces;
    using RobotSpiders.Movement;

    /// <inheritdoc />
    public class SpiderRobot : IRobot
    {
        /// <summary>
        /// The _movement strategy.
        /// </summary>
        private readonly IMovementStrategy _movementStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpiderRobot"/> class.
        /// </summary>
        /// <param name="envSettings">
        /// The env settings.
        /// </param>
        /// <param name="movementStrategy">
        /// The movement strategy.
        /// </param>
        public SpiderRobot(EnvironmentSettings envSettings, IMovementStrategy movementStrategy)
        {
            this._movementStrategy = movementStrategy;
            this.SetProperties(envSettings);
        }
        
        /// <inheritdoc />
        public int InstructionNumber { get; set; }

        /// <inheritdoc />
        public Point CurrentLocation { get; set; }

        /// <inheritdoc />
        public Orientation CurrentOrientation { get; set; }

        /// <inheritdoc />
        public List<char> InstructionSet { get; private set; }

        /// <inheritdoc />
        public Status Status { get; set; }

        /// <inheritdoc />
        public void Move()
        {
            this._movementStrategy.PerformMovement(this);
        }

        /// <summary>
        /// The parse instruction set.
        /// </summary>
        /// <param name="instructionSet"> The instruction set of the robot. </param>
        /// <returns>
        /// The list of chars read from the instruction set. 
        /// </returns>
        private static List<char> ParseInstructionSet(string instructionSet)
        {
            return instructionSet.ToList();
        }

        /// <summary>
        /// Sets the properties of the robot.
        /// </summary>
        /// <param name="envSettings"> The <see cref="EnvironmentSettings"/>. </param>
        private void SetProperties(EnvironmentSettings envSettings)
        {
            this.CurrentLocation = envSettings.Location;
            this.CurrentOrientation = envSettings.Orientation;
            this.InstructionSet = ParseInstructionSet(envSettings.InstructionSet);
            this.InstructionNumber = 0;
        }
    }
}