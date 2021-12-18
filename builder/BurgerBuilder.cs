using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Fluentbuilder
namespace builder
{
    public class BurgerBuilder
    {
        private readonly Burger _burger;

        public BurgerBuilder()
        {
            _burger = new Burger();
        }

        public Burger Build()
        {
            //if (noOfPatties <= 0)
            //{
            //    throw new ArgumentOutOfRangeException(("Can not create a negative number of parries!"));
            //}
            return _burger; 
        }

        public BurgerBuilder WithCheese()
        {
            _burger.Cheese = true;
            return this;
        }

        public BurgerBuilder AddNumberOfPatties(int noOfPatties)
        {
            // 1. Vi kan sätta 1 köttbit om vi petar in 0 eller negativt
            // 2. Kasta ett exception
            // 3. Döper om SetNumberOfPatties till AddNumberofPatties
            // 4. Om vi kastar exception, var ska vi göra det?

            if (noOfPatties <= 0)
            {
                throw new ArgumentOutOfRangeException(("Can not add a negative number of parries!"));
            }

            _burger.NumPatties += noOfPatties;
            return this;
        }

    }
}
