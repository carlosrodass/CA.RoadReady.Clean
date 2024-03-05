using CA.RoadReady.Domain.Shared;
using CA.RoadReady.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Rentings
{
    public class PriceService
    {

        public PriceDetail CalculatePrice(Vehicle vehicle, DateRange duration)
        {
            var currencyType = vehicle.Price!.CurrencyType;

            var pricePerTimeSpan = new Coin(duration.TotalDays * vehicle.Price.Amount, currencyType);

            decimal porcentageChange = 0;

            foreach (var accesory in vehicle.Accesories)
            {
                porcentageChange += accesory switch
                {
                    Accesories.AppleCar or Accesories.AndroidCar => 0.05m,
                    Accesories.AC => 0.01m,
                    Accesories.Maps => 0.01m,
                    _ => 0
                };
            }

            var accesoriesCharges = Coin.Zero(currencyType);

            if (porcentageChange > 0)
            {

                accesoriesCharges = new Coin(pricePerTimeSpan.Amount * porcentageChange, currencyType);
            }

            var totalPrice = Coin.Zero();
            totalPrice += pricePerTimeSpan;

            if (!vehicle.Maintenance!.IsZero)
            {
                totalPrice += vehicle.Maintenance;
            }

            totalPrice += accesoriesCharges;


            return new PriceDetail(pricePerTimeSpan,
                                   vehicle.Maintenance,
                                   accesoriesCharges,
                                   totalPrice);

        }

    }
}
