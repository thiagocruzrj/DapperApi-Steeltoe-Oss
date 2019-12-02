using System;
using FluentValidator;

namespace Dapper.Api.Domain.Entities.Base {
    public class Entity : Notifiable {

        protected Entity () 
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}