// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class StatusCodesPageTest : ProjectTestBase
    {
        [Test]
        public void Exercise_11_Test()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("status_codes");
            var statuscodesPage = new StatusCodesPage(this.DriverContext);
            Assert.True(statuscodesPage.IsElementPresent());
        }
    }
}