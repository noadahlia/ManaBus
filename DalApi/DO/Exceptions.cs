using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    
    #region BusException
    public class BadBusIdException : Exception
    {
        public int LICENSE;
        public BadBusIdException(int LicenseNum) : base() => LICENSE = LicenseNum;
        public BadBusIdException(int LicenseNum, string message) :
            base(message) => LICENSE = LicenseNum;
        public BadBusIdException(int LicenseNum, string message, Exception innerException) :
            base(message, innerException) => LICENSE = LicenseNum;

        public override string ToString() => base.ToString() + $", bad license number: {LICENSE}";
    }
    #endregion

    #region StationException
    public class BadStationIdException : Exception
    {
        public int CODE;
        public BadStationIdException(int Code) : base() => CODE = Code;
        public BadStationIdException(int Code, string message) :
            base(message) => CODE = Code;
        public BadStationIdException(int Code, string message, Exception innerException) :
            base(message, innerException) => CODE = Code;

        public override string ToString() => base.ToString() + $", bad station code: {CODE}";
    }
    #endregion

    #region LineException
    public class BadLineIdException : Exception
    {
        public int CODE;
        public BadLineIdException(int code) : base() => CODE = code;
        public BadLineIdException(int code, string message) :
            base(message) => CODE = code;
        public BadLineIdException(int code, string message, Exception innerException) :
            base(message, innerException) => CODE = code;

        public override string ToString() => base.ToString() + $", bad line code : {CODE}";
    }
    #endregion

    #region LineTrip
    public class BadLineTripIdException : Exception
    {
        public int ID;
        public BadLineTripIdException(int id) : base() => ID = id;
        public BadLineTripIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineTripIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad lineTrip id : {ID}";
    }
    #endregion

    #region UserException
    public class BadUserIdException : Exception
    {
        public string ID;
        public BadUserIdException(string id) : base() => ID = id;
        public BadUserIdException(string id, string message) :
            base(message) => ID = id;
        public BadUserIdException(string id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad user name: {ID}";
    }
    #endregion

    #region TripException
    public class BadTripIdException : Exception
    {
        public int ID;
        public BadTripIdException(int id) : base() => ID = id;
        public BadTripIdException(int id, string message) :
            base(message) => ID = id;
        public BadTripIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad trip id: {ID}";
    }
    #endregion

    #region LineSation
    public class BadLineIdStationIDException : Exception
    {
        public int lineID;
        public int stationID;
        public BadLineIdStationIDException(int linID, int statID) : base() { lineID = linID; stationID = statID; }
        public BadLineIdStationIDException(int linID, int statID, string message) :
            base(message)
        { lineID = linID; stationID = statID; }
        public BadLineIdStationIDException(int linID, int statID, string message, Exception innerException) :
            base(message, innerException)
        { lineID = linID; stationID = statID; }

        public override string ToString() => base.ToString() + $", bad line id: {lineID} and station id: {stationID}";
    }
    #endregion

    //Ajoutee... continuer???
    #region BusOnTripIdException
    public class BadBusOnTripIdException : Exception
    {
        public int ID;
        public BadBusOnTripIdException(int Id) : base() => ID = Id;
        public BadBusOnTripIdException(int Id, string message) :
            base(message) => ID = Id;
        public BadBusOnTripIdException(int Id, string message, Exception innerException) :
            base(message, innerException) => ID = Id;

        public override string ToString() => base.ToString() + $", bad Bus On Trip Id: {ID}";
    }
    #endregion
   
    #region XmlException
    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }
    #endregion



}
