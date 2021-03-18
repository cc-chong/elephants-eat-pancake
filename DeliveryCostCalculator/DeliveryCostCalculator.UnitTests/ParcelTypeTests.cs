using DeliveryCostCalculator.Models;
using DeliveryCostCalculator.ParcelTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace DeliveryCostCalculator.UnitTests
{
    [TestClass]
    public class ParcelTypeTests
    {
        [TestMethod]
        public void ExtraLargeParcelType_FitParcelType_WhenSizeFitsParcelType_ReturnTrue()
        {
            // Arrange
            var parcels = new List<Parcel>()
            {
                new Parcel() { Height = 100.1m },
                new Parcel() { Length = 100.1m },
                new Parcel() { Width = 100.1m }
            };
            var extraLargeParcelType = new ExtraLargeParcelType();

            // Act & Assert
            parcels.Select(x => extraLargeParcelType.FitParcelType(x).Should().BeTrue());
        }

        [TestMethod]
        public void ExtraLargeParcelType_FitParcelType_WhenSizeFitsParcelType_ReturnFalse()
        {
            // Arrange
            var parcels = new List<Parcel>()
            {
                new Parcel() { Height = 99.9m },
                new Parcel() { Length = 99.9m },
                new Parcel() { Width = 99.9m }
            };
            var extraLargeParcelType = new ExtraLargeParcelType();

            // Act & Assert
            parcels.Select(x => extraLargeParcelType.FitParcelType(x).Should().BeFalse());
        }
    }
}
