namespace RolePlayer.Model.Core.Interfaces;

internal interface IWrapper<T>
{
    public T Value { get; set; }
}