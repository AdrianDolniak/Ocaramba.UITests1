// <copyright file="DropdownPage.cs" company="PlaceholderCompany">
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
    /// Methods for DropdownPage.
    /// </summary>
    public class DropdownPage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Dropdown List']"),
            optionSelect = new ElementLocator(Locator.CssSelector, "[id='dropdown']");

        /// <summary>
        /// Initializes a new instance of the <see cref="DropdownPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public DropdownPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Gets the Header.
        /// </summary>
        /// <returns>Returns header.</returns>
        public string GetHeader()
        {
            var pageHeaderText = this.Driver.GetElement(this.pageHeader).Text;
            this.logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        /// <summary>
        /// Gets the option property.
        /// </summary>
        /// <returns>Returns option property status.</returns>
        public bool GetOptionProperty()
        {
            var optionSelectText = this.Driver.GetElement(this.optionSelect, BaseConfiguration.MediumTimeout, e => e.Displayed & e.Enabled).Enabled;
            this.logger.Info(CultureInfo.CurrentCulture, "Option selection bool: {0}", optionSelectText);
            return optionSelectText;
        }
    }
}