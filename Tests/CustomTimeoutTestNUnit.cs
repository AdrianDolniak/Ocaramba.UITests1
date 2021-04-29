// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using System.Threading;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CustomTimeoutTestNUnit : ProjectTestBase
    {
        [Test]
        public void CustomTimeoutTest()
        {
            // TODO: Add your test code here
            Assert.AreEqual(5, ProjectBaseConfiguration.CustomTimeout);
            Thread.Sleep(5000); // slow down closing the page
        }
    }
}