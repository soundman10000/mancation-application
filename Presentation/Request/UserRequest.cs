// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.


using System;
using System.Collections.Generic;
using Presentation.DTO;
using ServiceStack;

namespace Presentation.Request
{
    [Route("/users")]
    [Route("/users/{Ids}")]
    public class FindUsers : IReturn<List<UserDto>>
    {
        public Guid[] Ids { get; set; }
    }
}
