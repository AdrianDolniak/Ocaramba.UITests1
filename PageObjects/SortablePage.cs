// <copyright file="SortablePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace Ocaramba.UITests1.PageObjects
{
    /// <summary>
    /// Methods for SortablePage.
    /// </summary>
    public class SortablePage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Data Tables']"),
            pageTable = new ElementLocator(Locator.CssSelector, "[id='table1']"),
            pageRows = new ElementLocator(Locator.CssSelector, "#table1 td:nth-child(1)");

        /// <summary>
        /// Initializes a new instance of the <see cref="SortablePage"/> class.
        /// </summary>
        /// <param name="driverContext"> Sets the driver Context.</param>
        public SortablePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods to Get header.
        /// </summary>
        /// <returns>Returns header.</returns>
        public string GetHeader()
        {
            var pageHeaderText = this.Driver.GetElement(this.pageHeader).Text;
            this.logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        /// <summary>
        /// Methods to Get values from table.
        /// </summary>
        /// <returns>Returns last Names.</returns>
        public Collection<string> GetValues()
        {
            Collection<string> lastNames = new Collection<string>();
            var elements = this.Driver.GetElements(this.pageRows);
            foreach (var el in elements)
            {
                lastNames.Add(el.Text);
                this.logger.Debug("lastName '{0}'", el.Text);
            }

            return lastNames;
        }
    }
}