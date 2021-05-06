// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DragAndDropPageTest : ProjectTestBase
    {
        [Test]
        public void Exercise_10_Test()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("drag_and_drop");
            var draganddropPageHeader = new DragAndDropPage(this.DriverContext);
            Assert.AreEqual("Drag and Drop", draganddropPageHeader.GetHeader());
            var moveElementAtoElementB = new DragAndDropPage(this.DriverContext);
            moveElementAtoElementB.MoveElementAtoElementB();
            var draganddropPage = new DragAndDropPage(this.DriverContext);
            Assert.AreEqual("A", draganddropPage.GetText());
        }
    }
}


