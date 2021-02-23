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
            lineStationDataGrid.DataContext = bl.GetLine(curLine.Id).ListOfStations;
            
        }

        private void applyLine_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delLine_btn_Click(object sender, RoutedEventArgs e)
        {

        }




    }
}
