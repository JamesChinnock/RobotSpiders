namespace Patterns.State
{
    /// <summary>
    /// Represents the Finite State Machine pattern
    /// </summary>
    public interface IFiniteStateMachine
    {
        /// <summary>
        /// Moves to the next state based on the command parameter
        /// </summary>
        /// <param name="command"> The command to be executed </param>
        /// <returns> The new <see cref="Orientation"/> of the robot </returns>
        Orientation MoveNext(Command command);
    }
}