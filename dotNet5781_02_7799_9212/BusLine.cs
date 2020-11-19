using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class BusLine
    {
        private List<BusLineStation> stations;
        public List<BusLineStation> STATIONS
        {
            get { return stations; }
            set { /*nothing*/ }
        }

        private int busLine;
        public int BUSLINE { get => busLine; set => busLine = value; }

        private BusLineStation firstS, lastS;
        public BusLineStation FIRST { get => firstS; set => firstS = value; }
        public BusLineStation LAST { get => lastS; set => lastS = value; }

        private string area;
        internal string Area { get => area; set => area = value; }

        BusLine() { /*nothing*/}
        BusLine(int id, BusLineStation f, BusLineStation l, zone a)
        {
            busLine = id;
            firstS = f;
            lastS = l;
            area = a;
            stations.Add(firstS);
            stations.Add(lastS);
        }

        public override string ToString()
        {
            string tmp1 = "Line N°: " + busLine.ToString() + "Area: " + area.ToString() + "\nStations:";
            string tmp2="";
            foreach (BusLineStation st in stations)
            {
                tmp2 = tmp2 + st.ToString();
            }
            return tmp1 + tmp2;
        }

        public bool Search(BusLineStation stat)
        {
            foreach (BusLineStation st in stations)
            {
                if (st == stat) //will use IComparable of BusLineStation
                    return true;
            }
            return false;
        }

        public void AddStation(BusLineStation stat, BusLineStation before)
        {
            if (before.BSK == 0) //if the user wants to add a new first station
            {
                this.firstS = stat;
                this.stations.Insert(0, stat);
            }
            else if(before.BSK==lastS.BSK) //if the user wants to add a new last station
            {
                this.lastS = stat;
                this.stations.Add(stat);
            }
            else // if the user wants to add a new station in the line
            {
                int index = stations.IndexOf(stat); 
                this.stations.Insert(index, stat);
            }
        }

        public void DeleteStation(BusLineStation stat)
        {
            if (stat == FIRST)
            {
                stations.Remove(stat);
                FIRST = stations[0]; //returns the new first station
            }
            else if (stat == LAST)
            {
                stations.Remove(stat);
                int size = stations.Count;
                LAST = stations[size - 1];
            }
            else
            {
                stations.Remove(stat);
            }
        }

        public double CalcDistance(BusLineStation s1, BusLineStation s2)
        {
            double x1 = s1.Latitude;
            double x2 = s2.Latitude;
            double y1 = s1.Longitude;
            double y2 = s2.Longitude;

            return Math.Sqrt((y2 - y1)* (y2 - y1)  + (x2 - x1)* (x2 - x1)); // to calculate te distance between two points

        }

        public int TravelTime(BusLineStation from, BusLineStation to) //?????
        {
            return 0;
        }

        public BusLine SubTravel(BusLineStation from, BusLineStation to)
        {
            BusLine subLine = new BusLine(this.busLine, from, to, this.area); // 2 lignes avec le mm id ?!
            return subLine;
        }




    }
}
