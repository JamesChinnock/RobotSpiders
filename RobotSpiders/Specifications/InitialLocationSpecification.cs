namespace RobotSpiders.Specifications
{
    using System;
    using System.Drawing;

    using Patterns.Specification;

    /// <summary>
    /// Represents the functionality to check whether the initial location value passed is valid.
    /// </summary>
    public class InitialLocationSpecification : CompositeSpecification<Point>
    {
        /// <summary>
        /// Determines whether a <see cref="Point"/> meets the correct specification. 
        /// </summary>
        /// <param name="candidate"> The point to be checked. </param>
        /// <returns> True if the point is valid, else false. </returns>
        public override bool IsSatisfiedBy(Point candidate)
        {
            return candidate.X >= 0 && candidate.Y >= 0;
        }
    }
}
