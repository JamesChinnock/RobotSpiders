using System;

namespace SpidersConsoleApp
{
    using System.Drawing;

    using Patterns.State;

    using RobotSpiders.FractureDetection;
    using RobotSpiders.Interfaces;

    class Program
    {
        private static EnvironmentSettings GetSettingsFromUser()
        {
            var env = new EnvironmentSettings();

            Console.WriteLine("Please enter the size of the grid in form x y: ");

            env.GridSize = ReadGridSize(Console.ReadLine());

            Console.WriteLine("Please enter the starting location and orientation in the form x y Orientation: ");

            var orientParams = Console.ReadLine();
            env.Location = ReadLocation(orientParams);
            env.Orientation = ReadOrientation(orientParams);

            Console.WriteLine("Please enter the instruction set: ");

            env.InstructionSet = Console.ReadLine();
            
            return env;
        }

        private static GridSize ReadGridSize(string input)
        {
            var gridParams = input.Split(' ');
            return new GridSize(int.Parse(gridParams[0]), int.Parse(gridParams[1]));
        }

        private static Point ReadLocation(string input)
        {
            var locationParams = input.Split(' ');

            try
            {
                return new Point(int.Parse(locationParams[0]), int.Parse(locationParams[1]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static Orientation ReadOrientation(string input)
        {
            var orientationParams = input.Split(' ');

            switch (orientationParams[2].ToUpper())
            {
                case "LEFT":
                    return Orientation.Left;
                case "RIGHT":
                    return Orientation.Right;
                case "UP":
                    return Orientation.Up;
                case "DOWN":
                    return Orientation.Down;
                default:
                    throw new ArgumentException("Invalid Orientation setting");
            }
        }

        static void Main(string[] args)
        {
            EnvironmentSettings envSettings;

            if (args.Length == 0)
            {
                envSettings = new EnvironmentSettings
                                  {
                                      GridSize = new GridSize(7, 15),
                                      Location = new Point(2, 4),
                                      Orientation = Orientation.Left,
                                      InstructionSet = "FLFLFRFFLF"
                                  };
            }
            else
            {
                envSettings = GetSettingsFromUser();
            }


            var container = Ioc.Ioc.Initialize(envSettings);

            var settings = container.GetInstance<ISettings>();

            if (!settings.Validate(envSettings))
            {
                throw new ArgumentException("Invalid Environment Settings");
            }
            
            var building = container.GetInstance<IBuilding>();
            building.Inspect(envSettings);

            Console.Read();
        }
    }
}
