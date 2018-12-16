namespace RobotSpiders.Interfaces
{
    using System.Collections.Generic;
    using System.Drawing;

    using Patterns.State;

    using RobotSpiders.Movement;

    /// <summary>
    /// Represents a robot entity.
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Gets or sets the location of last element processed in the instruction array.
        /// </summary>
        /// <value> The instruction number. </value>
        int InstructionNumber { get; set; }

        /// <summary>
        /// Gets or sets the current location of the robot on the grid.
        /// </summary>
        /// <value> The current location of the robot. </value>
        Point CurrentLocation { get; set; }

        /// <summary>
        /// Gets or sets the current orientation of the robot.
        /// </summary>
        /// <value> The current orientation. </value>
        Orientation CurrentOrientation { get; set; }

        /// <summary>
        /// Gets the instruction set for the robot.
        /// </summary>
        /// <value> The instruction set. </value>
        List<char> InstructionSet { get; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value> The status. </value>
        Status Status { get; set; }

        /// <summary>
        /// Moves the robot.
        /// </summary>
        void Move();
    }
}