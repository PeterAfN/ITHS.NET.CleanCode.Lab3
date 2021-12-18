using HouseFB;

House house = House
    .builder
    .SetNumberOfRooms(1)
    .SetNumberOfWindows(2)
    .SetStreetAddress("åvägen 7c")
    .WithASwimmingPool()
    .SetNumberOfParkingSpotsInGarage(8)
    .Build();

Console.WriteLine(house.ToString());