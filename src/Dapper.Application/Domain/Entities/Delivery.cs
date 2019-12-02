using System;
using Dapper.Api.Domain.Entities.Base;
using Dapper.Api.Domain.Enums;

namespace Dapper.Api.Domain.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // If estimated date is in the past, doesnt ship
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            // If Status = delivery, we cant cancel
            Status = EDeliveryStatus.Canceled;
        }
    }
}