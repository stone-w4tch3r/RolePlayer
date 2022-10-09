using RolePlayer.Essentials.Interfaces;

namespace RolePlayer.Essentials.Classes;

public class OnChangeActingWrapper<TValue, TArgument> : IWrapper<TValue>
{
    private TValue _value;
    private readonly TArgument? _argument;
    private readonly Action<TValue, TArgument?>? _onChangeHandler;
    public TValue Value
    {
        get => _value;
        set 
        {
            _value = value;
            _onChangeHandler?.Invoke(_value, _argument);
        }
    }
    public OnChangeActingWrapper(TValue value, Action<TValue, TArgument?>? onChangeHandler = null, TArgument? argument = default)
    {
        _value = value;
        _onChangeHandler = onChangeHandler;
        _argument = argument;
        _onChangeHandler?.Invoke(_value, _argument);
    }
}