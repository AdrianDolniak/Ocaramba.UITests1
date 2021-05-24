// <copyright file="DynamicLoadingPage.cs" company="PlaceholderCompany">
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
    /// Methods for DynamicLoadingPage.
    /// </summary>
    public class DynamicLoadingPage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            linkLocator = new ElementLocator(Locator.CssSelector, "a[href='/{0}']"),
            startButton = new ElementLocator(Locator.CssSelector, "#{0}");

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicLoadingPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public DynamicLoadingPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this Example1.
        /// </summary>
        /// <param name="page">The page name.</param>
        public void ClickOnExample1Link(string page)
        {
            this.logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.linkLocator.Format(page)).Click();
        }

        /// <summary>
        /// Methods for this Example1.
        /// </summary>
        /// <param name="button">The page name.</param>
        public void ClickOnStartButtonExample1(string button)
        {
            this.logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.startButton.Format(button)).Click();
            this.Driver.WaitUntilElementIsNoLongerFound(this.startButton.Format("loading"), BaseConfiguration.MediumTimeout);
        }

        /// <summary>
        /// Methods for this Example2.
        /// </summary>
        /// <param name="page">The page name.</param>
        public void ClickOnExample2Link(string page)
        {
            this.logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.linkLocator.Format(page)).Click();
        }

        /// <summary>
        /// Methods for this Example2.
        /// </summary>
        /// <param name="button">The page name.</param>
        public void ClickOnStartButtonExample2(string button)
        {
            this.logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.startButton.Format(button)).Click();
            this.Driver.WaitForAjax();
        }

        /// <summary>
        /// Methods for this Finish.
        /// </summary>
        /// <param name="text">The text to get.</param>
        /// <returns>Returns header.</returns>
        public string GetText(string text)
        {
            var getText = this.Driver.GetElement(this.startButton.Format(text)).Text;
            this.logger.Info(CultureInfo.CurrentCulture, "Finish loading text: {0}", getText);
            return getText;
        }
    }
}