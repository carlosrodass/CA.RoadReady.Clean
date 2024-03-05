using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Shared;


namespace CA.RoadReady.Domain.Vehicles
{
    public sealed class Vehicle : Entity
    {
        public Model? Model { get; private set; }
        public Vin? Vin { get; private set; }
        public Direction? Direction { get; private set; }
        public Coin? Price { get; private set; }
        public Coin? Maintenance { get; private set; }
        public DateTime? LastRentDate { get; internal set; }
        public List<Accesories> Accesories { get; private set; } = new();


        private Vehicle(Guid id,
                        Model model,
                        Vin vin,
                        Coin price,
                        Coin maintenance,
                        DateTime? lastRentDate,
                        Direction direction) : base(id)

        {
            Model = model;
            Vin = vin;
            Price = price;
            Maintenance = maintenance;
            LastRentDate = lastRentDate;
            Direction = direction;
        }

        public static Vehicle Create(Model model,
                                     Vin vin,
                                     Coin price,
                                     Coin maintenance,
                                     DateTime? lastRentDate,
                                     Direction direction)
        {
            return new Vehicle(Guid.NewGuid(), model, vin, price, maintenance, lastRentDate, direction);
        }




    }
}
