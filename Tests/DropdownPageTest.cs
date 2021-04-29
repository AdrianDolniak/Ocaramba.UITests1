// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DropdownPageTest : ProjectTestBase
    {
        [Test]
        public void Exercise_6_Test()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("dropdown");
            var dropdownPage = new DropdownPage(this.DriverContext);
            Assert.AreEqual("Dropdown List", dropdownPage.GetHeader());
            Assert.False(dropdownPage.GetOptionProperty());
        }
    }
}