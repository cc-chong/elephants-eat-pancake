namespace DeliveryCostCalculator.Models
{
    public class ParcelCost
    {
        public Parcel Parcel { get; set; }

        public string ParcelType { get; set; }

        public decimal Cost { get; set; }
    }
}