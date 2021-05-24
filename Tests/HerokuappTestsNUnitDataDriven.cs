// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using System.Collections.Generic;
using NUnit.Framework;
using Ocaramba.UITests1.DataDriven;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check login using data from files.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HerokuappTestsNUnitDataDriven : ProjectTestBase
    {
        /// <summary>
        /// Test - Check login using data from XML file.
        /// </summary>
        /// <param name="parameters">The user and the password.</param>
        [Test]
        [TestCaseSource(typeof(TestData), "Credentials")]
        public void FormAuthenticationPageTestXml(IDictionary<string, string> parameters)
        {
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(parameters["user"]);
            formFormAuthentication.EnterPassword(parameters["password"]);
            formFormAuthentication.LogIn();
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual(parameters["message"], formFormAuthentication.GetMessageSecure()));
        }

        /// <summary>
        /// Test - Check login using data from excel file.
        /// </summary>
        /// <param name="parameters">The user and the password.</param>
        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsExcel")]
        public void FormAuthenticationPageTestExcel(IDictionary<string, string> parameters)
        {
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(parameters["user"]);
            formFormAuthentication.EnterPassword(parameters["password"]);
            formFormAuthentication.LogIn();
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual(parameters["message"], formFormAuthentication.GetMessageSecure()));
        }

        /// <summary>
        /// Test - Check login using data from CSV file.
        /// </summary>
        /// <param name="parameters">The user and the password.</param>
        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsCSV")]
        public void FormAuthenticationPageTestCSV(IDictionary<string, string> parameters)
        {
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(parameters["user"]);
            formFormAuthentication.EnterPassword(parameters["password"]);
            formFormAuthentication.LogIn();
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual(parameters["message"], formFormAuthentication.GetMessageSecure()));
        }
    }
}
