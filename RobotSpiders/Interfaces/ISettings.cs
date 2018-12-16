namespace RobotSpiders.Interfaces
{
    using RobotSpiders.FractureDetection;

    public interface ISettings
    {
        bool Validate(EnvironmentSettings envSettings);
    }
}