// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using Host.Infastructure;
using Microsoft.Practices.Unity;
using MongoDB.Driver;
using ServiceStack.Caching;

namespace Host
{
    /// <summary>
    ///     Set up dependency injection
    /// </summary>
    public class HostContainer
    {
        public static IUnityContainer Create()
        {
            var container = new UnityContainer();
            var connectionManager = new ConnectionManager();

            container.RegisterInstance<ICacheClient>(new MemoryCacheClient(), new ContainerControlledLifetimeManager());

            //TODO: check on what mongo actually keeps cached. Might want to make this a per thread manager.
            container.RegisterInstance(new MongoClient(connectionManager.ConnectionString),
                new ContainerControlledLifetimeManager());

            return container;
        }
    }
}