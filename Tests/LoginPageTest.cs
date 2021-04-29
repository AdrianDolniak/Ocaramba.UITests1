// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;


namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginPageTest : ProjectTestBase
    {
        [Test]
        public void Exercise_4_Test()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("login");
            var loginPage = new LoginPage(this.DriverContext);
            Assert.AreEqual("Login Page", loginPage.GetHeader());
            Assert.AreEqual("Login", loginPage.GetLoginButton());
        }
    }
}