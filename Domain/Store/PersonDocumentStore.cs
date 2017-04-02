// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using Domain;
using MongoDB.Driver;

namespace Mancation.Domain
{
    public interface IPersonDocumentStore : IDocumentStore<Person>
    {
    }

    public class PersonDocumentStore : UserDocumentStorageProvider<Person>, IPersonDocumentStore
    {
        public PersonDocumentStore(IMongoClient mongoClient) 
            : base(mongoClient)
        {
        }
    }
}
