namespace RobotSpiders.Factories
{
    using System;
    using System.Collections.Generic;

    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// Represents the functionality to create <see cref="T:RobotSpiders.SpiderRobot" />s.
    /// </summary>
    public class RobotSpiderFactory : RobotFactory
    {
        /// <summary>
        /// Reference to the movementFactory ctor parameter.
        /// </summary>
        private readonly MovementFactory _movementFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotSpiderFactory"/> class.
        /// </summary>
        /// <param name="movementFactory"> The movement factory. </param>
        public RobotSpiderFactory(MovementFactory movementFactory)
        {
            this._movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a collection of <see cref="T:RobotSpiders.SpiderRobot" />s.
        /// </summary>
        /// <param name="envSettings"> The <see cref="T:RobotSpiders.EnvironmentSettings" /> object. </param>
        /// <returns> Enumerable collection of <see cref="T:RobotSpiders.IRobot" />s. </returns>
        public override List<IRobot> CreateRobots(EnvironmentSettings envSettings)
        {
            if (envSettings == null)
            {
                throw new ArgumentNullException(nameof(envSettings));
            }

            return new List<IRobot> { this.CreateSingleRobot(envSettings) };
        }

        /// <summary>
        /// Creates a single <see cref="T:RobotSpiders.SpiderRobot" />.
        /// </summary>
        /// <param name="envSettings"> The <see cref="EnvironmentSettings"/> object. </param>
        /// <returns> A new <see cref="SpiderRobot"/>. </returns>
        private IRobot CreateSingleRobot(EnvironmentSettings envSettings)
        {
            var movementStrategy = this._movementFactory.CreateStrategy(envSettings);
            return new SpiderRobot(envSettings, movementStrategy);
        }
    }
}