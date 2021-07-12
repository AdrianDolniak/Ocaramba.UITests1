// <copyright file="SelectPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using Ocaramba.WebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Ocaramba.UITests1.PageObjects
{
    /// <summary>
    /// Methods for Checkboxes.
    /// </summary>
    public class SelectPage : ProjectPageBase
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='This would be your first example on select dropd down list to with Selenium.']"),
            singleSelect = new ElementLocator(Locator.XPath, "//*[@id='select-demo']/option[contains(text(),'{0}')]"),
            multiSelect = new ElementLocator(Locator.XPath, "//*[@id='multi-select']/option[contains(text(),'{0}')]"),
            getFirstSelectedButton = new ElementLocator(Locator.Id, "printMe"),
            getAllSelectedButton = new ElementLocator(Locator.Id, "printAll"),
            textSelected = new ElementLocator(Locator.ClassName, "{0}");

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectPage"/> class.
        /// </summary>
        /// <param name="driverContext">driverContext.</param>
        public SelectPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Gets the Header.
        /// </summary>
        /// <returns>Returns header.</returns>
        public string GetHeader()
        {
            var pageHeaderText = this.Driver.GetElement(this.pageHeader).Text;
            this.logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        /// <summary>
        /// Select one option from a dropdowwn list.
        /// </summary>
        /// <param name="selectOption">The select option.</param>
        /// <returns>Returns SelectPage.</returns>
        public SelectPage SelectSingle(string selectOption)
        {
            var selected = this.Driver.GetElement(this.singleSelect.Format(selectOption));
            selected.Click();
            this.logger.Info(CultureInfo.CurrentCulture, "{0} was selected.", selected.Text);
            return new SelectPage(this.DriverContext);
        }

        /// <summary>
        /// Select one option from a dropdowwn list.
        /// </summary>
        /// <param name="textFirst">Selected first item.</param>
        /// <param name="textSecond">Selected second item [Optional].</param>
        /// <returns>Returns SelectPage.</returns>
        public SelectPage SelectMulti(string textFirst, [Optional] string textSecond)
        {
            if (textSecond == null)
            {
                var selectedOne = this.Driver.GetElement(this.multiSelect.Format(textFirst));
                Actions actions = new Actions(this.Driver);
                actions.KeyDown(Keys.LeftControl)
                    .Click(selectedOne)
                    .KeyUp(Keys.LeftControl)
                    .Perform();
                this.Driver.GetElement(this.getFirstSelectedButton).Click();
                this.logger.Info(CultureInfo.CurrentCulture, "{0} was selected.", selectedOne.Text);
            }
            else
            {
                var selectedFirst = this.Driver.GetElement(this.multiSelect.Format(textFirst));
                var selectedSecond = this.Driver.GetElement(this.multiSelect.Format(textSecond));
                Actions actions = new Actions(this.Driver);
                actions.KeyDown(Keys.LeftControl)
                    .Click(selectedFirst)
                    .Click(selectedSecond)
                    .KeyUp(Keys.LeftControl)
                    .Perform();
                this.Driver.GetElement(this.getAllSelectedButton).Click();
                this.logger.Info(CultureInfo.CurrentCulture, "{0} and {1} were selected.", selectedFirst.Text, selectedSecond.Text);
            }

            return new SelectPage(this.DriverContext);
        }

        /// <summary>
        /// Gets text from selection.
        /// </summary>
        /// <param name="text">Selected item.</param>
        /// <returns> Returns text from selection.</returns>
        public string GetTextSelected(string text)
        {
            var textSelected = this.Driver.GetElement(this.textSelected.Format(text)).Text;
            this.logger.Info(CultureInfo.CurrentCulture, "{0}", textSelected);
            return textSelected;
        }
    }
}