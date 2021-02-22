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
    /// Interaction logic for AddBus.xaml
    /// </summary>
    public partial class AddBus : Window
    {
        IBL bl;
        public AddBus(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Bus newBus = new BO.Bus();
                newBus.LicenseNum = int.Parse(license_tbx.Text);
                newBus.FromDate = (DateTime)date.SelectedDate;
                newBus.Status = (BO.BusStatus)cbStatus.SelectedIndex;
                newBus.FuelRemain = int.Parse(fuelRemain_tbx.Text);
                newBus.TotalTrip = int.Parse(totalTrip_tbx.Text);
                bl.AddBus(newBus);
                this.Close();
            }
            catch (BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);


            }
        }
    }
}

