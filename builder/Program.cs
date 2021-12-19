using builder;

// Fluentbuilder

BurgerBuilder builder = new BurgerBuilder();
Burger Burger = builder
    .WithCheese()
    .AddNumberOfPatties(5)
    .Build();

Console.WriteLine(Burger.ToString());


