// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Mancation.Domain;
using MongoDB.Bson;
using Presentation.DTO;
using Presentation.Request;

namespace Host.Request
{
    public class UserRequest : ServiceRequestBase
    {
        private readonly IPersonDocumentStore _personStore;
        private readonly IAddressDocumentStore _addressStore;
        private readonly IUserDocumentStore _userStore;

        public UserRequest(
            IAddressDocumentStore addressStore, 
            IPersonDocumentStore personStore,
            IUserDocumentStore userStore)
        {
            this._addressStore = addressStore;
            this._personStore = personStore;
            this._userStore = userStore;
        }

        public async Task<UserDto> Get(GetUser request)
        {
            var entity = await this._userStore.Get(request.Id);
            return new UserDto
            {
                UserName = entity.UserName,
                Password = entity.UserPassword,
                AddressId = entity.AddressId,
                PersonId = entity.PersonId
            };
        }

        public async Task<List<ObjectId>> Get(FindUsers request)
        {
            var items = await this._userStore.Find(request.Filter);
            return items.ToList();
        }

        public Task Delete(DeleteUser request)
        {
            return this._userStore.Delete(request.Id);
        }

        public async Task<ObjectId> Post(CreateUser request)
        {
            var personEntity = new Person(request.Person);
            var addressEntity = new Address(request.Address);
            
            try
            {
                var personId = await this._personStore.Post(personEntity);
                var addressId = await this._addressStore.Post(addressEntity);

                var userEntity = new User(request.UserName, request.Password, personId, addressId);
                var id = await this._userStore.Post(userEntity);

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}