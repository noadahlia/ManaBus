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
        void RefuelBus(Bus bus);
        void RefreshBus(Bus bus);

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
        void UpdateTrip(Trip trip);
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
        bool LogInVerify(User user);
        bool isWorker(User user);

        #endregion

        #region BusOnTrip Function
        void AddBusOnTrip(BusOnTrip bus);
        void RemoveBusOnTrip(int id);
        void UpdateBusOnTrip(BusOnTrip bus);
        BusOnTrip GetBusOnTrip(int id, TimeSpan start);
        IEnumerable<BusOnTrip> GetAllBusOnTrip(Func<BusOnTrip, bool> predicate = null);
        IEnumerable<BusOnTrip> GetAllBusOnTrips();

        #endregion

        #region LineTrip Function
        void AddLineTrip(LineTrip station);
        void RemoveLineTrip(int id);
        void UpdateLineTrip(LineTrip station);
        LineTrip GetLineTrip(int id, TimeSpan now);
        IEnumerable<LineTrip> GetAllLineTrip(Func<LineTrip, bool> predicate = null);
        IEnumerable<LineTrip> GetAllLineTrip();

        #endregion

        #region LineStation Function
        void AddLineStation(int lineID, int stationID, int index, int prevID, int nextID);
        void RemoveLineStation(int lineID, int stationID);
        //void UpdateLineStation(LineStation station);
        //LineStation GetLineStation(int code);
        void DeleteStationFromAllLines(int statID);
        void DeleteLineFromAllStations(int linID);

        IEnumerable<LineStation> GetLineStation(Predicate<DO.LineStation> predicate);
        LineStation GetLS(int lineID, int stationID);
    
    //IEnumerable<LineStation> GetAllLineStation();

    #endregion

    #region AdjacentStation
    IEnumerable<AdjacentStations> GetAllAdjStation(Predicate<DO.AdjacentStations> predicate);
    AdjacentStations GetAdjacentStations(int station1, int station2);

    #endregion

}
    
}
