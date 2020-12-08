using System;

namespace dotNet5781_02_7799_9212
{
   public class BusLineStation : BuStation
    {


        public BusLineStation(int distance, int time, int Bsk, double Latitude, double Longitude, string Name) : base(Bsk, Latitude, Longitude, Name)
        {
            Station_Distance = distance;
            Travel_Time_From_Station = time;
        }
        private int Station_Distance;
        public int SD
        {
            get { return Station_Distance; }
            set
            {
                Station_Distance = value;
            }
        }
        private int Travel_Time_From_Station;
        public int TTFS
        {
            get { return Travel_Time_From_Station; }
            set
            {
                Travel_Time_From_Station = value;
            }
        }
         public override string ToString()
        { 
            TimeSpan travelTime = TimeSpan.FromMinutes(TTFS);
            return base.ToString()+"      "+travelTime ;
        }

    }
}
