using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp18.Models;

namespace WpfApp18.Views
{
    /// <summary>
    /// Interaction logic for Finish.xaml
    /// </summary>
    /// 

    // tamamlanmayib
    public partial class Finish : Window
    {
        public string text1 { get; set; }
        public string text2 { get; set; }

        public Tablee table { get; set; }


        Dictionary<string, string> ss { get; set; }
        public Finish()
        { 
            InitializeComponent();
            DataContext = this;
            ss = new Dictionary<string, string>();
            if (table != null)
            {
                ss.Add("Name:", table.Name);
                ss.Add("StartTime:", table.StartTime);
                ss.Add("Name:", table.Name);
                ss.Add("Name:", table.Name);
                ss.Add("Name:", table.Name);
            }


            foreach (var item in table.menuItems)
            {

            }
        }
    }
}
