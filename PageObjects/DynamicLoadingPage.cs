using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Globalization;

namespace Ocaramba.UITests1.PageObjects
{
    public class DynamicLoadingPage : ProjectPageBase
    {
        private readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            linkLocator = new ElementLocator(Locator.CssSelector, "a[href='/{0}']"),
            startButton = new ElementLocator(Locator.CssSelector, "#{0}");

        public DynamicLoadingPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this Example1
        /// </summary>
        public void ClickOnExample1Link(string page)
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.linkLocator.Format(page)).Click();
        }
        public void ClickOnStartButtonExample1(string button)
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.startButton.Format(button)).Click();
            this.Driver.WaitUntilElementIsNoLongerFound(this.startButton.Format("loading"), BaseConfiguration.MediumTimeout);
        }
        /// <summary>
        /// Methods for this Example2
        /// </summary>
        public void ClickOnExample2Link(string page)
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.linkLocator.Format(page)).Click();
        }
        public void ClickOnStartButtonExample2(string button)
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking on element link");
            this.Driver.GetElement(this.startButton.Format(button)).Click();
            // how to check below if it works?
            this.Driver.WaitForAjax();
        }

        /// <summary>
        /// Methods for this Finish
        /// </summary>
        public string GetText(string text)
        {
            var getText = this.Driver.GetElement(this.startButton.Format(text)).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Finish loading text: {0}", getText);
            return getText;
        }
    }
}

