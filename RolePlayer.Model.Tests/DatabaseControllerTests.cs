using Moq;
using RolePlayer.Model.API;
using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Tests;

public class DatabaseControllerTests
{
    private const string TestDbFileName = "testDb.json";
    private readonly FileInfo _testFileInfo;

    public DatabaseControllerTests()
    {
        var testFilesDirectoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory())
            .CreateSubdirectory("TestFiles");
        _testFileInfo = new FileInfo(Path.Combine(testFilesDirectoryInfo.FullName, TestDbFileName));
    }

    //[TearDown]
    public void AfterEachTest()
    {
        if (_testFileInfo.Exists)
            _testFileInfo.Delete();
    }

    [Test]
    public async Task InitializeAsync_FileNotExists_ReturnsEmpty()
    {
        var fileWorkerMock = new Mock<IFileWorker>(MockBehavior.Strict);
        fileWorkerMock.Setup(x => 
            x.WriteObjectToJsonFile(It.IsAny<IDatabase>(), It.IsAny<FileInfo>()));
        var databaseController = await DatabaseController.InitializeAsync(_testFileInfo, fileWorkerMock.Object);
        //Assert.IsEmpty(databaseController.GetAllStories());
        //Assert.IsEmpty(databaseController.GetAllTracks());
        fileWorkerMock.VerifyAll();
    }
}