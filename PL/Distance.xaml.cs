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
using BO;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Distance.xaml
    /// </summary>
    public partial class Distance : Window
    {
        public BO.LineStation curLs;
        public Distance(BO.LineStation _curLs)
        {
            InitializeComponent();
            curLs = _curLs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tb_value_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_value.Text = "";
        }
    }
}
