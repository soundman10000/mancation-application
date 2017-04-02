// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Presentation.DTO;
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
                RandomString());

            var address2 = address1;

            Assert.IsTrue(address1 == address2);
        }

        [Test]
        public async Task TestCreateAndGetSucceed()
        {
            var address1 = new AddressDto
            {
                Address1 = RandomString(),
                Address2 = RandomString(),
                Address3 = RandomString(),
                City = RandomString(),
                State = RandomString(),
                PostalCode = RandomString(),
                County = RandomString()
            };
                

            var request = new CreateAddress
            {
                AddressDto = address1
            };

            var id = await this.Client.PostAsync(request);

            var getRequest = new GetAddress
            {
                Id = id
            };

            var address = await this.Client.GetAsync(getRequest);

            address.ShouldBeEquivalentTo(address1);
        }
    }
}
