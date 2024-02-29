namespace EventSource.Domain.Rider
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
                OrderId = orderId,
                CurrentLocation = location
            };
        }

        public Guid OrderId { get; set; }
        public Location CurrentLocation { get; set; }

    }
}
