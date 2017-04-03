// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using NUnit.Framework;
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
        public async Task CreateGetAndDeleteSucceed()
        {
            var request = new CreateUser
            {
                UserName = "soundman10000",
                Password = "testPassword",
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

            //Time to delete
            var deleteRequest = new DeleteUser
            {
                Id = id
            };

            await this.Client.DeleteAsync(deleteRequest);
        }

        [Test]
        public async Task FindUserSuccess()
        {
            var users = await this.Client.GetAsync(new FindUsers
            {
                Filter = new BsonDocument()
            });

            Assert.IsTrue(users.Any());
        }
    }
}
