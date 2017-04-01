// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using Funq;
using Host.Request;
using ServiceStack;

namespace Tests
{
    public class TestAppHost : AppHostHttpListenerBase
    {
        public TestAppHost() 
            : base("Test Api", typeof(UserRequest).Assembly)
        {
        }

        public override void Configure(Container container)
        {
        }
    }
}
