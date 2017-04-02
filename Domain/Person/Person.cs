// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using MongoDB.Bson;
using Presentation;
using MongoDB.Bson.Serialization.Attributes;
using Presentation.DTO;

namespace Domain
{
    [Serializable]
    public class Person : BsonValue
    {
        [BsonElement("firstName")]
        public string FirstName { get; }
        [BsonElement("lastName")]
        public string LastName { get; }
        [BsonElement("middelName")]
        public string MiddleName { get; }
        [BsonElement("birthdate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Birthdate { get; }
        [BsonElement("gender")]
        public Gender Gender { get; }

        [BsonConstructor]
        public Person(
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

        public Person(PersonDto dto)
            : this(
                dto.FirstName,
                dto.LastName,
                dto.MiddleName,
                dto.Birthdate,
                dto.Gender)
        {
        }

        #region Equality

        public bool Equals(Person other)
        {
            return string.Equals(FirstName, other.FirstName) &&
                   string.Equals(LastName, other.LastName) &&
                   string.Equals(MiddleName, other.MiddleName) &&
                   this.Birthdate.Equals(other.Birthdate) &&
                   this.Gender == other.Gender;
        }

        public override int CompareTo(BsonValue other)
        {
            return this.GetHashCode() > other.GetHashCode()
                ? 0
                : 1;
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
                hashCode = (hashCode * 397) ^ (int)this.Gender;
                return hashCode;
            }
        }

        public override BsonType BsonType => BsonType.Int32;

        public static bool operator !=(Person person1, Person person2)
        {
            return !Equals(person1, person2);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return Equals(person1, person2);
        }

        #endregion
    }
}
