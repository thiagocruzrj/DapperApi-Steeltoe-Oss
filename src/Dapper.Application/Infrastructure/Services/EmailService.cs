using Dapper.Api.Domain.Services;

namespace Dapper.Api.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            // TODO: Implement
        }
    }
}