namespace RobotSpiders.Interfaces
{
    /// <summary>
    /// Represents the movement of a robot.
    /// </summary>
    public interface IMovementStrategy
    {
        /// <summary>
        /// Performs the movement of the robot.
        /// </summary>
        /// <param name="robot"> An implementation of <see cref="IRobot"/>. </param>
        void PerformMovement(IRobot robot);
    }
}