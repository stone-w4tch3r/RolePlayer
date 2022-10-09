using Moq;
using RolePlayer.Model.API;
using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Tests.API;

public class DatabaseControllerTests
{
    private static FileInfo CreateAndGetTestFileInfo()
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
        var mockFileWorker = new Mock<IFileWorker>();
        
        _ = await DatabaseController.InitializeAsync(new FileInfo("foo"), mockFileWorker.Object);
        
        mockFileWorker.Verify(x => x.WriteObjectToJsonFileAsync(It.IsAny<IDatabase>(), It.IsAny<FileInfo>()));
    }

    [Test]
    public async Task InitializeAsync_FileNotExists_PassesFileInfoToFileWorker()
    {
        var fileInfo = new FileInfo("foo");
        var mockFileWorker = new Mock<IFileWorker>();

        _ = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);

        mockFileWorker.Verify(x => x.WriteObjectToJsonFileAsync(It.IsAny<IDatabase>(), fileInfo));
    }

    [Test]
    public async Task InitializeAsync_FileNotExists_ReturnsEmpty()
    {
        var mockFileWorker = new Mock<IFileWorker>();

        var dbController = await DatabaseController.InitializeAsync(new FileInfo("foo"), mockFileWorker.Object);

        Assert.Multiple(() =>
        {
            Assert.That(dbController.GetAllStories(), Is.Empty);
            Assert.That(dbController.GetAllTracks(), Is.Empty);
        });
    }

    [Test]
    public async Task InitializeAsync_FileExists_CallsReadObjectFromJsonFileAsync()
    {
        var fileInfo = CreateAndGetTestFileInfo();
        var mockFileWorker = new Mock<IFileWorker>();

        _ = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);

        mockFileWorker.Verify(x => x.ReadObjectFromJsonFileAsync<IDatabase>(It.IsAny<FileInfo>()));
    }

    [Test]
    public async Task InitializeAsync_FileExists_ExposesReadDataInGetMethods()
    {
        var stories = Enumerable.Empty<IStory>();
        var tracks = Enumerable.Empty<ITrack>();
        var mockDb = new Mock<IDatabase>();
        mockDb.Setup(x => x.Stories).Returns(stories);
        mockDb.Setup(x => x.Tracks).Returns(tracks);
        var mockFileWorker = new Mock<IFileWorker>();
        mockFileWorker.Setup(x => x.ReadObjectFromJsonFileAsync<IDatabase>(It.IsAny<FileInfo>()))
            .Returns(Task.FromResult(mockDb.Object));
        var dbController = await DatabaseController.InitializeAsync(new FileInfo("foo"), mockFileWorker.Object);
        
        Assert.Multiple(() =>
        {
            Assert.That(dbController.GetAllStories(), Is.SameAs(stories));
            Assert.That(dbController.GetAllTracks(), Is.SameAs(tracks));
        });
    }

    [Test]
    public async Task AddStoryAsync_InvokesFileWorker()
    {
        var fileInfo = new FileInfo("foo");
        var mockFileWorker = new Mock<IFileWorker>();
        var dbController = await DatabaseController.InitializeAsync(fileInfo, mockFileWorker.Object);
        
        dbController.AddStoryAsync(Mock.Of<IStory>());
        
        mockFileWorker.Verify(x => 
            x.WriteObjectToJsonFileAsync(It.IsAny<object>(), fileInfo), Times.Exactly(2));
    }
    
    [Test]
    public async Task AddTracksAsync_InvokesFileWorker()
    {
        var mockFileWorker = new Mock<IFileWorker>();
        var dbController = await DatabaseController.InitializeAsync(new FileInfo("foo"), mockFileWorker.Object);
        
        dbController.AddTracksAsync(Enumerable.Empty<ITrack>());
        
        mockFileWorker.Verify(x => 
            x.WriteObjectToJsonFileAsync(It.IsAny<object>(), It.IsAny<FileInfo>()), Times.Exactly(2));
    }
    
    [Test]
    public async Task RemoveStoryAsync_InvokesFileWorker()
    {
        var mockFileWorker = new Mock<IFileWorker>();
        var dbController = await DatabaseController.InitializeAsync(new FileInfo("foo"), mockFileWorker.Object);
        
        dbController.RemoveStoryAsync(Mock.Of<IStory>());
        
        mockFileWorker.Verify(x => 
            x.WriteObjectToJsonFileAsync(It.IsAny<object>(), It.IsAny<FileInfo>()), Times.Exactly(2));
    }
    
    [Test]
    public async Task RemoveTracksAsync_InvokesFileWorker()
    {
        var mockFileWorker = new Mock<IFileWorker>();
        var dbController = await DatabaseController.InitializeAsync(new FileInfo("foo"), mockFileWorker.Object);
        
        dbController.RemoveTracksAsync(Enumerable.Empty<ITrack>());
        
        mockFileWorker.Verify(x => 
            x.WriteObjectToJsonFileAsync(It.IsAny<object>(), It.IsAny<FileInfo>()), Times.Exactly(2));
    }
}