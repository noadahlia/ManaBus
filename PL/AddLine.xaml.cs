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
    /// Interaction logic for AddLine.xaml
    /// </summary>
    public partial class AddLine : Window
    {
        IBL bl;
        List<BO.Station> lstStat = new List<BO.Station>();
        public AddLine(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            cbArea.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            stationsDataGrid.DataContext = bl.GetAllStations();
            stationsDataGrid.IsReadOnly = true;
           


            bl = _bl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstStat.Count < 2)
                    MessageBox.Show("The line must contains at least 2 stations", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {

                    BO.Line newLine = new BO.Line();
                    newLine.Id = int.Parse(id_tbx.Text);
                    newLine.Code = int.Parse(code_tbx.Text);
                    newLine.Area = (BO.Areas)cbArea.SelectedIndex;

                    //Create the first station of the line
                    bl.AddLineStation(newLine.Id, lstStat[0].Code, 1, lstStat[1].Code);
                    newLine.FirstStation = lstStat[0].Code;
                    //Create the last station of the line
                    bl.AddLineStation(newLine.Id, lstStat.Last().Code, lstStat[lstStat.Count-2].Code, 2);
                    newLine.LastStation = lstStat.Last().Code;


                    //Create the other stations
                    for (int i = 1; i < lstStat.Count-1; i++)
                    {
                        bl.AddLineStation(newLine.Id, lstStat[i].Code, lstStat[i - 1].Code, lstStat[i + 1].Code);
                    }


                    bl.AddLine(newLine);
                    this.Close();
                }
            }
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnAddStation_Click(object sender, RoutedEventArgs e)
        {
            BO.Station selectedStat = (sender as Button).DataContext as BO.Station;
            newlinestationsDataGrid.Items.Add(selectedStat);          
            lstStat.Add(selectedStat);
            RefreshAllNotAddedStations();
        }

        private void btnRemoveStation_Click(object sender, RoutedEventArgs e)
        {
            BO.Station selectedStat = (sender as Button).DataContext as BO.Station;
            newlinestationsDataGrid.Items.Remove(selectedStat);
            lstStat.Remove(selectedStat);
            RefreshAllNotAddedStations();
        }

        private void RefreshAllNotAddedStations()
        {
            stationsDataGrid.DataContext = bl.GetAllStations().Where(s1 => lstStat.All(s2 => s2.Code != s1.Code)).ToList();

        }
    }
}
