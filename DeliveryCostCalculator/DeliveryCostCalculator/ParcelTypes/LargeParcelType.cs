namespace DeliveryCostCalculator.ParcelTypes
{
    public sealed class LargeParcelType : ParcelType
    {
        public override string Name => "Large parcel";

        public override decimal DimensionLimit => 100.0m;

        public override decimal Price => 15.0m;
    }
}
