//namespace HouseFB
//{
//    public class HouseBuilder
//    {
//        private readonly House  _house;

//        public HouseBuilder()
//        {
//            _house = new House();
//        }

//        public House Build()
//        {
//            if (_house.NoOfRooms < 1) throw new ArgumentOutOfRangeException(("Can't create a house with less than 1 room!"));
//            if (_house.NoOfWindows < 0) throw new ArgumentOutOfRangeException(("Can't create a house with a negative number of windows!"));
//            if (_house.ParkingSpotsInGarage < 0) throw new ArgumentOutOfRangeException(("Can't create a house with a negative number of parking spots in garage!"));

//            return _house;
//        }

//        public HouseBuilder SetNumberOfRooms(int roomsCount)
//        {
//            _house.NoOfRooms = roomsCount;
//            return this;
//        }

//        public HouseBuilder SetNumberOfWindows(int windowsCount)
//        {
//            _house.NoOfWindows = windowsCount;
//            return this;
//        }

//        public HouseBuilder SetStreetAddress(string streetAddress)
//        {
//            _house.StreetAdress = streetAddress;
//            return this;
//        }

//        public HouseBuilder WithASwimmingPool()
//        {
//            _house.HasSwimmingPool = true;
//            return this;
//        }

//        public HouseBuilder SetNumberOfParkingSpotsInGarage(int parkingSpots)
//        {
//            _house.ParkingSpotsInGarage = parkingSpots;
//            return this;
//        }
//    }
//}
