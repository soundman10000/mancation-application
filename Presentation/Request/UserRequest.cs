// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.


using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Presentation.DTO;
using ServiceStack;

namespace Presentation.Request
{
    [Route("/users")]
    public class FindUsers : IReturn<List<ObjectId>>
    {
        public BsonDocument Filter { get; set; }
    }

    [Route("/users/{Id}")]
    public class GetUser : IReturn<UserDto>
    {
        public ObjectId Id { get; set; }
    }

    [Route("/users", "POST")]
    public class CreateUser : IReturn<ObjectId>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public PersonDto Person { get; set; }
        public AddressDto Address { get; set; }
    }
}
