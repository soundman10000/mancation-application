// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using NUnit.Framework;

namespace Tests
{
    [SetUpFixture]
    public class TestFixture
    {
        public static string ListeningOn = "http://localhost:1384/";
        public static readonly string UnitTestDatabase = "testingDatabase";
        public static readonly string UnitTestUserId = "csanonymous";

        #region Boilerplate

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // set up the service stack host
            new TestAppHost().Init().Start(ListeningOn);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        #endregion
    }
}
