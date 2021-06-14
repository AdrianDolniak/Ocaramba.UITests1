// <copyright file="FileUploadPage.cs" company="PlaceholderCompany">
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
    /// Methods for FileDownloadPage.
    /// </summary>
    public class FileUploadPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='File Uploader']"),
            chooseFileButton = new ElementLocator(Locator.Id, "file-upload"),
            uploadFileButton = new ElementLocator(Locator.Id, "file-submit"),
            fileUploadedPageHeader = new ElementLocator(Locator.XPath, "//h3[.='File Uploaded!']");

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploadPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public FileUploadPage(DriverContext driverContext)
            : base(driverContext)
        {
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
        /// <param name="newName">The file new name.</param>
        /// <returns>Returns this.</returns>
        public FileUploadPage UploadFile(string newName)
        {
            {
                FilesHelper.CopyFile(BaseConfiguration.ShortTimeout, "file-to-upload.txt", newName, this.DriverContext.DownloadFolder + "\\TestFilesToUpload\\", this.DriverContext.DownloadFolder + "\\TestFilesUploaded\\");
                this.Driver.GetElement(this.chooseFileButton).SendKeys(this.DriverContext.DownloadFolder + "\\TestFilesUploaded\\" + newName);
                this.Driver.GetElement(this.uploadFileButton).Click();
                this.Driver.IsElementPresent(this.fileUploadedPageHeader, BaseConfiguration.ShortTimeout);
            }

            return this;
        }
    }
}
