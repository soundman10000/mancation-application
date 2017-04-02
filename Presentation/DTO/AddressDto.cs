// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;

namespace Presentation.DTO
{
    [Serializable]
    public class AddressDto
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }

        public AddressDto(
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
    }
}
