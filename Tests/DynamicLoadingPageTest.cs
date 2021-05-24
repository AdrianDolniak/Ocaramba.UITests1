// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check dynamic loading page.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DynamicLoadingPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check dynamic loading page example1.
        /// </summary>
        [Test]
        public void Exercise_12_Test_Example1()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("dynamic_loading");
            var example1 = new DynamicLoadingPage(this.DriverContext);
            example1.ClickOnExample1Link("dynamic_loading/1");
            var start = new DynamicLoadingPage(this.DriverContext);
            start.ClickOnStartButtonExample1("start>button");
            var finish = new DynamicLoadingPage(this.DriverContext).GetText("finish");
            Assert.AreEqual("Hello World!", finish);
        }

        /// <summary>
        /// Test - Check dynamic loading page example2.
        /// </summary>
        [Test]
        public void Exercise_12_Test_Example2()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("dynamic_loading");
            var example2 = new DynamicLoadingPage(this.DriverContext);
            example2.ClickOnExample2Link("dynamic_loading/2");
            var start = new DynamicLoadingPage(this.DriverContext);
            start.ClickOnStartButtonExample2("start>button");
            var finish = new DynamicLoadingPage(this.DriverContext).GetText("finish");
            Assert.AreEqual("Hello World!", finish);
        }
    }
}