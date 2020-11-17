using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class BuStation
    {
        public BuStation(int key,double lat,double lon,string name)
        {
            Bus_Station_Key = key; 
            Latitude=lat;
            Longitude=lon;
            Station_Name = name;
        }
        int Bus_Station_Key;
        public double Latitude;
        double Longitude;
        string Station_Name;

    }
}




