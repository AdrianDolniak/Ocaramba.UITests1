// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using System.Threading;
using NUnit.Framework;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check custom timeout.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CustomTimeoutTestNUnit : ProjectTestBase
    {
        /// <summary>
        /// Test - Check custom timeout.
        /// </summary>
        [Test]
        public void CustomTimeoutTest()
        {
            // TODO: Add your test code here
            Assert.AreEqual(5, ProjectBaseConfiguration.CustomTimeout);
            Thread.Sleep(5000); // slow down closing the page
        }
    }
}