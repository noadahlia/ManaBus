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
using System.Collections.ObjectModel;

namespace dotNet5781_03B_7799_9212
{
    /// <summary>
    /// Logique d'interaction pour InsertWin.xaml
    /// </summary>
    public partial class InsertWin : Window
    {
        ObservableCollection<Bus> busList = new ObservableCollection<Bus>();
        public InsertWin(ObservableCollection<Bus> in_lst)
        {
            InitializeComponent();
            busList = in_lst;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = (DateTime)this.datePicker1.SelectedDate;
            int id = int.Parse(this.id_res.Text);
            if (insert(id, date))
            {
                Bus newBus = new Bus(id, date);
                busList.Add(newBus);
                MessageBox.Show("New bus id = " + newBus.B_ID);
                
            }
            else
            {
                if (date.Year <= 2018)
                    MessageBox.Show("ERROR\nThe license must contains 7 diggits.");
                else
                    MessageBox.Show("ERROR\nThe license must contains 8 diggits.");
            }
            this.Close();
        }

        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = (DateTime)this.datePicker1.SelectedDate;
        }
        public bool insert(int license, DateTime dt)
        {
            if (license.ToString().Length != 8 && dt.Year >= 2018)
            {
                return false;
            }

            if (license.ToString().Length != 7 && dt.Year < 2018)
            {
                return false;
            }

            return true;
        }

  
    }
}
