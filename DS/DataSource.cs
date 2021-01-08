using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public static class DataSource
    {
        public static List<Bus> ListBus;
        public static List<Station> ListStation;
        public static List<Line> ListLine;
        public static List<Trip> ListTrip;
        public static List<User> ListUser;
        public static List<BusOnTrip> ListBusOnTrip;//Ajoutee 
        public static List<LineStation> ListLineStation;

        static DataSource()
        {
            InitAllLists();
        }

        static void InitAllLists()
        {
            #region ListBus
            ListBus = new List<Bus>
            {
                new Bus
                {
                LicenseNum = 11-101-22,
                FromDate =DateTime.ParseExact("24.03.16", "dd.MM.yy", null),
                TotalTrip= 12000,
                FuelRemain= 1100,
                },

                new Bus
                {
                LicenseNum = 152-30-655,
                FromDate =DateTime.ParseExact("18.12.19", "dd.MM.yy", null),
                TotalTrip= 8000,
                FuelRemain= 500,
                },

                new Bus
                {
                LicenseNum = 20-999-34,
                FromDate =DateTime.ParseExact("12.01.15", "dd.MM.yy", null),
                TotalTrip= 19000,
                FuelRemain= 1200,
                },

                new Bus
                {
                LicenseNum = 59-009-23,
                FromDate =DateTime.ParseExact("05.05.05", "dd.MM.yy", null),
                TotalTrip= 16000,
                FuelRemain= 300,
                },

                new Bus
                {
                LicenseNum = 111-24-678,
                FromDate =DateTime.ParseExact("24.03.20", "dd.MM.yy", null),
                TotalTrip= 17400,
                FuelRemain= 100,
                },

                new Bus
                {
                LicenseNum = 303-88-784,
                FromDate =DateTime.ParseExact("13.11.18", "dd.MM.yy", null),
                TotalTrip= 6000,
                FuelRemain= 340,
                },

                new Bus
                {
                LicenseNum = 45-623-16,
                FromDate =DateTime.ParseExact("05.09.00", "dd.MM.yy", null),
                TotalTrip= 13000,
                FuelRemain=900,
                },

                new Bus
                {
                LicenseNum =23-865-32,
                FromDate =DateTime.ParseExact("24.03.85", "dd.MM.yy", null),
                TotalTrip= 1460,
                FuelRemain= 1000,
                },

                new Bus
                {
                LicenseNum = 911-01-191,
                FromDate =DateTime.ParseExact("31.05.20", "dd.MM.yy", null),
                TotalTrip= 17800,
                FuelRemain= 1200,
                },

                new Bus
                {
                LicenseNum = 123-45-678,
                FromDate =DateTime.ParseExact("09.08.19", "dd.MM.yy", null),
                TotalTrip= 6000,
                FuelRemain= 670,
                },

                new Bus
                {
                LicenseNum = 204-43-897,
                FromDate =DateTime.ParseExact("15.09.20", "dd.MM.yy", null),
                TotalTrip= 13000,
                FuelRemain= 430,
                },

                new Bus
                {
                LicenseNum = 63-223-78,
                FromDate =DateTime.ParseExact("11.01.01", "dd.MM.yy", null),
                TotalTrip= 19000,
                FuelRemain= 790,
                },

                new Bus
                {
                LicenseNum = 23-444-87,
                FromDate =DateTime.ParseExact("02.10.10", "dd.MM.yy", null),
                TotalTrip= 12980,
                FuelRemain= 160,
                },

                new Bus
                {
                LicenseNum = 66-372-65,
                FromDate =DateTime.ParseExact("27.02.13", "dd.MM.yy", null),
                TotalTrip= 16000,
                FuelRemain= 300,
                },

                new Bus
                {
                LicenseNum = 365-89-765,
                FromDate =DateTime.ParseExact("31.12.20", "dd.MM.yy", null),
                TotalTrip= 500,
                FuelRemain= 990,
                },

                new Bus
                {
                LicenseNum = 444-89-678,
                FromDate =DateTime.ParseExact("02.01.21", "dd.MM.yy", null),
                TotalTrip= 100,
                FuelRemain= 1000,
                },

                new Bus
                {
                LicenseNum = 67-276-90,
                FromDate =DateTime.ParseExact("25.01.08", "dd.MM.yy", null),
                TotalTrip= 14500,
                FuelRemain= 450,
                },

                new Bus
                {
                LicenseNum = 769-98-526,
                FromDate =DateTime.ParseExact("14.02.18", "dd.MM.yy", null),
                TotalTrip= 13900,
                FuelRemain= 1670,
                },

                new Bus
                {
                LicenseNum = 56-890-67,
                FromDate =DateTime.ParseExact("18.07.06", "dd.MM.yy", null),
                TotalTrip= 15600,
                FuelRemain= 890,
                },

                new Bus
                {
                LicenseNum = 34-111-13,
                FromDate =DateTime.ParseExact("13.03.90", "dd.MM.yy", null),
                TotalTrip= 4000,
                FuelRemain= 1980,
                },



            };
            #endregion
            
            #region ListStation
            ListStation = new List<Station>
            {
                new Station
                {
                    Code = 100000,
                    Name ="Bar Lev/ Ben Yehuda",
                    Longitude =34.917806,
                    Latitude =32.183921,
                    Adress= "Ben Yehuda 76",

                },

                 new Station
                {
                    Code =100010,
                    Name ="Chana Avarech/ Wallkeny",
                    Longitude =34.796071,
                    Latitude =31.892166,
                    Adress="Chana Avarech 9",

                },

                new Station
                {
                    Code =100020,
                    Name ="Hertzel/Golani",
                    Longitude =34.825249,
                    Latitude =31.856115,
                    Adress="Hertzel 4",
                },

                new Station
                {
                    Code =100030,
                    Name ="Beith Halevi",
                    Longitude =34.926837,
                    Latitude =32.349776,
                    Adress="Beith Halevi 100",

                },

                new Station
                {
                    Code =100040,
                    Name ="Charud Aleph",
                    Longitude =34.850134,
                    Latitude =31.912572,
                    Adress="Charud 45",

                },

                new Station
                {
                    Code =100050,
                    Name ="Odem/Shoam",
                    Longitude =34.864843,
                    Latitude =32.256581,
                    Adress="Odem 54",

                },

                new Station
                {
                    Code =100060,
                    Name ="Mazkiruth",
                    Longitude =34.864793,
                    Latitude =32.260481,
                    Adress="odem 90",

                },

                new Station
                {
                    Code =100070,
                    Name ="Shneur/Ben Gurion",
                    Longitude =34.847761,
                    Latitude =32.282745,
                    Adress="Zalman Shneur 8",

                },

                new Station
                {
                    Code =100080,
                    Name ="Levon/Yignon",
                    Longitude =34.853363,
                    Latitude =32.282133,
                    Adress="Sderot Pinchas Levon 22",

                },

                new Station
                {
                    Code =100090,
                    Name ="Train Station Sapir",
                    Longitude =34.864471,
                    Latitude =32.28034,
                    Adress=" Yad Charutzim 34",

                },

                new Station
                {
                    Code =100100,
                    Name = "Hayeria",
                    Longitude =34.86565,
                    Latitude =32.28872,
                    Adress="Hatzoren",

                },

                new Station
                {
                    Code =100110,
                    Name ="Nahum/Yeshayahu",
                    Longitude =34.854651,
                    Latitude =32.300595 ,
                    Adress="Nachum 1",

                },

                new Station

                {
                    Code =100120,
                    Name ="Machane Navo",
                    Longitude =35.50534,
                    Latitude =31.822234,
                    Adress="Megilot Dead Sea",

                },

                new Station

                {
                    Code =100130,
                    Name ="Yehua Hanassi/Yehara",
                    Longitude = 34.84973,
                    Latitude =32.151037,
                    Adress="Yehuda Hanassi 119",

                },

                new Station

                {
                    Code =100140,
                    Name ="Derech Nachal Kedem",
                    Longitude =35.321644,
                    Latitude =31.821209 ,
                    Adress="Derech Nachal Kedem 20",

                },

                new Station

                {
                    Code =100150,
                    Name ="Midbar Paran",
                    Longitude =35.288809,
                    Latitude =31.824836 ,
                    Adress="Midbar Paran 57",

                },

                new Station

                {
                    Code =100160,
                    Name ="Hatamar/Hagefen",
                    Longitude =34.800939,
                    Latitude =31.846039,
                    Adress= "Hatamar 77",
                },

                new Station

                {
                    Code =100170,
                    Name ="Haneviim",
                    Longitude =35.510469,
                    Latitude =32.786886,
                    Adress="Haneviim 78",

                },

                new Station

                {
                    Code =100180,
                    Name ="Alssad",
                    Longitude = 35.299156,
                    Latitude =32.859672,
                    Adress="Alssad 90",

                },

                new Station

                {
                    Code =100190,
                    Name ="Matsada/Chermon",
                    Longitude =35.274401,
                    Latitude =33.00277,
                    Adress="Matsada 53",

                },

                new Station
                {
                    Code =100200 ,
                    Name ="Rabid Entrance",
                    Longitude =35.436042,
                    Latitude =32.844873,
                    Adress="Hagalil Hatachton 8079",

                },

                new Station

                {
                    Code =100210 ,
                    Name ="Messed/Merkaz",
                    Longitude =35.424349,
                    Latitude =32.843974,
                    Adress="Messed 9",

                },

                new Station

                {
                    Code =100220,
                    Name ="Limonit/Marwa",
                    Longitude =34.754165,
                    Latitude =31.258021,
                    Adress="Limonit 6",

                },

                new Station
                {
                    Code =100230 ,
                    Name ="Sderot Chita/Nachal Kaziv",
                    Longitude =34.811188,
                    Latitude =31.362962   ,
                    Adress="Sderot Chita 3",

                },

                new Station


                {
                    Code =100240,
                    Name ="Mizrah",
                    Longitude =35.106092,
                    Latitude =32.70887,
                    Adress="Mizrah 18",

                },

                 new Station
                {
                    Code =100250,
                    Name ="Hagalil/Hayarden",
                    Longitude =35.138305
,
                    Latitude =31.957681,
                    Adress="Hagalil 88",

                },

                new Station

                {
                    Code =100260,
                    Name ="Lotem",
                    Longitude =35.050336,
                    Latitude =32.453232,
                    Adress="Lotem 25",

                },

                new Station

                {
                    Code =100270,
                    Name ="Heshkol",
                    Longitude =34.666431,
                    Latitude = 31.449688,
                    Adress="Heshkol 10",

                },

                new Station

                {
                    Code =100280 ,
                    Name ="Central Station Chadera",
                    Longitude =34.900363,
                    Latitude =32.438755,
                    Adress="Chadera 5",

                },

                new Station

                {
                    Code =100290,
                    Name ="Nave Zohar",
                    Longitude =35.363509,
                    Latitude =31.181302,
                    Adress="Zohar 32",

                },

                new Station

                {
                    Code =100300,
                    Name ="Ein Bokek",
                    Longitude =35.362547,
                    Latitude =31.191618,
                    Adress="Ein Bokek 70",

                },

                new Station

                {
                    Code =100310,
                    Name ="Raanan",
                    Longitude =34.9704,
                    Latitude = 32.80473,
                    Adress ="Raanan 77",

                },

                new Station

                {
                    Code =100320 ,
                    Name ="Guesher Paz",
                    Longitude =35.018059,
                    Latitude =32.798787,
                    Adress="Guesher Paz 12",

                },

                new Station

                {
                    Code =100330,
                    Name ="Hakerem/Tehaya",
                    Longitude =34.953969,
                    Latitude =32.469568,
                    Adress="Hakerem 1",

                },

                new Station

                {
                    Code =100340,
                    Name ="Harar/Haoren",
                    Longitude =35.135656,
                    Latitude =32.798087,
                    Adress="Harar 20",

                },

                new Station

                {
                    Code =100350,
                    Name ="Truman",
                    Longitude =35.054777,
                    Latitude =32.835898,
                    Adress="Sderot President Truman",

                },

                new Station
                {
                    Code =100360,
                    Name ="Nave David",
                    Longitude =34.957982,
                    Latitude = 32.805406,
                    Adress="Sderot Haagana",

                },

                new Station

                {
                    Code =100370,
                    Name ="Ankor/Chassida",
                    Longitude =34.954776,
                    Latitude =32.462786,
                    Adress="Ankor 40",

                },

                new Station

                {
                    Code =100380,
                    Name ="Mechlaf Yigor",
                    Longitude =35.071543,
                    Latitude =32.752167,
                    Adress="Zevulun 70",

                },

                new Station

                {
                    Code =100390,
                    Name ="Tzomet Pel Yam",
                    Longitude =34.920973,
                    Latitude =32.48007,
                    Adress="Ceisaria 651",

                },

                new Station
                {
                    Code =100400,
                    Name ="Beith Almin",
                    Longitude =34.911989,
                    Latitude =32.409079,
                    Adress="Itshak Ben Tzi 3",

                },

                new Station

                {
                    Code =100410,
                    Name ="Bath Iftach/Yeshayahu",
                    Longitude =34.937597,
                    Latitude =32.19008,
                    Adress="Yeshayahu 23",

                },

                new Station

                {
                    Code =100420,
                    Name ="Beith Cholim Meir",
                    Longitude =34.897648,
                    Latitude =32.181197,
                    Adress="Tshanichowski",

                },

                new Station
                {
                    Code =100430,
                    Name ="Tzomet Shaar Efraim",
                    Longitude =35.005424,
                    Latitude =32.279162,
                    Adress="Tayva 444",

                },

                new Station

                {
                    Code =100440,
                    Name ="Pankas/Hakader",
                    Longitude =34.874522,
                    Latitude =32.323412,
                    Adress="David Pankas",

                },

                new Station

                {
                    Code =100450,
                    Name ="Kvish 4/Tel Tsur",
                    Longitude = 34.895065,
                    Latitude =32.275284,
                    Adress="Iben Yehuda 4",

                },

                new Station
                {
                    Code =100460,
                    Name ="Harav Maymon/Moryah",
                    Longitude =34.860892,
                    Latitude =32.345805,
                    Adress="Harav Maymon 27",

                },

                new Station
                {
                    Code =100470,
                    Name ="Weitzman/Shareth",
                    Longitude = 34.859784,
                    Latitude =32.337702,
                    Adress="Sderot Chaim Weitzman 76",

                }

            };
            #endregion

            #region ListLineStation
            ListLineStation = new List<LineStation>
            {
                 new LineStation
                {
                    LineId = 1,
                    Station = 100000,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100010,
                },

                 new LineStation
                {
                    LineId = 1,
                    Station = 100010,
                    LineStationIndex = 1,
                    PrevStation = 100000,
                    NextStation = 100020,
                },

                new LineStation
                {
                    LineId = 1,
                    Station = 100020,
                    LineStationIndex = 2,
                    PrevStation = 100010,
                    NextStation = 100030,
                },

                new LineStation
                {
                    LineId = 1,
                    Station = 100030,
                    LineStationIndex = 3,
                    PrevStation = 100020,
                    NextStation = 100040,
                },

                 new  LineStation
                {
                    LineId = 1,
                    Station = 100040,
                    LineStationIndex = 4,
                    PrevStation = 100030,
                    NextStation = 100050,
                },

                new LineStation
                {
                    LineId = 1,
                    Station = 100050,
                    LineStationIndex = 5,
                    PrevStation = 100040,
                    NextStation = 100060,
                },

                new LineStation
                {
                    LineId = 1,
                    Station = 100060,
                    LineStationIndex = 6,
                    PrevStation = 100050,
                    NextStation = 100070,
                },

                new LineStation
                {
                    LineId = 1,
                    Station = 100070,
                    LineStationIndex = 7,
                    PrevStation = 100060,
                    NextStation = 100080,
                },

                new LineStation
                {
                    LineId = 1,
                    Station = 100080,
                    LineStationIndex = 8,
                    PrevStation = 100070,
                    NextStation = 100090,
                },

                new LineStation
                {
                    LineId = 1,
                    Station = 100090,
                    LineStationIndex = 9,
                    PrevStation = 100080,
                    NextStation = -2,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100040,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100050,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100050,
                    LineStationIndex = 1,
                    PrevStation = 100040,
                    NextStation = 100020,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100020,
                    LineStationIndex = 2,
                    PrevStation = 100050,
                    NextStation = 100100,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100100,
                    LineStationIndex = 3,
                    PrevStation = 100020,
                    NextStation = 100110,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100110,
                    LineStationIndex = 4,
                    PrevStation = 100100,
                    NextStation = 100120,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100120,
                    LineStationIndex = 5,
                    PrevStation = 100110,
                    NextStation = 100130,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100130,
                    LineStationIndex = 6,
                    PrevStation = 100120,
                    NextStation = 100140,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100140,
                    LineStationIndex = 7,
                    PrevStation = 100130,
                    NextStation = 100150,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100150,
                    LineStationIndex = 8,
                    PrevStation = 100140,
                    NextStation = 100160,
                },

                new LineStation
                {
                    LineId = 2,
                    Station = 100160,
                    LineStationIndex = 9,
                    PrevStation = 100150,
                    NextStation = -2,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100000,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100030,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100030,
                    LineStationIndex = 1,
                    PrevStation = 100000,
                    NextStation = 100090,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100090,
                    LineStationIndex = 2,
                    PrevStation = 100030,
                    NextStation = 100100,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100100,
                    LineStationIndex = 3,
                    PrevStation = 100090,
                    NextStation = 100200,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100200,
                    LineStationIndex = 4,
                    PrevStation = 100100,
                    NextStation = 100210,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100210,
                    LineStationIndex = 5,
                    PrevStation = 100200,
                    NextStation = 100220,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100220,
                    LineStationIndex = 6,
                    PrevStation = 100210,
                    NextStation = 100230,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100230,
                    LineStationIndex = 7,
                    PrevStation = 100220,
                    NextStation = 100240,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100240,
                    LineStationIndex = 8,
                    PrevStation = 100230,
                    NextStation = 100250,
                },

                new LineStation
                {
                    LineId = 3,
                    Station = 100250,
                    LineStationIndex = 9,
                    PrevStation = 100240,
                    NextStation = -2,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100300,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100030,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100030,
                    LineStationIndex = 1,
                    PrevStation = 100300,
                    NextStation = 100320,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100320,
                    LineStationIndex = 2,
                    PrevStation = 100030,
                    NextStation = 100330,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100330,
                    LineStationIndex = 3,
                    PrevStation = 100320,
                    NextStation = 100210,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100210,
                    LineStationIndex = 4,
                    PrevStation = 100330,
                    NextStation = 100340,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100340,
                    LineStationIndex = 5,
                    PrevStation = 100210,
                    NextStation = 100350,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100350,
                    LineStationIndex = 6,
                    PrevStation = 100340,
                    NextStation = 100360,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100360,
                    LineStationIndex = 7,
                    PrevStation = 100350,
                    NextStation = 100370,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100370,
                    LineStationIndex = 8,
                    PrevStation = 100360,
                    NextStation = 100380,
                },

                new LineStation
                {
                    LineId = 4,
                    Station = 100380,
                    LineStationIndex = 9,
                    PrevStation = 100370,
                    NextStation = -2,
                },

                new LineStation
                {
                    LineId = 5,
                    Station = 100030,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100060,
                },

                 new LineStation
               {
                    LineId = 5,
                    Station = 100060,
                    LineStationIndex = 1,
                    PrevStation = 100030,
                    NextStation = 100010,
                },

                new LineStation
                {
                    LineId = 5,
                    Station = 100010,
                    LineStationIndex = 2,
                    PrevStation = 100060,
                    NextStation = 100000,
                },

               new LineStation
                {
                    LineId = 5,
                    Station = 100000,
                    LineStationIndex = 3,
                    PrevStation = 100010,
                    NextStation = 100400,
                },

                new LineStation
                {
                    LineId = 5,
                    Station = 100400,
                    LineStationIndex = 4,
                    PrevStation = 100000,
                    NextStation = 100410,
                },

               new LineStation
                {
                    LineId = 5,
                    Station = 100410,
                    LineStationIndex = 5,
                    PrevStation = 100400,
                    NextStation = 100420,
                },

                new LineStation
                {
                    LineId = 5,
                    Station = 100420,
                    LineStationIndex = 6,
                    PrevStation = 100410,
                    NextStation = 100430,
                },

               new LineStation
                {
                    LineId = 5,
                    Station = 100430,
                    LineStationIndex = 7,
                    PrevStation = 100420,
                    NextStation = 100440,
                },

                new LineStation
                {
                    LineId = 5,
                    Station = 100440,
                    LineStationIndex = 8,
                    PrevStation = 100430,
                    NextStation = 100450,
                },

                new LineStation
                {
                    LineId = 5,
                    Station = 100450,
                    LineStationIndex = 9,
                    PrevStation = 100440,
                    NextStation = -2,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100440,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100450,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100450,
                    LineStationIndex = 1,
                    PrevStation = 100440,
                    NextStation = 100460,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100460,
                    LineStationIndex = 2,
                    PrevStation = 100450,
                    NextStation = 100470,
                },

               new LineStation
                {
                    LineId = 6,
                    Station = 100470,
                    LineStationIndex = 3,
                    PrevStation = 100460,
                    NextStation = 100480,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100480,
                    LineStationIndex = 4,
                    PrevStation = 100470,
                    NextStation = 100490,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100490,
                    LineStationIndex = 5,
                    PrevStation = 100480,
                    NextStation = 100500,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100500,
                    LineStationIndex = 6,
                    PrevStation = 100490,
                    NextStation = 100070,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100070,
                    LineStationIndex = 7,
                    PrevStation = 100060,
                    NextStation = 100080,
                },

                new LineStation
                {
                    LineId = 6,
                    Station = 100080,
                    LineStationIndex = 8,
                    PrevStation = 100070,
                    NextStation = 100090,
                },

               new LineStation
                {
                    LineId = 6,
                    Station = 100090,
                    LineStationIndex = 9,
                    PrevStation = 100080,
                    NextStation = -2,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100040,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100050,
                },

               new LineStation
                {
                    LineId = 7,
                    Station = 100050,
                    LineStationIndex = 1,
                    PrevStation = 100040,
                    NextStation = 100020,
                },

               new LineStation
                {
                    LineId = 7,
                    Station = 100020,
                    LineStationIndex = 2,
                    PrevStation = 100050,
                    NextStation = 100300,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100300,
                    LineStationIndex = 3,
                    PrevStation = 100020,
                    NextStation = 100330,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100330,
                    LineStationIndex = 4,
                    PrevStation = 100300,
                    NextStation = 100340,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100340,
                    LineStationIndex = 5,
                    PrevStation = 100330,
                    NextStation = 100350,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100350,
                    LineStationIndex = 6,
                    PrevStation = 100340,
                    NextStation = 100360,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100360,
                    LineStationIndex = 7,
                    PrevStation = 100350,
                    NextStation = 100370,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100370,
                    LineStationIndex = 8,
                    PrevStation = 100360,
                    NextStation = 100380,
                },

                new LineStation
                {
                    LineId = 7,
                    Station = 100380,
                    LineStationIndex = 9,
                    PrevStation = 100370,
                    NextStation = -2,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100000,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100200,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100200,
                    LineStationIndex = 1,
                    PrevStation = 100000,
                    NextStation = 100210,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100210,
                    LineStationIndex = 2,
                    PrevStation = 100200,
                    NextStation = 100220,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100220,
                    LineStationIndex = 3,
                    PrevStation = 100210,
                    NextStation = 100230,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100230,
                    LineStationIndex = 4,
                    PrevStation = 100220,
                    NextStation = 100240,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100240,
                    LineStationIndex = 5,
                    PrevStation = 100230,
                    NextStation = 100250,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100250,
                    LineStationIndex = 6,
                    PrevStation = 100240,
                    NextStation = 100260,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100260,
                    LineStationIndex = 7,
                    PrevStation = 100250,
                    NextStation = 100270,
                },

                new LineStation
                {
                    LineId = 8,
                    Station = 100270,
                    LineStationIndex = 8,
                    PrevStation = 100260,
                    NextStation = 100280,
                },

            new LineStation
            {
                    LineId = 8,
                    Station = 100280,
                    LineStationIndex = 9,
                    PrevStation = 100270,
                    NextStation = -2,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100300,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100030,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100030,
                    LineStationIndex = 1,
                    PrevStation = 100300,
                    NextStation = 100320,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100320,
                    LineStationIndex = 2,
                    PrevStation = 100030,
                    NextStation = 100110,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100110,
                    LineStationIndex = 3,
                    PrevStation = 100320,
                    NextStation = 100210,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100210,
                    LineStationIndex = 4,
                    PrevStation = 100110,
                    NextStation = 100310,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100310,
                    LineStationIndex = 5,
                    PrevStation = 100210,
                    NextStation = 100410,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100410,
                    LineStationIndex = 6,
                    PrevStation = 100310,
                    NextStation = 100420,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100420,
                    LineStationIndex = 7,
                    PrevStation = 100410,
                    NextStation = 100430,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100430,
                    LineStationIndex = 8,
                    PrevStation = 100420,
                    NextStation = 100440,
                },

            new LineStation
            {
                    LineId = 9,
                    Station = 100440,
                    LineStationIndex = 9,
                    PrevStation = 100430,
                    NextStation = -2,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100450,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 100460,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100460,
                    LineStationIndex = 1,
                    PrevStation = 100450,
                    NextStation = 100470,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100470,
                    LineStationIndex = 2,
                    PrevStation = 100460,
                    NextStation = 100480,
                },
            new LineStation
            {
                    LineId = 10,
                    Station = 100480,
                    LineStationIndex = 3,
                    PrevStation = 100470,
                    NextStation = 100490,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100490,
                    LineStationIndex = 4,
                    PrevStation = 100480,
                    NextStation = 100500,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100500,
                    LineStationIndex = 5,
                    PrevStation = 100490,
                    NextStation = 100000,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100000,
                    LineStationIndex = 6,
                    PrevStation = 100500,
                    NextStation = 100110,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100110,
                    LineStationIndex = 7,
                    PrevStation = 100000,
                    NextStation = 100330,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100330,
                    LineStationIndex = 8,
                    PrevStation = 100110,
                    NextStation = 100200,
                },

            new LineStation
            {
                    LineId = 10,
                    Station = 100200,
                    LineStationIndex = 9,
                    PrevStation = 100330,
                    NextStation = -2,
                },
            };
            #endregion

            //ListLine code a completer 
            #region ListLine
            ListLine = new List<Line>
            {
                new Line
                {
                Id=1,
                Code=,
                FirstStation=100000,
                LastStation=100090,
                Area=Areas.Jerusalem,
                },
                
                new Line
                {
                Id=2,
                Code=,
                FirstStation=100040,
                LastStation=100160,
                Area= Areas.Center,
                },
               
                new Line
                {
                Id=3,
                Code=,
                FirstStation=100000,
                LastStation=100250,
                Area=Areas.North,
                },
                new Line
                {
                Id=4,
                Code=,
                FirstStation=100300,
                LastStation=100380,
                Area=Areas.South,
                },

                new Line
                {
                Id=5,
                Code=,
                FirstStation=100030,
                LastStation=100450,
                Area=Areas.Jerusalem,
                },

                new Line
                {
                Id=6,
                Code=,
                FirstStation=100440,
                LastStation=100090,
                Area=Areas.Center,
                },

                new Line
                {
                Id=7,
                Code=,
                FirstStation=100040,
                LastStation=100380,
                Area=Areas.North,
                },

                new Line
                {
                Id=8,
                Code=,
                FirstStation=100000,
                LastStation=100280,
                Area=Areas.South,
                },

                new Line
                {
                Id=9,
                Code=,
                FirstStation=100300,
                LastStation=100440,
                Area=Areas.Jerusalem,
                },

                new Line
                {
                Id=10,
                Code=,
                FirstStation=100450,
                LastStation=100200,
                Area=Areas.Center,
                },
            };
            #endregion

            #region ListUser 
            ListUser = new List<User>
            {
            new User
            {
                UserName="David",
                Password="aaa",
                Admin=true,
            },

             new User
            { 
                UserName="Sarah",
                Password="bbb",
                Admin=true,
            },
            
            new User
            {
                UserName="Yonhatan",
                Password="ccc",
                Admin=false,
            },

            new User
            {
                UserName="Noa",
                Password="ddd",
                Admin=false,
            },

            new User
            {
                UserName="Daniel",
                Password="eee",
                Admin=false,
            }

            };
            #endregion

            //public int Id { get; set; }
            //public string UserName { get; set; }
            //public int LineId { get; set; }
            //public int InStation { get; set; }
            //public TimeSpan InAt { get; set; }
            //public int OutStation { get; set; }
            //public TimeSpan OutAt { get; set; }
            //public bool IsActive = true;
            #region ListTrip
            ListTrip = new List<Trip>
            {
                new Trip
                {
                    Id=100,
                    UserName="",
                    LineId=1,
                    InStation=100010,
                    InAt=new TimeSpan(15,30,00),
                    OutStation=100050,
                    OutAt=,


                }
            };
            #endregion

        }



    }

    
}
