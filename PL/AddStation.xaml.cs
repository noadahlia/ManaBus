using BLAPI;
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

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour AddStation.xaml
    /// </summary>
    public partial class AddStation : Window
    {
        IBL bl;
        public AddStation(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            try
            {
                BO.Station newStat = new BO.Station();
                newStat.Code = int.Parse(code_tbx.Text);
                newStat.Name = name_tbx.Text;
                newStat.Longitude = double.Parse(long_tbx.Text);
                newStat.Latitude= double.Parse(lat_tbx.Text);
                newStat.Adress = adress_tbx.Text;
                bl.AddStation(newStat);
                this.Close();
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                

            }
        }
    }
}
