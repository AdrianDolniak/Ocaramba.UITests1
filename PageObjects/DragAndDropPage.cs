// <copyright file="DragAndDropPage.cs" company="PlaceholderCompany">
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
    /// Class DragAndDropPage.
    /// </summary>
    public class DragAndDropPage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='{0}']"),
            fromElem = new ElementLocator(Locator.Id, "column-a"),
            toElem = new ElementLocator(Locator.Id, "column-b");

        /// <summary>
        /// Initializes a new instance of the <see cref="DragAndDropPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public DragAndDropPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage.
        /// </summary>
        /// <returns>Returns Header.</returns>
        public string GetHeader()
        {
            var pageHeaderText = this.Driver.GetElement(this.pageHeader.Format("Drag and Drop")).Text;
            this.logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        /// <summary>
        /// Moves element A to B.
        /// </summary>
        public void MoveElementAtoElementB()
        {
            var fromBox = this.Driver.GetElement(this.fromElem);
            var toBox = this.Driver.GetElement(this.toElem);
            this.logger.Info(CultureInfo.CurrentCulture, "Drag: {0}", fromBox.Text);
            this.logger.Info(CultureInfo.CurrentCulture, "Drop: {0}", toBox.Text);
            this.Driver.DragAndDropJs(fromBox, toBox);
        }

        /// <summary>
        /// Gets text of element.
        /// </summary>
        /// <returns>Returns header after dropped the element.</returns>
        public string GetText()
        {
            var toHeader = this.Driver.GetElement(this.toElem).Text;
            this.logger.Info(CultureInfo.CurrentCulture, "Header dropped: {0}", toHeader);
            return toHeader;
        }
    }
}