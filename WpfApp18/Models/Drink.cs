using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp18.Models
{
    public class Drink : MenuItem
    {
        public Drink(string name, string description, double price) : base(name, description, price)
        {
        }
    }
}
