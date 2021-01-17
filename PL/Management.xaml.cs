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
            lb_bus.ItemsSource = bl.GetAllBuses();
            lb_bus.DisplayMemberPath = "LicenseNum";
            lb_line.ItemsSource = bl.GetAllLines();
            lb_line.DisplayMemberPath = "Code";
            RefreshAllStationsListBox();


        }
        void RefreshAllStationsListBox()
        {
            lb_station.ItemsSource = bl.GetAllStations();
            lb_station.DisplayMemberPath = "Code";
        }

        

        private void addBus_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("coucou elishou");
        }

        private void addLine_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addStation_btn_Click(object sender, RoutedEventArgs e)
        {
            AddStation addStation = new AddStation(bl);
            addStation.ShowDialog();
            RefreshAllStationsListBox();
        }
    }
}
