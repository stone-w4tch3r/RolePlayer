namespace RolePlayer.ViewModel;

public class ExtendedCommand : IExtendedCommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;
    public event EventHandler? CanExecuteChanged;
    
    public ExtendedCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    public bool CanExecute(object? _) => _canExecute?.Invoke() ?? true;
    public void Execute(object? _) => _execute();
    public void Execute() => Execute(null);
    public bool CanExecute() => CanExecute(null);
}

public class ExtendedCommand<T> : IExtendedCommand<T>
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool>? _canExecute;
    public event EventHandler? CanExecuteChanged;
    
    public ExtendedCommand(Action<T> execute, Func<T, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    public bool CanExecute(object? parameter) => _canExecute?.Invoke((T)parameter!) ?? true;
    public void Execute(object? parameter) => _execute((T)parameter!);
    public void Execute(T parameter) => Execute(parameter as object);
    public bool CanExecute(T parameter) => CanExecute(parameter as object);
}