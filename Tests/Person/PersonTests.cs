// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Presentation;
using Presentation.DTO;
using Presentation.Request;
using static Tests.Utilities.StringHelpers;

namespace Tests.Person
{
    public class PersonTests : Test
    {
        [Test]
        public void PersonValueEquality()
        {
            var person1 = new Domain.Person(
                RandomString(),
                RandomString(),
                RandomString(),
                DateTime.Today,
                Gender.Male);

            var person2 = person1;

            Assert.IsTrue(person1 == person2);
        }

        [Test]
        public async Task TestCreateAndGetSucceed()
        {
            var personDto = new PersonDto
            {
                FirstName = RandomString(),
                LastName = RandomString(),
                MiddleName = RandomString(),
                Birthdate = DateTime.Today,
                Gender = Gender.Male
            };

            var request = new CreatePerson
            {
                PersonDto = personDto
            };

            var id = await this.Client.PostAsync(request);

            var getRequest = new GetPerson
            {
                Id = id
            };

            var person = await this.Client.GetAsync(getRequest);

            person.ShouldBeEquivalentTo(personDto);
        }
    }
}
