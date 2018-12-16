namespace RobotSpiders.Factories
{
    using System.Collections.Generic;

    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;

    /// <summary>
    /// Represents the factory used to create robots.
    /// </summary>
    public abstract class RobotFactory
    {
        /// <summary>
        /// Creates a collection of <see cref="IRobot"/>s.
        /// </summary>
        /// <param name="envSettings"> The <see cref="EnvironmentSettings"/> object. </param>
        /// <returns> An enumerable collection of <see cref="IRobot"/>s. </returns>
        public abstract List<IRobot> CreateRobots(EnvironmentSettings envSettings);
    }
}