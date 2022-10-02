using RolePlayer.Model.Core.Infrastructure.Classes;
using System.Text.Json;

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
    public void SetUp() => _testFileInfo.Delete();

    [Test]
    public void WriteObjectToJsonFileAsync_CreatesFile()
    {
        var fileWorker = new FileWorker();
        var obj = new object();
        
        fileWorker.WriteObjectToJsonFileAsync(obj, _testFileInfo);
        
        Assert.That(_testFileInfo.RefreshImmediately().Exists);
    }
    
    [Test]
    public async Task ReadObjectFromJsonFileAsync_FileDeserialized()
    {
        var fileWorker = new FileWorker();
        var obj = new List<string>() { "str" };
        await using (var stream = File.Create(_testFileInfo.FullName))
        {
            await JsonSerializer.SerializeAsync(stream, obj).ConfigureAwait(false);
        }

        var result = await fileWorker.ReadObjectFromJsonFileAsync<List<string>>(_testFileInfo);
        
        Assert.That(result, Is.EqualTo(obj));
    }
}