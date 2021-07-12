// <copyright file="SqlData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Ocaramba.UITests1.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using Microsoft.VisualStudio.TestPlatform.TestHost;
    using NLog;
    using NUnit.Framework;
    using Ocaramba;
    using Ocaramba.Extensions;
    using Ocaramba.Helpers;
    using Ocaramba.Types;

    /// <summary>
    /// Methods for getting data from DB.
    /// </summary>
    public class SqlData
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Gets one column from DB.
        /// </summary>
        /// <param name="columnName">Selected column name.</param>
        /// <param name="dbName">The DB name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="columnNameFilter">Column name filter.</param>
        /// <param name="filterValue">Filter value.</param>
        /// <param name="orderColumnName">Sort column name [Optional].</param>
        /// <returns>Returns one column from DB. </returns>
        public static ICollection<string> GetOneColumnFromDB(string columnName, string dbName, string tableName, string columnNameFilter, string filterValue, [Optional] string orderColumnName)
        {
            if (orderColumnName == null)
            {
                string sqlQuery = "SELECT " + columnName + " FROM " + dbName + "." + tableName + " WHERE " + columnNameFilter + " IN " + "(" + filterValue + ")";
                Logger.Info(CultureInfo.CurrentCulture, "SQL query: {0}", sqlQuery);
                var result = SqlHelper.ExecuteSqlCommand(sqlQuery, ProjectBaseConfiguration.ConnectionString, columnName);
                foreach (var rows in result)
                {
                    Logger.Info(CultureInfo.CurrentCulture, "SQL query result: {0}", rows);
                }

                return result;
            }
            else
            {
                string sqlQuery = "SELECT " + columnName + " FROM " + dbName + "." + tableName + " WHERE " + columnNameFilter + " IN " + "(" + filterValue + ")" + " ORDER BY " + orderColumnName;
                Logger.Info(CultureInfo.CurrentCulture, "SQL query: {0}", sqlQuery);
                var result = SqlHelper.ExecuteSqlCommand(sqlQuery, ProjectBaseConfiguration.ConnectionString, columnName);
                foreach (var rows in result)
                {
                    Logger.Info(CultureInfo.CurrentCulture, "SQL query result: {0}", rows);
                }

                return result;
            }
        }

        /// <summary>
        /// Gets four columns (one row).
        /// </summary>
        /// <param name="columnFirst">Selected first column name.</param>
        /// <param name="columnSecond">Selected second column name.</param>
        /// <param name="columnThird">Selected third column name.</param>
        /// <param name="columnFourth">Selected fourth column name.</param>
        /// <param name="dbName">The DB name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="columnNameFilter">Column name filter.</param>
        /// <param name="filterValue">Filter value.</param>
        /// <returns>Returns four columns from DB. </returns>
        public static Dictionary<string, string> GetGetFourColumnsFromDB(string columnFirst, string columnSecond, string columnThird, string columnFourth, string dbName, string tableName, string columnNameFilter, string filterValue)
        {
            ICollection<string> column = new List<string>();
            column.Add(columnFirst);
            column.Add(columnSecond);
            column.Add(columnThird);
            column.Add(columnFourth);
            string sqlQuery = "SELECT " + column.ElementAt(0) + "," + column.ElementAt(1) + "," + column.ElementAt(2) + "," + column.ElementAt(3) + " FROM " + dbName + "." + tableName + " WHERE " + columnNameFilter + " = " + filterValue;
            Logger.Info(CultureInfo.CurrentCulture, "SQL query: {0}", sqlQuery);
            Dictionary<string, string> results = SqlHelper.ExecuteSqlCommand(sqlQuery, ProjectBaseConfiguration.ConnectionString, column);
            foreach (var row in results)
            {
                Logger.Info(CultureInfo.CurrentCulture, "SQL query result: {0}", row);
            }

            return results;
        }

        /// <summary>
        /// Gets four columns (one row).
        /// </summary>
        /// <param name="columnFirst">Selected first column name.</param>
        /// <param name="columnSecond">Selected second column name.</param>
        /// <param name="columnThird">Selected third column name.</param>
        /// <param name="columnFourth">Selected fourth column name.</param>
        /// <param name="dbName">The DB name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="columnNameFilter">Column name filter.</param>
        /// <param name="filterValue">Filter value.</param>
        /// <param name="fileName">Saved file name.</param>
        public static void WriteToFile(string columnFirst, string columnSecond, string columnThird, string columnFourth, string dbName, string tableName, string columnNameFilter, string filterValue, string fileName)
        {
            try
            {
                using StreamWriter file = new StreamWriter(ProjectBaseConfiguration.DownloadFolderPath + "\\TestFilesSql\\" + fileName, false);
                {
                    ICollection<string> column = new List<string>();
                    column.Add(columnFirst);
                    column.Add(columnSecond);
                    column.Add(columnThird);
                    column.Add(columnFourth);
                    string sqlQuery = "SELECT " + column.ElementAt(0) + "," + column.ElementAt(1) + "," + column.ElementAt(2) + "," + column.ElementAt(3) + " FROM " + dbName + "." + tableName + " WHERE " + columnNameFilter + " = " + filterValue;
                    Logger.Info(CultureInfo.CurrentCulture, "SQL query: {0}", sqlQuery);
                    Dictionary<string, string> results = SqlHelper.ExecuteSqlCommand(sqlQuery, ProjectBaseConfiguration.ConnectionString, column);
                    file.WriteLine(column.ElementAt(0) + ";" + column.ElementAt(1) + ";" + column.ElementAt(2) + ";" + column.ElementAt(3) + ";");
                    foreach (var row in results)
                    {
                        file.Write(row.Value + ";");
                        Logger.Info(CultureInfo.CurrentCulture, "Save to file: {0}", row.Value);
                    }

                    Logger.Info(CultureInfo.CurrentCulture, "File path: {0}", ProjectBaseConfiguration.DownloadFolderPath + "\\TestFilesSql\\" + fileName);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ups, something went wrong:", ex);
            }
        }

        /// <summary>
        /// Methods for this File.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        public static void DeleteFile(string fileName)
        {
            {
                FilesHelper.DeleteFile(fileName, ProjectBaseConfiguration.DownloadFolderPath + "\\TestFilesSql\\");
                WaitHelper.Wait(
                        () => FilesHelper.CountFiles(ProjectBaseConfiguration.DownloadFolderPath + "\\TestFilesSql\\", FileType.Csv) == 1, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1), "Expected files count equal to 1.");
            }
        }
    }
}
