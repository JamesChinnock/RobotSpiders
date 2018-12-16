namespace RobotSpiders.Movement
{
    using System;

    using Patterns.State;

    using RobotSpiders.Interfaces;

    /// <inheritdoc />
    public class InstructionParser : IInstructionParser
    {
        /// <inheritdoc />
        public Command Parse(char instructionCharachter)
        {
            switch (instructionCharachter)
            {
                case 'L':
                    return Command.Left;
                case 'F':
                    return Command.Forward;
                case 'R':
                    return Command.Right;
                default:
                    throw new ArgumentException();
            }
        }
    }
}