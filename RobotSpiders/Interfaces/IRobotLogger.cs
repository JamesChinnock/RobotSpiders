namespace RobotSpiders.Interfaces
{
    using System.Drawing;

    using Patterns.State;

    /// <summary>
    /// Represents the logging and feedback associated with the robots.
    /// </summary>
    public interface IRobotLogger
    {
        /// <summary>
        /// Logs the current location and orientation of a robot.
        /// </summary>
        /// <param name="location"> The current location of the robot. </param>
        /// <param name="orientation"> The current orientation of the robot. </param>
        void Log(Point location, Orientation orientation);
    }
}