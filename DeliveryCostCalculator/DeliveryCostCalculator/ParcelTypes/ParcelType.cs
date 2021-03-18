using DeliveryCostCalculator.Models;

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

        public virtual bool FitParcelType(Parcel parcel)
        {
            return parcel.Length < DimensionLimit && parcel.Width < DimensionLimit && parcel.Height < DimensionLimit;
        }
    }
}
