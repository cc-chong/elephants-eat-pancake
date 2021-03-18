using DeliveryCostCalculator.Models;
using DeliveryCostCalculator.ParcelTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryCostCalculator
{
    public class Calculator
    {
        private readonly List<ParcelType> _parcelLimits;

        public Calculator(List<ParcelType> parcelLimits)
        {
            _parcelLimits = parcelLimits;
        }

        public OrderCost Calculate(List<Parcel> parcels, bool speedyShippingSelected)
        {
            var orderCost = new OrderCost();
            foreach (var parcel in parcels)
            {
                var parcelType = _parcelLimits.Where(type => type.FitParcelType(parcel)).OrderBy(type => type.Price).First();
                var parcelCost = new ParcelCost()
                {
                    Parcel = parcel,
                    ParcelType = parcelType.Name,
                    Cost = parcelType.GetDeliveryCost(parcel)
                };
                orderCost.ParcelCosts.Add(parcelCost);
            }

            decimal subtotal = orderCost.ParcelCosts.Sum(parcel => parcel.Cost);

            orderCost.SpeedyShippingFee = speedyShippingSelected ? subtotal : 0.0m;
            orderCost.TotalCost = subtotal + orderCost.SpeedyShippingFee;
            
            return orderCost;
        }
    }
}
