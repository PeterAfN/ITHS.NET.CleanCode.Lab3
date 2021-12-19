using Factory;
using Factory.Burgers;

BurgerFactory factory = new BurgerFactory();

//Burger burger = factory.CreateBurger("cheeseburger");
Burger burger = factory.CreateBurger("superDeLuxeburger");
//Burger burger = factory.CreateBurger("plainburger");



Console.WriteLine(burger);