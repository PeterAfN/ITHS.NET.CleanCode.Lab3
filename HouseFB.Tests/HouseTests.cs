using NUnit.Framework;
using System;

namespace HouseFB.Tests
{
    [TestFixture]
    public class HouseTests
    {
        private House.HouseBuilder _house = new();   

        [SetUp]
        public void Setup()
        {
            _house = new House.HouseBuilder();
        }

        #region Rooms

            [TestCase(1, "It has 1 rooms and ")]
            [TestCase(10, "It has 10 rooms and ")]
            public void SetNumberOfRooms_GivenRoomCountHigherThanZero_ReturnCorrectString(int roomCount, string expectedResult)
            {
                var calculatedResult = _house.SetNumberOfRooms(roomCount);
                StringAssert.Contains(expectedResult, calculatedResult.Build().ToString()); ;
            }

            [TestCase(0)]
            [TestCase(-10)]
            public void Build_GivenRoomCountZeroOrNegative_ReturnArgumentOutOfRangeException(int rommCount)
            {
                House house;
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => house = _house.SetNumberOfRooms(rommCount).Build());
                Assert.That(ex?.ParamName == "Can't create a house with less than 1 room!");
            }

        #endregion Rooms

        #region Windows

            [TestCase(0, " rooms and 0 windows")]
            [TestCase(10, " rooms and 10 windows")]
            public void SetNumberOfWindows_GivenWindowsCountHigherThanZero_ReturnCorrectString(int windowCount, string expectedResult)
            {
                var calculatedResult = _house.SetNumberOfWindows(windowCount);
                StringAssert.Contains(expectedResult, calculatedResult.Build().ToString()); ;
            }

            [Test]
            public void Build_GivenNegativeNrOfWindows_ReturnArgumentOutOfRangeException()
            {
                House house;
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => house = _house.SetNumberOfWindows(-1).Build());
                Assert.That(ex?.ParamName == "Can't create a house with a negative number of windows!");
            }

        #endregion Windows

        #region StreetAddress

            [TestCase("testStreet 666")]
            [TestCase("anotherTestStreet 12-23a")]
            public void SetStreetAddress_GivenStreetAdress_ReturnCorrectString(string expectedResult)
            {
                var calculatedResult = _house.SetStreetAddress(expectedResult);
                StringAssert.Contains(expectedResult, calculatedResult.Build().ToString()); ;
            }

        #endregion StreetAddress

        #region SwimmingPool

            [Test]
            public void WithASwimmingPool_GivenSwimmingPool_ReturnCorrectString()
            {
                var calculatedResult = _house.WithASwimmingPool();
                StringAssert.Contains("It has a nice swimming pool", calculatedResult.Build().ToString()); ;
            }

            [Test]
            public void WithASwimmingPool_GivenNoSwimmingPool_ReturnCorrectString()
            {
                var calculatedResult = _house.SetStreetAddress("");
                StringAssert.DoesNotContain("It has a nice swimming pool", calculatedResult.Build().ToString()); ;
            }

        #endregion SwimmingPool

        #region ParkingSpots/HasGarage

            [Test]
            public void SetNumberOfParkingSpotsInGarage_GivenNoParkingSpotsAndNoSwimmingPool_ReturnCorrectString()
            {
                var calculatedResult = _house.SetNumberOfParkingSpotsInGarage(0);
                StringAssert.DoesNotContain("It has a garage with place for 0 cars", calculatedResult.Build().ToString()); ;
            }

            [TestCase(1, "It has a garage with place for 1 cars")]
            [TestCase(10, "It has a garage with place for 10 cars")]
            public void SetNumberOfParkingSpotsInGarage_GivenParkingSpotsIsHigherThanZeroAndNoSwimmingPool_ReturnCorrectString(int carsCount,
                string expectedResult)
            {
                var calculatedResult = _house.SetNumberOfParkingSpotsInGarage(carsCount);
                StringAssert.Contains(expectedResult, calculatedResult.Build().ToString()); ;
            }

            [Test]
            public void SetNumberOfParkingSpotsInGarage_Given1ParkingSpotAndSwimmingPool_ReturnCorrectString()
            {
                var calculatedResult = _house.SetNumberOfParkingSpotsInGarage(1).WithASwimmingPool();
                StringAssert.Contains($"It is very fancy and have both a swimming pool, and a garage with place for 1 car.",
                    calculatedResult.Build().ToString());
                StringAssert.DoesNotContain($"It is very fancy and have both a swimming pool, and a garage with place for 1 cars.",
                    calculatedResult.Build().ToString());
            }

            [TestCase(2)]
            [TestCase(10)]
            public void SetNumberOfParkingSpotsInGarage_GivenParkingSpotsHigherThan1AndSwimmingPool_ReturnCorrectString(int parkingSpotCount)
            {
                var calculatedResult = _house.SetNumberOfParkingSpotsInGarage(parkingSpotCount).WithASwimmingPool();
                StringAssert.Contains($"It is very fancy and have both a swimming pool, and a garage with place for {parkingSpotCount} cars.",
                    calculatedResult.Build().ToString()); ;
            }

            [Test]
            public void Build_GivenNegativeNrOfParkingSpotsInGarage_ReturnArgumentOutOfRangeException()
            {
                House house;
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => house = _house.SetNumberOfParkingSpotsInGarage(-1).Build());
                Assert.That(ex?.ParamName == "Can't create a house with a negative number of parking spots in garage!");
            }

        #endregion ParkingSpots/HasGarage

    }
}