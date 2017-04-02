// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Mancation.Domain
{
    public abstract class UserDocumentStorageProvider<T> : IDocumentStore<T>
        where T : BsonValue
    {
        private const string UserDatabase = "users";
        public string CollectionName => typeof(T).Name;

        protected UserDocumentStorageProvider(IMongoClient mongoClient)
        {
            this._database = mongoClient.GetDatabase(UserDatabase);
            this.DocumentCollection = this._database.GetCollection<BsonDocument>(typeof(T).Name);
        }

        private readonly IMongoDatabase _database;
        internal readonly IMongoCollection<BsonDocument> DocumentCollection;

        public async Task<T> Get(ObjectId id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var document = await this.DocumentCollection.Find(filter).FirstOrDefaultAsync();

            if (document == null)
            {
                throw new NotFoundException(this.CollectionName, id);
            }

            return BsonSerializer.Deserialize<T>(document[this.CollectionName].AsBsonDocument);
        }

        public async Task<ObjectId> Post(T entity)
        {
            var document = entity.ToBson(this);

            await this.DocumentCollection.InsertOneAsync(document);
            return new ObjectId(document["_id"].ToString());
        }
    }

    public static class Extensions
    {
        public static BsonDocument ToBson<T>(this T value, UserDocumentStorageProvider<T> input) 
            where T : BsonValue
        {
            return new BsonDocument {new BsonElement(input.CollectionName, value)};
        }
    }
}
