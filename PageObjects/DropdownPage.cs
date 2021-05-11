using System;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace Ocaramba.UITests1.PageObjects
{
    public class DropdownPage : ProjectPageBase
    {
        private readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Dropdown List']"),
            optionSelect = new ElementLocator(Locator.CssSelector, "[id='dropdown']");

        public DropdownPage(DriverContext driverContext)
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

        public bool GetOptionProperty()
        {
            var optionSelectText = this.Driver.GetElement(this.optionSelect, BaseConfiguration.MediumTimeout, e => e.Displayed & e.Enabled).Enabled;
            Logger.Info(CultureInfo.CurrentCulture, "Option selection bool: {0}", optionSelectText);
            return optionSelectText;
        }
    }
}

