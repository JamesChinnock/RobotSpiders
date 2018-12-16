namespace RobotSpiders.Movement
{
    using System;

    using Patterns.State;

    using RobotSpiders.Interfaces;

    /// <inheritdoc />
    public class SpiderMovementStrategy : IMovementStrategy
    {
        /// <summary>
        /// Reference to the robotState ctor parameter.
        /// </summary>
        private readonly IFiniteStateMachine _robotState;

        /// <summary>
        /// Reference to the updateLocationStrategy ctor parameter.
        /// </summary>
        private readonly IUpdateLocationStrategy _updateLocationStrategy;

        /// <summary>
        /// Reference to the instruction ctor parameter.
        /// </summary>
        private readonly IInstructionParser _instructionParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpiderMovementStrategy"/> class.
        /// </summary>
        /// <param name="robotState"> The robot state Finite State Machine. </param>
        /// <param name="updateLocationStrategy"> The strategy used to update the location. </param>
        /// <param name="instructionParser"> The instance of <see cref="instructionParser"/> that cn convert the char based instruction set. </param>
        public SpiderMovementStrategy(IFiniteStateMachine robotState, IUpdateLocationStrategy updateLocationStrategy, IInstructionParser instructionParser)
        {
            this._robotState = robotState ?? throw new ArgumentNullException(nameof(robotState));
            this._updateLocationStrategy = updateLocationStrategy ?? throw new ArgumentNullException(nameof(updateLocationStrategy));
            this._instructionParser = instructionParser ?? throw new ArgumentNullException(nameof(instructionParser));
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs the movement of a SpiderRobot.
        /// </summary>
        /// <param name="robot"> An implementation of <see cref="T:RobotSpiders.IRobot" />. </param>
        public void PerformMovement(IRobot robot)
        {
            try
            {
                foreach (var command in robot.InstructionSet)
                {
                    var instruction = this.ReadNextInstruction(robot);
                    var actualCommand = this._instructionParser.Parse(instruction);
                    var state = this._robotState.MoveNext(actualCommand);

                    if (actualCommand == Command.Forward)
                    {
                        this._updateLocationStrategy.Update(robot, state);
                    }

                    robot.CurrentOrientation = state;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Reads the next instruction in the set.
        /// </summary>
        /// <param name="spider"> The robot. </param>
        /// <returns> The next char in teh instruction set. </returns>
        private char ReadNextInstruction(IRobot spider)
        {
            if (spider.InstructionNumber > spider.InstructionSet.Count)
            {
                spider.Status = Status.Stopped;
            }

            var inst = spider.InstructionSet[spider.InstructionNumber];
            spider.InstructionNumber++;
            return inst;
        }
    }
}