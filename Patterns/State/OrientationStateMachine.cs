namespace Patterns.State
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc />
    public class OrientationStateMachine : IFiniteStateMachine
    {
        /// <summary>
        /// Key Value Pairs of <see cref="StateTransition"/>s and <see cref="Orientation"/> 
        /// </summary>
        private readonly Dictionary<StateTransition, Orientation> _transitions;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientationStateMachine"/> class.
        /// </summary>
        /// <param name="startingOrientation"> The starting orientation. </param>
        public OrientationStateMachine(Orientation startingOrientation)
        {
            this.CurrentState = startingOrientation;
            this._transitions = new Dictionary<StateTransition, Orientation>
                              {
                                  { new StateTransition(Orientation.Up, Command.Right), Orientation.Right },
                                  { new StateTransition(Orientation.Up, Command.Left), Orientation.Left },
                                  { new StateTransition(Orientation.Up, Command.Forward), Orientation.Up },
                                  { new StateTransition(Orientation.Down, Command.Right), Orientation.Left },
                                  { new StateTransition(Orientation.Down, Command.Left), Orientation.Right },
                                  { new StateTransition(Orientation.Down, Command.Forward), Orientation.Down },
                                  { new StateTransition(Orientation.Left, Command.Right), Orientation.Up },
                                  { new StateTransition(Orientation.Left, Command.Left), Orientation.Down },
                                  { new StateTransition(Orientation.Left, Command.Forward), Orientation.Left },
                                  { new StateTransition(Orientation.Right, Command.Right), Orientation.Down },
                                  { new StateTransition(Orientation.Right, Command.Left), Orientation.Up },
                                  { new StateTransition(Orientation.Right, Command.Forward), Orientation.Right }
                              };
        }

        /// <summary>
        /// Gets the current state.
        /// </summary>
        public Orientation CurrentState { get; private set; }

        /// <inheritdoc />
        public Orientation MoveNext(Command command)
        {
            this.CurrentState = this.GetNext(command);
            return this.CurrentState;
        }

        /// <summary> The get next. </summary>
        /// <param name="command"> The command. </param>
        /// <returns> The <see cref="Orientation"/>. </returns>
        /// <exception cref="Exception"> Thrown if an unknown transition is request, that is a command that cannot be completed </exception>
        private Orientation GetNext(Command command)
        {
            var transition = new StateTransition(this.CurrentState, command);
            Orientation nextState;
            if (!this._transitions.TryGetValue(transition, out nextState))
            {
                throw new Exception("Invalid transition: " + this.CurrentState + " -> " + command);
            }

            return nextState;
        }
     }
}
