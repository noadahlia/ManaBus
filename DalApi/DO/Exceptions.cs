using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BadBusIdException : Exception
    {
        public int ID;
        public BadBusIdException(int id) : base() => ID = id;
        public BadBusIdException(int id, string message) :
            base(message) => ID = id;
        public BadBusIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad bus id: {ID}";
    }
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(int id) : base() => ID = id;
        public BadLineIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }
    public class BadStationIdException : Exception
    {
        public int ID;
        public BadStationIdException(int id) : base() => ID = id;
        public BadStationIdException(int id, string message) :
            base(message) => ID = id;
        public BadStationIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad station id: {ID}";
    }
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



}
