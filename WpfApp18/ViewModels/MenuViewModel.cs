using Source.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp18.Models;
using WpfApp18.Repo;
using WpfApp18.Views;

namespace WpfApp18.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        public ObservableCollection<MenuItem> items { get; set; }
        public ObservableCollection<Food> foods { get; set; }
        public ObservableCollection<Drink> drinks { get; set; }
        public Menuu menuu { get; set; } = new Menuu();

        private MenuItem ?itm;

        public MenuItem? item
        {
            get { return itm; }
            set { itm = value;
                OnPropertyChanged();
            }
        }


        public ICommand enter { get; set; }
        public ICommand check{ get; set; }
        public MenuViewModel()
        {
            foods = menuu.foods;
            drinks = menuu.drinks;
            items = new ObservableCollection<MenuItem>();
            check = new RelayCommand(CheckExecute);
            enter = new RelayCommand(EnterExecute);
        }

        public void EnterExecute(object parameter)
        {
            ViewModel1? viewModel1 = App.Current.MainWindow.DataContext as ViewModel1;
            ObservableCollection<MenuItem>? b= viewModel1?.table.menuItems;
            foreach (var item in items)
            {
                b.Add(item);
            }
            items.Clear();
            App.Current.Windows[1].Close();
        }


        public void CheckExecute(object parameter)
        {
            if (item != null)
            {
                MenuItem temp = new MenuItem(item.Name, item.Description, item.Price);
                string ?s = parameter as string;
                temp.Number = Convert.ToInt32(s);
                items.Add(temp);
                item = null;
            }
            else MessageBox.Show("Sec sonra doldur");
        }


        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
