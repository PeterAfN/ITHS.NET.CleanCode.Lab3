using Factory.Burgers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class BurgerFactory
    {
        private Dictionary<string, Type> _burgers;

        public BurgerFactory()
        {
            //_burgers = LoadBurgers();
            _burgers = LoadBurgersByReflection();
        }

        public Burger CreateBurger(string burgerName)
        {
            LoadBurgersByReflection();
            return GetBurgerFromDictionary(burgerName.ToLower());
        }

        //private Dictionary<string, Type> LoadBurgers()
        //{
        //    Dictionary<string, Type> availableBurgers = new Dictionary<string, Type>();
        //    availableBurgers.Add("cheeseburger", typeof(CheeseBurger));
        //    availableBurgers.Add("plainburger", typeof(PlainBurger));
        //    availableBurgers.Add("superburger", typeof(SuperDeLuxeBurger));
        //    return availableBurgers;
        //}

        private Dictionary<string, Type> LoadBurgersByReflection()
        {
            IEnumerable<Type>? availableTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && t.IsSubclassOf(typeof(Burger)));

            Dictionary<string, Type> availableBurgers = new Dictionary<string, Type>();

            foreach (Type t in availableTypes)
            {
                availableBurgers.Add(t.Name.ToLower(), t);
                //Console.WriteLine(t.Name.ToLower());
            }

            return availableBurgers;    
        }


        private Burger GetBurgerFromDictionary(string burgerName)
        {
            Type type = _burgers[burgerName];
            if (type is null)
            {
                throw new ArgumentException("Could not find burger with name " + burgerName);
            }

            return (Burger)Activator.CreateInstance(type);
        }
    }
}
