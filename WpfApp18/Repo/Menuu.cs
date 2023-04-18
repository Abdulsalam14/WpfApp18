using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp18.Models;

namespace WpfApp18.Repo
{
    public class Menuu
    {
       public  ObservableCollection<Food> foods { get; set; } = new ObservableCollection<Food> {
        new Food("Doner","Toyuq",2.5),
        new Food("Doner","Et",3),
        new Food ("Lahmacun","Sade",2),
        new Food ("Lahmacun","Pendirli",3),
        new Food("Shaurma","Lavash",2.5),
        
        };
       public ObservableCollection<Drink> drinks { get; set; } = new ObservableCollection<Drink>
        {
            new Drink("Ayran","Damashni",1),
            new Drink("Ayran","Sade",0.8),
            new Drink("Cola","0.5",1.5),
            new Drink("Bizon","0.5",2),
            new Drink("Tea","Black",1),
        };

    }
}
