namespace RobotSpiders.Interfaces
{
    using RobotSpiders.FractureDetection;

    /// <summary>
    /// Represents the building to be inspected for fractures.
    /// </summary>
    public interface IBuilding
    {
        /// <summary>
        /// Inspects a wall of a building.
        /// </summary>
        /// <param name="envSettings"> The <see cref="EnvironmentSettings"/> settings. </param>
        void Inspect(EnvironmentSettings envSettings);
    }
}