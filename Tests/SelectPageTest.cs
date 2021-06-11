// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Select.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SelectPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Select one option.
        /// </summary>
        [Test]
        [Order(1)]
        public void Exercise_Select_Single_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.GoToPageNew("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
            this.DriverContext.WindowMaximize();
            var selectPage = new SelectPage(this.DriverContext);
            selectPage.SelectSingle("Friday");
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("This would be your first example on select dropd down list to with Selenium.", selectPage.GetHeader()),
                () => Assert.AreEqual("Day selected :- Friday", selectPage.GetTextSelected("selected-value")));
        }

        /// <summary>
        /// Test - Select multi option - one item.
        /// </summary>
        [Test]
        [Order(2)]
        public void Exercise_Select_Multi_One_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.GoToPageNew("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
            this.DriverContext.WindowMaximize();
            var selectPage = new SelectPage(this.DriverContext);
            selectPage.SelectMulti("Washington");
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("This would be your first example on select dropd down list to with Selenium.", selectPage.GetHeader()),
                () => Assert.AreEqual("First selected option is : Washington", selectPage.GetTextSelected("getall-selected")));
        }

        /// <summary>
        /// Test - Select multi option - two items.
        /// </summary>
        [Test]
        [Order(3)]
        public void Exercise_Select_Multi_Two_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.GoToPageNew("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
            this.DriverContext.WindowMaximize();
            var selectPage = new SelectPage(this.DriverContext);
            selectPage.SelectMulti("Florida", "Texas");
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("This would be your first example on select dropd down list to with Selenium.", selectPage.GetHeader()),
                () => Assert.AreEqual("Options selected are : Florida,Texas", selectPage.GetTextSelected("getall-selected")));
        }
    }
}