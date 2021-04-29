using System;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace Ocaramba.UITests1.PageObjects
{
    public class InternetPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            linkLocator = new ElementLocator(Locator.CssSelector, "a[href='/{0}']");

        public InternetPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public void OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            this.Driver.NavigateTo(new Uri(url));
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public void GoToPage(string page)
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking on element link {0}", page);
            this.Driver.GetElement(this.linkLocator.Format(page)).Click();
        }
    }
}
