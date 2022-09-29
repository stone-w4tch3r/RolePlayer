using RolePlayer.Model.Core.Infrastructure.Classes;

namespace RolePlayer.Model.Tests.Core.Infrastructure;

internal class FileWorkerTests
{
    private const string TestFileName = "FileWorkerTestFile";
    private readonly FileInfo _testFileInfo;

    public FileWorkerTests()
    {
        var testFilesDirectoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory())
            .CreateSubdirectory("TestFiles");
        _testFileInfo = new FileInfo(Path.Combine(testFilesDirectoryInfo.FullName, TestFileName));
    }

    [SetUp]
    public void SetUp()
    {
        _testFileInfo.Delete();
    }

    [Test]
    public void WriteObjectToJsonFile_CreatesFile()
    {
        var fileWorker = new FileWorker();
        var obj = new object();
        
        fileWorker.WriteObjectToJsonFile(obj, _testFileInfo);
        
        Assert.That(_testFileInfo.RefreshImmediately().Exists);
    }
    
    [Test]
    public async Task WriteObjectToJsonFile_FileDeserialized()
    {
        var fileWorker = new FileWorker();
        var obj = new List<string>() { "str" };
        fileWorker.WriteObjectToJsonFile(obj, _testFileInfo);
        
        var result = await fileWorker.ReadObjectFromJsonFile<List<string>>(_testFileInfo);
        
        Assert.That(result, Is.EqualTo(obj));
    }
}