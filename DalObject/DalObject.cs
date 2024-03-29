﻿using System;
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
        #region singelton
        static readonly DalObject instance = new DalObject();
        static DalObject() { }// static ctor to ensure instance init is done just before first usage
        DalObject() { } // default => private
        public static DalObject Instance { get => instance; }// The public Instance property to use
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

        public void RefuelBus(Bus bus)
        {
            DO.Bus bu = DataSource.ListBus.Find(b => b.LicenseNum == bus.LicenseNum && b.IsActive == true);
            if (bu != null)
            {
                bu.FuelRemain = 1200;
            }
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus id: {bus.LicenseNum}");
        }
       public void RefreshBus(Bus bus)
        {
            DO.Bus bu = DataSource.ListBus.Find(b => b.LicenseNum == bus.LicenseNum && b.IsActive == true);
            if (bu != null)
            {
                bu.FromDate = DateTime.Now;
                bu.TotalTrip = 0;
            }
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus id: {bus.LicenseNum}");
        }

        public void UpdateBus(Bus bus)
        {
            DO.Bus bu = DataSource.ListBus.Find(b => b.LicenseNum == bus.LicenseNum && b.IsActive == true);

            if (bu != null)
            {
                DataSource.ListBus.Remove(bu);
                DataSource.ListBus.Add(bus.Clone());
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
                   where bus.IsActive == true
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
        public void UpdateStation(Station station)
        {
            DO.Station st = DataSource.ListStation.Find(l => l.Code == station.Code && l.IsActive == true);

            if (st != null)
            {
                DataSource.ListStation.Remove(st);
                DataSource.ListStation.Add(station.Clone());
            }
            else
                throw new DO.BadStationIdException(station.Code, $"bad station id: {station.Code}");
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
                   where station.IsActive == true
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
            DO.Line line = DataSource.ListLine.Find(l => l.Id == id && l.IsActive == true);

            if (line != null)
            {
                line.IsActive = false;
            }
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        public void UpdateLine(Line line)
        {
            DO.Line li = DataSource.ListLine.Find(l => l.Id == line.Id && l.IsActive == true);

            if (li != null)
            {
             
                DataSource.ListLine.Remove(li);
                DataSource.ListLine.Add(line.Clone());
            }
            else
                throw new DO.BadLineIdException(line.Code, $"bad line id: {line.Code}");
        }
        public Line GetLine(int id)
        {
            DO.Line line = DataSource.ListLine.Find(l => l.Id == id && l.IsActive == true);

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
                   where line.IsActive == true
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
            public bool LogInVerify(User user)
            {
            DO.User us = DataSource.ListUser.Find(u => u.UserName == user.UserName);
            if (us != null)
            {
                if (us.Password == user.Password)
                {
                   
                    return true; 
                }
                else
                    throw new DO.BadUserIdException(user.Password, $"wrong password:{user.UserName}");
            }
            else
                throw new DO.BadUserIdException(user.UserName, $"bad user id: {user.UserName}");
            }

        public bool isWorker(User user)
        {
            bool worker;
            DO.User us = DataSource.ListUser.Find(u => u.UserName == user.UserName);
            worker = us.Worker;
            return worker;
        }

        #endregion

        #region LineStation Function
        public IEnumerable<DO.LineStation> GetLineStation(Predicate<DO.LineStation> predicate)
        {

            return from ls in DataSource.ListLineStation
                   where predicate(ls)
                   select ls.Clone();
        }
        public void AddLineStation(int linID, int statID,int prev, int next)
        {
            if (DataSource.ListLineStation.FirstOrDefault(ls => (ls.LineId == linID && ls.Station == statID)) != null)
                throw new DO.BadLineIdStationIDException(linID, statID, "line ID already arrives at station ID");
            DO.LineStation linsta = new DO.LineStation() { LineId = linID, Station = statID, 
                PrevStation = prev, NextStation = next };
            DataSource.ListLineStation.Add(linsta);
            AddAdjacentStation(linsta.Station, linsta.NextStation);
        }

        public LineStation GetLS(int lineID, int stationID)
        {
            DO.LineStation linsta = DataSource.ListLineStation.Find(ls => ls.LineId == lineID && ls.Station == stationID && ls.IsActive == true);

            if (linsta != null)
                return linsta;
            else
                throw new DO.BadLineIdStationIDException(lineID,stationID);
        }



        public void RemoveLineStation(int linID, int statID)
        {
            DO.LineStation linsta = DataSource.ListLineStation.Find(ls => (ls.LineId == linID && ls.Station == statID&&ls.IsActive));

            if (linsta != null)
            {
                linsta.IsActive = false;
            }
            else
                throw new DO.BadLineIdStationIDException(linID, statID, "Not found LineStation ID");
        }
        public void DeleteLineFromAllStations(int linID)
        {
            foreach(LineStation ls in DataSource.ListLineStation)
            {
                if (ls.LineId == linID && ls.IsActive)
                    RemoveLineStation(ls.LineId, ls.Station); ;
            }
        }

        public void DeleteStationFromAllLines(int statID)
        {
            //Passer kav kav si j'ai la stat dans le kav alors je regarde qui est son prev et je maj le pointeur
            foreach(Line line in DataSource.ListLine)
            {
                if(line.IsActive)
                    foreach(LineStation ls in DataSource.ListLineStation)
                {
                    if (ls.LineId==line.Id && ls.Station == statID && ls.IsActive)
                    {
                        if (ls.PrevStation == 1) {
                            //if it's a departure station
                            LineStation next = GetLS(line.Id, ls.NextStation);
                            next.PrevStation = 1;
                            RemoveAdjacentStation(ls.PrevStation, ls.Station);
                            RemoveAdjacentStation(ls.Station, ls.NextStation);
                            RemoveLineStation(ls.LineId, ls.Station);
                            AddAdjacentStation(1,next.Station);
                            line.FirstStation = next.Station;

                        }
                        else if (ls.NextStation == 2) {
                            //if it's an arrival station
                            LineStation prev = GetLS(line.Id, ls.PrevStation);
                            prev.NextStation = 2;
                            RemoveAdjacentStation(ls.PrevStation, ls.Station);
                            RemoveAdjacentStation(ls.Station, ls.NextStation);
                            RemoveLineStation(ls.LineId, ls.Station);
                            AddAdjacentStation(prev.Station,2);
                            line.LastStation = prev.Station;

                        }
                        else
                        {
                            LineStation prev = GetLS(line.Id, ls.PrevStation);
                            prev.NextStation = ls.NextStation;
                            LineStation next = GetLS(line.Id, ls.NextStation);
                            next.PrevStation = ls.PrevStation;
                            RemoveAdjacentStation(ls.PrevStation, ls.Station);
                            RemoveAdjacentStation(ls.Station, ls.NextStation);
                            RemoveLineStation(ls.LineId, ls.Station);
                            AddAdjacentStation(prev.Station, next.Station);

                        }
                    }
                }
            }

        }
        #endregion

        #region AdjacentStation Functions

        public void AddAdjacentStation(int station1, int station2)
        {
            Random r = new Random();
            AdjacentStations adjStat = new AdjacentStations
            {
                Station1 =station1,
                Station2 = station2,
                Distance = r.Next(3000, 10000),
            };
            adjStat.Time = TimeSpan.FromMinutes(adjStat.Distance / 1160);

            DataSource.ListAdjacentStations.Add(adjStat);
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjStation(Predicate<DO.AdjacentStations> predicate)
        {
            return from adjs in DataSource.ListAdjacentStations
                   where predicate(adjs)
                   select adjs.Clone();

        }

        public AdjacentStations GetAdjacentStations(int station1, int station2)
        {
            
                DO.AdjacentStations adjs = DataSource.ListAdjacentStations.Find(ads => ads.Station1 == station1 && ads.Station2 == station2 && ads.IsActive);
                return adjs;
            
    
        }

        public void RemoveAdjacentStation(int station1, int station2)
        {
            DO.AdjacentStations adjs = DataSource.ListAdjacentStations.Find(ads => ads.Station1 == station1 && ads.Station2 == station2 && ads.IsActive);

            if (adjs!=null)
            {
                adjs.IsActive = false;
            }
        }

        public void UpdateAdjacentStations(int station1, int station2, double distance)
        {
            DO.AdjacentStations adjs = DataSource.ListAdjacentStations.Find(ads => ads.Station1 == station1 && ads.Station2 == station2 && ads.IsActive);
            DO.AdjacentStations updatedAdjs;

            if (adjs != null)
            {
                updatedAdjs = adjs;
                updatedAdjs.Distance = distance;
                updatedAdjs.Time= TimeSpan.FromMinutes(updatedAdjs.Distance / 1160);
                DataSource.ListAdjacentStations.Remove(adjs);
                DataSource.ListAdjacentStations.Add(updatedAdjs.Clone());

            }          

        }
        
        #endregion

        #region LineTrip Function
        public void AddLineTrip(LineTrip lineTrip)
        {
              if (DataSource.ListLineTrip.FirstOrDefault(t => t.LineId == lineTrip.LineId) != null)
                throw new DO.BadLineTripIdException(lineTrip.LineId, "Duplicate LineTrip ID");
            DataSource.ListLineTrip.Add(lineTrip.Clone());
        }

        public void RemoveLineTrip(int id)
        {
            DO.LineTrip lineTrip = DataSource.ListLineTrip.Find(t => t.LineId == id && t.IsActive == true);

            if (lineTrip != null)
            {
                lineTrip.IsActive = false;
            }
            else
                throw new DO.BadTripIdException(id, $"bad lineTrip id: {id}");
        }

        public void UpdateLineTrip(LineTrip Ltrip)
        {
            DO.LineTrip lineT = DataSource.ListLineTrip.Find(t => t.LineId == Ltrip.LineId && t.IsActive == true);

            if (lineT != null)
            {
                DataSource.ListLineTrip.Remove(lineT);
                DataSource.ListLineTrip.Add(lineT.Clone());
            }
            else
                throw new DO.BadLineTripIdException(lineT.LineId, $"bad trip id: {lineT.LineId}");
        }

        public LineTrip GetLineTrip(int id, TimeSpan now)
        {
            DO.LineTrip lineT = DataSource.ListLineTrip.Find(t => t.LineId == id && t.IsActive == true && t.StartAt <= now && t.FinishAt >= now);

            if (lineT != null)
                return lineT.Clone();
            else
                throw new DO.BadLineTripIdException(id, $"bad trip id: {id}");
        }

        public IEnumerable<LineTrip> GetAllLineTrip(Func<LineTrip, bool> predicate = null)
        {
            if (predicate == null)
            {
                return from lTrip in DataSource.ListLineTrip
                       where lTrip.IsActive == true
                       select lTrip.Clone();
            }
            else
            {
                return from lTrip in DataSource.ListLineTrip
                       where lTrip.IsActive == true
                       where predicate(lTrip)
                       select lTrip.Clone();
            }
        }

        public IEnumerable<LineTrip> GetAllLineTrip()
        {
            return from lTrip in DataSource.ListLineTrip
                   select lTrip.Clone();
        }

        public IEnumerable<User> GetAllUsers()
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

        #endregion






    }
}