namespace RobotSpiders.FractureDetection
{
    using System.Drawing;

    using Patterns.Specification;

    using RobotSpiders.Interfaces;

    public class Settings : ISettings
    {
        private readonly CompositeSpecification<GridSize> _gridSizeSpec;

        private readonly CompositeSpecification<Point> _initialLocationSpec;

        private readonly CompositeSpecification<string> _instructionSpec;

        private readonly CompositeSpecification<string> _orientationSpec;

        public Settings(CompositeSpecification<GridSize> gridSizeSpec, 
                        CompositeSpecification<Point> initialLocationSpec,
                        CompositeSpecification<string> instructionSpec)
        {
            this._gridSizeSpec = gridSizeSpec;
            this._initialLocationSpec = initialLocationSpec;
            this._instructionSpec = instructionSpec;
        }

        public bool Validate(EnvironmentSettings envSettings)
        {
            return this._gridSizeSpec.IsSatisfiedBy(envSettings.GridSize)
                   && this._initialLocationSpec.IsSatisfiedBy(envSettings.Location)
                   && this._instructionSpec.IsSatisfiedBy(envSettings.InstructionSet);
        }
    }
}