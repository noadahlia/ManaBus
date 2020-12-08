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
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_02_7799_9212;


namespace dotNet5781_03A_7799_9212
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinesList busLines = new LinesList();

        public MainWindow()
        {

            InitializeComponent();
            Random r = new Random();
            List<BusLineStation> allStations = new List<BusLineStation>(); //Contains all the stations in the program

            /* Create 40 stations */
            for (int i = 0; i < 40; i++)
            {
                BusLineStation newSt = new BusLineStation(r.Next(300), r.Next(30), r.Next(100000, 999999), r.Next(31, 33) + r.NextDouble(), r.Next(34, 36) + r.NextDouble(), "station" + i);
                allStations.Add(newSt);
            }

            /* Create 10 lists of stations to 10 new lines */
            for (int i = 0; i < 15; i++) // the loop will execute 10 times the code to create our 10 lines
            {
                List<BusLineStation> lst = new List<BusLineStation>(); // an object from BusLine class has to have a List of stations, so we create it
                for (int j = 0; j < 9; j++)
                { //every line has to stop at 1à stations
                    lst.Add(allStations[r.Next(0, 39)]); //so the loop with j add to the list 10 stations from the list AllStations
                }

                BusLine newLine = new BusLine(r.Next(1, 1000), lst, r.Next(1, 6)); // then we can create 10 different lines and every time that the loop for 
                                                                                   // increases i by 1, a new line is created and added to our LineList collection

                busLines.AddLine(newLine);
            }
                
            this.cbBusLines.ItemsSource = busLines;
            this.cbBusLines.DisplayMemberPath = "BUSLINE";
            this.cbBusLines.SelectedIndex = 0;
            //ShowBusLine


         }
        private BusLine currentDisplayBusLine;//8

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLine).BUSLINE);
        
        }
        
        private void ShowBusLine(int index)
        {
            currentDisplayBusLine = busLines[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.STATIONS;
        }

    }
}
