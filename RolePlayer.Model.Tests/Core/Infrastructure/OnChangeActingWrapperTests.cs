using RolePlayer.Model.API.Interfaces;
using RolePlayer.Model.Core.Infrastructure.Classes;

namespace RolePlayer.Model.Tests.Core.Infrastructure;

public class OnChangeActingWrapperTests
{
    [Test]
    public void Test()
    {
        var wrapper = new OnChangeActingWrapper<IDatabase, FileInfo>();
    }
}