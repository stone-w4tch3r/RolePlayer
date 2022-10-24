using System.ComponentModel;
using System.Windows.Input;
using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.ViewModel;

public class FileManagerViewModel : BaseViewModel
{
    private IEnumerable<IStory> _stories;
    public IEnumerable<IStory> Stories
    {
        get => _stories;
        set => SetField(ref _stories, value);
    }
    public ICommand AddStoriesCommand { get; }
    internal FileManagerViewModel(IEnumerable<IStory> stories)
    {
        _stories = stories;
        AddStoriesCommand = new Command(AddStories);
    }
    private void AddStories()
    {
        
    }
}