using RolePlayerCore.Interfaces;

namespace RolePlayerCore;

internal class DatabaseController : IDatabaseController
{
    IDatabase IDatabaseController.Database => throw new NotImplementedException();
}
