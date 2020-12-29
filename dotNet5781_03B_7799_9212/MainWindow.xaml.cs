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
using System.Threading;
using System.Collections.ObjectModel;

namespace dotNet5781_03B_7799_9212
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    ///        

    public partial class MainWindow : Window
    {
        ObservableCollection<Bus> busList = new ObservableCollection<Bus>();


        public MainWindow()
        {
            InitializeComponent();
        

            #region createBus
            /*Create 8 random buses*/
            Random r = new Random();
            string in_date1, in_date2, in_date3;
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dt1, dt2, dt3;
            
            for (int i = 0; i < 4; i++)
            {
                 in_date1 = r.Next(3)+""+r.Next(1,10) + "/" + r.Next(1,13) + "/" + r.Next(1990, 2019);
                 dt1 = DateTime.ParseExact(in_date1, "dd/M/yyyy", provider);
                 in_date3 = r.Next(3) + "" + r.Next(1,10) + "/" + r.Next(1, 12) + "/2020";
                 dt3 = DateTime.ParseExact(in_date3, "dd/M/yyyy", provider);
                Bus bus = new Bus(r.Next(1000000, 10000000), dt1);
                bus.lastRefresh = dt3;
                busList.Add(bus);
            }

            for (int i = 0; i < 4; i++)
            {
                 in_date2 = r.Next(3) + "" + r.Next(1,10) + "/" + r.Next(1, 13) + "/" + r.Next(2019, 2021);
                 in_date3 = r.Next(3) + "" + r.Next(1,10) + "/" + r.Next(1, 12) + "/2020";
                 dt2 = DateTime.ParseExact(in_date2, "dd/M/yyyy", provider);
                 dt3 = DateTime.ParseExact(in_date3, "dd/M/yyyy", provider);
                Bus bus = new Bus(r.Next(10000000, 100000000), dt2);
                bus.lastRefresh = dt3;
                busList.Add(bus);

            }
            /*Create 3 special buses*/
            in_date1 = r.Next(3) + "" + r.Next(1,10) + "/" + r.Next(1, 13) + "/" + r.Next(1990, 2019);
            dt1 = DateTime.ParseExact(in_date1, "dd/M/yyyy", provider);
            Bus b1 = new Bus(r.Next(10000000, 99999999), dt1);
            b1.lastRefresh = DateTime.ParseExact("12/12/2019", "dd/MM/yyyy", provider);
            busList.Add(b1);
            in_date1 = r.Next(3) + "" + r.Next(1,10) + "/" + r.Next(1, 13) + "/" + r.Next(1990, 2019);
            dt1 = DateTime.ParseExact(in_date1, "dd/M/yyyy", provider);
            Bus b2 = new Bus(r.Next(10000000, 99999999), dt1);
            b2.KM_C = 19935;
            busList.Add(b2);
            in_date1 = r.Next(3) + "" + r.Next(1,10) + "/" + r.Next(1, 13) + "/" + r.Next(1990, 2019);
            dt1 = DateTime.ParseExact(in_date1, "dd/M/yyyy", provider);
            Bus b3 = new Bus(r.Next(10000000, 99999999), dt1);
            b3.FUEL = 30;
            busList.Add(b3);

            #endregion

            this.lb_bus.ItemsSource = busList;
            this.lb_bus.DataContext = busList;
            this.lb_bus.SelectedIndex = 0;

        }
   

        private void btn_insertClick(object sender, RoutedEventArgs e) {
            InsertWin insertWin = new InsertWin(busList);
            insertWin.ShowDialog();

        }

        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               
        }

        private void btnFuel_Click(object sender, RoutedEventArgs e)
        {
            Bus selBus = ((Button)sender).DataContext as Bus;
            selBus.Refueling();
        }

        private void btnDrive_Click(object sender, RoutedEventArgs e)
        {
            Bus selBus = ((Button)sender).DataContext as Bus;
            Drive driveWin = new Drive(selBus);
            driveWin.ShowDialog();
        }

        private void lb_bus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(lb_bus.SelectedItem.ToString(), "Bus informations");
        }
    }





} 
    

    

