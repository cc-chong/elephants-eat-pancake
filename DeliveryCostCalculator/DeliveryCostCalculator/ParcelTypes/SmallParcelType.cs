namespace DeliveryCostCalculator.ParcelTypes
{
    public sealed class SmallParcelType : ParcelType
    {
        public override string Name => "Small parcel";

        public override decimal DimensionLimit => 10.0m;

        public override decimal Price => 3.0m;
    }
}
