// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check Open Page.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HerokuappTestsNUnit : ProjectTestBase
    {
        /// <summary>
        /// Test - Check Open Home Page.
        /// </summary>
        [Test]
        public void HomePageTest()
        {
            // TODO: Add your test code here
            var homePage = new InternetPage(this.DriverContext);
            homePage.OpenHomePage();
        }

        /// <summary>
        /// Test - Check Open Home Page and Login.
        /// </summary>
        [Test]
        public void BasicAuthTest()
        {
            // TODO: Add your test code here
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("login");
        }
    }
}
