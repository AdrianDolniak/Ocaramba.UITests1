// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check drop down.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DropdownPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check drop down.
        /// </summary>
        [Test]
        public void Exercise_6_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("dropdown");
            var dropdownPage = new DropdownPage(this.DriverContext);
            Assert.AreEqual("Dropdown List", dropdownPage.GetHeader());
            Assert.True(dropdownPage.GetOptionProperty());
        }
    }
}