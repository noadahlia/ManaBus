using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DL;
using DO;


namespace DL
{
    sealed class DLXML : IDAL    //internal
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string busPath = @"BusXml.xml"; //XElement

        string stationPath = @"StationXml.xml"; //XMLSerializer
        string linePath = @"LineXml.xml"; //XMLSerializer
        string userPath = @"UserXml.xml"; //XMLSerializer
        string lineTripPath = @"LineTripPathXml.xml"; //XMLSerializer
        string busOnTripPath = @"BusOnTripXml.xml"; //XMLSerializer
        string lineStationPath = @"LineStationXml.xml"; //XMLSerializer
        string adjacentStationsPath = @"AdjacentStationsXml.xml"; //XMLSerializer
        string tripPath = @"TripXml.xml"; //XMLSerializer



        #endregion

        #region Bus
        public DO.Bus GetBus(int id)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            Bus b = (from bus in busRootElem.Elements()
                     where int.Parse(bus.Element("LicenseNum").Value) == id
                     select new Bus()
                     {
                         LicenseNum = Int32.Parse(bus.Element("LicenseNum").Value),
                         FromDate = DateTime.Parse(bus.Element("Date").Value),
                         TotalTrip = double.Parse(bus.Element("TotalTrip").Value),
                         FuelRemain = double.Parse(bus.Element("FuelRemain").Value),
                         Status = (BusStatus)Enum.Parse(typeof(BusStatus), bus.Element("BusStatus").Value),
                         IsActive = bool.Parse(bus.Element("IsActive").Value),
                     }
                        ).FirstOrDefault();

            if (b == null)
                throw new DO.BadBusIdException(id, $"bad bus License Number: {id}");

            return b;
        }
        public IEnumerable<DO.Bus> GetAllBus()
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            return (from bus in busRootElem.Elements()
                    select new Bus()
                    {
                        LicenseNum = Int32.Parse(bus.Element("LicenseNum").Value),
                        FromDate = DateTime.Parse(bus.Element("Date").Value),
                        TotalTrip = double.Parse(bus.Element("TotalTrip").Value),
                        FuelRemain = double.Parse(bus.Element("FuelRemain").Value),
                        Status = (BusStatus)Enum.Parse(typeof(BusStatus), bus.Element("BusStatus").Value),
                        IsActive = bool.Parse(bus.Element("IsActive").Value),
                    }
                   );
        }
        public void AddBus(DO.Bus bus)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            XElement bus1 = (from b in busRootElem.Elements()
                             where int.Parse(b.Element("LicenseNum").Value) == bus.LicenseNum
                             select b).FirstOrDefault();

            if (bus1 != null)
                throw new DO.BadBusIdException(bus.LicenseNum, "Duplicate bus License Number");

            XElement busElem = new XElement("Bus",
                                   new XElement("LicenseNum", bus.LicenseNum),
                                   new XElement("Date", bus.FromDate),// reprendre d ici 
                                   new XElement("TotalTrip", bus.TotalTrip),
                                   new XElement("FuelRemain", bus.FuelRemain),
                                   new XElement("IsActive", bus.IsActive),
                                   new XElement("BusStatus", bus.Status));


            busRootElem.Add(busElem);

            XMLTools.SaveListToXMLElement(busRootElem, busPath);
        }
        public IEnumerable<DO.Bus> GetAllbusBy(Predicate<DO.Bus> predicate)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            return from bus in busRootElem.Elements()
                   let bus1 = new Bus()
                   {
                       LicenseNum = Int32.Parse(bus.Element("LicenseNum").Value),
                       FromDate = DateTime.Parse(bus.Element("Date").Value),
                       TotalTrip = double.Parse(bus.Element("TotalTrip").Value),
                       FuelRemain = double.Parse(bus.Element("FuelRemain").Value),
                       Status = (BusStatus)Enum.Parse(typeof(BusStatus), bus.Element("BusStatus").Value),
                       IsActive = bool.Parse(bus.Element("IsActive").Value),
                   }
                   where predicate(bus1)
                   select bus1;
        }

        public void RemoveBus(int LicenseNum)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            XElement bus = (from b in busRootElem.Elements()
                            where int.Parse(b.Element("ID").Value) == LicenseNum
                            select b).FirstOrDefault();

            if (bus != null)
            {
                bus.Remove(); //<==>   Remove per from personsRootElem

                XMLTools.SaveListToXMLElement(busRootElem, busPath);
            }
            else
                throw new DO.BadBusIdException(LicenseNum, $"bad bus license: {LicenseNum}");
        }

        public void UpdateBus(DO.Bus bus1)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            XElement bus = (from b in busRootElem.Elements()
                            where int.Parse(b.Element("ID").Value) == bus1.LicenseNum
                            select b).FirstOrDefault();

            if (bus != null)
            {
                bus.Element("License").Value = bus1.LicenseNum.ToString();
                bus.Element("Date").Value = bus1.FromDate.ToString();
                bus.Element("TotalTrip").Value = bus1.TotalTrip.ToString();
                bus.Element("FuelRemain").Value = bus1.FuelRemain.ToString();
                bus.Element("IsActive").Value = bus1.IsActive.ToString();
                bus.Element("BusStatus").Value = bus1.Status.ToString();


                XMLTools.SaveListToXMLElement(busRootElem, busPath);
            }
            else
                throw new DO.BadBusIdException(bus1.LicenseNum, $"bad bus license: {bus1.LicenseNum}");
        }
        //public void RefuelBus(Bus bus1)
        //{
        //    XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

        //    XElement bus = (from b in busRootElem.Elements()
        //                    where int.Parse(b.Element("ID").Value) == bus1.LicenseNum
        //                    select b).FirstOrDefault();
        //    if (bus != null)
        //    {
        //        bus.Element("FuelRemain").Value = 
        //    }
        //    else
        //        throw new DO.BadBusIdException(bus1.LicenseNum, $"bad bus license: {bus1.LicenseNum}");
        //}
        //public void RefreshBus(Bus bus)
        //{
        //    DO.Bus bu = DataSource.ListBus.Find(b => b.LicenseNum == bus.LicenseNum && b.IsActive == true);
        //    if (bu != null)
        //    {
        //        bu.FromDate = DateTime.Now;
        //        bu.TotalTrip = 0;
        //    }
        //    else
        //        throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus id: {bus.LicenseNum}");
        //}

        #endregion

        #region Line

        public void AddLine(Line line)
        {
            List<Line> ListLine = XMLTools.LoadListFromXMLSerializer<Line>(linePath);
            if (ListLine.FirstOrDefault(l => l.Id == line.Id) != null)
                throw new DO.BadLineIdException(line.Id, "Duplicate Line ID");


            if (GetLine(line.Id) == null)
                throw new DO.BadLineIdException(line.Id, "Missing Line ID");

            ListLine.Add(line); //no need to Clone()

            XMLTools.SaveListToXMLSerializer(ListLine, linePath);

        }

        public void RemoveLine(int id)
        {
            List<Line> ListLine = XMLTools.LoadListFromXMLSerializer<Line>(linePath);

            DO.Line line = ListLine.Find(l => l.Id == id);
            if (line != null)
                ListLine.Remove(line);
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");

            XMLTools.SaveListToXMLSerializer(ListLine, linePath);

        }

        public void UpdateLine(Line line)
        {
            List<Line> ListLine = XMLTools.LoadListFromXMLSerializer<Line>(linePath);

            DO.Line line1 = ListLine.Find(l => l.Id == line.Id);
            if (line1 != null)
            {
                ListLine.Remove(line1);
                ListLine.Add(line);
            }
            else
                throw new DO.BadLineIdException(line.Id, "Missing Line ID");

            XMLTools.SaveListToXMLSerializer(ListLine, linePath);
        }



        public Line GetLine(int id)
        {

            List<Line> ListLine = XMLTools.LoadListFromXMLSerializer<Line>(linePath);

            DO.Line line = ListLine.Find(l => l.Id == id);
            if (line != null)
                return line; //no need to Clone()
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }


        public IEnumerable<Line> GetAllLine(Func<Line, bool> predicate = null)
        {
            List<Line> ListLine = XMLTools.LoadListFromXMLSerializer<Line>(linePath);

            return from line in ListLine
                   where predicate(line)
                   select line; //no need to Clone()
        }

        public IEnumerable<Line> GetAllLines()
        {
            List<Line> ListLine = XMLTools.LoadListFromXMLSerializer<Line>(linePath);

            return from line in ListLine
                   select line; //no need to Clone()
        }
        #endregion
        #region Station
        public void AddStation(Station station)
        {
            List<Station> ListStation = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            if (ListStation.FirstOrDefault(l => l.Code == station.Code) != null)
                throw new DO.BadStationIdException(station.Code, "Duplicate Station Code");


            if (GetStation(station.Code) == null)
                throw new DO.BadStationIdException(station.Code, "Missing Station Code");

            ListStation.Add(station); //no need to Clone()

            XMLTools.SaveListToXMLSerializer(ListStation, stationPath);
        }

        public void RemoveStation(int code)
        {
            List<Station> ListStation = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);

            DO.Station station = ListStation.Find(s => s.Code == code);
            if (station != null)
                ListStation.Remove(station);
            else
                throw new DO.BadStationIdException(code, $"bad station id: {code}");

            XMLTools.SaveListToXMLSerializer(ListStation, stationPath);
        }

        public void UpdateStation(Station station)
        {
            List<Station> ListStation = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);

            DO.Station station1 = ListStation.Find(s => s.Code == station.Code);
            if (station1 != null)
            {
                ListStation.Remove(station1);
                ListStation.Add(station);
            }
            else
                throw new DO.BadStationIdException(station.Code, "Missing Station Code");

            XMLTools.SaveListToXMLSerializer(ListStation, stationPath);
        }

        public Station GetStation(int code)
        {
            List<Station> ListStation = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);

            DO.Station station = ListStation.Find(s => s.Code == code);
            if (station != null)
                return station; //no need to Clone()
            else
                throw new DO.BadStationIdException(code, $"bad station code: {code}");
        }

        public IEnumerable<Station> GetAllStation(Func<Station, bool> predicate = null)
        {
            List<Station> ListStation = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);

            return from station in ListStation
                   where predicate(station)
                   select station; //no need to Clone()
        }

        public IEnumerable<Station> GetAllStations()
        {
            List<Station> ListStation = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);

            return from station in ListStation
                   select station; //no need to Clone()
        }
        #endregion

        #region Trip
        public void AddTrip(Trip trip)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);
            if (ListTrip.FirstOrDefault(t => t.Id == trip.Id) != null)
                throw new DO.BadTripIdException(trip.Id, "Duplicate Trip Id");


            if (GetTrip(trip.Id) == null)
                throw new DO.BadTripIdException(trip.Id, "Missing Trip Id");

            ListTrip.Add(trip); //no need to Clone()

            XMLTools.SaveListToXMLSerializer(ListTrip, tripPath);
        }

        public void RemoveTrip(int id)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);

            DO.Trip trip = ListTrip.Find(t => t.Id == id);
            if (trip != null)
                ListTrip.Remove(trip);
            else
                throw new DO.BadTripIdException(id, $"bad station id: {id}");

            XMLTools.SaveListToXMLSerializer(ListTrip, tripPath);
        }

        public void UpdateTrip(Trip trip)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);

            DO.Trip trip1 = ListTrip.Find(t => t.Id == trip.Id);
            if (trip1 != null)
            {
                ListTrip.Remove(trip1);
                ListTrip.Add(trip);
            }
            else
                throw new DO.BadTripIdException(trip.Id, "Missing Trip Id");

            XMLTools.SaveListToXMLSerializer(ListTrip, tripPath);
        }

        public Trip GetTrip(int id)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);

            DO.Trip trip = ListTrip.Find(t => t.Id == id);
            if (trip != null)
                return trip; //no need to Clone()
            else
                throw new DO.BadTripIdException(id, $"bad station code: {id}");
        }

        public IEnumerable<Trip> GetAllTrip(Func<Trip, bool> predicate = null)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);

            return from trip in ListTrip
                   where predicate(trip)
                   select trip; //no need to Clone()
        }

        public IEnumerable<Trip> GetAlTrips()
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);

            return from trip in ListTrip
                   select trip; //no need to Clone()
        }
        #endregion

        #region User    
        public void AddUser(User user)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            if (ListUser.FirstOrDefault(u => u.UserName == user.UserName) != null)
                throw new DO.BadUserIdException(user.UserName, "Duplicate User UserName");


            if (GetUser(user.UserName) == null)
                throw new DO.BadUserIdException(user.UserName, "Missing User UserName");

            ListUser.Add(user); //no need to Clone()

            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }

        public void RemoveUser(string name)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);

            DO.User user = ListUser.Find(u => u.UserName == name);
            if (user != null)
                ListUser.Remove(user);
            else
                throw new DO.BadUserIdException(name, $"bad user userName: {name}");

            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }

        public void UpdateUser(User user)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);

            DO.User user1 = ListUser.Find(u => u.UserName == user.UserName);
            if (user1 != null)
            {
                ListUser.Remove(user1);
                ListUser.Add(user1);
            }
            else
                throw new DO.BadUserIdException(user.UserName, "Missing User UserName");

            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }

        public User GetUser(string name)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);

            DO.User user = ListUser.Find(u => u.UserName == name);
            if (user != null)
                return user; //no need to Clone()
            else
                throw new DO.BadUserIdException(name, $"bad station code: {name}");
        }

        public IEnumerable<User> GetAllUser(Func<User, bool> predicate = null)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);

            return from user in ListUser
                   where predicate(user)
                   select user; //no need to Clone()
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);

            return from user in ListUser
                   select user; //no need to Clone()
        }

        public IEnumerable<Bus> GetAllBuses(Func<Bus, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            throw new NotImplementedException();
        }

        public void RefuelBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public void RefreshBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public bool LogInVerify(User user)
        {
            throw new NotImplementedException();
        }

        public bool isWorker(User user)
        {
            throw new NotImplementedException();
        }

        public void AddBusOnTrip(BusOnTrip bus)
        {
            throw new NotImplementedException();
        }

        public void RemoveBusOnTrip(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusOnTrip(BusOnTrip bus)
        {
            throw new NotImplementedException();
        }

        public BusOnTrip GetBusOnTrip(int id, TimeSpan start)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusOnTrip> GetAllBusOnTrip(Func<BusOnTrip, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusOnTrip> GetAllBusOnTrips()
        {
            throw new NotImplementedException();
        }

        public void AddLineTrip(LineTrip station)
        {
            throw new NotImplementedException();
        }

        public void RemoveLineTrip(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineTrip(LineTrip station)
        {
            throw new NotImplementedException();
        }

        public LineTrip GetLineTrip(int id, TimeSpan now)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineTrip> GetAllLineTrip(Func<LineTrip, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineTrip> GetAllLineTrip()
        {
            throw new NotImplementedException();
        }

        public void AddLineStation(int lineID, int stationID, int index, int prevID, int nextID)
        {
            throw new NotImplementedException();
        }

        public void RemoveLineStation(int lineID, int stationID)
        {
            throw new NotImplementedException();
        }

        public void DeleteStationFromAllLines(int statID)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineFromAllStations(int linID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetLineStation(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public LineStation GetLS(int lineID, int stationID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdjacentStations> GetAllAdjStation(Predicate<AdjacentStations> predicate)
        {
            throw new NotImplementedException();
        }

        public AdjacentStations GetAdjacentStations(int station1, int station2)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
