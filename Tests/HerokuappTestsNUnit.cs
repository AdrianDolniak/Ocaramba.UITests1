// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HerokuappTestsNUnit : ProjectTestBase
    {
        [Test]
        public void HomePageTest()
        {
            // TODO: Add your test code here
            var homePage = new InternetPage(this.DriverContext);
            homePage.OpenHomePage();
        }

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
