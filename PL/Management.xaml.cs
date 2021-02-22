using System;
using System.Collections.Generic;
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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        IBL bl;

        public Management(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;

            RefreshAllStationsListBox();
            RefreshAllBusesListBox();
            RefreshAllLinesListBox();

        }
        void RefreshAllStationsListBox()
        {
            lb_station.ItemsSource = bl.GetAllStations();
            lb_station.DisplayMemberPath = "Code";
        }

        void RefreshAllBusesListBox()
        {
            lb_bus.ItemsSource = bl.GetAllBuses();
            lb_bus.DisplayMemberPath = "LicenseNum";
        }
        void RefreshAllLinesListBox()
        {
            lb_line.ItemsSource = bl.GetAllLines();
            lb_line.DisplayMemberPath = "Code";
        }



        private void addBus_btn_Click(object sender, RoutedEventArgs e)
        {
         AddBus addBus = new AddBus(bl);
         addBus.ShowDialog();
         RefreshAllBusesListBox();
        }

      

        private void addStation_btn_Click(object sender, RoutedEventArgs e)
        {
            AddStation addStation = new AddStation(bl);
            addStation.ShowDialog();
            RefreshAllStationsListBox();
        }

     

        private void lb_station_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.Station curStat = (lb_station.SelectedItem as BO.Station);
            Station statWin = new Station(bl,curStat);
            statWin.ShowDialog();
            RefreshAllStationsListBox();

        }

        private void lb_bus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            BO.Bus curBus = (lb_bus.SelectedItem as BO.Bus);
            Bus busWin = new Bus(bl, curBus);
            busWin.ShowDialog();
            RefreshAllBusesListBox();

        }
    }
}
