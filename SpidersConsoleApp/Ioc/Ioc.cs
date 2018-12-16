
namespace SpidersConsoleApp.Ioc
{
    using System.Collections.Generic;
    using System.Drawing;

    using Patterns.Specification;

    using RobotSpiders;
    using RobotSpiders.Factories;
    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;
    using RobotSpiders.Movement;
    using RobotSpiders.Specifications;

    using StructureMap;

    public class Ioc
    {
        public static Container Initialize(EnvironmentSettings envSettings)
        {
            return new Container(
                _ =>
                    {
                        _.For<IBuilding>().Use<Building>();
                        _.For<RobotFactory>().Use<RobotSpiderFactory>();
                        _.For<IRobotLogger>().Use<RobotSpiderLogger>();
                        _.For<IInstructionParser>().Use<InstructionParser>();
                        _.For<IUpdateLocationStrategy>().Use<UpdateLocationStrategy>();
                        _.For<MovementFactory>().Use<MovementStrategyFactory>();
                        _.For<IMovementStrategy>().Use<SpiderMovementStrategy>();
                        _.For<ISettings>().Use<Settings>();
                        _.For<CompositeSpecification<GridSize>>().Use<GridSizeSpecification>();
                        _.For<CompositeSpecification<Point>>().Use<InitialLocationSpecification>();
                        _.For<CompositeSpecification<string>>().Use<InstructionSetSpecification>().Ctor<IList<char>>().Is(GetValidCharacters());

                    });
        }

        private static List<char> GetValidCharacters()
        {
            return new List<char> { 'F', 'R', 'L' };
        }



    }
}
