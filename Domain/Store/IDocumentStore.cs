// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mancation.Domain
{
    public interface IDocumentStore<T>
    {
        string CollectionName { get; }
        Task<T> Get(ObjectId id);
        Task<IEnumerable<ObjectId>> Find(BsonDocument filter);
        Task<ObjectId> Post(T value);
        Task Delete(ObjectId id);
    }
}
