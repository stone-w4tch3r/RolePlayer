namespace RolePlayer.Model.API.Interfaces;

public interface IFileWorker
{
    public void WriteObjectToJsonFile<T>(T obj, FileInfo fileInfo);
}