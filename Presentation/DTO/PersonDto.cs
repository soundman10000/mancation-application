// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;

namespace Presentation.DTO
{
    [Serializable]
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
    }
}
