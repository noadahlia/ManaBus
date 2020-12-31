using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_7799_9212
{
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
        public enum State { readyToGo, inProgress, onRefueling, inTreatment };
        public State buState;
        //public void Refueling(int km) // verifier si besoin de remplir le reservoir
        //{
        //    if (this.FUEL < km)
        //    {
        //        this.FUEL = 1200;
        //    }
        //    passer de l etat onRefueling a readyToGo
        //    }

        public void Refueling()
        {
            this.FUEL = 1200;
        }

        //public void dateTreatment() // verifier si besoin de tipoul par rap a annee
        //{
        //   
        //}

        public void dateTreatment()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = this.lastRefresh;
            TimeSpan gap = d1 - d2;
            if (gap.TotalDays > 365)
            {
                this.lastRefresh = DateTime.Now;
            }

            else
                if(this.KM_C>=20000)
            {
                this.KM_C = 0;
            }
        }

        //public void kmTreatment(int miles) // verifier si besoin de tipoul par rap a Km 
        //{
        //    int total =  + miles;
        //    if (total > 20000)
        //    {
        //        this.KM_C = 0;
        //    }
        //}

        public void drive(int dist) 
        {
            this.KM_C += dist;
            this.FUEL -= dist;
        }



        public override string ToString()
        {
            string str;
            CultureInfo provider = CultureInfo.InvariantCulture;

            str = "Bus id: " + this.B_ID + "\n";
            str += "Date of last refresh: " + this.lastRefresh.ToString("dd/MM/yyyy") + "\n";
            str += "Kilometrage: " + this.KM_C + "\n";
            str += "Fuel kilometers: " + this.FUEL;
            return str;
        }

        public override string ToString()
        {
            string str;
            CultureInfo provider = CultureInfo.InvariantCulture;

            str = "Bus id: " + this.B_ID + "\n";
            str += "Date of last refresh: " + this.lastRefresh.ToString("dd/MM/yyyy") + "\n";
            str += "Kilometrage: " + this.KM_C + "\n";
            str += "Fuel kilometers: " + this.FUEL;
            return str;
        }

    }
}
