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
using BO;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Bus.xaml
    /// </summary>
    public partial class Bus : Window
    {
        IBL bl;
        BO.Bus curBus;
        public Bus(IBL _bl, BO.Bus _curBus)
        {
            InitializeComponent();
            bl = _bl;
            curBus = _curBus;
            busDetails.DataContext = curBus;
            cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));


        }

        private void applyBus_btn_Click(object sender, RoutedEventArgs e)
        {
            busDetails.DataContext = curBus;
            try
            {
                bl.UpdateBusInfos(curBus);
                MessageBox.Show("Saved!");
                this.Close();
            }
            catch (BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void delBus_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult myResult;
            myResult = MessageBox.Show("Are you really want to delete the bus?", "Delete Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (myResult == MessageBoxResult.Cancel)
            {
                return;
            }
            try
            {
                if (curBus != null)
                {
                    bl.DeleteBus(curBus.LicenseNum);
                    this.Close();

                }
            }
            catch (BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }

        private void refuel_btn_Click(object sender, RoutedEventArgs e)
        {
            busDetails.DataContext = curBus;
            MessageBoxResult message;
            message = MessageBox.Show("Are you really want to refuel the bus?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (message == MessageBoxResult.No)
            {
                return;
            }
            try
            {
                bl.RefuelBus(curBus);
                MessageBox.Show("Refueled!");
                this.Close();
            }
            catch (BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            busDetails.DataContext = curBus;
            MessageBoxResult message;
            message = MessageBox.Show("Are you really want to refresh the bus?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (message == MessageBoxResult.No)
            {
                return;
            }
            try
            {
                bl.RefreshBus(curBus);
                MessageBox.Show("Refreshed!");
                this.Close();
            }
            catch (BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busViewSource.Source = [generic data source]
        }

        
      
    }
}