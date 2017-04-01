// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System.Configuration;
using Microsoft.Practices.Unity;
using MongoDB.Driver;
using ServiceStack;

namespace Host
{
    public class ServiceRequestBase : Service
    {
        protected ServiceRequestBase()
        {
            this.Container = HostContainer.Create();

            var databaseClient = this.Container.Resolve<MongoClient>();

            //might want to move this to be injected.
            var addressDatabaseName = ConfigurationManager.AppSettings["AddressDatabase"];
            this.AddressDatabase = databaseClient.GetDatabase(addressDatabaseName);
        }

        protected IUnityContainer Container { get; set; }
        protected IMongoDatabase AddressDatabase { get; set; }
    }
}