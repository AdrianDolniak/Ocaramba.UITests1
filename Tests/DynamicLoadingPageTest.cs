// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DynamicLoadingPageTest : ProjectTestBase
    {
        [Test]
        public void Exercise_12_Test_Example1()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("dynamic_loading");
            var example1 = new DynamicLoadingPage(this.DriverContext);
            example1.ClickOnExample1Link("dynamic_loading/1");
            var start = new DynamicLoadingPage(this.DriverContext);
            start.ClickOnStartButtonExample1("start>button");
            var finish = new DynamicLoadingPage(this.DriverContext).GetText("finish");
            Assert.AreEqual("Hello World!", finish);
        }

        [Test]
        public void Exercise_12_Test_Example2()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("dynamic_loading");
            var example2 = new DynamicLoadingPage(this.DriverContext);
            example2.ClickOnExample2Link("dynamic_loading/2");
            var start = new DynamicLoadingPage(this.DriverContext);
            start.ClickOnStartButtonExample2("start>button");
            var finish = new DynamicLoadingPage(this.DriverContext).GetText("finish");
            Assert.AreEqual("Hello World!", finish);
        }
    }
}