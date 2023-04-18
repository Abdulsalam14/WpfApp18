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
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp18.Models;
using WpfApp18.Repo;
using WpfApp18.Views;

namespace WpfApp18.ViewModels
{

    public class ViewModel1 : INotifyPropertyChanged
    {
        public Tables tables { get; set; }

        public ICommand StartCommand { get; set; }


        private ViewModel2 vm2;

        public ViewModel2 viewModel2
        {
            get { return vm2; }
            set { vm2 = value;
                OnPropertyChanged();
            }
        }

        private string tm;

        public string CurrentTime
        {
            get { return tm; }
            set { tm = value;
                OnPropertyChanged();
            }
        }

        public Page1 page1 { get; set; }

        public Page2 page2 { get; set; }


        private Tablee? taBle;

        public Tablee? table
        {
            get { return taBle; }
            set
            {
                taBle = value;
                OnPropertyChanged();
            }
        }

        private ICommand cmnd;

        public ICommand command
        {
            get { return cmnd; }
            set
            {
                cmnd = value;
                OnPropertyChanged();
            }
        }



        public ViewModel1()
        {
            tables = new Tables();
            command = new RelayCommand(Myexecute);
            page1 = new Page1();
            page2 = new Page2();
            viewModel2 = new ViewModel2();
            page1.DataContext = viewModel2;
            page2.DataContext = viewModel2;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Start();

        }



        public void Myexecute(object parameter)
        {


            table = parameter as Tablee;
            viewModel2.table = table;

            OnPropertyChanged(nameof(viewModel2));

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("dd.MM.yy  HH:mm:ss");
        }

        public event PropertyChangedEventHandler? PropertyChanged;



        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
