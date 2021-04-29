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
    public class SortablePage : ProjectPageBase
    {
        private readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Data Tables']"),
            pageTable = new ElementLocator(Locator.CssSelector, "[id='table1']"),
            pageRows = new ElementLocator(Locator.TagName, "tr");

        public SortablePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public string GetHeader()
        {
            var pageHeaderText = this.Driver.GetElement(this.pageHeader).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        public string GetValues()
        {
            // not finished yet
            Collection<string> lastNames = new Collection<string>();
            var elements = this.Driver.GetElements(this.pageTable);
            foreach (var el in elements)
            {
                lastNames.Add(el.Text);
                Logger.Debug("lastName '{0}'", el.Text);
            }
            return lastNames.ToString();
        }
    }
}

