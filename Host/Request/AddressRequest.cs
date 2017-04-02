// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using Presentation.DTO;
using Presentation.Request;

namespace Host.Request
{
    public class AddressRequest : ServiceRequestBase
    {
        public async Task<AddressDto> Get(GetAddress request)
        {
            var addressValueCollection = this.UserDatabase.GetCollection<BsonDocument>("addresses");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", request.Id);
            var doc = await addressValueCollection.Find(filter).FirstOrDefaultAsync();
            var address = doc["address"];

            return JsonConvert.DeserializeObject<AddressDto>(address.ToJson());
        }

        public async Task<string> Post(CreateAddress createAddress)
        {
            var addressDto = createAddress.AddressDto;

            var addressValueCollection = this.UserDatabase.GetCollection<BsonDocument>("addresses");

            //need to validate
            var address = new Address(
                addressDto.Address1,
                addressDto.Address2,
                addressDto.Address3,
                addressDto.City,
                addressDto.State,
                addressDto.PostalCode,
                addressDto.County);

            var document = new BsonDocument {new BsonElement("address", address)};

            try
            {
                await addressValueCollection.InsertOneAsync(document);
                var id = document["_id"].ToString();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}