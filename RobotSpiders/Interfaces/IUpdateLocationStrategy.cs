namespace RobotSpiders.Interfaces
{
    using Patterns.State;

    /// <summary>
    /// Represents the strategy to change a robots' location.
    /// </summary>
    public interface IUpdateLocationStrategy
    {
        /// <summary>
        /// Updates the robots' location.
        /// </summary>
        /// <param name="robot"> An instance of <see cref="IRobot"/>. </param>
        /// <param name="orientation"> The <see cref="Orientation"/> of the robot. </param>
        void Update(IRobot robot, Orientation orientation);
    }
}