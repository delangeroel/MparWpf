using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


// Numeric field for your screen
// http://wpfknowledge.blogspot.com/2014/11/numeric-text-box.html
// https://stackoverflow.com/questions/17038336/make-input-textbox-as-currency-format-wpf-mvvm/17038523
// Mouse over https://docs.microsoft.com/en-us/dotnet/desktop-wpf/themes/how-to-create-apply-template met eigen button ontwerp

namespace MparWpf.Tests.Sorting.Screens.Screen1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>


    public partial class Window1 : Window
    {
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }


        private decimal _price2;
        public decimal Price2
        {
            get { return _price2; }
            set { _price2 = value; }
        }

        private decimal _price3 = new decimal(-12345678.90);
        public decimal Price3
        {
            get { return _price3; }
            set { _price3 = value; }
        }
        private decimal _price4 = new decimal(-12345678.90);
        public decimal Price4
        {
            get { return _price4; }
            set { _price4 = value; }
        }
        public Window1()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
            CultureInfo nlNLs = new CultureInfo("nl-NL");
            InitializeComponent();
            DataContext = this;
   
  

            var d = decimal.Parse("-0.8",
                      NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                      CultureInfo.InvariantCulture);

            CultureInfo enGb = new CultureInfo("en-GB");
            CultureInfo enUs = new CultureInfo("en-US");


            checkNum(enGb);
            checkNum(enUs);
            checkNum(nlNLs);// Deze omzetting van decimal naar string naar decimal werkt goed en is taalafhankelijk
        }
        private void checkNum(CultureInfo ci)
        {
            //CultureInfo.CurrentCulture = new CultureInfo("nl-NL", false);

            decimal amount0 = new decimal(-12345678.90);
            decimal amount1 = new decimal(-0.00);
            string a0 = amount0.ToString("N2", ci);
            string a1 = amount1.ToString("N2", ci);

            decimal aa0 = Convert.ToDecimal(a0, ci);
            decimal aa1 = Convert.ToDecimal(a1, ci);

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Price44_GotFocus(object sender, RoutedEventArgs e)
        {
            Price44.SelectAll(); 
        }
    }
}

