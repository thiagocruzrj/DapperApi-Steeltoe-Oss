using System.Collections.Generic;

namespace Dapper.Api.Domain.Entities {
    public class Request {
        public Request (string from, string subject, string message, int type) {
            this.From = from;
            this.Subject = subject;
            this.Message = message;
            this.Type = type;

        }
        public string From { get; private set; }
        public List<string> To { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
        public int Type { get; private set; }
    }
}