using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record Session(List<IScene> Scenes) : ISession;