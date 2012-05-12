namespace SMO.Core
{
    public class SystemConfiguration : ISystemConfiguration
    {
        public ISystemGenerator Generator { get; private set; }
        public ISystemDevices Devices { get; private set; }
        public ISystemDiscipline Discipline { get; private set; }

        public SystemConfiguration(ISystemGenerator generator,
                                   ISystemDevices devices,
                                   ISystemDiscipline systemDiscipline)
        {
            Generator = generator;
            Devices = devices;
            Discipline = systemDiscipline;
        }
    }
}