using MparWpf.Tests.Sorting.DtaGrid3;
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

namespace MparWpf.Tests.Sorting.DtaGrid4
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public ObservableCollection<GridItem> GridItems { get; set; }
        public ObservableCollection<CompanyItem> CompanyItems { get; set; }

        public ObservableCollection<CompanyItem> Kleuren { get; set; }
        public Window1()
        {
            InitializeComponent();

            DataContext = this;
            

            GridItems = new ObservableCollection<GridItem>() {
            new GridItem() { Name = "Jim1", CompanyID = 1, Status=Status.New } ,
            new GridItem() { Name = "Jim2", CompanyID = 2, Status=Status.New } ,
            new GridItem() { Name = "Jim3", CompanyID = 2, Status=Status.Closed } ,
            new GridItem() { Name = "Jim4", CompanyID = 3, Status=Status.Closed} };

            CompanyItems = new ObservableCollection<CompanyItem>() {
            new CompanyItem() { ID = 1, Name = "Rood" },
            new CompanyItem() { ID = 2, Name = "Groen" },
            new CompanyItem() { ID = 3, Name = "Blauw" } };
        }
    }

    public class GridItem
    {
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public Enum Status { get; set; }
    }

    public class CompanyItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    
    public enum StatusList { New, Open, Running, Closed };
}
