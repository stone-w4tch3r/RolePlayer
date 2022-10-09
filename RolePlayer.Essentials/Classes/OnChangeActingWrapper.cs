using RolePlayer.Essentials.Interfaces;

namespace RolePlayer.Essentials.Classes;

public class OnChangeActingWrapper<TValue, TArgument> : IWrapper<TValue>
{
    private TValue _value;
    private readonly Action<TValue, TArgument> _onChangeHandler;
    private readonly TArgument _argument;
    public TValue Value
    {
        get => _value;
        set 
        {
            _value = value;
            _onChangeHandler(_value, _argument);
        }
    }
    public OnChangeActingWrapper(TValue value, Action<TValue, TArgument> onChangeHandler, TArgument argument)
    {
        _value = value;
        _onChangeHandler = onChangeHandler;
        _argument = argument;
        _onChangeHandler(_value, _argument);
    }
}