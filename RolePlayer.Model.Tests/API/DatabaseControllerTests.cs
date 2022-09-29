using Moq;
using RolePlayer.Model.API;
using RolePlayer.Model.API.Interfaces;
using RolePlayer.Model.Core.Infrastructure.Classes;

namespace RolePlayer.Model.Tests.API;

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

    [SetUp]
    public void Setup() => _testFileInfo.Delete();

    [Test]
    public async Task InitializeAsync_FileNotExists_ReturnsEmpty()
    {
        var fileWorkerMock = new Mock<IFileWorker>(MockBehavior.Strict);
        fileWorkerMock.Setup(x => 
            x.WriteObjectToJsonFile(It.IsAny<IDatabase>(), It.IsAny<FileInfo>()));
        
        var databaseController = await DatabaseController.InitializeAsync(_testFileInfo, fileWorkerMock.Object);
        
        Assert.That(databaseController.GetAllStories(), Is.Empty);
        Assert.That(databaseController.GetAllTracks(), Is.Empty);
        fileWorkerMock.VerifyAll();
    }
    
    [Test]
    public async Task InitializeAsync_FileNotExists_WritesFile()
    {
        _ = await DatabaseController.InitializeAsync(_testFileInfo, new FileWorker());
        
        Assert.That(_testFileInfo.RefreshImmediately().Exists);
    }
}