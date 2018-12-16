namespace RobotSpiders.FractureDetection
{
    using System;
    using System.Collections.Generic;

    using RobotSpiders.Factories;
    using RobotSpiders.Interfaces;

    /// <inheritdoc />
    public class Building : IBuilding
    {
        /// <summary>
        /// Reference to the robotFactory ctor parameter.
        /// </summary>
        private readonly RobotFactory _robotFactory;

        /// <summary>
        /// Reference to the logger ctor parameter.
        /// </summary>
        private readonly IRobotLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Building"/> class.
        /// </summary>
        /// <param name="robotFactory"> The robotFactory used to build robots. </param>
        /// /// <param name="logger"> The logger used for inspection feedback. </param>
        public Building(RobotFactory robotFactory, IRobotLogger logger)
        {
            this._robotFactory = robotFactory ?? throw new ArgumentNullException(nameof(robotFactory));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public void Inspect(EnvironmentSettings envSettings)
        {
            var robots = this.GetRobots(envSettings);
            InspectBuilding(robots);
            this.LogProgress(robots);
        }

        /// <summary>
        /// Instructs the robots to start their inspection.
        /// </summary>
        /// <param name="robots"> Collection of robots. </param>
        private static void InspectBuilding(IEnumerable<IRobot> robots)
        {
            try
            {
                foreach (var robot in robots)
                {
                    robot.Move();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Logs the inspection progress.
        /// </summary>
        /// <param name="robots"> Collection of robots. </param>
        private void LogProgress(IEnumerable<IRobot> robots)
        {
            foreach (var robot in robots)
            {
                this._logger.Log(robot.CurrentLocation, robot.CurrentOrientation);
            }
        }

        /// <summary>
        /// Retrieves an enumerable collection of robots.
        /// </summary>
        /// <param name="envSettings"> The <see cref="EnvironmentSettings"/> object. </param>
        /// <returns> Enumerable collection of <see cref="IRobot"/> implementations. </returns>
        private List<IRobot> GetRobots(EnvironmentSettings envSettings)
        {
            return this._robotFactory.CreateRobots(envSettings);
        }
    }
}