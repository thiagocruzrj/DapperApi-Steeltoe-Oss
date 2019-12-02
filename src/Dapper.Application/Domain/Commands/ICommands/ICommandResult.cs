namespace Dapper.Api.Domain.Commands.ICommands
{
    public interface ICommandResult
    {
         bool Success { get; set; }
         string Message { get; set; }
         object Data { get; set; }
    }
}