namespace RobotSpiders.FractureDetection
{
    using System;
    using System.Drawing;

    using Patterns.State;

    using RobotSpiders.Interfaces;

    /// <inheritdoc />
    public class RobotSpiderLogger : IRobotLogger
    {
        /// <inheritdoc />
        public void Log(Point location, Orientation orientation)
        {
            var horizontal = location.X;
            var vertical = location.Y;
            var direction = orientation;

            var logMessage = string.Format("{0} {1} {2}", horizontal, vertical, direction);

            Console.WriteLine("Robot Spider task completed, final location and orientation are:");
            Console.WriteLine(logMessage);
        }
    }
}