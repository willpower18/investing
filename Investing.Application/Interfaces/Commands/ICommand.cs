using MediatR;

namespace Investing.Application.Interfaces.Commands
{
    public interface ICommand<ICommandResult> : IRequest<ICommandResult>
    {
    }
}
