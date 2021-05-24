// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check login on page.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check login on page.
        /// </summary>
        [Test]
        public void Exercise_4_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("login");
            var loginPage = new LoginPage(this.DriverContext);
            Assert.AreEqual("Login Page", loginPage.GetHeader());
            Assert.AreEqual("Login", loginPage.GetLoginButton());
        }
    }
}