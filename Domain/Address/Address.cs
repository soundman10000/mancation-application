// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using Newtonsoft.Json;

namespace Domain
{
    [Serializable]
    public struct Address
    {
        public string Address1 { get; }
        public string Address2 { get; }
        public string Address3 { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
        public string County { get; }
        public Guid CountryId { get; }

        [JsonConstructor]
        public Address(
            string address1, 
            string address2, 
            string address3, 
            string city, 
            string state, 
            string postalCode, 
            string county, 
            Guid countryId)
        {
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            City = city;
            State = state;
            PostalCode = postalCode;
            County = county;
            CountryId = countryId;
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
                   string.Equals(County, other.County) &&
                   CountryId.Equals(other.CountryId);
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
                hashCode = (hashCode * 397) ^ CountryId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator !=(Address address1, Address address2)
        {
            return !address1.Equals(address2);
        }

        public static bool operator ==(Address address1, Address address2)
        {
            return address1.Equals(address2);
        }

        #endregion
    }
}
