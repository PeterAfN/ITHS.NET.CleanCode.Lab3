using System.Text;

namespace HouseF
{
    public class House
    {
        public string StreetAdress { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasGarage => ParkingSpotsInGarage > 0;

        private int _noOfRooms;
        public int NoOfRooms
        {
            get { return _noOfRooms; }
            set 
            {
                if (value < 1) throw new ArgumentOutOfRangeException(("Can't create a house with less than 1 room!"));
                _noOfRooms = value; 
            }
        }

        private int _noOfWindows;
        public int NoOfWindows
        {
            get { return _noOfWindows; }
            set 
            {
                if (value < 0) throw new ArgumentOutOfRangeException(("Can't create a house with a negative number of windows!"));
                _noOfWindows = value; 
            }
        }

        private int _parkingSpotsInGarage;
        public int ParkingSpotsInGarage
        {
            get { return _parkingSpotsInGarage; }
            set 
            {
                if (value < 0) throw new ArgumentOutOfRangeException(("Can't create a house with a negative number of parking spots in garage!"));
                _parkingSpotsInGarage = value; 
            }
        }


        public House() { NoOfRooms = 1; NoOfWindows = 0; }

        public House(int noOfRooms, int noOfWindows, string streeAdress, bool hasSwimmingPool, int parkingSpotsInGarage)
        {
            NoOfRooms = noOfRooms;
            NoOfWindows = noOfWindows;
            StreetAdress = streeAdress;
            HasSwimmingPool = hasSwimmingPool;
            ParkingSpotsInGarage = parkingSpotsInGarage;
        }

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
    }
}
