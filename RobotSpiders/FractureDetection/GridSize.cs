namespace RobotSpiders.FractureDetection
{
    /// <summary>
    /// Represents the dimensions of a grid, made up of X and Y Axis settings.
    /// </summary>
    public class GridSize
    {
        /// <summary> Initializes a new instance of the <see cref="GridSize"/> class. </summary>
        /// <param name="horizontal"> The size of the horizontal x-axis of the grid. </param>
        /// <param name="vertical"> The size of the vertical y-axis of the grid. </param>
        public GridSize(int horizontal, int vertical)
        {
            this.VerticalCells = vertical;
            this.HorizontalCells = horizontal;
        }

        /// <summary> Gets the vertical cells. </summary>
        /// <value> The number of vertical cells, the y-axis of the grid. </value>
        public int VerticalCells { get; }

        /// <summary> Gets the horizontal cells. </summary>
        /// <value> The number of horizontal cells, the x-axis of the grid. </value>
        public int HorizontalCells { get; }
    }
}
