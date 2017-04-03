// Mancation
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Threading.Tasks;
using Domain;
using Mancation.Domain;
using Presentation.DTO;
using Presentation.Request;
using ServiceStack;

namespace Host.Request
{
    public class AddressRequest : Service
    {
        private readonly IAddressDocumentStore _store;

        public AddressRequest(IAddressDocumentStore store)
        {
            this._store = store;
        }

        public async Task<AddressDto> Get(GetAddress request)
        {
            var entity = await this._store.Get(request.Id);
            return new AddressDto
            {
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                Address3 = entity.Address3,
                City = entity.City,
                State = entity.State,
                County = entity.County,
                PostalCode = entity.PostalCode
            };
        }

        public async Task<string> Post(CreateAddress createAddress)
        {
            var addressEntity = new Address(createAddress.AddressDto);

            try
            {
                var id = await this._store.Post(addressEntity);
                return id.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}