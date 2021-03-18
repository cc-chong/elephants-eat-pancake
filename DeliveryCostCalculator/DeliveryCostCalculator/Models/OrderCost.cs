using System.Collections.Generic;

namespace DeliveryCostCalculator.Models
{
    public class OrderCost
    {
        public OrderCost()
        {
            ParcelCosts = new List<ParcelCost>();
        }

        public List<ParcelCost> ParcelCosts { get; set; }

        public decimal TotalCost { get; set; }
    }
}
