using System;
using Dapper.Api.Domain.Commands.ICommands;
using Dapper.Api.Domain.Enums;
using FluentValidator;

namespace Dapper.Api.Domain.Commands.CustomerCommands.Input
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        public bool Valid()
        {
            return IsValid;
        }
    }
}