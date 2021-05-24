// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.UITests1.PageObjects;

namespace Ocaramba.UITests1.Tests
{
    /// <summary>
    /// Test - Check file download.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class FileDownloadPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check login on page.
        /// </summary>
        [Test]
        public void Exercise_File_Download_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("download");
            var fileDownload = new FileDownloadPage(this.DriverContext);
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("File Downloader", fileDownload.GetHeader()));
            fileDownload.SaveFile("data.txt");
        }
    }
}