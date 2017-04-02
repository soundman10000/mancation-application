// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;

namespace Mancation.Domain.User
{
    public class User
    {
        public Guid Id { get; }
        public string UserId { get; }
        public Guid PersonId { get; }
    }
}
