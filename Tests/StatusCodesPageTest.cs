// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check if element is present.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class StatusCodesPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check if element is present.
        /// </summary>
        [Test]
        public void Exercise_11_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("status_codes");
            var statuscodesPage = new StatusCodesPage(this.DriverContext);
            Assert.True(statuscodesPage.IsElementPresent());
        }
    }
}