// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mancation.Domain.User
{
    [Serializable]
    public class User : BsonValue
    {
        [BsonConstructor]
        public User(
            string userName, 
            string userPassword, 
            ObjectId personId, 
            ObjectId addressId)
        {
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.PersonId = personId;
            this.AddressId = addressId;
        }

        public string UserName { get; }
        public string UserPassword { get; }
        public ObjectId PersonId { get; }
        public ObjectId AddressId { get; }

        #region Equality


        public override int CompareTo(BsonValue other)
        {
            return this.GetHashCode() > other.GetHashCode()
            ? 0
            : 1;
        }

        public bool Equals(User other)
        {
            return string.Equals(this.UserName, other.UserName) &&
                   string.Equals(this.UserPassword, other.UserPassword) &&
                   string.Equals(PersonId, other.PersonId) &&
                   string.Equals(AddressId, other.AddressId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = UserName?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (UserPassword?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ PersonId.GetHashCode();
                hashCode = (hashCode*397) ^ AddressId.GetHashCode();
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Address && Equals((Address)obj);
        }

        public override BsonType BsonType => BsonType.Int32;

        public static bool operator !=(User user1, User user2)
        {
            return !Equals(user1, user2);
        }

        public static bool operator ==(User user1, User user2)
        {
            return Equals(user1, user2);
        }

        #endregion
    }
}

