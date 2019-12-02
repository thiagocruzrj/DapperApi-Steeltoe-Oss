using FluentValidator;
using FluentValidator.Validation;

namespace Dapper.Api.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Name must be have 3 characters at minimum.")
                .HasMaxLen(FirstName, 40, "FirstName", "Name must be have 40 characters at maximum.")
                .HasMaxLen(LastName, 3, "LastName", "Surname must be have 3 characters at minimum.")
                .HasMinLen(LastName, 40, "LastName", "Surname must be have 40 characters at minimum."));
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}