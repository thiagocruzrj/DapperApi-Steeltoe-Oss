using Dapper.Api.Domain.Commands.CustomerCommands.Input;
using Dapper.Api.Domain.Commands.CustomerCommands.Output;
using Dapper.Api.Domain.Commands.ICommands;
using Dapper.Api.Domain.Entities;
using Dapper.Api.Domain.Repository;
using Dapper.Api.Domain.Services;
using Dapper.Api.Domain.ValueObjects;
using FluentValidator;

namespace Dapper.Api.Domain.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verify if CPF exist on DB
            if(_repository.CheckDocument(command.Document))
            AddNotification("Document", "This CPF is already in use");

            // Verify if Email exist on DB
            if(_repository.CheckEmail(command.Email))
            AddNotification("Email", "This Email is already in use");

            // Create VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Create Entities
            var customer = new Customer(name, document, email, command.Phone);

            // Validating Entities and VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid) return new CreateCustomerCommandResult(false, "Please, correcty the fields below ", Notifications);
            
            // Persist the customer on DB
            _repository.Save(customer);

            // Send welcome email
            _emailService.Send(email.Address, "thagocruz@gmail.com", "Welcome", "Test email");

            // Return result to screen
            return new CreateCustomerCommandResult(true, "Welcome To Dapper Store", new{
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}