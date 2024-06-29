using MediatR;

namespace Investing.Application.Interfaces.Commands
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>, IRequest<TResult> where TResult : ICommandResult
    {
    }
}
