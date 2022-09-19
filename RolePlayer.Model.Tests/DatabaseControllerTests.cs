using RolePlayer.Model.API;

namespace RolePlayer.Model.Tests;

public class DatabaseControllerTests
{
    private const string _testDbFileName = "testDb.json";
    private readonly DirectoryInfo _testFilesDirectoryInfo;
    private readonly FileInfo _testFileInfo;

    public DatabaseControllerTests()
    {
        _testFilesDirectoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory())
            .CreateSubdirectory("TestFiles");
        _testFileInfo = new FileInfo(Path.Combine(_testFilesDirectoryInfo.FullName, _testDbFileName));
    }

    //TearDown]
    public void AfterEachTest()
    {
        if (_testFileInfo.Exists)
            _testFileInfo.Delete();
    }

    [Test]
    public async Task InitializeAsync_FileNotExists_ReturnsEmpty()
    {
        var databaseController = await DatabaseController.InitializeAsync(_testFileInfo);
        Assert.IsEmpty(databaseController.GetAllStories());
        Assert.IsEmpty(databaseController.GetAllTracks());
    }
}