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
    /// Logique d'interaction pour Station.xaml
    /// </summary>
    public partial class Station : Window
    {
        IBL bl;
        BO.Station curStat;
        public Station(IBL _bl, BO.Station _curStat)
        {
            InitializeComponent();
            bl = _bl;
            curStat = _curStat;
            statDetails.DataContext = curStat;
            lineListDataGrid.DataContext = curStat.ListOfLines;
            lineListDataGrid.IsReadOnly = true;
        }

        private void applyStat_btn_Click(object sender, RoutedEventArgs e)
        {
            statDetails.DataContext = curStat;
            try
            {
                bl.UpdateStationInfos(curStat);
                MessageBox.Show("Saved!");
                this.Close();
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void delStat_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Delete selected station?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
                return;
            try
            {
                if (curStat != null)
                {
                    bl.DeleteStation(curStat.Code);
                    
                    this.Close();
                    
                }
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadLineIdStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

       
    }
}
