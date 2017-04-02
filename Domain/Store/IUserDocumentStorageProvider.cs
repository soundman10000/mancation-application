// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mancation.Domain
{
    public interface IUserDocumentStorageProvider<T, TValue>
    {
        string CollectionName { get; }
        string DataName { get; }
        Task<TValue> Get(ObjectId id);
        Task<ObjectId> Post(TValue value);
    }
}
