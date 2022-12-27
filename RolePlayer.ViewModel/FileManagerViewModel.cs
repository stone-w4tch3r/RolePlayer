using System.Windows.Input;
using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.ViewModel;

public class FileManagerViewModel : BaseViewModel
{
    private IObservable<IStory> _stories;
    public IObservable<IStory> Stories
    {
        get => _stories;
        set => SetField(ref _stories, value);
    }
    public IExtendedCommand AddStoriesCommand { get; }
    internal FileManagerViewModel(IObservable<IStory> stories)
    {
        _stories = stories;
        AddStoriesCommand = new ExtendedCommand(AddStories);
    }
    private void AddStories()
    {
        
    }
}