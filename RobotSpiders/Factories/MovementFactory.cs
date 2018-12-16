namespace RobotSpiders.Factories
{
    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;

    /// <summary>
    /// Represents a factory to create <see cref="IMovementStrategy"/>s.
    /// </summary>
    public abstract class MovementFactory
    {
        /// <summary>
        /// Creates a movement strategy for the robot.
        /// </summary>
        /// <param name="environmentSettings"> THe <see cref="EnvironmentSettings"/> object. </param>
        /// <returns> An implementation of <see cref="IMovementStrategy"/> </returns>
        public abstract IMovementStrategy CreateStrategy(EnvironmentSettings environmentSettings);
    }
}