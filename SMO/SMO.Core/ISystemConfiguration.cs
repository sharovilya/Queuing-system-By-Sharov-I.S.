namespace SMO.Core
{
    public interface ISystemConfiguration 
    {
        ISystemDevices Devices { get; }
        ISystemDiscipline Discipline { get; }
        ISystemGenerator Generator { get; }
    }
}