namespace RobotSpiders.Specifications
{
    using System;

    using Patterns.Specification;
    using Patterns.State;

    /// <summary>
    /// Represents the functionality to check whether the orientation value passed is valid.
    /// </summary>
    public class OrientationSpecification : CompositeSpecification<string>
    {
        /// <summary>
        /// Determines whether a string meets the correct specification. 
        /// </summary>
        /// <param name="candidate"> The string to be checked. </param>
        /// <returns> True if the string is valid, else false. </returns>
        public override bool IsSatisfiedBy(string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
            {
                throw new ArgumentException(nameof(candidate));
            }

            return DownIsValid(candidate) 
                   || UpIsValid(candidate) 
                   || LeftIsValid(candidate) 
                   || RightIsValid(candidate);
        }

        /// <summary>
        /// Determines whether the Orientation is 'Down'.
        /// </summary>
        /// <param name="candidate"> The string to be validated. </param>
        /// <returns> True if the string is 'Down', else false. </returns>
        private static bool DownIsValid(string candidate)
        {
            return string.Equals(candidate, Orientation.Down.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Determines whether the Orientation is 'Up'.
        /// </summary>
        /// <param name="candidate"> The string to be validated. </param>
        /// <returns> True if the string is 'Up', else false. </returns>
        private static bool UpIsValid(string candidate)
        {
            return string.Equals(candidate, Orientation.Up.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Determines whether the Orientation is 'Left'.
        /// </summary>
        /// <param name="candidate"> The string to be validated. </param>
        /// <returns> True if the string is 'Left', else false. </returns>
        private static bool LeftIsValid(string candidate)
        {
            return string.Equals(candidate, Orientation.Left.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Determines whether the Orientation is 'Right'.
        /// </summary>
        /// <param name="candidate"> The string to be validated. </param>
        /// <returns> True if the string is 'Right', else false. </returns>
        private static bool RightIsValid(string candidate)
        {
            return string.Equals(candidate, Orientation.Right.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}