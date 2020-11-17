using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    enum zone { General, North, South, Center, Jerusalem };
    class BusLine
    {
        private List<BusStation> stations;
        public List<BusStation> STATIONS
        {
            get { return stations; }
            set { /*nothing*/ }
        }

        private int busLine;
        public int BUSLINE { get => busLine; set => busLine = value; }

        private BusStation firstS, lastS;
        public BusStation FIRST { get => firstS; set => firstS = value; }
        public BusStation LAST { get => lastS; set => lastS = value; }

        private zone area;
        internal zone Area { get => area; set => area = value; }

        BusLine() { /*nothing*/}
        BusLine(int id, BusStation f, BusStation l, zone a)
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
            Console.WriteLine("Line N°:{0}  Area:{1} " , busLine,area);
            Console.WriteLine("Stations:");
            foreach(BusStation st in stations)
            {
                st.ToString();
            }
        }

        public bool Search(BusStation stat)
        {
            foreach (BusStation st in stations)
            {
                if (st == stat) //will use IComparable of BusStation
                    return true;
            }
            return false;
        }

        public void AddStation(BusStation stat, BusStation before)
        {
            if (before.BUSTATIONKEY == 0) //if the user wants to add a new first station
            {
                this.firstS = stat;
                this.stations.Insert(0, stat);
            }
            else if(before.BUSTATIONKEY==lastS.BUSTATIONKEY) //if the user wants to add a new last station
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

        public void DeleteStation(BusStation stat)
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

        public double CalcDistance(BusStation s1, BusStation s2)
        {
            int x1 = s1.LATITUDE;
            int x2 = s2.LATITUDE;
            int y1 = s1.LONGITUDE;
            int y2 = s2.LONGITUDE;

            return Math.Sqrt((y2 - y1) ^ 2 + (x2 - x1) ^ 2);

        }

        public DateTime TravelTime(BusStation from, BusStation to)
        {
            DateTime totalTime;
            // à poursuivre...
        }



    }
}
