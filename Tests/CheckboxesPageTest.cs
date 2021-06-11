// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check Checkboxes.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CheckboxesPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check Checkboxes is selected.
        /// </summary>
        [Test]
        [Order(1)]
        public void Exercise_Checkboxes_Select_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("checkboxes");
            var checkBoxesPage = new CheckboxesPage(this.DriverContext);
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("Checkboxes", checkBoxesPage.GetHeader()),
                () => Assert.IsTrue(checkBoxesPage.SelectCheckBox("1")));
        }

        /// <summary>
        /// Test - Check Checkboxes is not selected.
        /// </summary>
        [Test]
        [Order(2)]
        public void Exercise_Checkboxes_Deselect_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("checkboxes");
            var checkBoxesPage = new CheckboxesPage(this.DriverContext);
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("Checkboxes", checkBoxesPage.GetHeader()),
                () => Assert.IsFalse(checkBoxesPage.SelectCheckBox("2")));
        }
    }
}