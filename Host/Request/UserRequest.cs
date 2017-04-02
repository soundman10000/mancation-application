// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System.Collections.Generic;
using Presentation.DTO;
using Presentation.Request;

namespace Host.Request
{
    public class UserRequest : ServiceRequestBase
    {
        public List<UserDto> Get(FindUsers request)
        {
            return new List<UserDto>
            {
                new UserDto("jason", "Scott", "Malley")
            };
        }
    }
}