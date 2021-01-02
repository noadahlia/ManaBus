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
        bool RemoveBus(int license);
        void UpdateBus(Bus bus);
        Bus GetBus(int license);
        IEnumerable<Bus> GetAllBus(Func<Bus, bool> predicat = null);

        #endregion
        
        #region Line Function
        void AddLine(Line line);
        bool RemoveLine(int id);
        void UpdateBus(Line line);
        Line GetLine(int id);
        IEnumerable<Line> GetAllLine(Func<Line, bool> predicat = null);

        #endregion

        #region Station Function
        void AddStation(Station station);
        bool RemoveStation(int code);
        void UpdateStation(Station station);
        Station GetStation(int code);
        IEnumerable<Station> GetAllStation(Func<Station, bool> predicat = null);

        #endregion

        #region Trip Function
        void AddTrip(Trip trip);
        bool RemoveTrip(int id);
        void UpdateTrip(Trip trip );
        Trip GGetTrip(int id);
        IEnumerable<Trip> GetAllTrip(Func<Trip, bool> predicat = null);

        #endregion

        #region User Function
        void AddUser(Bus bus);
        bool RemoveUser(int license);
        void UpdateUser(Bus bus);
        Bus GetUser(int license);
        IEnumerable<Bus> GetAllUser(Func<Bus, bool> predicat = null);

        #endregion

        //Toutes faire? Surement...on verra bien..
        

    }
}
