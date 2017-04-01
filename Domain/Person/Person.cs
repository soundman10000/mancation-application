// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using Presentation;

namespace Domain
{
    public struct Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public DateTime Birthdate { get; }
        public Gender Gender { get; }
        public Guid Address { get; }

        public Person(
            string firstName, 
            string lastName, 
            string middleName, 
            DateTime birthdate, 
            Gender gender, 
            Guid address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Birthdate = birthdate;
            this.Gender = gender;
            this.Address = address;
        }

        #region Equality

        public bool Equals(Person other)
        {
            return string.Equals(FirstName, other.FirstName) && 
                string.Equals(LastName, other.LastName) && 
                string.Equals(MiddleName, other.MiddleName) && 
                this.Birthdate.Equals(other.Birthdate) && 
                this.Gender == other.Gender &&
                string.Equals(Address, other.Address);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Person && Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.FirstName?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (this.LastName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (this.MiddleName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ this.Birthdate.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Address.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)this.Gender;
                return hashCode;
            }
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        #endregion
    }
}
