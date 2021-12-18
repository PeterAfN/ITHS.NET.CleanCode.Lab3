using builder;

//Burger burger = new Burger();
//burger.Cheese = true;
//burger.Pickles = true;
//Console.WriteLine(burger.ToString()); ;

BurgerBuilder builder = new BurgerBuilder();
Burger Burger = builder
    .WithCheese()
        .AddNumberOfPatties(-4)
                .AddNumberOfPatties(5)
    .Build();

Console.WriteLine(Burger.ToString());