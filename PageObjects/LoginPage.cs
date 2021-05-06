using System;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace Ocaramba.UITests1.PageObjects
{
    public class LoginPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h2[.='Login Page']"),
            loginButton = new ElementLocator(Locator.XPath, "//i[.=' Login']");

        public LoginPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this LoginPage
        /// </summary>
        public string GetHeader()
        {
            this.Driver.IsElementPresent(this.pageHeader, BaseConfiguration.MediumTimeout);
            var pageHeaderText = this.Driver.GetElement(this.pageHeader).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        public string GetLoginButton()
        {
            var loginButtonText = this.Driver.GetElement(this.loginButton).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Login button text: {0}", loginButtonText);
            return loginButtonText;
        }
    }
}
