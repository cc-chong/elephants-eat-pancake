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
        }

        [TestMethod]
        public void Calculator_Calculate_ShouldReturnExpectedOrderCost()
        {
            var expected = new OrderCost()
            {
                ParcelCosts = new List<ParcelCost>
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
                }
                , TotalCost = 153.0m
            };

            var parcels = expected.ParcelCosts.Select(x => x.Parcel).ToList();

            var result = unitUnderTest.Calculate(parcels);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
