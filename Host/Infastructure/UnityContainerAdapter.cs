// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using Microsoft.Practices.Unity;
using ServiceStack.Configuration;

namespace Host
{
    /// <summary>
    /// Adpater for the func framework in service stack
    /// </summary>
    public class UnityContainerAdapter : IContainerAdapter
    {
        private readonly IUnityContainer _container;


        public UnityContainerAdapter(IUnityContainer container)
        {
            this._container = container;
        }

        public T TryResolve<T>()
        {

            if (this._container.IsRegistered<T>())
            {
                return this._container.Resolve<T>();
            }

            return default(T);

        }

        public T Resolve<T>()
        {
            return this._container.Resolve<T>();
        }
    }
}