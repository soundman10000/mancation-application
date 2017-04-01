using System.Configuration;

namespace Host.Infastructure
{
    public class ConnectionManager
    {
        public string ConnectionString { get; }

        public ConnectionManager()
        {
            this.ConnectionString = ConfigurationManager.AppSettings["mongoDb"];
        }
    }
}