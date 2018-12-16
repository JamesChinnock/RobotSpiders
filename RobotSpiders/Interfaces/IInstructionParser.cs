namespace RobotSpiders.Interfaces
{
    using Patterns.State;

    /// <summary>
    /// Represents functionality to be performed on instructions.
    /// </summary>
    public interface IInstructionParser
    {
        /// <summary>
        /// Parses a character based instruction set.
        /// </summary>
        /// <param name="instructionCharachter"> The char instruction to be parsed. </param>
        /// <returns> The <see cref="Command"/> relating to the instruction. </returns>
        Command Parse(char instructionCharachter);
    }
}