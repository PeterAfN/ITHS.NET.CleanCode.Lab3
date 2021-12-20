using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HouseF.Tests
{
    public class HouseFactoryTests
    {
        private HouseFactory _factory = new();
        private House _house = new();

        [SetUp]
        public void Setup()
        {
            _factory = new HouseFactory();
        }

        #region CreateHouse

            [TestCase("apartment", "Worker street 34", 2, 2, 0, false, false, "This house is located at Worker street 34.\r\nIt has 2 rooms and 2 windows\r\n")]
            [TestCase("singleFamily", "De Luxe Avenue 34", 6, 11, 2, true, true, "This house is located at De Luxe Avenue 34.\r\nIt has 6 rooms and 11 windows\r\nIt is very fancy and have both a swimming pool, and a garage with place for 2 cars.\r\n")]
            [TestCase("castle", "Castle Vania 11", 103, 66, 10, true, false, "This house is located at Castle Vania 11.\r\nIt has 103 rooms and 66 windows\r\nIt has a garage with place for 10 cars\r\n")]

            public void CreateHouse_GivenHouseType_ReturnCorrectPropertiesAndCorrectResultString(
                string HouseType, string street, int rooms, int windows, int parkingSpots, bool garage, bool pool, string expectedResult)
            {
                _house = _factory.CreateHouse(HouseType);
                string calculatedResult = _house.ToString();

                Assert.That(_house.StreetAdress, Is.EqualTo(street));
                Assert.That(_house.NoOfRooms, Is.EqualTo(rooms));
                Assert.That(_house.NoOfWindows, Is.EqualTo(windows));
                Assert.That(_house.ParkingSpotsInGarage, Is.EqualTo(parkingSpots));
                Assert.That(_house.HasGarage, Is.EqualTo(garage));
                Assert.That(_house.HasSwimmingPool, Is.EqualTo(pool));
                Assert.That(calculatedResult, Is.EqualTo(expectedResult));
            }

            [Test]
            public void CreateHouse_GivenWrongHouseType_ReturnKeyNotFoundException()
            {
                string houseType = "unknown";
                var ex = Assert.Throws<KeyNotFoundException>(() => _factory.CreateHouse(houseType));
                Assert.That(ex?.Message == $"The given key '{houseType}' was not present in the dictionary.");
            }

            [Test]
            public void CreateHouse_GivenNullHouseType_ReturnNullReferenceException()
            {
                var ex = Assert.Throws<NullReferenceException>(() => _factory.CreateHouse(null));
                Assert.That(ex?.Message == $"Object reference not set to an instance of an object.");
            }

        #endregion CreateHouse


        #region Rooms

            [TestCase(1, "It has 1 rooms and ")]
            [TestCase(10, "It has 10 rooms and ")]
            public void SetNumberOfRooms_GivenRoomCountHigherThanZero_ReturnCorrectString(int roomCount, string expectedResult)
            {
                _house = new House(roomCount, 0, string.Empty, true, 0);
                var calculatedResult = _house.ToString();
                StringAssert.Contains(expectedResult, calculatedResult);
            }

            [TestCase(0)]
            [TestCase(-10)]
            public void Build_GivenRoomCountZeroOrNegative_ReturnArgumentOutOfRangeException(int roomCount)
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new House(roomCount, 2, "testaddress", true, 1));
                Assert.That(ex?.ParamName == "Can't create a house with less than 1 room!");
            }

        #endregion Rooms

        #region Windows

            [TestCase(0, " rooms and 0 windows")]
            [TestCase(10, " rooms and 10 windows")]
            public void SetNumberOfWindows_GivenWindowsCountHigherThanZero_ReturnCorrectString(int windowCount, string expectedResult)
            {
                _house = new House(1, windowCount, string.Empty, true, 0);
                var calculatedResult = _house.ToString();
                StringAssert.Contains(expectedResult, calculatedResult);
            }

            [Test]
            public void Build_GivenNegativeNrOfWindows_ReturnArgumentOutOfRangeException()
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new House(1, -1, "testaddress", true, 1));
                Assert.That(ex?.ParamName == "Can't create a house with a negative number of windows!");
            }

        #endregion Windows

        #region StreetAddress

            [TestCase("testStreet 666")]
            [TestCase("anotherTestStreet 12-23a")]
            public void SetStreetAddress_GivenStreetAdress_ReturnCorrectString(string expectedResult)
            {
                _house = new House(1, 1, expectedResult, true, 0);
                var calculatedResult = _house.ToString();
                StringAssert.Contains(expectedResult, calculatedResult);
            }

        #endregion StreetAddress

        #region SwimmingPool

            [Test]
            public void WithASwimmingPool_GivenSwimmingPool_ReturnCorrectString()
            {
                _house = new House(1, 1, string.Empty, true, 0);
                var calculatedResult = _house.ToString();
                StringAssert.Contains("It has a nice swimming pool", calculatedResult);
            }

            [Test]
            public void WithASwimmingPool_GivenNoSwimmingPool_ReturnCorrectString()
            {
                _house = new House(1, 1, string.Empty, false, 0);
                var calculatedResult = _house.ToString();
                StringAssert.DoesNotContain("It has a nice swimming pool", calculatedResult); ;
            }

        #endregion SwimmingPool

        #region ParkingSpots/HasGarage

            [Test]
            public void SetNumberOfParkingSpotsInGarage_GivenNoParkingSpotsAndNoSwimmingPool_ReturnCorrectString()
            {
                _house = new House(1, 1, string.Empty, false, 0);
                var calculatedResult = _house.ToString();
                StringAssert.DoesNotContain("It has a garage with place for 0 cars", calculatedResult);
            }

            [TestCase(1, "It has a garage with place for 1 cars")]
            [TestCase(10, "It has a garage with place for 10 cars")]
            public void SetNumberOfParkingSpotsInGarage_GivenParkingSpotsIsHigherThanZeroAndNoSwimmingPool_ReturnCorrectString(int carsCount,
                string expectedResult)
            {
                _house = new House(2, 0, string.Empty, false, carsCount);
                var calculatedResult = _house.ToString();
                StringAssert.Contains(expectedResult, calculatedResult);
            }

            [Test]
            public void SetNumberOfParkingSpotsInGarage_Given1ParkingSpotAndSwimmingPool_ReturnCorrectString()
            {
                _house = new House(2, 0, string.Empty, true, 1);
                var calculatedResult = _house.ToString();
                StringAssert.Contains($"It is very fancy and have both a swimming pool, and a garage with place for 1 car.",
                    calculatedResult);
                StringAssert.DoesNotContain($"It is very fancy and have both a swimming pool, and a garage with place for 1 cars.",
                    calculatedResult);
            }

            [TestCase(2)]
            [TestCase(10)]
            public void SetNumberOfParkingSpotsInGarage_GivenParkingSpotsHigherThan1AndSwimmingPool_ReturnCorrectString(int parkingSpotCount)
            {
                _house = new House(2, 0, string.Empty, true, parkingSpotCount);
                var calculatedResult = _house.ToString();
                StringAssert.Contains($"It is very fancy and have both a swimming pool, and a garage with place for {parkingSpotCount} cars.",
                    calculatedResult); ;
            }

            [Test]
            public void Build_GivenNegativeNrOfParkingSpotsInGarage_ReturnArgumentOutOfRangeException()
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _house = new House(2, 0, string.Empty, true, -1));
                Assert.That(ex?.ParamName == "Can't create a house with a negative number of parking spots in garage!");
            }

        #endregion ParkingSpots/HasGarage

    }
}