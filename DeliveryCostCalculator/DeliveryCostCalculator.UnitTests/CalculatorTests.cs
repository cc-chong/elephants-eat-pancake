using DeliveryCostCalculator.Models;
using DeliveryCostCalculator.ParcelTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryCostCalculator.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator unitUnderTest;
        private List<ParcelCost> _parcelCosts;

        [TestInitialize]
        public void Initialise()
        {
            var parcelTypes = new List<ParcelType>()
            {
                new SmallParcelType(),
                new MediumParcelType(),
                new LargeParcelType(),
                new ExtraLargeParcelType(),
            };

            unitUnderTest = new Calculator(parcelTypes);

            _parcelCosts = new List<ParcelCost>
            {
                    new ParcelCost{ Parcel = new Parcel{ Height = 9.0m}, Cost = 3.0m, ParcelType = "Small parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 9.0m}, Cost = 3.0m, ParcelType = "Small parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 9.0m}, Cost = 3.0m, ParcelType = "Small parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 49.0m}, Cost = 8.0m, ParcelType = "Medium parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 49.0m}, Cost = 8.0m, ParcelType = "Medium parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 49.0m}, Cost = 8.0m, ParcelType = "Medium parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 99.0m}, Cost = 15.0m, ParcelType = "Large parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 99.0m}, Cost = 15.0m, ParcelType = "Large parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 99.0m}, Cost = 15.0m, ParcelType = "Large parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 100.0m}, Cost = 25.0m, ParcelType = "XL parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 100.0m}, Cost = 25.0m, ParcelType = "XL parcel" },
                    new ParcelCost{ Parcel = new Parcel{ Height = 100.0m}, Cost = 25.0m, ParcelType = "XL parcel" },
            };
        }

        [TestMethod]
        public void Calculator_Calculate_WithSpeedyShipping_ShouldReturnExpectedOrderCost()
        {
            var expected = new OrderCost()
            {
                ParcelCosts = _parcelCosts,
                SpeedyShippingFee = 153.0m,
                TotalCost = 306.0m
            };

            var parcels = expected.ParcelCosts.Select(x => x.Parcel).ToList();

            var result = unitUnderTest.Calculate(parcels, true);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Calculator_Calculate_WithoutSpeedyShipping_ShouldReturnExpectedOrderCost()
        {
            var expected = new OrderCost()
            {
                ParcelCosts = _parcelCosts,
                SpeedyShippingFee = 0.0m,
                TotalCost = 153.0m
            };

            var parcels = expected.ParcelCosts.Select(x => x.Parcel).ToList();

            var result = unitUnderTest.Calculate(parcels, false);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
