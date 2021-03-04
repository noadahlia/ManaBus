using BLAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Line.xaml
    /// </summary>
    public partial class Line : Window
    {
        IBL bl;
        BO.Line curLine;
        public Line(IBL _bl, BO.Line _curLine)
        {
            InitializeComponent();
            bl = _bl;
            curLine = _curLine;
            lineDetails.DataContext = curLine;
            cbArea.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            lineStationDataGrid.DataContext = bl.GetLine(curLine.Id).ListOfStations;
            
        }

        private void applyLine_btn_Click(object sender, RoutedEventArgs e)
        {
            lineDetails.DataContext = curLine;
            try
            {
                bl.UpdateLineInfos(curLine);
                MessageBox.Show("Saved!");
                this.Close();
            }
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void delLine_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Delete selected line?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
                return;
            try
            {
                if (curLine != null)
                {
                    bl.DeleteLine(curLine.Id);
                    MessageBox.Show("Deletion", "The line have been deletes succesfully ");
                    this.Close();

                }
            }
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadLineIdStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteStation_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.LineStation lsBO = ((sender as Button).DataContext as BO.LineStation);
                bl.DeleteLineStation(curLine.Id,lsBO.Code);
                lineStationDataGrid.DataContext = bl.GetLine(curLine.Id).ListOfStations;
            }
            catch(BO.BadLineIdStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void updateDistance_btn_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation lsBO = ((sender as Button).DataContext as BO.LineStation);
            Distance win = new Distance(lsBO);
            win.Closing += WinUpdateDistance_Closing;
            win.ShowDialog();

        }

        private void WinUpdateDistance_Closing(object sender, CancelEventArgs e)
        {
            BO.LineStation lsBO = (sender as Distance).curLs;
            MessageBoxResult res = MessageBox.Show("Update distance for selected station?", "Verification", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (res == MessageBoxResult.OK)
            {
                try
                {
                    double newDist = double.Parse((sender as Distance).tb_value.Text);
                    bl.UpdateStationDistanceToNext(lsBO, newDist);
                    lineStationDataGrid.DataContext = bl.GetLine(curLine.Id).ListOfStations;

                }
                catch (BO.BadLineIdStationIDException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                return;
            }

        }
    }
}
