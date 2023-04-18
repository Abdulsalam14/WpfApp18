using Source.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp18.Models;
using WpfApp18.Views;

namespace WpfApp18.ViewModels
{
    public class ViewModel2:INotifyPropertyChanged
    {
        public ICommand StartCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand NewOrderCommand { get; set; }
        public ICommand FinishCommand { get; set; }

        private Tablee ?tbl;
        public Tablee ?table
        {
            get { return tbl; }
            set { tbl = value;
                OnPropertyChanged();
            }
        }

        public ViewModel2()
        {
            StartCommand = new RelayCommand(StartExecute);
            CancelCommand = new RelayCommand(CancelExecute);
            FinishCommand=new RelayCommand(FinishExecute);
            NewOrderCommand = new RelayCommand(NewOrderExecute);
        }

        public event PropertyChangedEventHandler? PropertyChanged;



        public void CancelExecute(object parameter)
        {
            ViewModel1? vm=App.Current.MainWindow.DataContext as ViewModel1;
            vm.table = null;
        }

        public void StartExecute(object parameter)
        {
            if (table != null)
            {
                table.Isfull = true;
                MessageBox.Show(table.Name);
                table.StartTime = DateTime.Now.ToString("dd.MM.yy HH:mm:ss");
                table.stopwatch.Start();
                table.dispatcher.Tick += Timer_Tick;
                table.dispatcher.Interval = TimeSpan.FromMilliseconds(1000);
                table.dispatcher.Start();
            }
            else
            {
                MessageBox.Show("ss");
            }
        }


       public void FinishExecute(object parameter)
        {
            ViewModel1 ?vm=App.Current.MainWindow.DataContext as ViewModel1;
            vm.table.FinishTime = DateTime.Now.ToString();
            double hesab = 0;
            foreach (var item in table.menuItems)
            {
                hesab += (item.Price * item.Number);
            }
            table.Isfull = false;
            table.StartTime = null;
            table.stopwatch.Reset();
            table.dispatcher.Tick -= Timer_Tick;
            table.menuItems.Clear();
            MessageBox.Show("Hesab:"+hesab.ToString()+"AZN");
            table.dispatcher.Tick -= Timer_Tick;
            vm.table = null;

        }


       public void NewOrderExecute(object parameter)
        {
            MenuView menuView=new MenuView();
            menuView.Show();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
           table.ts = table.stopwatch.Elapsed;
            table.time = table.ts.ToString(@"hh\:mm\:ss");
        }

        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
