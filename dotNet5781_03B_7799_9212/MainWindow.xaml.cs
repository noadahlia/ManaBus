using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_01_7799_9212;
using static dotNet5781_01_7799_9212.Program;

namespace dotNet5781_03B_7799_9212
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Bus> busList = new List<Bus>();
            #region createBus
            /*Create 8 random buses*/
            Random r = new Random();
            CultureInfo provider = CultureInfo.InvariantCulture;
            string in_date1 = r.Next(31) + "/" + r.Next(13) + "/" + r.Next(1990,2019);
            string in_date2= r.Next(31) + "/" + r.Next(13) + "/" + r.Next(2019, 2099);
            string in_date3 = r.Next(31) + "/" + r.Next(12) + "/2020";

            DateTime dt1 = DateTime.ParseExact(in_date1, "dd/MM/yyyy", provider);
            DateTime dt2 = DateTime.ParseExact(in_date2, "dd/MM/yyyy", provider);
            DateTime dt3 = DateTime.ParseExact(in_date3, "dd/MM/yyyy", provider);


            for (int i = 0; i < 4; i++)
            {
                Bus bus = new Bus(r.Next(10000000,99999999), dt1);
                bus.lastRefresh= dt3;
                busList.Add(bus);
            }
            for (int i = 0; i < 4; i++)
            {
                Bus bus = new Bus(r.Next(1000000, 9999999), dt2);
                bus.lastRefresh = dt3;
                busList.Add(bus);

            }
            /*Create 3 special buses*/
            Bus b1 = new Bus(r.Next(10000000, 99999999), dt1);
            b1.lastRefresh = DateTime.ParseExact("12/12/2019", "dd/MM/yyyy", provider);
            busList.Add(b1);
            Bus b2 = new Bus(r.Next(10000000, 99999999), dt1);
            b2.KM_C = 19935;
            busList.Add(b2);
            Bus b3 = new Bus(r.Next(10000000, 99999999), dt1);
            b3.FUEL = 30;
            busList.Add(b3);

            #endregion


        }
    }
}
