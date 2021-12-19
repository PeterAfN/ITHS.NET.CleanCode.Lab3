using System.Text;

namespace HouseFB
{
    public class House
    {
        public int NoOfRooms { get; set; } = 1;

        public int NoOfWindows { get; set; } = 0;

        /// <summary>This field includes the street name and the street number</summary>
        public string StreetAdress { get; set; }

        public bool HasSwimmingPool { get; set; }

        public int ParkingSpotsInGarage { get; set; }

        public bool HasGarage => ParkingSpotsInGarage > 0;

        private House() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"This house is located at {StreetAdress}.");
            sb.AppendLine($"It has {NoOfRooms} rooms and {NoOfWindows} windows");
            if (HasSwimmingPool & HasGarage)
            {
                sb.Append($"It is very fancy and have both a swimming pool, and a garage with place for {ParkingSpotsInGarage} car");
                if (ParkingSpotsInGarage > 1)
                {
                    sb.Append("s");
                }
                sb.AppendLine(".");
            }
            else if (HasSwimmingPool)
            {
                sb.AppendLine("It has a nice swimming pool");
            }
            else if (HasGarage)
            {
                sb.AppendLine($"It has a garage with place for {ParkingSpotsInGarage} cars");
            }

            return sb.ToString();
        }

        public static HouseBuilder builder = new();

        public class HouseBuilder
        {
            private readonly House _house;

            public HouseBuilder()
            {
                _house = new House();
            }

            public House Build()
            {
                if (_house.NoOfRooms < 1) throw new ArgumentOutOfRangeException(("Can't create a house with less than 1 room!"));
                if (_house.NoOfWindows < 0) throw new ArgumentOutOfRangeException(("Can't create a house with a negative number of windows!"));
                if (_house.ParkingSpotsInGarage < 0) throw new ArgumentOutOfRangeException(("Can't create a house with a negative number of parking spots in garage!"));

                return _house;
            }

            public HouseBuilder SetNumberOfRooms(int roomsCount)
            {
                _house.NoOfRooms = roomsCount;
                return this;
            }

            public HouseBuilder SetNumberOfWindows(int windowsCount)
            {
                _house.NoOfWindows = windowsCount;
                return this;
            }

            public HouseBuilder SetStreetAddress(string streetAddress)
            {
                _house.StreetAdress = streetAddress;
                return this;
            }

            public HouseBuilder WithASwimmingPool()
            {
                _house.HasSwimmingPool = true;
                return this;
            }

            public HouseBuilder SetNumberOfParkingSpotsInGarage(int parkingSpots)
            {
                _house.ParkingSpotsInGarage = parkingSpots;
                return this;
            }
        }
    }
}
