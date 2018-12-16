namespace RobotSpiders.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Patterns.Specification;

    /// <summary>
    /// Represents the functionality to check whether the orientation value passed is valid.
    /// </summary>
    public class InstructionSetSpecification : CompositeSpecification<string>
    {
        /// <summary>
        /// The list of valid characters passed in the constructor.
        /// </summary>
        private readonly IList<char> _validCharacters;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstructionSetSpecification"/> class.
        /// </summary>
        /// <param name="validCharacters"> A list of valid characters. </param>
        /// <exception cref="ArgumentNullException"> Thrown if validCharacters is null. </exception>
        /// <exception cref="ArgumentException"> Thrown if validCharacters does not contain any elements. </exception>
        public InstructionSetSpecification(IList<char> validCharacters)
        {
            if (validCharacters == null)
            {
                throw new ArgumentNullException(nameof(validCharacters));
            }

            if (!validCharacters.Any())
            {
                throw new ArgumentException("No valid command characters were submitted");
            }

            this._validCharacters = validCharacters;
        }

        /// <summary>
        /// Determines whether the string meets the correct specification. 
        /// </summary>
        /// <param name="candidate"> The string to be checked. </param>
        /// <returns> True if the string is valid valid, else false. </returns>
        public override bool IsSatisfiedBy(string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
            {
                throw new ArgumentException(nameof(candidate));
            }

            return this.CommandCharactersAreValid(candidate.ToList());
        }

        /// <summary> The command characters are valid. </summary>
        /// <param name="candidate"> The List of characters to be checked against valid characters. </param>
        /// <returns> True if all characters are valid, else false.
        /// </returns>
        private bool CommandCharactersAreValid(IList<char> candidate)
        {
            return !candidate.Except(this._validCharacters).Any();
        }
    }
}