﻿// <copyright file="TestData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <license>
//     The MIT License (MIT)
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </license>

using System.Collections;
using System.Globalization;
using NUnit.Framework;

namespace Ocaramba.UITests1.DataDriven
{
    /// <summary>
    /// DataDriven methods for NUnit test framework.
    /// </summary>
    public static class TestData
    {
        /// <summary>
        /// Gets the data driven file and set the test name.
        /// </summary>
        public static IEnumerable Credentials
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "credential", new[] { "user", "password" }, "credentialXml"); }
        }

        /// <summary>
        /// Gets the data driven file and set the test name.
        /// </summary>
        public static IEnumerable CredentialsExcel
        {
            get { return DataDrivenHelper.ReadXlsxDataDriveFile(ProjectBaseConfiguration.DataDrivenFileXlsx, "credential", new[] { "user", "password" }, "credentialExcel"); }
        }

        /// <summary>
        /// Gets the data driven file and set the test name.
        /// </summary>
        public static IEnumerable LinksSetTestName
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "links", new[] { "number" }, "Count_links"); }
        }

        /// <summary>
        /// Gets the data driven file and set the test name.
        /// </summary>
        public static IEnumerable Links
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "links"); }
        }

        /// <summary>
        /// Gets the data driven file and set the test name.
        /// </summary>
        /// <returns>Return the data driven file and set the test name.</returns>
        public static IEnumerable LinksExcel()
        {
            return DataDrivenHelper.ReadXlsxDataDriveFile(ProjectBaseConfiguration.DataDrivenFileXlsx, "links");
        }

        /// <summary>
        /// Gets the data driven file and set the test name.
        /// </summary>
        /// <returns>Return the data driven file and set the test name.</returns>
        public static IEnumerable CredentialsCSV()
        {
            var path = TestContext.CurrentContext.TestDirectory;
            path = string.Format(CultureInfo.CurrentCulture, "{0}{1}", path, @"\DataDriven\TestDataDrivenCsv.csv");
            return DataDrivenHelper.ReadDataDriveFileCsv(path, new[] { "user", "password" }, "credentialCsv");
        }
    }
}
