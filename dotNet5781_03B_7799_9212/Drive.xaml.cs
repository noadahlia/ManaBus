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
using dotNet5781_01_7799_9212;

namespace dotNet5781_03B_7799_9212
{
    /// <summary>
    /// Logique d'interaction pour Drive.xaml
    /// </summary>
    public partial class Drive : Window
    {
        Bus selBus;
         public Drive(Bus selectedItem)
        {
            InitializeComponent();
            selBus = selectedItem;
            this.tbKM.Focus();
            
        }

        private void tbKM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               
                int travelKM = int.Parse(tbKM.Text);
                if (isReady(travelKM, selBus.KM_C, selBus.FUEL))
                {
                    selBus.KM_C += travelKM;
                    selBus.FUEL -= travelKM; 
                    MessageBox.Show("Saved travel");
                }
                else
                {
                    if (selBus.KM_C - travelKM > 20000)
                        MessageBox.Show("The kilmetrage is upper 20000 km. Please send the bus to refresh.",
                            "The bus can't travel");
                   else if (selBus.FUEL - travelKM < 0)
                        MessageBox.Show("The fuel level is low. Please send the bus to refueling.",
                            "The bus can't travel");
                   
                    else
                    {
                        MessageBox.Show("The last refresh is over a year ago. Please send the bus to refresh.",
                           "The bus can't travel");
                    }
                }
               
                this.Close();
            }
                
        }

        bool isReady(int km,int b_km, int b_fuel)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = selBus.lastRefresh;
            TimeSpan gap = d1 - d2;
            if (b_km - km <= 20000 && b_fuel - km >= 0 && gap.TotalDays < 365)
                return true;
            else
            {          
                return false;
            }
        }

      
    }
}
