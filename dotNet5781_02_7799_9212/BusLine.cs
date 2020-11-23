using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class BusLine : IComparable<BusLine>
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

        private EnumZone area { get; set; }

        private int travelTime { get; set; }
      

        public BusLine() { /*nothing*/}

        public BusLine(int id, List<BusLineStation> lst, int a)
        {
            try
            {
                if (id.ToString().Length > 3 || id.ToString().Length < 2)
                    throw new ArgumentException("Invalide number of line");
                busLine = id;
            }
            catch (ArgumentException exx)
            {
                Console.WriteLine(exx.Message);
            }

            stations = lst;
            area = (EnumZone)a;
            if (lst.Count != 0)
            {
                firstS = lst[0];
                lastS = lst[lst.Count - 1];
            }
            travelTime = TravelTime(FIRST, LAST);
           
        }

        public override string ToString()
        {
            string tmp1 = "Line N°: " + busLine.ToString() + " Area: " + area.ToString() + "\nStations:\n";
            string tmp2="";
            foreach (BusLineStation st in stations)
            {
                tmp2 = tmp2 + st.ToString()+"\n";
            }
            return tmp1 + tmp2;
        }

        public BusLineStation Find(int key)
        {

            try
            {
                foreach (BusLineStation st in stations)
                {
                    if (st.BSK == key)
                        return st;
                }
                    throw new ArgumentException("Doesn't exist");
            }

            catch (ArgumentException exp)
            {
                Console.WriteLine(exp.Message);
                return null;
            }         
  
        }

        public bool SearchByKey(int key)
        {
            try
            {
                foreach (BusLineStation item in stations)
                {
                    if (item.BSK == key)
                        return true;
                }
                throw new ArgumentException("Does'nt exist");
            }
            catch (ArgumentException ex3)
            {
                Console.WriteLine(ex3.Message);
                return false;
            }
           

        }

        public void AddFirstStation(BusLineStation input)
        {
            this.firstS = input;
            this.stations.Insert(0, input);
        }
        public void AddLastStation(BusLineStation input)
        {
            this.lastS = input;
            this.stations.Add(input);
        }
        public void AddMiddleStation(BusLineStation stat, BusLineStation before)
        {
            int index = stations.IndexOf(before); 
            this.stations.Insert(index, stat);
            
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
                LAST = stations[stations.Count];
            }
            else
            {
                stations.Remove(stat);
            }
        }

        public double CalcDistance(BusLineStation s1, BusLineStation s2)
        {
            double x1 = s1.LATITUDE;
            double x2 = s2.LATITUDE;
            double y1 = s1.LONGITUDE;
            double y2 = s2.LONGITUDE;

            return Math.Sqrt((y2 - y1)* (y2 - y1)  + (x2 - x1)* (x2 - x1)); // to calculate te distance between two points

        }

        public int TravelTime(BusLineStation from, BusLineStation to) 
        {
            int totalTime = 0;
            for (int i = stations.IndexOf(from); i<=stations.IndexOf(to); i++) //when i increase, we add the traveltime of the next station in the station list of this line
            {
                totalTime += stations[i].TTFS;
            }
            return totalTime;
        }

        public BusLine SubTravel(BusLineStation from, BusLineStation to)
        {
            BusLine subLine = new BusLine(); //create a virtual line (whithout any key or first station
                                            // it's just to collect the section of line between the two stations
            for(int i = stations.IndexOf(from); i <= stations.IndexOf(to); i++)
            {
                subLine.stations.Add(this.stations[i]);
            }
            subLine.FIRST = subLine.stations[0];
            subLine.LAST = subLine.stations[subLine.stations.Count - 1];
            return subLine;
        }

        public int CompareTo(BusLine other)
        {
            return this.travelTime.CompareTo(other.travelTime);
        }
    }
}
