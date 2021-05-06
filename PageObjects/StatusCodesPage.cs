using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Globalization;

namespace Ocaramba.UITests1.PageObjects
{
    public class StatusCodesPage : ProjectPageBase
    {
        private readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            statusCodes = new ElementLocator(Locator.CssSelector, "#content>div>h3");
 
        public StatusCodesPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public bool IsElementPresent()
        {
            var statusCodesHeader = this.Driver.IsElementPresent(this.statusCodes, BaseConfiguration.ShortTimeout);
            Logger.Info(CultureInfo.CurrentCulture, "Header is displayed: {0}", statusCodesHeader);
            return statusCodesHeader;
        }
    }
}

