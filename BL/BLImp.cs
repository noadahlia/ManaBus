using System;
using System.Collections.Generic;
using System.Linq;
using DalApi;
using BLAPI;
using System.Threading;
using BO;

namespace BL
{
    //in this  class we'll implement the IBL CRUD functions
    class BLImp : IBL
    {
        IDAL dal = DalFactory.GetDal(); //new instance of the Dal layer

        //Probleme dans copyBy
        #region Bus
        BO.Bus busDoBoAdapter(DO.Bus busDO)
        {
            BO.Bus busBO = new BO.Bus();
            int id = busDO.LicenseNum;
            try
            {
                busDO = dal.GetBus(id);
            }
            catch (DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("Bus ID doesn't exist", ex);
            }
          
            busDO.CopyPropertiesTo(busBO);          

            return busBO;
        }

        // Je vais verifier si y a 8 chiffres en supposant que les nouveaux bus seront recents et non d'avant 2018
        // A noter qu'au moment de l'affichage dans le PL essayer de mettre au format xxx-xx-xxx
        public void AddBus(Bus bus)
        {
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                if (bus.LicenseNum.ToString().Length == 8)
                    dal.AddBus(busDO);
                else throw new Exception("License Number must be 8 digits");
            }
            catch(DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("This bus already exists", ex);
            }

        } //pas totatelment finie //???

        public Bus GetBus(int id)
        {
            DO.Bus busDO;
            try
            {
                busDO = dal.GetBus(id);
            }
            catch (DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("This bus doesn't exist",ex);
            }
            return busDoBoAdapter(busDO);
        }

        public void DeleteBus(int id)
        {
            try
            {
                dal.RemoveBus(id);
            }
            catch (DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("Bus License number doesn't exist", ex);
            }
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            return from busDO in dal.GetAllBuses()
                   orderby busDO.LicenseNum
                   select busDoBoAdapter(busDO);
        }

        public IEnumerable<Bus> GetBusesBy(Predicate<Bus> predicate)// Ils ont pas ete memamesh mais a completer si on le veut 
        {
            return from bus in dal.GetAllBuses()
                   where predicate(busDoBoAdapter(bus))
                   select busDoBoAdapter(bus);
        }
        
        public void UpdateBusInfos(BO.Bus bus)
        {
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                dal.UpdateBus(busDO);
            }
            catch (DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("This bus doesn't exist", ex);
            }
        }


        #endregion

        #region Line
        BO.Line LineDoBoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            int id = lineDO.Id;
            try
            {
                lineDO = dal.GetLine(id);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdException("Line ID doesn't exist", ex);
            }

            lineDO.CopyPropertiesTo(lineBO);

            return lineBO;
        }
        public void AddLine(Line line)
        {
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            try
            {
              dal.AddLine(lineDO);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadBusIdException("This line already exists", ex);
            }
        }

        public void DeleteLine(int id)
        {
            try
            {
                dal.RemoveLine(id);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdException("This line doesn't exist", ex);
            }
        }
        public IEnumerable<Line> GetAllLines()
        {
            return from lineDO in dal.GetAllLine()
                   orderby lineDO.Id
                   select LineDoBoAdapter(lineDO);
        }
        public Line GetLine(int id)
        {
            DO.Line lineDO;
            try
            {
                lineDO = dal.GetLine(id);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdException("This line doesn't exist", ex);
            }
            return LineDoBoAdapter(lineDO);
        }
        public IEnumerable<Line> GetLinesBy(Predicate<Line> predicate )// a completer ils l ont laisse vide efrat et dan 
        {
            return from line in dal.GetAllLines()
                   where predicate(LineDoBoAdapter(line))
                   select LineDoBoAdapter(line);//inadequat

        }
        public void UpdateLineInfos(BO.Line line)
        {
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            try
            {
                dal.UpdateLine(lineDO);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdException("This line doesn't exist", ex);
            }
        }

        #endregion

        #region Station
        BO.Station StationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            int code = stationDO.Code;
            try
            {
                stationDO = dal.GetStation(code);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdException("Station code doesn't exist", ex);
            }

            stationDO.CopyPropertiesTo(stationBO);

            return stationBO;
        }

        public void AddStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dal.AddStation(stationDO);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("This station already exists", ex);
            }
        }




        public void DeleteStation(int code)
        {
            try
            {
                dal.RemoveStation(code);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("This station doesn't exist", ex);
            }
        }




        public IEnumerable<Station> GetAllStations()
        {
            return from stationDO in dal.GetAllStation()
                   orderby stationDO.Code
                   select StationDoBoAdapter(stationDO);
        }





        public Station GetStation(int code)
        {
            DO.Station stationDO;
            try
            {
                stationDO = dal.GetStation(code);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("This station doesn't exist", ex);
            }
            return StationDoBoAdapter(stationDO);
        }

        public IEnumerable<Station> GetStationsBy(Predicate<Station> predicate)
        {
            return from station in dal.GetAllStation()
                   where predicate(StationDoBoAdapter(station))
                   select StationDoBoAdapter(station);
        }



        public void UpdateStationInfos(BO.Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dal.UpdateStation(stationDO);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("This station doesn't exist", ex);
            }
        }


        #endregion

        #region LineStation

        #endregion

    }
}
