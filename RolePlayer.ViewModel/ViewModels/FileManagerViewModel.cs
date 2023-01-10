using RolePlayer.Model.API.Interfaces;
using RolePlayer.ViewModel.Infrastructure;

namespace RolePlayer.ViewModel.ViewModels;

public class FileManagerViewModel : BaseViewModel
{
    private IObservable<IStory> _stories;
    public IObservable<IStory> Stories
    {
        get => _stories;
        set => SetField(ref _stories, value); 
    }
    public IExtendedCommand OpenStoriesFilePickerCommand { get; }
    internal FileManagerViewModel(Action openStoriesFilePickerAction)
    {
        OpenStoriesFilePickerCommand = new ExtendedCommand(openStoriesFilePickerAction);
        // _stories = stories;
    }
}