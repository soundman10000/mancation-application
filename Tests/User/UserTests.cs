// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Bson;
using NUnit.Framework;
using Presentation;
using Presentation.DTO;
using Presentation.Request;
using static Tests.Utilities.StringHelpers;

namespace Tests.User   
{
    public class UsersTests : Test
    {
        [Test]
        public void UserValueEquality()
        {
            var person1 = new Mancation.Domain.User(
                RandomString(),
                RandomString(),
                ObjectId.GenerateNewId(),
                ObjectId.GenerateNewId());

            var person2 = person1;

            Assert.IsTrue(person1 == person2);
        }

        [Test]
        public async Task TestCreateAndGetSucceed()
        {
            var request = new CreateUser
            {
                UserName = "soundman10000",
                Password = "soundman10000",
                Address = new AddressDto(),
                Person = new PersonDto()
            };

            var id = await this.Client.PostAsync(request);

            var getRequest = new GetUser    
            {
                Id = id
            };

            var user = await this.Client.GetAsync(getRequest);

            Assert.IsTrue(user.UserName == request.UserName);
            Assert.IsTrue(user.Password == request.Password);
        }
    }
}
