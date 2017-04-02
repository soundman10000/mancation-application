﻿// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using Domain;
using MongoDB.Driver;

namespace Mancation.Domain
{
    public interface IAddressDocumentStore : IDocumentStore<Address>
    {
    }

    public class AddressDocumentStore : UserDocumentStorageProvider<Address>, IAddressDocumentStore
    {
        public AddressDocumentStore(IMongoClient mongoClient) 
            : base(mongoClient)
        {
        }
    }
}
