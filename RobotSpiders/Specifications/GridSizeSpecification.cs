namespace RobotSpiders.Specifications
{
    using System;

    using Patterns.Specification;

    using RobotSpiders.FractureDetection;

    /// <summary>
    /// Represents the functionality to check whether the the grid size values are valid.
    /// </summary>
    public class GridSizeSpecification : CompositeSpecification<GridSize>
    {
        /// <summary>
        /// Determines whether the grid size meets the correct specification. 
        /// </summary>
        /// <param name="candidate"> The <see cref="GridSize"/> to be checked. </param>
        /// <returns> True if the grid values are valid, else false. </returns>
        public override bool IsSatisfiedBy(GridSize candidate)
        {
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate));
            }

            return candidate.VerticalCells > 0 && candidate.HorizontalCells > 0;
        }
    }
}