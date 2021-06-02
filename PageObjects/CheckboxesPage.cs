// <copyright file="CheckboxesPage.cs" company="PlaceholderCompany">
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
    /// Methods for Checkboxes.
    /// </summary>
    public class CheckboxesPage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Checkboxes']"),
            checkBox = new ElementLocator(Locator.XPath, "//*[@id='checkboxes']/input[{0}]");

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckboxesPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public CheckboxesPage(DriverContext driverContext)
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
        /// Gets the Checkoboxes status.
        /// </summary>
        /// <param name="checkBox">The checkbox number.</param>
        /// <returns>Returns status of checkbox.</returns>
        public bool SelectCheckBox(string checkBox)
        {
            var checkBoxSelect = this.Driver.GetElement(this.checkBox.Format(checkBox), BaseConfiguration.MediumTimeout, e => e.Displayed & e.Enabled);
            this.logger.Info(CultureInfo.CurrentCulture, "Checkbox is selected: {0}", checkBoxSelect.Selected);
            if (checkBoxSelect.Selected == false)
            {
                this.logger.Info(CultureInfo.CurrentCulture, "Click on Checkbox");
                checkBoxSelect.Click();
                this.logger.Info(CultureInfo.CurrentCulture, "Checkbox is selected: {0}", checkBoxSelect.Selected);
                return checkBoxSelect.Selected;
            }
            else
            {
                this.logger.Info(CultureInfo.CurrentCulture, "Click on Checkbox");
                checkBoxSelect.Click();
                this.logger.Info(CultureInfo.CurrentCulture, "Checkbox is selected: {0}", checkBoxSelect.Selected);
            }

            return checkBoxSelect.Selected;
        }
    }
}