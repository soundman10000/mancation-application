// Mancation
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Threading.Tasks;
using Domain;
using Mancation.Domain;
using Presentation.DTO;
using Presentation.Request;
using ServiceStack;

namespace Host.Request
{
    public class PersonRequest : Service
    {
        private readonly IPersonDocumentStore _store;

        public PersonRequest(IPersonDocumentStore store)
        {
            this._store = store;
        }

        public async Task<PersonDto> Get(GetPerson request)
        {
            var entity = await this._store.Get(request.Id);

            return new PersonDto
            {
               Gender = entity.Gender,
               Birthdate = entity.Birthdate,
               MiddleName = entity.MiddleName, 
               FirstName = entity.FirstName, 
               LastName = entity.LastName
            };
        }

        public async Task<string> Post(CreatePerson createPerson)
        {
            var person = new Person(createPerson.PersonDto);

            try
            {
                var id = await this._store.Post(person);
                return id.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}