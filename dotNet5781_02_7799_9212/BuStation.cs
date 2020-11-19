using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class BuStation
    {

        public BuStation(int key, double lat, double lon, string name)
        {
            Bus_Station_Key = key;
            Latitude = lat;
            Longitude = lon;
            Station_Name = name;
        }

        private int Bus_Station_Key;
        public int BSK
        {
            get { return Bus_Station_Key; }
            set 
            {
                if (value.ToString().Length!=6)
                    throw new ArgumentOutOfRangeException("The Bus Station Key must be a number with 6 digits");
                Bus_Station_Key = value;
            }
        }
        
        private double Latitude;
        public double LATITUDE 
        {
            get { return Latitude; }
            set
            {
                if(value < 31 || value > 33.3)
                    throw new ArgumentOutOfRangeException("The Latitude must be between 31 and 33.3 degrees");
                Latitude = value;
            }
        }
        
        private double Longitude;
        public double LONGITUDE
        {
            get { return Longitude; }
            set
            {  
            if (value< 34.3 || value  < 35.5)
                    throw new ArgumentOutOfRangeException("The Longitude must be between 34.3 and 35.5 degrees");
                Longitude = value;
            }
        }
       
        private string Station_Name;
        public string SNAME
        { get => Station_Name; set => Station_Name = value; }

        public override string ToString()
        {
            return "Bus Station Code: " + Bus_Station_Key.ToString() + ", " + Latitude.ToString() + "°N " + Longitude.ToString() + "°E";
        }

    }
}




