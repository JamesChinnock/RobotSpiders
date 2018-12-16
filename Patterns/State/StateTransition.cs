namespace Patterns.State
{
    /// <summary>
    /// Represents the state and command of a state machine
    /// </summary>
    internal class StateTransition
    {
        /// <summary>
        /// Reference to the currentState ctor parameter.
        /// </summary>
        private readonly Orientation _currentState;

        /// <summary>
        /// Reference to the command ctor parameter.
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateTransition"/> class.
        /// </summary>
        /// <param name="currentState"> The current state. </param>
        /// <param name="command"> The command. </param>
        public StateTransition(Orientation currentState, Command command)
        {
            this._currentState = currentState;
            this._command = command;
        }

        /// <summary>
        /// Overriden method to generate a hashcode.
        /// </summary>
        /// <returns> The objects hash code. </returns>
        public override int GetHashCode()
        {
            return 17 + (31 * this._currentState.GetHashCode()) + (37 * this._command.GetHashCode());
        }

        /// <summary>
        /// Overriden object comparison method
        /// </summary>
        /// <param name="obj"> The second object </param>
        /// <returns> True if the objects are equal, else false. </returns>
        public override bool Equals(object obj)
        {
            var other = obj as StateTransition;
            return other != null && this._currentState == other._currentState && this._command == other._command;
        }
    }
}