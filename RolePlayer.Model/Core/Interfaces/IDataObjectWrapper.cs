namespace RolePlayer.Model.Core.Interfaces;

internal interface IDataObjectWrapper<T>
{
    public T GetValue();
    public void SetValue(T obj);
}

class OnChangeActingObjectWrapper<T> : IDataObjectWrapper<T>
{
    private T _obj;
    public OnValueChangedEventHandler 
    private readonly EventHandler _onChangeHandler;
    public OnChangeActingObjectWrapper(T obj, EventHandler onChangeHandler)
    {
        _obj = obj;
        _onChangeHandler = onChangeHandler;
    }
    public T GetValue() => _obj;
    public void SetValue(T obj)
    {
        _obj = obj;
        _onChangeHandler(this, new EventArgs(obj));
    }
}