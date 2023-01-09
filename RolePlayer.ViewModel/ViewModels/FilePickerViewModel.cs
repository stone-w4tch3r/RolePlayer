using RolePlayer.ViewModel.Infrastructure;

namespace RolePlayer.ViewModel.ViewModels;

public class FilePickerViewModel : BaseViewModel
{
    public FilePickerViewModel(Action<IEnumerable<FileInfo>> closeAction)
    {
        CloseCommand = new ExtendedCommand<IEnumerable<FileInfo>>(closeAction);
    }

    public IExtendedCommand<IEnumerable<FileInfo>> CloseCommand { get; }
}