using System;

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
            get => Bus_Station_Key;
            set => Bus_Station_Key = value;
        }

        private double Latitude;
        public double LATITUDE
        {
            get => Latitude;
            set => Latitude = value;
        }

        private double Longitude;
        public double LONGITUDE
        {
            get => Longitude;
            set => Longitude = value;
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




