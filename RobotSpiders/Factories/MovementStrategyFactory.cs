namespace RobotSpiders.Factories
{
    using System;

    using Patterns.State;

    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;
    using RobotSpiders.Movement;

    /// <inheritdoc />
    /// <summary>
    /// The movement strategy factory.
    /// </summary>
    public class MovementStrategyFactory : MovementFactory
    {
        /// <summary>
        /// Reference to the locationStrategy ctor parameter.
        /// </summary>
        private readonly IUpdateLocationStrategy _locationStrategy;

        /// <summary>
        /// Reference to the instruction ctor parameter.
        /// </summary>
        private readonly IInstructionParser _instructionParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovementStrategyFactory"/> class.
        /// </summary>
        /// <param name="locationStrategy">  The location strategy. </param>
        /// <param name="instructionParser"> The instructionParser. </param>
        public MovementStrategyFactory(IUpdateLocationStrategy locationStrategy, IInstructionParser instructionParser)
        {
            this._locationStrategy = locationStrategy ?? throw new ArgumentNullException(nameof(locationStrategy));
            this._instructionParser = instructionParser ?? throw new ArgumentNullException(nameof(instructionParser));
        }

        /// <inheritdoc />
        public override IMovementStrategy CreateStrategy(EnvironmentSettings environmentSettings)
        {
            if (environmentSettings == null)
            {
                throw new ArgumentNullException(nameof(environmentSettings));
            }

            var stateMachine = new OrientationStateMachine(environmentSettings.Orientation);
            return new SpiderMovementStrategy(stateMachine, this._locationStrategy, this._instructionParser);
        }
    }
}