namespace Dapper.Api.Domain.Services
{
    public interface IEmailService
    {
         void Send(string to, string from, string subject, string body);
    }
}