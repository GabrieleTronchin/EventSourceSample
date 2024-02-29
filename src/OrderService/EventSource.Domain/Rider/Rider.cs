﻿namespace EventSource.Domain.Rider
{

    public class RiderEntity
    {
        private RiderEntity()
        {
        }

        public static RiderEntity Create(Guid orderId, Location location)
        {
            return new RiderEntity()
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                StartLocation = location
            };
        }
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public Location StartLocation { get; set; }

    }
}
