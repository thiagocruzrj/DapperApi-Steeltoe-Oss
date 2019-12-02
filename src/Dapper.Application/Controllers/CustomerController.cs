using System;
using System.Collections.Generic;
using Dapper.Api.Domain.Commands.CustomerCommands.Input;
using Dapper.Api.Domain.Commands.CustomerCommands.Output;
using Dapper.Api.Domain.Commands.ICommands;
using Dapper.Api.Domain.Entities;
using Dapper.Api.Domain.Handlers;
using Dapper.Api.Domain.Queries;
using Dapper.Api.Domain.Repository;
using Dapper.Api.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        
        [HttpGet]
        [Route("v1/customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.GetList();
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetById(Guid document)
        {
            return _repository.GetById(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetByDocument(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            return new { message = "Customer removed with sucess!"};
        }
    }
}