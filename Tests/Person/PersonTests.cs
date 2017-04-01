// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using NUnit.Framework;
using Presentation;
using static Tests.Utilities.StringHelpers;

namespace Tests.Person
{
    public class PersonTests
    {
        #region Boilerplate

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        #endregion Boilerplate

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
    }
}
