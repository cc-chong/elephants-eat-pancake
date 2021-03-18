namespace DeliveryCostCalculator.ParcelTypes
{
    public sealed class MediumParcelType : ParcelType
    {
        public override string Name => "Medium parcel";

        public override decimal DimensionLimit => 50.0m;

        public override decimal Price => 8.0m;

        public override decimal WeightLimit => 3.0m;

    }
}
