using RolePlayer.Model.Core.Interfaces;

namespace RolePlayer.Model.Core.Classes;

internal class OnChangeActingWrapper<TValue, TArgument> : IWrapper<TValue>
{
    private TValue _obj;
    private readonly OnChangeHandler<TValue, TArgument> _onChangeHandler;
    private readonly TArgument _argument;

    public delegate void OnChangeHandler<in TSender, in TArgs>(TSender sender, TArgs args);
    public TValue Value
    {
        get => GetValue();
        set => SetValue(value);
    }
    public OnChangeActingWrapper(TValue obj, OnChangeHandler<TValue, TArgument> onChangeHandler, TArgument argument)
    {
        _obj = obj;
        _onChangeHandler = onChangeHandler;
        _argument = argument;
        _onChangeHandler(_obj, _argument);
    }
    private TValue GetValue() => _obj;
    private void SetValue(TValue obj)
    {
        _obj = obj;
        _onChangeHandler(_obj, _argument);
    }
}