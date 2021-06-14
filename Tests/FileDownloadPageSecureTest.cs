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
    public class FileDownloadPageSecureTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check secure download file.
        /// </summary>
        [Test]
        public void Exercise_File_Download_Secure_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("download_secure");
            var fileDownloadSecurePage = new FileDownloadSecurePage(this.DriverContext);
            fileDownloadSecurePage.SignIn("admin", "admin");
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("Secure File Downloader", fileDownloadSecurePage.GetHeader()));
            fileDownloadSecurePage.SaveFile("some-file.txt", "new-file.txt");
            fileDownloadSecurePage.DeleteFile("new-file.txt");
        }
    }
}