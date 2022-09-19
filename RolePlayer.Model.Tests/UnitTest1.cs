using RolePlayer.Model.API;

namespace RolePlayer.Model.Tests;

public class DatabaseControllerTests
{
    private const string _testDbFileName = "testDb.json";
    private readonly DirectoryInfo _testFilesDirectoryInfo;

    public DatabaseControllerTests()
    {
        _testFilesDirectoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory())
            .CreateSubdirectory("TestFiles");
    }

    [Test]
    public void Test1()
    {
        File.Create(_testFilesDirectoryInfo.FullName + _testDbFileName);
        var fileInfo = _testFilesDirectoryInfo.EnumerateFiles().First(f => f.Name == _testDbFileName);
        var databaseController = DatabaseController.InitializeAsync(fileInfo);
    }
}