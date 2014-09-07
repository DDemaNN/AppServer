namespace Inceptum.AppServer.Host.Model
{
    public class Instance
    {
        public string Application { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }

        public bool AutoStart { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Environment { get; set; }
        //TODO: use custom type
      //  public LoggerLevel LogLevel { get; set; } 
    }
}