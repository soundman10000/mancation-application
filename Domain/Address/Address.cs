// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Presentation.DTO;

namespace Domain
{
    [Serializable]
    public class Address : BsonValue
    {
        [BsonElement("address1")]
        public string Address1 { get; }
        [BsonElement("address2")]
        public string Address2 { get; }
        [BsonElement("address3")]
        public string Address3 { get; }
        [BsonElement("city")]
        public string City { get; }
        [BsonElement("state")]
        public string State { get; }
        [BsonElement("postalCode")]
        public string PostalCode { get; }
        [BsonElement("county")]
        public string County { get; }

        [JsonConstructor]
        public Address(
            string address1, 
            string address2, 
            string address3, 
            string city, 
            string state, 
            string postalCode, 
            string county)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.Address3 = address3;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.County = county;
        }

        public Address(AddressDto dto)
            : this(
                dto.Address1,
                dto.Address2,
                dto.Address3,
                dto.City,
                dto.State,
                dto.PostalCode,
                dto.County)
        {
        }

        #region Equality

        public bool Equals(Address other)
        {
            return string.Equals(Address1, other.Address1) &&
                   string.Equals(Address2, other.Address2) &&
                   string.Equals(Address3, other.Address3) &&
                   string.Equals(City, other.City) &&
                   string.Equals(State, other.State) &&
                   string.Equals(PostalCode, other.PostalCode) &&
                   string.Equals(County, other.County);
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
            return obj is Address && Equals((Address)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Address1?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Address2?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Address3?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (City?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (State?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (PostalCode?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (County?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public override BsonType BsonType => BsonType.Int32;

        public static bool operator !=(Address address1, Address address2)
        {
            return !Equals(address1, address2);
        }

        public static bool operator ==(Address address1, Address address2)
        {
            return Equals(address1, address2);
        }

        #endregion
    }
}
