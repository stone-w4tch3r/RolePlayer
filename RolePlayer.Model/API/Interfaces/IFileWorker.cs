namespace RolePlayer.Model.API.Interfaces;

public interface IFileWorker
{
    public void WriteObjectToJsonFileAsync<T>(T obj, FileInfo fileInfo);
    public Task<T> ReadObjectFromJsonFileAsync<T>(FileInfo fileInfo);
}