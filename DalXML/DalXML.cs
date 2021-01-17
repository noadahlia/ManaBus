using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DL;
using DO;

namespace DL
{
    sealed class DLXML : IDL    //internal
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
        public IEnumerable<DO.Bus> GetAllPersonsBy(Predicate<DO.Bus> predicate)
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
//        public void AddBus(DO.Bus bus)
//        {
//            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

//            XElement bus1 = (from b in busRootElem.Elements()
//                             where int.Parse(b.Element("LicenseNum").Value) == bus.LicenseNum
//                             select b).FirstOrDefault();

//            if (bus1 != null)
//                throw new DO.BadBusIdException(bus.LicenseNum, "Duplicate bus License Number");

//            XElement personElem = new XElement("Bus",
//                                   new XElement("LicenseNum", bus.LicenseNum),
//                                   new XElement("Name", person.Name),// reprendre d ici 
//                                   new XElement("Street", person.Street),
//                                   new XElement("HouseNumber", person.HouseNumber.ToString()),
//                                   new XElement("City", person.City),
//                                   new XElement("BirthDate", person.BirthDate),
//                                   new XElement("PersonalStatus", person.PersonalStatus.ToString()));

//            personsRootElem.Add(personElem);

//            XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
//        }

//        public void DeletePerson(int id)
//        {
//            XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

//            XElement per = (from p in personsRootElem.Elements()
//                            where int.Parse(p.Element("ID").Value) == id
//                            select p).FirstOrDefault();

//            if (per != null)
//            {
//                per.Remove();
//                XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
//            }
//            else
//                throw new DO.BadPersonIdException(id, $"bad person id: {id}");
//        }

//        public void UpdatePerson(DO.Person person)
//        {
//            XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

//            XElement per = (from p in personsRootElem.Elements()
//                            where int.Parse(p.Element("ID").Value) == person.ID
//                            select p).FirstOrDefault();

//            if (per != null)
//            {
//                per.Element("ID").Value = person.ID.ToString();
//                per.Element("Name").Value = person.Name;
//                per.Element("Street").Value = person.Street;
//                per.Element("HouseNumber").Value = person.HouseNumber.ToString();
//                per.Element("City").Value = person.City;
//                per.Element("BirthDate").Value = person.BirthDate.ToString();
//                per.Element("PersonalStatus").Value = person.PersonalStatus.ToString();

//                XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
//            }
//            else
//                throw new DO.BadPersonIdException(person.ID, $"bad person id: {person.ID}");
//        }

//        public void UpdatePerson(int id, Action<DO.Person> update)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion Bus
//    }
//}
