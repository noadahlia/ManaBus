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
using BL;
using BO;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Bus.xaml
    /// </summary>
    public partial class Bus : Window
    {
        public Bus()
        {
            InitializeComponent();
            //this.lb_bus.ItemsSource = BO.ListOfBus;//rattacher a notre BusOfList de BL
            //this.lb_bus.DataContext = ListOfBus;
            //this.lb_bus.SelectedIndex = 0;
        }
        private void delBus_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult myResult;
            myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (myResult == MessageBoxResult.OK)
            {
                
                   
             }
            else
            {
                //No delete
            }
        }

        private void applyBus_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refuel_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refresh_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
