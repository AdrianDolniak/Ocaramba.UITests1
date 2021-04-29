// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;
using System.Collections.ObjectModel;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SortablePageTest : ProjectTestBase
    {
        [Test]
        public void Exercise_7_Test()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("tables");
            var sortablePage = new SortablePage(this.DriverContext);
            Assert.AreEqual("Data Tables", sortablePage.GetHeader());
            var lastNames = new Collection<string> { "Smith", "Bach", "Doe", "Conway" };
            Assert.AreEqual(lastNames, sortablePage.GetValues());
        }
    }
}