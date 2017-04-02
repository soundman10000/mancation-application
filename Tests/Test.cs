// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using ServiceStack;

namespace Tests
{
    public abstract class Test
    {
        protected IUnityContainer Container { get; private set; }

        [SetUp]
        public virtual void Setup()
        {
            this.Container = TestFixture.Container;
            this.Client = new JsonServiceClient(TestFixture.ListeningOn)
            {
                Timeout = TimeSpan.FromMinutes(1)
            };
        }

        protected JsonServiceClient Client { get; private set; }
    }
}
