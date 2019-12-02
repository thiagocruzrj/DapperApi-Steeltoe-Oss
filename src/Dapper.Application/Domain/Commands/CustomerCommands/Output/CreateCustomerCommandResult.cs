using Dapper.Api.Domain.Commands.ICommands;

namespace Dapper.Api.Domain.Commands.CustomerCommands.Output
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get ; set ; }
        public string Message { get ; set ; }
        public object Data { get ; set ; }
    }
}