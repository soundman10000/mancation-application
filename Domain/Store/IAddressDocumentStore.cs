// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using System.Threading.Tasks;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using Presentation.DTO;

namespace Mancation.Domain
{
    public interface IAddressDocumentStore :  IUserDocumentStorageProvider<Address, AddressDto>
    {
    }

    public class AddressDocumentStore : UserDocumentStorageProvider<Address, AddressDto>, IAddressDocumentStore
    {
        public AddressDocumentStore(IMongoClient mongoClient) 
            : base(mongoClient)
        {
        }

        public async Task<AddressDto> Get(ObjectId id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var document = await this.DocumentCollection.Find(filter).FirstOrDefaultAsync();

            if (document == null)
            {
                throw new NotFoundException(this.CollectionName, id);
            }

            var bsonValue = document[this.CollectionName];

            return base.DeserializeBson(bsonValue);
        }

        public async Task<ObjectId> Post(AddressDto dto)
        {
            var address = new Address(dto);
            var document = address.ToBson(this);

            await this.DocumentCollection.InsertOneAsync(document);
            return new ObjectId(document["_id"].ToString());
        }
    }
}
