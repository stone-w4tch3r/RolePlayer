using System.Windows.Input;

namespace RolePlayer.ViewModel;

public interface IExtendedCommand : ICommand
{
    public void Execute();
    
    public bool CanExecute();
}

public interface IExtendedCommand<T> : ICommand
{
    public void Execute(T parameter);
    
    public bool CanExecute(T parameter);
}