using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DalApi
{
   public interface IDAL
   {
        #region Bus Function
        void AddBus(Bus bus);
        void RemoveBus(int license);
        void UpdateBus(Bus bus);
        Bus GetBus(int license);
        IEnumerable<Bus> GetAllBuses(Func<Bus, bool> predicate = null);
        IEnumerable<Bus> GetAllBuses();

        #endregion

        #region Line Function
        void AddLine(Line line);
        void RemoveLine(int id);
        void UpdateLine(Line line);
        Line GetLine(int id);
        IEnumerable<Line> GetAllLine(Func<Line, bool> predicate = null);
        IEnumerable<Line> GetAllLines();

        #endregion

        #region Station Function
        void AddStation(Station station);
        void RemoveStation(int code);
        void UpdateStation(Station station);
        Station GetStation(int code);
        IEnumerable<Station> GetAllStation(Func<Station, bool> predicate = null);
        IEnumerable<Station> GetAllStations();

        #endregion

        #region Trip Function
        void AddTrip(Trip trip);
        void RemoveTrip(int id);
        void UpdateTrip(Trip trip );
        Trip GetTrip(int id);
        IEnumerable<Trip> GetAllTrip(Func<Trip, bool> predicate = null);
        IEnumerable<Trip> GetAlTrips();

        #endregion

        #region User Function
        void AddUser(User user);
        void RemoveUser(string name);
        void UpdateUser(User user);
        User GetUser(string name);
        IEnumerable<User> GetAllUser(Func<User, bool> predicate = null);
        IEnumerable<User> GetAllUsers();

        #endregion

        #region BusOnTrip Function
        void AddBusOnTrip(BusOnTrip bus);
        void RemoveBusOnTrip(int id);
        void UpdateBusOnTrip(BusOnTrip bus);
        BusOnTrip GetBusOnTrip(int id);
        IEnumerable<BusOnTrip> GetAllBusOnTrip(Func<BusOnTrip, bool> predicate = null);
        IEnumerable<BusOnTrip> GetAllBusOnTrips();

        #endregion

        #region AdjacentStations Function
        void AddAdjacentStations(AdjacentStations station);
        void RemoveAdjacentStationsp(int code);
        void UpdateAdjacentStations(AdjacentStations station);
        AdjacentStations GetAdjacentStations(int code);
        IEnumerable<AdjacentStations> GetAllAdjacentStations(Func<AdjacentStations, bool> predicate = null);
        IEnumerable<AdjacentStations> GetAllAdjacentStationss();

        #endregion

        #region LineTrip Function
        void AddLineTrip(LineTrip station);
        void RemoveLineTrip(int code);
        void UpdateLineTrip(LineTrip station);
        LineTrip GetLineTrip(int code);
        IEnumerable<LineTrip> GetAllLineTrip(Func<LineTrip, bool> predicate = null);
        IEnumerable<LineTrip> GetAllLineTrip();

        #endregion
        
        #region LineStation Function
        void AddLineStationp(LineStation station);
        void RemoveLineStation(int code);
        void UpdateLineStation(LineStation station);
        LineStation GetLineStationp(int code);
        IEnumerable<LineStation> GetAllLineStation(Func<LineStation, bool> predicate = null);
        IEnumerable<LineStation> GetAllLineStation();

        #endregion

    }
}
