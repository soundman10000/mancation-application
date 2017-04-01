// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using Microsoft.Practices.Unity;
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

            container.RegisterInstance<ICacheClient>(new MemoryCacheClient(), new ContainerControlledLifetimeManager());

            return container;
        }
    }
}