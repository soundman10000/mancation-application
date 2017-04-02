// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Threading.Tasks;
using Mancation.Domain;
using Presentation.DTO;
using Presentation.Request;

namespace Host.Request
{
    public class AddressRequest : ServiceRequestBase
    {
        private readonly IAddressDocumentStore _store;

        public AddressRequest(IAddressDocumentStore store)
        {
            this._store = store;
        }

        public async Task<AddressDto> Get(GetAddress request)
        {
            return await this._store.Get(request.Id);
        }

        public async Task<string> Post(CreateAddress createAddress)
        {
            var addressDto = createAddress.AddressDto;

            try
            {
                var id = await this._store.Post(addressDto);
                return id.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}