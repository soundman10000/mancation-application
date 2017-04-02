// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using MongoDB.Bson;
using Presentation.DTO;
using ServiceStack;

namespace Presentation.Request
{
    [Route("/person/{Id}")]
    public class GetPerson : IReturn<PersonDto>
    {
        public ObjectId Id { get; set; }
    }

    [Route("/person/", "POST")]
    public class CreatePerson : IReturn<ObjectId>
    {
        public PersonDto PersonDto { get; set; }
    }
}
