// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class FormAuthenticationPageTest : ProjectTestBase
    {
        [Test]
        public void Exercise_5_Test()
        {
            // TODO: Add your test code here
            var InternetPage = new InternetPage(this.DriverContext);
            InternetPage.OpenHomePage();
            InternetPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(BaseConfiguration.Username);
            formFormAuthentication.EnterPassword(BaseConfiguration.Password);
            formFormAuthentication.LogIn();
            Assert.AreEqual("You logged into a secure area!", formFormAuthentication.GetMessageSecure());
        }
    }
}