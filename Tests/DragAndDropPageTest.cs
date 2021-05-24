// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check drag and drop.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DragAndDropPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check drag and drop.
        /// </summary>
        [Test]
        public void Exercise_10_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("drag_and_drop");
            var dragAndDropPageHeader = new DragAndDropPage(this.DriverContext);
            Assert.AreEqual("Drag and Drop", dragAndDropPageHeader.GetHeader());
            var moveElementAtoElementB = new DragAndDropPage(this.DriverContext);
            moveElementAtoElementB.MoveElementAtoElementB();
            var draganddropPage = new DragAndDropPage(this.DriverContext);
            Assert.AreEqual("A", draganddropPage.GetText());
        }
    }
}