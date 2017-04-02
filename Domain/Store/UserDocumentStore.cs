// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using MongoDB.Driver;

namespace Mancation.Domain
{
    public interface IUserDocumentStore : IDocumentStore<User>
    {
    }

    public class UserDocumentStore : UserDocumentStorageProvider<User>, IUserDocumentStore
    {
        public UserDocumentStore(IMongoClient mongoClient)
            : base(mongoClient)
        {
        }
    }
}
