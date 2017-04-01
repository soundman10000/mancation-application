// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Threading.Tasks;
using Domain;
using MongoDB.Bson;
using Presentation.DTO;
using Presentation.Request;

namespace Host.Request
{
    public class AddressRequest : ServiceRequestBase
    {
        public async Task<AddressDto> Get(GetAddress request)
        {
            var address = new Address(null, null, null, null, null, null, null, Guid.Empty);
            var bsonElement = new BsonElement(request.Id.ToString(), address);

            var document = new BsonDocument().Add(bsonElement);

            var addressValueCollection = this.AddressDatabase.GetCollection<BsonDocument>("addresses");
            await addressValueCollection.InsertOneAsync(document);

            return new AddressDto(request.Id, null, null, null, null, null, null, null, Guid.Empty);
        }
    }
}