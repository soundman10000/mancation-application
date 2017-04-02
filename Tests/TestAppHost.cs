// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using Funq;
using Host;
using Host.Request;
using Microsoft.Practices.Unity;
using ServiceStack;

namespace Tests
{
    public class TestAppHost : AppHostHttpListenerBase
    {
        private readonly IUnityContainer _container;

        public TestAppHost(IUnityContainer container) 
            : base("Test Api", typeof(UserRequest).Assembly)
        {
            this._container = container;
        }

        public override void Configure(Container container)
        {
            container.Adapter = new UnityContainerAdapter(this._container);
        }
    }
}
