// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System;
using NUnit.Framework;

using static Tests.Utilities.StringHelpers;

namespace Tests.Address
{

    public class AddressTests
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
        public void AddressValueEquality()
        {
            var address1 = new Domain.Address(
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                Guid.NewGuid());

            var address2 = address1;

            Assert.IsTrue(address1 == address2);
        }
    }
}
