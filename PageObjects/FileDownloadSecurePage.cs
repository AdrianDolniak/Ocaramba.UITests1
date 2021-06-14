// <copyright file="FileDownloadSecurePage.cs" company="PlaceholderCompany">
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
    /// Methods for FileDownloadSecurePage.
    /// </summary>
    public class FileDownloadSecurePage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Secure File Downloader']"),
            fileLink = new ElementLocator(Locator.CssSelector, "a[href='download_secure/{0}']");

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDownloadSecurePage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public FileDownloadSecurePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void SignIn(string username, string password)
        {
            this.Driver.Navigate().GoToUrl("http://" + username + ":" + password + "@the-internet.herokuapp.com/download_secure");
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
        /// <param name="newName">The new file name.</param>
        /// <returns>Returns this.</returns>
        public FileDownloadSecurePage SaveFile(string fileName, string newName)
        {
            {
                this.Driver.GetElement(this.fileLink.Format(fileName), "Click on file").Click();
                FilesHelper.WaitForFileOfGivenName(fileName, this.DriverContext.DownloadFolder, false);
                FileInfo file = FilesHelper.GetLastFile(this.DriverContext.DownloadFolder);
                FilesHelper.RenameFile(5, file.Name, newName, this.DriverContext.DownloadFolder);
            }

            return this;
        }

        /// <summary>
        /// Methods for this Page.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <returns>Returns this.</returns>
        public FileDownloadSecurePage DeleteFile(string fileName)
        {
            {
                FilesHelper.DeleteFile(fileName, this.DriverContext.DownloadFolder);
            }

            return this;
        }
    }
}
