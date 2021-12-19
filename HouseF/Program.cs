using HouseF;

HouseFactory factory = new HouseFactory();

//House house = factory.CreateHouse("apartment");
House house = factory.CreateHouse("singleFamily");
//House house = factory.CreateHouse("castle");
//House house = factory.CreateHouse("unknown");

Console.WriteLine(house);