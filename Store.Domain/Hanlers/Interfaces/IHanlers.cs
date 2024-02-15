using Store.Domain.Commands.Interfaces;

namespace Store.Tests.Hanlers.Interfaces
{
    public interface IHanlers<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
