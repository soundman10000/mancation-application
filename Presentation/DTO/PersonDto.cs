// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;

namespace Presentation.DTO
{
    [Serializable]
    public class PersonDto
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public DateTime Birthdate { get; }
        public Gender Gender { get; }

        public PersonDto(
            string firstName, 
            string lastName, 
            string middleName, 
            DateTime birthdate, 
            Gender gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Birthdate = birthdate;
            this.Gender = gender;
        }
    }
}
