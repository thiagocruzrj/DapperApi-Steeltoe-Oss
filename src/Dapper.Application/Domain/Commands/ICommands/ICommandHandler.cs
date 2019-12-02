namespace Dapper.Api.Domain.Commands.ICommands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         ICommandResult Handle(T command);
    }
}