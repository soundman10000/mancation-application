// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using Presentation.Request;
using static Tests.Utilities.StringHelpers;

namespace Tests.Address
{

    public class AddressTests : Test
    {
        [Test]
        public void AddressValueEquality()
        {
            var address1 = new Domain.Address(
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                Guid.NewGuid());

            var address2 = address1;

            Assert.IsTrue(address1 == address2);
        }


        [Test]
        public async Task TestThing()
        {

            var test = await this.Client.GetAsync(new GetAddress());
        }
    }
}
