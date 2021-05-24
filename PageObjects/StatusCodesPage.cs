// <copyright file="StatusCodesPage.cs" company="PlaceholderCompany">
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
    /// Methods for StatusCodesPage.
    /// </summary>
    public class StatusCodesPage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            statusCodes = new ElementLocator(Locator.CssSelector, "#content>div>h3");

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCodesPage"/> class.
        /// </summary>
        /// <param name="driverContext"> Sets the driver Context.</param>
        public StatusCodesPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage.
        /// </summary>
        /// <returns>Returns status of element.</returns>
        public bool IsElementPresent()
        {
            var statusCodesHeader = this.Driver.IsElementPresent(this.statusCodes, BaseConfiguration.ShortTimeout);
            this.logger.Info(CultureInfo.CurrentCulture, "Header is displayed: {0}", statusCodesHeader);
            return statusCodesHeader;
        }
    }
}