namespace RobotSpiders.Movement
{
    using System.Drawing;

    using Patterns.State;

    using RobotSpiders.Interfaces;

    /// <inheritdoc />
    public class UpdateLocationStrategy : IUpdateLocationStrategy
    {
        /// <inheritdoc />
        public void Update(IRobot robot, Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Down:
                    robot.CurrentLocation = new Point(robot.CurrentLocation.X, robot.CurrentLocation.Y - 1);
                    break;
                case Orientation.Up:
                    robot.CurrentLocation = new Point(robot.CurrentLocation.X, robot.CurrentLocation.Y + 1);
                    break;
                case Orientation.Left:
                    robot.CurrentLocation = new Point(robot.CurrentLocation.X - 1, robot.CurrentLocation.Y);
                    break;
                case Orientation.Right:
                    robot.CurrentLocation = new Point(robot.CurrentLocation.X + 1, robot.CurrentLocation.Y);
                    break;
                default:
                    break;
            }
        }
    }
}