namespace RobotSpiders.FractureDetection
{
    using System.Drawing;

    using Patterns.State;

    public class EnvironmentSettings
    {
        public Orientation Orientation { get; set; }

        public Point Location { get; set; }

        public GridSize GridSize { get; set; }

        public string InstructionSet { get; set; }
    }
}