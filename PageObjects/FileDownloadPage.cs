// <copyright file="FileDownloadPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.IO;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Helpers;
using Ocaramba.Types;
using OpenQA.Selenium.Chrome;

namespace Ocaramba.UITests1.PageObjects
{
    /// <summary>
    /// Methods for InternetPage.
    /// </summary>
    public class FileDownloadPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='File Downloader']"),
            linkLocator = new ElementLocator(Locator.CssSelector, "a[href='/{0}']"),
            fileLink = new ElementLocator(Locator.CssSelector, "a[href='download/{0}']");

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDownloadPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public FileDownloadPage(DriverContext driverContext)
            : base(driverContext)
        {
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

        /// <summary>
        /// Methods for this Page.
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
        /// Methods for this Page.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <returns>Returns header.</returns>
        public FileDownloadPage SaveFile(string fileName)
        {
            {
                this.Driver.GetElement(this.fileLink.Format(fileName), "Click on file").Click();
                FilesHelper.WaitForFileOfGivenName(fileName, this.DriverContext.DownloadFolder, false);
            }

            return this;
        }
    }
}
