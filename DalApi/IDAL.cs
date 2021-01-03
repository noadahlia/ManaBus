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
        IEnumerable<Bus> GetAllBus(Func<Bus, bool> predicate = null);

        #endregion
        
        #region Line Function
        void AddLine(Line line);
        void RemoveLine(int id);
        void UpdateLine(Line line);
        Line GetLine(int id);
        IEnumerable<Line> GetAllLine(Func<Line, bool> predicate = null);

        #endregion

        #region Station Function
        void AddStation(Station station);
        void RemoveStation(int code);
        void UpdateStation(Station station);
        Station GetStation(int code);
        IEnumerable<Station> GetAllStation(Func<Station, bool> predicate = null);

        #endregion

        #region Trip Function
        void AddTrip(Trip trip);
        void RemoveTrip(int id);
        void UpdateTrip(Trip trip );
        Trip GetTrip(int id);
        IEnumerable<Trip> GetAllTrip(Func<Trip, bool> predicate = null);

        #endregion

        #region User Function
        void AddUser(User user);
        void RemoveUser(string name);
        void UpdateUser(User user);
        User GetUser(string name);
        IEnumerable<User> GetAllUser(Func<User, bool> predicate = null);

        #endregion

        //Toutes faire? Surement...on verra bien..
        

    }
}
