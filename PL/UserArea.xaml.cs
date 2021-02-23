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
    /// Interaction logic for UserArea.xaml
    /// </summary>
    public partial class UserArea : Window
    {
        IBL bl;
        BO.User curUser;
        public UserArea()
        {
            InitializeComponent();
        }
        public UserArea(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            //curBus = _curBus;
            //busDetails.DataContext = curBus;
            //cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWin = new MainWindow();
            this.Close();
            mainWin.ShowDialog();
        }
    }
}
