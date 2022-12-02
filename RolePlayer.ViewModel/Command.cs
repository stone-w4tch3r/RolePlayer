using System.Windows.Input;

namespace RolePlayer.ViewModel;

public class Command : ICommand
{
    private readonly Action _action;
    public event EventHandler? CanExecuteChanged;
    public Command(Action action)   
        _action = action;
    }
    public bool CanExecute(object? parameter) => throw new NotImplementedException();
    public void Execute(object? parameter) => _action();
}