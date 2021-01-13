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
                throw new BO.BadBusIdException(id,"Bus ID doesn't exist", ex);
            }
          
            busDO.CopyPropertiesTo(busBO);          

            return busBO;
        }

        public void AddBus(Bus bus)
        {
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                //verify the licenseNumber
                dal.AddBus(busDO);
            }
            catch(DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException(bus.LicenseNum, "This bus already exists", ex);
            }

        } //pas totatelment finie

        public Bus GetBus(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBus(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetBusesBy(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateBusInfos(Bus bus)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Line
        public void AddLine(Line Line)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Line> GetAllLines()
        {
            throw new NotImplementedException();
        }
        public Line GetLine(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Line> GetLinesBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateLineInfos(Line line)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Station
        public void AddStation(Station station)
        {
            throw new NotImplementedException();
        }




        public void DeleteStation(int id)
        {
            throw new NotImplementedException();
        }




        public IEnumerable<Station> GetAllStations()
        {
            throw new NotImplementedException();
        }





        public Station GetStation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetStationsBy(Predicate<Station> predicate)
        {
            throw new NotImplementedException();
        }



        public void UpdateStationInfos(Station station)
        {
            throw new NotImplementedException();
        }

     
        #endregion


    }
}
