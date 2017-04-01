// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;

namespace Presentation.DTO
{
    [Serializable]
    public class AddressDto
    {
        public Guid Id { get; }
        public string Address1 { get; }
        public string Address2 { get; }
        public string Address3 { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
        public string County { get; }
        public Guid CountryId { get; }

        public AddressDto(
            Guid id, 
            string address1, 
            string address2, 
            string address3, 
            string city, 
            string state, 
            string postalCode, 
            string county, 
            Guid countryId)
        {
            this.Id = id;
            this.Address1 = address1;
            this.Address2 = address2;
            this.Address3 = address3;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.County = county;
            this.CountryId = countryId;
        }
    }
}
