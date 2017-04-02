// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using Host;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Tests
{
    [SetUpFixture]
    public class TestFixture
    {
        public static IUnityContainer Container { get; private set; }
        public static string ListeningOn = "http://localhost:1384/";

        public static readonly string UnitTestDatabase = "testingDatabase";
        public static readonly string UnitTestUserId = "csanonymous";

        #region Boilerplate

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // set up the service stack host
            Container = HostContainer.Create();
            new TestAppHost(Container).Init().Start(ListeningOn);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Container = null;
        }

        #endregion
    }
}
