// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Mancation.Domain
{
    public class UserDocumentStorageProvider<T, TValue> where T : BsonValue
    {
        private const string UserDatabase = "users";
        public string CollectionName => typeof(T).Name;

        public UserDocumentStorageProvider(IMongoClient mongoClient)
        {
            this._database = mongoClient.GetDatabase(UserDatabase);
            this.DocumentCollection = this._database.GetCollection<BsonDocument>(typeof(T).Name);
        }

        private readonly IMongoDatabase _database;
        internal readonly IMongoCollection<BsonDocument> DocumentCollection;

        internal TValue DeserializeBson(BsonValue value)
        {
            return JsonConvert.DeserializeObject<TValue>(value.ToJson());
        } 
    }

    public static class Extensions
    {
        public static BsonDocument ToBson<T, TValue>(this T value, UserDocumentStorageProvider<T, TValue> input) 
            where T : BsonValue
        {
            return new BsonDocument {new BsonElement(input.CollectionName, value)};
        }
    }
}
