// <copyright file="LoginPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace Ocaramba.UITests1.PageObjects
{
    /// <summary>
    /// Methods for LoginPage.
    /// </summary>
    public class LoginPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.CssSelector, ".example>h2"),
            loginButton = new ElementLocator(Locator.CssSelector, ".radius>i");

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="driverContext"> Sets the driver Context.</param>
        public LoginPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this Login Page.
        /// </summary>
        /// <returns>Returns header.</returns>
        public string GetHeader()
        {
            this.Driver.IsElementPresent(this.pageHeader, BaseConfiguration.MediumTimeout);
            var pageHeaderText = this.Driver.GetElement(this.pageHeader).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        /// <summary>
        /// Methods for this Login button.
        /// </summary>
        /// <returns>Returns login button text.</returns>
        public string GetLoginButton()
        {
            var loginButtonText = this.Driver.GetElement(this.loginButton).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Login button text: {0}", loginButtonText);
            return loginButtonText;
        }
    }
}
