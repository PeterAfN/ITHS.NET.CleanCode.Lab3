using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Burgers
{

    public class Burger
    {
        public int NumPatties { get; set; } = 1;
        public bool Cheese { get; set; }
        public bool Bacon { get; set; }
        public bool Pickles { get; set; }
        public bool Letuce { get; set; }
        public bool Tomato { get; set; }
        public Burger() { }
        public Burger(int numPatties, bool cheese, bool bacon, bool pickles, bool letuce, bool tomato)
        {
            Cheese = cheese;
            Bacon = bacon;
            Pickles = pickles;
            Letuce = letuce;
            Tomato = tomato;
            NumPatties = numPatties;
        }
        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"A nice burger with {NumPatties} patties");
            if (hasAnyExtras())
                sb.Append(" and:");
            sb.AppendLine();
            if (Cheese)
                sb.AppendLine("- Cheese");
            if (Bacon)
                sb.AppendLine("- Bacon");
            if (Pickles)
                sb.AppendLine("- Pickles");
            if (Letuce)
                sb.AppendLine("- Letuce");
            if (Tomato)
                sb.AppendLine("- Tomato");
            return sb.ToString();
        }
        private bool hasAnyExtras()
        {
            return Cheese || Bacon || Pickles || Letuce || Tomato;
        }
    }
}
