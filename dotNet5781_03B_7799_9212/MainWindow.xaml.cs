using System;
using System.Collections.Generic;
using System.Globalization;
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
using dotNet5781_01_7799_9212;
using static dotNet5781_01_7799_9212.Program;
using System.Threading;


namespace dotNet5781_03B_7799_9212
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Bus> busList = new List<Bus>();
            #region createBus
            /*Create 8 random buses*/
            Random r = new Random();
            CultureInfo provider = CultureInfo.InvariantCulture;
            string in_date1, in_date2, in_date3;
            DateTime dt1, dt2, dt3;
            
            for (int i = 0; i < 4; i++)
            {
                 in_date1 = r.Next(1, 31) + "/" + r.Next(1, 13) + "/" + r.Next(1990, 2019);
                 dt1 = DateTime.ParseExact(in_date1, "d/M/yyyy", provider);
                 in_date3 = r.Next(1, 31) + "/" + r.Next(1, 12) + "/2020";
                 dt3 = DateTime.ParseExact(in_date3, "d/M/yyyy", provider);
                Bus bus = new Bus(r.Next(1000000, 10000000), dt1);
                bus.lastRefresh = dt3;
                busList.Add(bus);
            }
            for (int i = 0; i < 4; i++)
            {
                 in_date2 = r.Next(1, 31) + "/" + r.Next(1, 13) + "/" + r.Next(2019, 2021);
                 in_date3 = r.Next(1, 31) + "/" + r.Next(1, 12) + "/2020";
                 dt2 = DateTime.ParseExact(in_date2, "d/M/yyyy", provider);
                 dt3 = DateTime.ParseExact(in_date3, "d/M/yyyy", provider);
                Bus bus = new Bus(r.Next(10000000, 100000000), dt2);
                bus.lastRefresh = dt3;
                busList.Add(bus);

            }
            /*Create 3 special buses*/
            in_date1 = r.Next(1, 31) + "/" + r.Next(1, 13) + "/" + r.Next(1990, 2019);
            dt1 = DateTime.ParseExact(in_date1, "d/M/yyyy", provider);
            Bus b1 = new Bus(r.Next(10000000, 99999999), dt1);
            b1.lastRefresh = DateTime.ParseExact("12/12/2019", "dd/MM/yyyy", provider);
            busList.Add(b1);
            in_date1 = r.Next(1, 31) + "/" + r.Next(1, 13) + "/" + r.Next(1990, 2019);
            dt1 = DateTime.ParseExact(in_date1, "d/M/yyyy", provider);
            Bus b2 = new Bus(r.Next(10000000, 99999999), dt1);
            b2.KM_C = 19935;
            busList.Add(b2);
            in_date1 = r.Next(1, 31) + "/" + r.Next(1, 13) + "/" + r.Next(1990, 2019);
            dt1 = DateTime.ParseExact(in_date1, "d/M/yyyy", provider);
            Bus b3 = new Bus(r.Next(10000000, 99999999), dt1);
            b3.FUEL = 30;
            busList.Add(b3);

            #endregion

            this.cbBus.ItemsSource = busList;
            this.cbBus.DisplayMemberPath = "B_ID";
            this.cbBus.SelectedIndex = 0;

        }
   

        private void btn_insertClick(object sender, RoutedEventArgs e) {
            
        }



    }

    #region classBus
    public class Bus
    {
        private int b_id;
        public int B_ID
        {
            get { return b_id; }
            set { b_id = value; }
        }
        private int km_counter;
        public int KM_C
        {
            get { return km_counter; }
            set { km_counter = value; }
        }

        private int fuel_level;
        public int FUEL
        {
            get { return fuel_level; }
            set { fuel_level = value; }
        }

            public DateTime lastRefresh;
            public Bus(int id) { b_id = id; }
            public Bus(int id, DateTime date)
            {
                b_id = id;
                lastRefresh = date;
                km_counter = 0;
                fuel_level = 1200;
            }
            enum State { readyToGo, inProgress, onRefueling, inTreatment };
            private State buState;
            public void Refueling(int km) // verifier si besoin de remplir le reservoir
            {
                if (this.FUEL < km)
                {
                    this.FUEL = 1200;
                }
                //passer de l etat onRefueling a readyToGo
            }

            public void dateTreatment() // verifier si besoin de tipoul par rap a annee
            {
                DateTime d1 = DateTime.Now;
                DateTime d2 = this.lastRefresh;
                TimeSpan gap = d1 - d2;
                if (gap.TotalDays > 365)
                {
                    this.lastRefresh = DateTime.Now;
                }
            }

            public void kmTreatment(int miles) // verifier si besoin de tipoul par rap a Km 
            {
                int total = this.KM_C + miles;
                if (total > 20000)
                {
                    this.KM_C = 0;
                }
            }
            public bool insert(int license,DateTime dt)
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
        
        #endregion
        //public class 
        
    
}
    

    

