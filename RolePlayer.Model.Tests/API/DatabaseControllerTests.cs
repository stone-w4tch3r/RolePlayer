using Moq;
using RolePlayer.Model.API;
using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Tests.API;

public class DatabaseControllerTests
{
    private FileInfo GetAndCreateTestFileInfo()
    {
        var testFilesDirectoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory())
            .CreateSubdirectory("TestFiles");
        var fileInfo =  new FileInfo(Path.Combine(testFilesDirectoryInfo.FullName, "dbControllerTestFile"));
        File.WriteAllText(fileInfo.FullName, "");
        return fileInfo;
    }

    [Test]
    public async Task InitializeAsync_FileNotExists_CallsWriteObjectOfFileWorker()
    {
        var fileInfo = new FileInfo("");
        var mockFileWorker = new Mock<IFileWorker>(MockBehavior.Strict);
        mockFileWorker.Setup(x => x.WriteObjectToJsonFileAsync(It.IsAny<IDatabase>(), It.IsAny<FileInfo>()));
        
        _ = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);
        
        mockFileWorker.VerifyAll();
    }

    [Test]
    public async Task InitializeAsync_FileNotExists_PassesFileInfoToFileWorker()
    {
        var fileInfo = new FileInfo("");
        var mockFileWorker = new Mock<IFileWorker>(MockBehavior.Strict);
        mockFileWorker.Setup(x => x.WriteObjectToJsonFileAsync(It.IsAny<IDatabase>(), fileInfo));

        _ = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);

        mockFileWorker.VerifyAll();
    }

    [Test]
    public async Task InitializeAsync_FileNotExists_ReturnsEmpty()
    {
        var fileInfo = new FileInfo("");
        var mockFileWorker = new Mock<IFileWorker>(MockBehavior.Strict);
        mockFileWorker.Setup(x => x.WriteObjectToJsonFileAsync(It.IsAny<IDatabase>(), It.IsAny<FileInfo>()));

        var dbController = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);

        Assert.Multiple(() =>
        {
            Assert.That(dbController.GetAllStories(), Is.Empty);
            Assert.That(dbController.GetAllTracks(), Is.Empty);
        });
        mockFileWorker.VerifyAll();
    }

    [Test]
    public async Task InitializeAsync_FileExists_CallsReadObjectFromJsonFileAsync()
    {
        var fileInfo = GetAndCreateTestFileInfo();
        var mockFileWorker = new Mock<IFileWorker>(MockBehavior.Strict);
        mockFileWorker.Setup(x => x.ReadObjectFromJsonFileAsync<IDatabase>(It.IsAny<FileInfo>()));

        _ = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);

        mockFileWorker.VerifyAll();
    }

    [Test]
    public async Task InitializeAsync_FileExists_ExposesReadDataInGetMethods()
    {
        var fileInfo = GetAndCreateTestFileInfo();
        var mockDb = new Mock<IDatabase>(MockBehavior.Strict);
        mockDb.Setup(x => x.Stories);
        mockDb.Setup(x => x.Tracks);
        var mockFileWorker = new Mock<IFileWorker>(MockBehavior.Strict);
        mockFileWorker.Setup(x => x.ReadObjectFromJsonFileAsync<IDatabase>(It.IsAny<FileInfo>()))
            .Returns(Task.FromResult(mockDb.Object));

        _ = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);

        mockFileWorker.VerifyAll();
        mockDb.VerifyAll();
    }
}