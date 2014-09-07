using System;

namespace Inceptum.AppServer.Host.Model
{
    public class Appliction
    {
        public string Name { get; set; }
        public string PackageId { get; set; }
        public string PackageVendor { get; set; }
        public Version Version { get; set; }
        public string DefaultConfiguration { get; set; }
        public Instance[] Instances { get; set; }

#region Defaults for instances
        public bool AutoStart { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Environment { get; set; }
        //TODO: use custom type
        //public LoggerLevel LogLevel { get; set; }
#endregion
    }
}