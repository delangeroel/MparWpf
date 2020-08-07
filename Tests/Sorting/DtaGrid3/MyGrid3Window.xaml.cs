using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace MparWpf.Tests.Sorting.DtaGrid3
{
    /// <summary>
    /// Interaction logic for MyGrid3Window.xaml
    /// </summary>
    public partial class MyGrid3Window : Window, INotifyPropertyChanged
    {
        public   ObservableCollection<Track> list = new ObservableCollection<Track>();
        public   ObservableCollection<Track> List
        {
            get { return list; }
            
        }

        public static string DateTimeUiFormat = "dd/MM/yyyy";
        public static ObservableCollection<string> _kleurenList = new ObservableCollection<string>()
            {
                "Rood","Groen","Blauw"
            };
    public  ObservableCollection<string> KleurenList 
        {
            get { return _kleurenList; } 
            set { _kleurenList = value; }
        }
        private string _selectedKleur;
        public string selectedKleur
        {
            get{ return _selectedKleur; }
            set{ _selectedKleur = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public MyGrid3Window()
        {
            InitializeComponent();

            //
            //selectedKleur = KleurenList[0];

            list.Add(new Track() { title = "Think",
                artist = "Aretha Franklin",
                number = 7,
                url = "ww.nos.nl",
                forSale = true,
                amount = new Decimal(1234567.89),
                dateTime = new DateTime(2015, 12, 31),
                status = Status.Open,
                birthday = DateTime.Now
            });
            list.Add(new Track() { title = "Minnie The Moocher",
                artist = "Cab Calloway",
                number = 9,
                url = "ww.nos.nl",
                forSale = true,
                amount = new Decimal(1234567.89),
                dateTime = DateTime.Now,
                birthday = new DateTime(2017,1,21),
                status = Status.Open
            });  
            list.Add(new Track() {  
                title = "Shake A Tail Feather", 
                artist = "Ray Charles", 
                number = 4,
                url = "ww.nos.nl",
                forSale = true,
                amount = new Decimal(1234567.89),
                birthday = DateTime.Now,
                status = Status.New
            });
            NotifyPropertyChanged("List");
            //dgTest.DataContext = data;
            DataContext = this;
        }
        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
    public class Track
    {
        private String _t;
        private String _a;
        private int _n;
        private string _url;
        private bool _forSale;
        private decimal _amount;
        private DateTime _dateTime;
        private Status _status;
        private DateTime _birthDay;

        public String title
        {
            get { return _t; }
            set { _t = value; }
        }
        public String artist
        {
            get { return _a; }
            set { _a = value; }
        }
        public int number
        {
            get { return _n; }
            set { _n = value; }
        }
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }
        public bool forSale
        {
            get { return _forSale; }
            set { _forSale = value; }
        }
        public decimal amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public DateTime dateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
        public Status status
        {
            get { return _status; }
            set { _status = value; }
        }
        public DateTime birthday
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }

        public IList<Status> StatusTypes
        {
            get
            {
                // Will result in a list like {"Tester", "Engineer"}
                return Enum.GetValues(typeof(Status)).Cast<Status>().ToList<Status>();
            }
        }
        public ObservableCollection<Status> StatusItems {
            get {
                return new ObservableCollection<Status> (Enum.GetValues(typeof(Status)).Cast<Status>().ToList<Status>());
            }  
        }
        public Status StatusType
        {
            get;
            set;
        }
    }

    public enum Status { New, Open, Running, Closed};

}
