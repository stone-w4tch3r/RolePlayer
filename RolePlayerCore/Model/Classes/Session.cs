using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Model.Classes;

internal record Session(List<IScene> Scenes) : ISession;