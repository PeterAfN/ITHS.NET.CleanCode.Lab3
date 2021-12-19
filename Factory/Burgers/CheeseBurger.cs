using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Burgers
{
    public class CheeseBurger : Burger
    {

        public CheeseBurger()
        {
            Cheese = true;
        }
    }
}
