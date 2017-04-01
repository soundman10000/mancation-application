// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using NUnit.Framework;
using ServiceStack;

namespace Tests
{
    public abstract class Test
    {
        [SetUp]
        public virtual void Setup()
        {
            // load the client
            this.Client = new JsonServiceClient(TestFixture.ListeningOn)
            {
                Timeout = TimeSpan.FromMinutes(1)
            };
        }

        protected JsonServiceClient Client { get; private set; }
    }
}
