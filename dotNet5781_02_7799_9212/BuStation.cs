using System;

namespace dotNet5781_02_7799_9212
{
    class BuStation
    {

        public BuStation(int key, double lat, double lon, string name)
        {

            try
            {
                if (key.ToString().Length != 6)
                {
                    throw new ArgumentException("The Bus Station Key must be a number with 6 digits");
                    //Bus_Station_Key = 0;
                }

                Bus_Station_Key = key;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                if (lat < 31 || lat > 33.3)
                {
                    throw new ArgumentException("The Latitude must be between 31 and 33.3 degrees");
                    //Latitude = 0.0;
                }
                Latitude = lat;
            }
            catch (ArgumentException ex2)
            {
                Console.WriteLine(ex2.Message);
            }

            try
            {
                if (lon < 34 || lon > 36)
                {
                    throw new ArgumentException("The Longitude must be between 34.3 and 35.5 degrees");
                    //  Longitude = 0.0;
                }

                Longitude = lon;
            }
            catch (ArgumentException ex3)
            {
                Console.WriteLine(ex3.Message);
            }
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




