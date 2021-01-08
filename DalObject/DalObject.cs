using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;
using DS;


namespace DAL
{
    sealed class DalObject : IDAL
    {
        //necessaire???
        #region singelton
        static readonly DalObject instance = new DalObject();
        static DalObject() { }// static ctor to ensure instance init is done just before first usage
        DalObject() { } // default => private
        public static DalObject Instance { get => instance; }// The public Instance property to use
        #endregion

        /* Implementation of CRUD functions
         * 
         * Remove Function: In order to keep a history of data, 
         *                  an object is not deleted but is out of service.
         */

        #region Bus Function
        public void AddBus(Bus bus)
        {
            if (DataSource.ListBus.FirstOrDefault(p => p.LicenseNum == bus.LicenseNum) != null)
                throw new DO.BadBusIdException(bus.LicenseNum, "Duplicate bus ID");
            DataSource.ListBus.Add(bus.Clone());
        }
        public void RemoveBus(int license)
        {
            DO.Bus bus = DataSource.ListBus.Find(b => b.LicenseNum == license && b.IsActive == true);

            if (bus != null)
            {
                bus.IsActive = false;
            }
            else
                throw new DO.BadBusIdException(license, $"bad bus id: {license}");
        }
        public void UpdateBus(Bus bus)
        {
            DO.Bus bu = DataSource.ListBus.Find(b => b.LicenseNum == bus.LicenseNum && b.IsActive == true);

            if (bu != null)
            {
                DataSource.ListBus.Remove(bu);
                DataSource.ListBus.Add(bu.Clone());
            }
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus id: {bus.LicenseNum}");

        }
        public DO.Bus GetBus(int license)
        {
            DO.Bus bus = DataSource.ListBus.Find(b => b.LicenseNum == license && b.IsActive == true);

            if (bus != null)
                return bus.Clone();
            else
                throw new DO.BadBusIdException(license, $"bad bus id: {license}");
        }
        public IEnumerable<Bus> GetAllBuses(Func<Bus, bool> predicate = null)
        {
            if (predicate == null)
            {
                return from bus in DataSource.ListBus
                       where bus.IsActive == true
                       select bus.Clone();


            }
            else
            {
                return from bus in DataSource.ListBus
                       where predicate(bus)
                       where bus.IsActive == true
                       select bus.Clone();
            }
        }
        public IEnumerable<Bus> GetAllBuses()
        {
            return from bus in DataSource.ListBus
                   select bus.Clone();
        }

        #endregion

        #region Station Function
        public void AddStation(Station station)
        {
            if (DataSource.ListStation.FirstOrDefault(s => s.Code == station.Code) != null)
                throw new DO.BadStationIdException(station.Code, "Duplicate station ID");
            DataSource.ListStation.Add(station.Clone());
        }
        public void RemoveStation(int id)
        {
            DO.Station station = DataSource.ListStation.Find(s => s.Code == id && s.IsActive == true);

            if (station != null)
            {
                station.IsActive = false;
            }
            else
                throw new DO.BadStationIdException(id, $"bad station id: {id}");
        }
        public void UpdateStation(Station Station)
        {
            DO.Station st = DataSource.ListStation.Find(l => l.Code == Station.Code && l.IsActive == true);

            if (st != null)
            {
                DataSource.ListStation.Remove(st);
                DataSource.ListStation.Add(st.Clone());
            }
            else
                throw new DO.BadStationIdException(Station.Code, $"bad station id: {Station.Code}");
        }
        public Station GetStation(int id)
        {
            DO.Station station = DataSource.ListStation.Find(s => s.Code == id && s.IsActive == true);

            if (station != null)
                return station.Clone();
            else
                throw new DO.BadStationIdException(id, $"bad station id: {id}");
        }
        public IEnumerable<Station> GetAllStation(Func<Station, bool> predicate = null)
        {
            if (predicate == null)
            {
                return from station in DataSource.ListStation
                       where station.IsActive == true
                       select station.Clone();
            }
            else
            {
                return from station in DataSource.ListStation
                       where station.IsActive == true
                       where predicate(station)
                       select station.Clone();
            }
        }
        public IEnumerable<Station> GetAllStations()
        {
            return from station in DataSource.ListStation
                   select station.Clone();
        }

        #endregion

        #region Line Function
        public void AddLine(Line line)
        {
            if (DataSource.ListLine.FirstOrDefault(l => l.Code == line.Code) != null)
                throw new DO.BadLineIdException(line.Code, "Duplicate line ID");
            DataSource.ListLine.Add(line.Clone());
        }
        public void RemoveLine(int id)
        {
            DO.Line line = DataSource.ListLine.Find(l => l.Code == id && l.IsActive == true);

            if (line != null)
            {
                line.IsActive = false;
            }
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        public void UpdateLine(Line line)
        {
            DO.Line li = DataSource.ListLine.Find(l => l.Code == line.Code && l.IsActive == true);

            if (li != null)
            {
                DataSource.ListLine.Remove(li);
                DataSource.ListLine.Add(li.Clone());
            }
            else
                throw new DO.BadLineIdException(line.Code, $"bad line id: {line.Code}");
        }
        public Line GetLine(int id)
        {
            DO.Line line = DataSource.ListLine.Find(l => l.Code == id && l.IsActive == true);

            if (line != null)
                return line.Clone();
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        public IEnumerable<Line> GetAllLine(Func<Line, bool> predicate = null)
        {
            if (predicate == null)
            {
                return from line in DataSource.ListLine
                       where line.IsActive == true
                       select line.Clone();
            }
            else
            {
                return from line in DataSource.ListLine
                       where line.IsActive == true
                       where predicate(line)
                       select line.Clone();
            }
        }
        public IEnumerable<Line> GetAllLines()
        {
            return from line in DataSource.ListLine
                   select line.Clone();
        }
        #endregion

        #region Trip Function
        public void AddTrip(Trip trip)
        {
            if (DataSource.ListTrip.FirstOrDefault(t => t.Id == trip.Id) != null)
                throw new DO.BadTripIdException(trip.Id, "Duplicate Trip ID");
            DataSource.ListTrip.Add(trip.Clone());
        }
        public void RemoveTrip(int id)
        {
            DO.Trip trip = DataSource.ListTrip.Find(t => t.Id == id && t.IsActive == true);

            if (trip != null)
            {
                trip.IsActive = false;
            }
            else
                throw new DO.BadTripIdException(id, $"bad trip id: {id}");
        }
        public void UpdateTrip(Trip trip)
        {
            DO.Trip li = DataSource.ListTrip.Find(t => t.Id == trip.Id && t.IsActive == true);

            if (li != null)
            {
                DataSource.ListTrip.Remove(li);
                DataSource.ListTrip.Add(li.Clone());
            }
            else
                throw new DO.BadTripIdException(trip.Id, $"bad trip id: {trip.Id}");
        }
        public Trip GetTrip(int id)
        {
            DO.Trip trip = DataSource.ListTrip.Find(t => t.Id == id && t.IsActive == true);

            if (trip != null)
                return trip.Clone();
            else
                throw new DO.BadTripIdException(id, $"bad trip id: {id}");
        }
        public IEnumerable<Trip> GetAllTrip(Func<Trip, bool> predicate = null)
        {
            if (predicate == null)
            {
                return from trip in DataSource.ListTrip
                       where trip.IsActive == true
                       select trip.Clone();
            }
            else
            {
                return from trip in DataSource.ListTrip
                       where trip.IsActive == true
                       where predicate(trip)
                       select trip.Clone();
            }
        }
        public IEnumerable<Trip> GetAlTrips()
        {
            return from trip in DataSource.ListTrip
                   select trip.Clone();
        }


        #endregion

        #region User Function   
        public void AddUser(User user)
        {
            if (DataSource.ListUser.FirstOrDefault(u => u.UserName == user.UserName) != null)
                throw new DO.BadUserIdException(user.UserName, "Duplicate user ID");
            DataSource.ListUser.Add(user.Clone());
        }
        public void RemoveUser(string name)
        {
            DO.User user = DataSource.ListUser.Find(u => u.UserName == name && u.IsActive == true);

            if (user != null)
            {
                user.IsActive = false;
            }
            else
                throw new DO.BadUserIdException(name, $"bad user name: {name}");
        }
        public void UpdateUser(User user)
        {
            DO.User us = DataSource.ListUser.Find(u => u.UserName == user.UserName && u.IsActive == true);

            if (us != null)
            {
                DataSource.ListUser.Remove(us);
                DataSource.ListUser.Add(us.Clone());
            }
            else
                throw new DO.BadUserIdException(user.UserName, $"bad user name: {user.UserName}");
        }
        public DO.User GetUser(string name)
        {
            DO.User user = DataSource.ListUser.Find(u => u.UserName == name && u.IsActive == true);

            if (user != null)
                return user.Clone();
            else
                throw new DO.BadUserIdException(name, $"bad user name: {name}");
        }
        public IEnumerable<User> GetAllUser(Func<User, bool> predicate = null)
        {
            if (predicate == null)
            {
                return from user in DataSource.ListUser
                       where user.IsActive == true
                       select user.Clone();
            }
            else
            {
                return from user in DataSource.ListUser
                       where user.IsActive == true
                       where predicate(user)
                       select user.Clone();
            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            return from user in DataSource.ListUser
                   select user.Clone();
        }

        #endregion


        //Pas finis 4 class a completer 

        #region BusOnTrip Function
        public void AddBusOnTrip(BusOnTrip bus)
        {
            if (DataSource.ListBusOnTrip.FirstOrDefault(b => b.Id == b.Id) != null)
                throw new DO.BadUserIdException(bus.Id, "Duplicate user ID");
            DataSource.ListBusOnTrip.Add(bus.Clone());
        }

        public void RemoveBusOnTrip(int id)
        {
            BusOnTrip trip = DataSource.ListBusOnTrip.Find(u => u.Id == id && u.IsActive == true);

            if (trip != null)
            {
                trip.IsActive = false;
            }
            else
                throw new DO.BadBusOnTripIdException(id, $"bad user name: {id}");
        }
        //public void UpdateBusOnTrip(User user)
        //{
        //    DO.BusOnTrip us = DataSource.ListUser.Find(u => u.UserName == user.UserName && u.IsActive == true);

        //    if (us != null)
        //    {
        //        DataSource.ListUser.Remove(us);
        //        DataSource.ListUser.Add(us.Clone());
        //    }
        //    else
        //        throw new DO.BadUserIdException(user.UserName, $"bad user name: {user.UserName}");
        //}
        //public DO.User GetUser(string name)
        //{
        //    DO.User user = DataSource.ListUser.Find(u => u.UserName == name && u.IsActive == true);

        //    if (user != null)
        //        return user.Clone();
        //    else
        //        throw new DO.BadUserIdException(name, $"bad user name: {name}");
        //}
        //public IEnumerable<User> GetAllUser(Func<User, bool> predicate = null)
        //{
        //    if (predicate == null)
        //    {
        //        return from user in DataSource.ListUser
        //               where user.IsActive == true
        //               select user.Clone();
        //    }
        //    else
        //    {
        //        return from user in DataSource.ListUser
        //               where user.IsActive == true
        //               where predicate(user)
        //               select user.Clone();
        //    }
        //}
        //public IEnumerable<User> GetAllUsers()
        //{
        //    return from user in DataSource.ListUser
        //           select user.Clone();
        //}

        #endregion
    }
}