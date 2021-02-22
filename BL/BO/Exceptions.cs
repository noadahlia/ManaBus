using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BO
{
    [Serializable]
    public class BadBusIdException : Exception
    {
        public int ID;
        public BadBusIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadBusIdException)innerException).LICENSE;
        public override string ToString() => base.ToString() + $", bad bus id: {ID}";
    }

    [Serializable]
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadLineIdException)innerException).CODE;
        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }

    [Serializable]
    public class BadStationIdException : Exception
    {
        public int ID;
        public BadStationIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadStationIdException)innerException).CODE;
        public override string ToString() => base.ToString() + $", bad station id: {ID}";
    }

    [Serializable]
    public class BadLineIdStationIDException : Exception
    {
        public int lineID;
        public int stationID;
        public BadLineIdStationIDException(string message, Exception innerException) :
            base(message, innerException)
        {
            lineID = ((DO.BadLineIdStationIDException)innerException).lineID;
            stationID = ((DO.BadLineIdStationIDException)innerException).stationID;
        }
        public override string ToString() => base.ToString() + $", bad student id: {lineID} and course ID: {stationID}";
    }

    [Serializable]
    public class BadUserIdException : Exception
    {
        public string Pseudo;
        public BadUserIdException(string message, Exception innerException) :
            base(message, innerException) => Pseudo = ((DO.BadUserIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad user id: {Pseudo}";
    }
}








//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BO
//{
//    #region BusException
//    public class BadBusIdException : Exception
//    {
//        public int LICENSE;
//        public BadBusIdException(int LicenseNum) : base() => LICENSE = LicenseNum;
//        public BadBusIdException(int LicenseNum, string message) :
//            base(message) => LICENSE = LicenseNum;
//        public BadBusIdException(int LicenseNum, string message, Exception innerException) :
//            base(message, innerException) => LICENSE = LicenseNum;
//        public BadBusIdException(string message, Exception innerException) :
//           base(message, innerException) => LICENSE = ((DO.BadBusIdException)innerException).LICENSE;

//        public override string ToString() => base.ToString() + $", bad license number: {LICENSE}";
//    }
//    #endregion

//    #region StationException
//    public class BadStationIdException : Exception
//    {
//        public int CODE;
//        public BadStationIdException(int Code) : base() => CODE = Code;
//        public BadStationIdException(int Code, string message) :
//            base(message) => CODE = Code;
//        public BadStationIdException(int Code, string message, Exception innerException) :
//            base(message, innerException) => CODE = Code;
//        public BadStationIdException(string message, Exception innerException) :
//          base(message, innerException) => CODE = ((DO.BadStationIdException)innerException).CODE;
//        public override string ToString() => base.ToString() + $", bad station code: {CODE}";
//    }
//    #endregion

//    #region LineException
//    public class BadLineIdException : Exception
//     {
//         public int CODE;
//         public BadLineIdException(int code) : base() => CODE = code;
//         public BadLineIdException(int code, string message) :
//             base(message) => CODE = code;
//         public BadLineIdException(int code, string message, Exception innerException) :
//             base(message, innerException) => CODE = code;
//        public BadLineIdException(string message, Exception innerException) :
//           base(message, innerException) => CODE = ((DO.BadLineIdException)innerException).CODE;

//        public override string ToString() => base.ToString() + $", bad line code : {CODE}";
//     }
//    #endregion

//    #region UserException
//    public class BadUserIdException : Exception
//     {
//        public string ID;
//        public BadUserIdException(string id) : base() => ID = id;
//        public BadUserIdException(string id, string message) :
//            base(message) => ID = id;
//        public BadUserIdException(string id, string message, Exception innerException) :
//            base(message, innerException) => ID = id;

//        public override string ToString() => base.ToString() + $", bad user name: {ID}";
//    }
//    #endregion

//    #region TripException
//    public class BadTripIdException : Exception
//     {
//         public int ID;
//         public BadTripIdException(int id) : base() => ID = id;
//         public BadTripIdException(int id, string message) :
//             base(message) => ID = id;
//         public BadTripIdException(int id, string message, Exception innerException) :
//             base(message, innerException) => ID = id;

//         public override string ToString() => base.ToString() + $", bad trip id: {ID}";
//     }
//    #endregion

//    #region XmlException
//    public class XMLFileLoadCreateException : Exception
//     {
//         public string xmlFilePath;
//         public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
//         public XMLFileLoadCreateException(string xmlPath, string message) :
//             base(message)
//         { xmlFilePath = xmlPath; }
//         public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
//             base(message, innerException)
//         { xmlFilePath = xmlPath; }

//         public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
//     }
//    #endregion

//}
