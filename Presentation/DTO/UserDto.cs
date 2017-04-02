// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using MongoDB.Bson;

namespace Presentation.DTO
{
    [Serializable]
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ObjectId PersonId { get; set; }
        public ObjectId AddressId { get; set; }
    }
}
