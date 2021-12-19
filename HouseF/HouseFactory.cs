using System.Reflection;

namespace HouseF
{
    public class HouseFactory
    {
        private Dictionary<string, Type> _houses;

        public HouseFactory()
        {
            _houses = LoadHousesByReflection();
        }

        public House CreateHouse(string houseName)
        {
            LoadHousesByReflection();
            return GetHouseFromDictionary(houseName.ToLower());
        }

        private Dictionary<string, Type> LoadHousesByReflection()
        {
            IEnumerable<Type>? availableTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && t.IsSubclassOf(typeof(House)));

            Dictionary<string, Type> availableHouses = new Dictionary<string, Type>();

            foreach (Type t in availableTypes)
            {
                availableHouses.Add(t.Name.ToLower(), t);
            }

            return availableHouses;
        }


        private House GetHouseFromDictionary(string HouseName)
        {
            Type type = _houses[HouseName];
            if (type is null)
            {
                throw new ArgumentException("Could not find a house with name " + HouseName);
            }

            return (House)Activator.CreateInstance(type);
        }
    }
}
