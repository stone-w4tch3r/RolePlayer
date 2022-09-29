using Moq;
using RolePlayer.Model.Core.Infrastructure.Classes;
// ReSharper disable UseObjectOrCollectionInitializer

namespace RolePlayer.Model.Tests.Core.Infrastructure;

internal class OnChangeActingWrapperTests
{
    [Test]
    public void ValueGetter_ContainsInitialValue()
    {
        var value = new object();
        
        var wrapper = new OnChangeActingWrapper<object, object>(value, (_, _) => {}, default!);

        Assert.That(wrapper.Value, Is.SameAs(value));
    }
    
    [Test]
    public void ValueSetter_OverwritesValue()
    {
        var value = new object();
        var wrapper = new OnChangeActingWrapper<object, object>(value, (_, _) => {}, default!);

        wrapper.Value = new object();
        
        Assert.That(wrapper.Value, Is.Not.SameAs(value));
    }
    
    [Test]
    public void Constructor_InvokesDelegate()
    {
        var value = new object();
        var handlerMock = new Mock<Action<object, object>>();
        _ = new OnChangeActingWrapper<object, object>(value, handlerMock.Object, default!);

        handlerMock.Verify(x => x(It.IsAny<object>(), It.IsAny<object>()), Times.Once);
    }
    
    [Test]
    public void ValueSetter_InvokesDelegate()
    {
        var value = new object();
        var handlerMock = new Mock<Action<object, object>>();
        var wrapper = new OnChangeActingWrapper<object, object>(value, handlerMock.Object, default!);

        wrapper.Value = default!;
        
        handlerMock.Verify(x => x(It.IsAny<object>(), It.IsAny<object>()), Times.Exactly(2));
    }

    [Test]
    public void DelegateInvocation_ArgumentPassed()
    {
        var value = new object();
        var argument = new object();
        var handlerMock = new Mock<Action<object, object>>();
        _ = new OnChangeActingWrapper<object, object>(value, handlerMock.Object, argument);
        
        handlerMock.Verify(x => x(It.IsAny<object>(), argument), Times.Once);
    }
    
    [Test]
    public void DelegateInvocation_ValuePassed()
    {
        var value = new object();
        var argument = new object();
        var handlerMock = new Mock<Action<object, object>>();
        _ = new OnChangeActingWrapper<object, object>(value, handlerMock.Object, argument);
        
        handlerMock.Verify(x => x(value, It.IsAny<object>()), Times.Once);
    }
}