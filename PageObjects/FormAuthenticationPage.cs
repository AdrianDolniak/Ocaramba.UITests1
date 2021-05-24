// <copyright file="FormAuthenticationPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;

namespace Ocaramba.UITests1.PageObjects
{
    /// <summary>
    /// Methods for FormAuthenticationPage.
    /// </summary>
    public class FormAuthenticationPage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            userNameLoc = new ElementLocator(Locator.CssSelector, "Input[id={0}]"),
            passwordLoc = new ElementLocator(Locator.CssSelector, "Input[id={0}]"),
            loginButtonLoc = new ElementLocator(Locator.XPath, "//form[@id='login']/button"),
            messageSecure = new ElementLocator(Locator.XPath, "//*[@id='flash']");

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAuthenticationPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public FormAuthenticationPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage.
        /// </summary>
        /// <returns>Returns header.</returns>
        public string GetMessageSecure()
        {
            var messageSecureText = this.Driver.GetElement(this.messageSecure, ProjectBaseConfiguration.CustomTimeout, e => e.Displayed).Text;
            messageSecureText = messageSecureText.Split('\r')[0];
            this.logger.Info(CultureInfo.CurrentCulture, "Message text: {0}", messageSecureText);
            return messageSecureText;
        }

        /// <summary>
        /// Password method.
        /// </summary>
        /// <param name="password"> Username text for login.</param>
        public void EnterPassword(string password)
        {
            this.logger.Info(CultureInfo.CurrentCulture, "Password '{0}'", password);
            this.Driver.GetElement(this.passwordLoc.Format("password"), BaseConfiguration.ShortTimeout).SendKeys(password);
        }

        /// <summary>
        /// Username method.
        /// </summary>
        /// <param name="userName"> Username text for login.</param>
        public void EnterUserName(string userName)
        {
            this.logger.Info(CultureInfo.CurrentCulture, "User name '{0}'", userName);
            this.Driver.GetElement(this.userNameLoc.Format("username"), BaseConfiguration.ShortTimeout).SendKeys(userName);
        }

        /// <summary>
        /// Login method.
        /// </summary>
        public void LogIn()
        {
            this.logger.Info(CultureInfo.CurrentCulture, "Click on Login Button");
            this.Driver.GetElement(this.loginButtonLoc).Click();
        }
    }
}