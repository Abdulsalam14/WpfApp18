using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp18.Models;

public class Tablee : INotifyPropertyChanged
{
    public Tablee(string name, bool isfull)
    {
        Name = name;
        Isfull = isfull;
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value;
            OnPropertyChanged();
        }
    }

    public Stopwatch stopwatch = new Stopwatch();

    private bool isFull;

    public bool Isfull
    {
        get { return isFull; }
        set {
            isFull = value;
            OnPropertyChanged(); }
    }


    private string sttime;

    public string StartTime
    {
        get { return sttime; }
        set { sttime = value;
            OnPropertyChanged();
        }
    }

    private string tm;

    public string time
    {
        get { return tm; }
        set { tm = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<MenuItem> menuItems{ get; set; }= new ObservableCollection<MenuItem>();
    public TimeSpan ts { get; set; } = new TimeSpan();
    public string FinishTime { get; set; }


    public DispatcherTimer dispatcher  { get; set; } =new DispatcherTimer();
    public event PropertyChangedEventHandler? PropertyChanged;


    private void OnPropertyChanged([CallerMemberName] string propertyname = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }

}
