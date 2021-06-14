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
    public class FileUploadDownloadPageTest : ProjectTestBase
    {
        /// <summary>
        /// Test - Check upload files.
        /// </summary>
        [Test]
        [Order(1)]
        public void Exercise_File_Upload_Test()
        {
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("upload");
            var fileUpload = new FileUploadPage(this.DriverContext);
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("File Uploader", fileUpload.GetHeader()));
            fileUpload.UploadFile("file-uploaded.txt");
        }

        /// <summary>
        /// Test - Check download files.
        /// </summary>
        [Test]
        [Order(2)]
        public void Exercise_Uploaded_File_Download_Test()
        {
            // TODO: Add your test code here
            var internetPage = new InternetPage(this.DriverContext);
            internetPage.OpenHomePage();
            internetPage.GoToPage("download");
            var fileDownload = new FileDownloadPage(this.DriverContext);
            Verify.That(
                this.DriverContext,
                () => Assert.AreEqual("File Downloader", fileDownload.GetHeader()));
            fileDownload.SaveFile("file-uploaded.txt", "file-uploaded-downloaded.txt");
            fileDownload.DeleteFile("file-uploaded-downloaded.txt");
        }
    }
}