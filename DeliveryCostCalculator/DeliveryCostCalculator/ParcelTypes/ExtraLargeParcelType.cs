using DeliveryCostCalculator.Models;

namespace DeliveryCostCalculator.ParcelTypes
{
    public sealed class ExtraLargeParcelType : ParcelType
    {
        public override string Name => "XL parcel";

        public override decimal DimensionLimit => 100.0m;

        public override decimal Price => 25.0m;

        public override decimal WeightLimit => 10.0m;


        public override bool FitParcelType(Parcel parcel)
        {
            return parcel.Length >= DimensionLimit || parcel.Width >= DimensionLimit || parcel.Height >= DimensionLimit;
        }
    }
}
