using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Globalization;

namespace Ocaramba.UITests1.PageObjects
{
    public class DragAndDropPage : ProjectPageBase
    {
        private readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='{0}']"),
            fromElem = new ElementLocator(Locator.Id, "column-a"),
            toElem = new ElementLocator(Locator.Id, "column-b");

        public DragAndDropPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public string GetHeader()
        {
            var pageHeaderText = this.Driver.GetElement(this.pageHeader.Format("Drag and Drop")).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }
        public void MoveElementAtoElementB()
        {
            var fromBox = this.Driver.GetElement(this.fromElem);
            var toBox = this.Driver.GetElement(this.toElem);
            Logger.Info(CultureInfo.CurrentCulture, "Drag: {0}", fromBox.Text);
            Logger.Info(CultureInfo.CurrentCulture, "Drop: {0}", toBox.Text);
            this.Driver.DragAndDropJs(fromBox, toBox);
        }
        public string GetText()
        {
            var toHeader = this.Driver.GetElement(this.toElem).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Header dropped: {0}", toHeader);
            return toHeader;
        }

    }
}

