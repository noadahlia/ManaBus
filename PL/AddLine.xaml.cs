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
        public AddLine(IBL _bl)
        {
            InitializeComponent();
            cbArea.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            bl = _bl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Line newLine = new BO.Line();
                newLine.Id = int.Parse(id_tbx.Text);
                newLine.Code = int.Parse(code_tbx.Text);
                newLine.FirstStation = int.Parse(first_tbx.Text);
                newLine.LastStation = int.Parse(last_tbx.Text);
                newLine.Area = (BO.Areas)cbArea.SelectedIndex;
                bl.AddLine(newLine);
                this.Close();
            }
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);


            }
        }
    }
}
