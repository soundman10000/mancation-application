// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using MongoDB.Driver;
using static Mancation.Domain.Values.Values;

namespace Mancation.Domain
{
    public interface IUserDocumentStore : IDocumentStore<User>
    {
    }

    public class UserDocumentStore : DocumentStorageProvider<User>, IUserDocumentStore
    {
        public UserDocumentStore(IMongoClient mongoClient)
            : base(UserDatabaseName, mongoClient)
        {
        }
    }
}
