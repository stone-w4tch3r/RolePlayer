using System.ComponentModel;
using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.ViewModel;

public class FileManagerViewModel
{
    public IEnumerable<IStory> Stories { get; set; }
}