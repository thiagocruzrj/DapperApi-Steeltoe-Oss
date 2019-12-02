using System;
using System.Collections.Generic;
using Dapper.Api.Domain.Entities;
using Dapper.Api.Domain.Queries;

namespace Dapper.Api.Domain.Repository
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);
         void Save(Customer customer);
         CustomerOrdersCountResult GetCustomerOrdersCount(string document);
         IEnumerable<ListCustomerQueryResult> GetList();
         GetCustomerQueryResult GetById(Guid id);
         IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id);
    }
}