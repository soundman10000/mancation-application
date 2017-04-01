// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.


using System;
using MongoDB.Bson;
using Presentation.DTO;
using ServiceStack;

namespace Presentation.Request
{
    [Route("/address/{Id}")]
    public class GetAddress : IReturn<AddressDto>
    {
        public ObjectId Id { get; set; }
    }

    [Route("/address/", "POST")]
    public class CreateAddress : IReturn<ObjectId>
    {
        public AddressDto AddressDto { get; set; }
    }
}
