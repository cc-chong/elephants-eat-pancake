using DeliveryCostCalculator.Models;
using System;

namespace DeliveryCostCalculator.ParcelTypes
{
    public abstract class ParcelType
    {
        public abstract string Name { get; }
        /// <summary>
        /// Dimension limit in centimeter.
        /// </summary>
        public abstract decimal DimensionLimit { get; }

        public abstract decimal Price { get; }

        /// <summary>
        /// Weight limit in kilogram.
        /// </summary>
        public abstract decimal WeightLimit { get; }

        public decimal ExtraCostPerKilogram => 2.0m;

        public virtual bool FitParcelType(Parcel parcel)
        {
            return parcel.Length < DimensionLimit && parcel.Width < DimensionLimit && parcel.Height < DimensionLimit;
        }

        public decimal GetDeliveryCost(Parcel parcel)
        {
            var exceedWeightLimit = (parcel.Weight - WeightLimit) > 0 ? Math.Ceiling(parcel.Weight - WeightLimit) : 0;
            return Price + exceedWeightLimit * ExtraCostPerKilogram;
        }
    }
}
