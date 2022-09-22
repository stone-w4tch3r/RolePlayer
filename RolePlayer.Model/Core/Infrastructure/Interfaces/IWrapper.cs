namespace RolePlayer.Model.Core.Infrastructure.Interfaces;

internal interface IWrapper<T>
{
    public T Value { get; set; }
}