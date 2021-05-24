// <copyright file="ProjectPageBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Ocaramba;
using OpenQA.Selenium;

namespace Ocaramba.UITests1
{
    /// <summary>
    /// Methods for Pages.
    /// </summary>
    public partial class ProjectPageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPageBase"/> class.
        /// </summary>
        /// <param name="driverContext"> Sets the driver Context. </param>
        public ProjectPageBase(DriverContext driverContext)
        {
            this.DriverContext = driverContext;
            this.Driver = driverContext.Driver;
        }

        /// <summary>
        /// Gets or sets Driver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets DriverContext.
        /// </summary>
        protected DriverContext DriverContext { get; set; }
    }
}
