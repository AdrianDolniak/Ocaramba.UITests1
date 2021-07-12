// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Select.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SqlDataTest
    {
        /// <summary>
        /// Test - Select one column "NazwaDzialu" from DB [Pracownicy].
        /// </summary>
        [Test]
        [Order(1)]
        public void Exercise_Select_One_Column_Pracownicy_Test()
        {
            ICollection<string> dataQuery = SqlData.GetOneColumnFromDB("NazwaDzialu", "Pracownicy", "dbo.Dzial", "NrPietra", "1");
            var departments = new Collection<string> { "Promocja", "Dział techniczny" };
            CollectionAssert.AreEqual(departments, dataQuery);
        }

        /// <summary>
        /// Test - Select one column "NazwaDzialu" from DB [Pracownicy] with sorting.
        /// </summary>
        [Test]
        [Order(2)]
        public void Exercise_Select_One_Column_Pracownicy_OrderBy_Test()
        {
            ICollection<string> dataQuery = SqlData.GetOneColumnFromDB("NazwaDzialu", "Pracownicy", "dbo.Dzial", "NrPietra", "1", "NazwaDzialu");
            var departments = new Collection<string> { "Dział techniczny", "Promocja" };
            CollectionAssert.AreEqual(departments, dataQuery);
        }

        /// <summary>
        /// Test - Select one column "Name" from DB [AdventureWorks2014].
        /// </summary>
        [Test]
        [Order(3)]
        public void Exercise_Select_One_Column_AdventureWorks_Test()
        {
            ICollection<string> dataQuery = SqlData.GetOneColumnFromDB("Name", "AdventureWorks2014", "Production.Product", "ProductID", "322");
            var departments = new Collection<string> { "Chainring" };
            CollectionAssert.AreEqual(departments, dataQuery);
        }

        /// <summary>
        /// Test - Select four columns "Imie","Nazwisko","PESEL","Pensja" from DB [Pracownicy].
        /// </summary>
        [Test]
        [Order(4)]
        public void Exercise_Select_Four_Columns_Pracownicy_Test()
        {
            Dictionary<string, string> dataQuery = SqlData.GetGetFourColumnsFromDB("Imie", "Nazwisko", "PESEL", "Pensja", "Pracownicy", "dbo.Pracownik", "IdPracownik", "1");
            var dataPersonal = new Dictionary<string, string>();
            dataPersonal.Add("Imie", "Andrzej");
            dataPersonal.Add("Nazwisko", "Kowalski");
            dataPersonal.Add("PESEL", "83060206996");
            dataPersonal.Add("Pensja", "2000.00");
            CollectionAssert.AreEqual(dataPersonal, dataQuery);
        }

        /// <summary>
        /// Test - Select four columns "Imie","Nazwisko","PESEL","Pensja" from DB [Pracownicy] and compare with file template.
        /// </summary>
        [Test]
        [Order(5)]
        public void Exercise_Select_Four_Columns_Pracownicy_File_Test()
        {
            SqlData.WriteToFile("Imie", "Nazwisko", "PESEL", "Pensja", "Pracownicy", "dbo.Pracownik", "IdPracownik", "2", "sqlQueryOutputFile.csv");
            string fileNameQuery = File.ReadAllText(ProjectBaseConfiguration.DownloadFolderPath + "\\TestFilesSql\\" + "sqlQueryOutputFile.csv");
            string fileNameTemplate = File.ReadAllText(ProjectBaseConfiguration.DownloadFolderPath + "\\TestFilesSql\\" + "sqlTemplateFile.csv");
            Assert.AreEqual(fileNameQuery, fileNameTemplate);
            SqlData.DeleteFile("sqlQueryOutputFile.csv");
        }
    }
}