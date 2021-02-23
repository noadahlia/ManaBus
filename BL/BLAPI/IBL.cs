using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;


namespace BLAPI
{
    /// <summary>
    /// Definition of CRUD functions
    /// This constract will be used by PL layer and implemented by BL layer 
    /// </summary>
    public interface IBL
    {


        // La question à se poser c'est "quelles fonctions je vais avoir besoin depuis PL?"
        #region Bus

        void AddBus(BO.Bus bus);
        void RefuelBus(BO.Bus bus);
        void RefreshBus(BO.Bus bus);
        BO.Bus GetBus(int id);
        IEnumerable<BO.Bus> GetAllBuses();

        IEnumerable<BO.Bus> GetBusesBy(Predicate<BO.Bus> predicate);

        void UpdateBusInfos(BO.Bus bus);

        void DeleteBus(int id);

        #endregion

        #region Line
        void AddLine(BO.Line Line);

        BO.Line GetLine(int id);
        IEnumerable<BO.Line> GetAllLines();

        IEnumerable<BO.Line> GetLinesBy(Predicate<BO.Line> predicate);

        void UpdateLineInfos(BO.Line line);

        void DeleteLine(int id);

        #endregion

        #region Station
        void AddStation(BO.Station station);

        BO.Station GetStation(int id);
        IEnumerable<BO.Station> GetAllStations();

        IEnumerable<BO.Station> GetStationsBy(Predicate<BO.Station> predicate);

        void UpdateStationInfos(BO.Station station);

        void DeleteStation(int id);

        IEnumerable<BO.LineStation> GetAllStationsPerLine(int id);

        #endregion

        #region User Function
        void AddUser(User user);
        void DeleteUser(string name);
        void UpdateUserInfos(User user);
        User GetUser(string name);
        IEnumerable<User> GetUserBy(Predicate<User> predicate);
        IEnumerable<User> GetAllUsers();
        bool LogInVerify(User user);
        bool isWorker(User user);


        #endregion
        //IEnumerable<Line> ListArrivalOfLine(int lineId, TimeSpan hour, int stationKey);
        //IEnumerable<IGrouping<TimeSpan, LineTime>> StationTiming(BO.Station station, TimeSpan hour);

    }
}
