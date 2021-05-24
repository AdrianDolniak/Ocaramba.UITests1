// <copyright file="InternetPage.cs" company="PlaceholderCompany">
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
    /// Methods for InternetPage.
    /// </summary>
    public class InternetPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            linkLocator = new ElementLocator(Locator.CssSelector, "a[href='/{0}']");

        /// <summary>
        /// Initializes a new instance of the <see cref="InternetPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public InternetPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage.
        /// </summary>
        /// <returns>Returns Home Page.</returns>
        public InternetPage OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            this.Driver.NavigateTo(new Uri(url));
            return this;
        }

        /// <summary>
        /// Methods for this HomePage.
        /// </summary>
        /// <param name="page">The page name.</param>
        /// <returns>Returns Page.</returns>
        public InternetPage GoToPage(string page)
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking on element link {0}", page);
            this.Driver.GetElement(this.linkLocator.Format(page)).Click();
            return new InternetPage(this.DriverContext);
        }
    }
}
