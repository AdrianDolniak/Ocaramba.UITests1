// <copyright file="ProjectBaseConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Configuration;
using System.IO;
using Ocaramba;
using Ocaramba.Helpers;

namespace Ocaramba.UITests1
{
    /// <summary>
    /// SeleniumConfiguration that consume app.config file.
    /// </summary>
    public static class ProjectBaseConfiguration
    {
        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        /// <summary>
        /// Gets Connection to DB (auth).
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return BaseConfiguration.Builder["appSettings:ConnectionString"];
            }
        }

        /// <summary>
        /// Gets the custom Timeout.
        /// </summary>
        public static int CustomTimeout
        {
            get
            {
                return int.Parse(BaseConfiguration.Builder["appSettings:customTimeout"]);
            }
        }

        /// <summary>
        /// Gets the New Page.
        /// </summary>
        public static string NewPage
        {
            get
            {
                return BaseConfiguration.Builder["appSettings:newUrl"];
            }
        }

        /// <summary>
        /// Gets the data driven file.
        /// </summary>
        /// <value>
        /// The data driven file.
        /// </value>
        public static string DataDrivenFile
        {
            get
            {
                if (BaseConfiguration.UseCurrentDirectory)
                {
                    return Path.Combine(CurrentDirectory + BaseConfiguration.Builder["appSettings:DataDrivenFile"]);
                }

                return BaseConfiguration.Builder["appSettings:DataDrivenFile"];
            }
        }

        /// <summary>
        /// Gets the Excel data driven file.
        /// </summary>
        /// <value>
        /// The Excel data driven file.
        /// </value>
        public static string DataDrivenFileXlsx
        {
            get
            {
                if (BaseConfiguration.UseCurrentDirectory)
                {
                    return Path.Combine(CurrentDirectory + BaseConfiguration.Builder["appSettings:DataDrivenFileXlsx"]);
                }

                return BaseConfiguration.Builder["appSettings:DataDrivenFileXlsx"];
            }
        }

        /// <summary>
        /// Gets the Download Folder path.
        /// </summary>
        public static string DownloadFolderPath
        {
            get { return FilesHelper.GetFolder(BaseConfiguration.Builder["appSettings:DownloadFolder"], CurrentDirectory); }
        }
    }
}
