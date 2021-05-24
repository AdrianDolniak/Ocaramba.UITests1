// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check Login on Form Authentication Page.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class FormAuthenticationPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check Login on Form Authentication Page.
        /// </summary>
        [Test]
        public void Exercise_5_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(BaseConfiguration.Username);
            formFormAuthentication.EnterPassword(BaseConfiguration.Password);
            formFormAuthentication.LogIn();
            Assert.AreEqual("You logged into a secure area!", formFormAuthentication.GetMessageSecure());
        }
    }
}