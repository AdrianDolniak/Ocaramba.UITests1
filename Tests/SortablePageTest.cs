// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using System.Collections.ObjectModel;
using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check data from a table.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SortablePageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check data from a table.
        /// </summary>
        [Test]
        public void Exercise_7_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("tables");
            var sortablePage = new SortablePage(this.DriverContext);
            Assert.AreEqual("Data Tables", sortablePage.GetHeader());
            var lastNames = new Collection<string> { "Smith", "Bach", "Doe", "Conway" };
            CollectionAssert.AreEqual(lastNames, sortablePage.GetValues());
        }
    }
}