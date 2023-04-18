using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp18.Models
{
    public class Food:MenuItem
    {
        public Food(string name, string description, double price) : base(name, description, price)
        {
        }

    }
}
