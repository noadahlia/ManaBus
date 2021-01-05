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
                    Code = 38831,
                    Name ="Bar Lev/ Ben Yehuda",
                    Longitude =34.917806,
                    Latitude =32.183921,
                    Adress= "Ben Yehuda 76",

                },

                 new Station
                {
                    Code =38837,
                    Name ="Chana Avarech/ Wallkeny",
                    Longitude =34.796071,
                    Latitude =31.892166,
                    Adress="Chana Avarech 9",

                },

                new Station
                {
                    Code =38855,
                    Name ="Hertzel/Golani",
                    Longitude =34.825249,
                    Latitude =31.856115,
                    Adress="Hertzel 4",
                },

                new Station
                {
                    Code =38869,
                    Name ="Beith Halevi",
                    Longitude =34.926837,
                    Latitude =32.349776,
                    Adress="Beith Halevi 100",

                },

                new Station
                {
                    Code =39072,
                    Name ="Charud Aleph",
                    Longitude =34.850134,
                    Latitude =31.912572,
                    Adress="Charud 45",

                },

                new Station
                {
                    Code =39108,
                    Name ="Odem/Shoam",
                    Longitude =34.864843,
                    Latitude =32.256581,
                    Adress="Odem 54",

                },

                new Station
                {
                    Code =39113,
                    Name ="Mazkiruth",
                    Longitude =34.864793,
                    Latitude =32.260481,
                    Adress="odem 90",

                },

                new Station
                {
                    Code =39121,
                    Name ="Shneur/Ben Gurion",
                    Longitude =34.847761,
                    Latitude =32.282745,
                    Adress="Zalman Shneur 8",

                },

                new Station
                {
                    Code =39153,
                    Name ="Levon/Yignon",
                    Longitude =34.853363,
                    Latitude =32.282133,
                    Adress="Sderot Pinchas Levon 22",

                },

                new Station
                {
                    Code =39173,
                    Name ="Train Station Sapir",
                    Longitude =34.864471,
                    Latitude =32.28034,
                    Adress=" Yad Charutzim 34",

                },

                new Station
                {
                    Code =39183,
                    Name = "Hayeria",
                    Longitude =34.86565,
                    Latitude =32.28872,
                    Adress="Hatzoren",

                },

                new Station
                {
                    Code =39197,
                    Name ="Nahum/Yeshayahu",
                    Longitude =34.854651,
                    Latitude =32.300595 ,
                    Adress="Nachum 1",

                },

                new Station

                {
                    Code =61422,
                    Name ="Machane Navo",
                    Longitude =35.50534,
                    Latitude =31.822234,
                    Adress="Megilot Dead Sea",

                },
 
                new Station 		

                {
                    Code =20470,
                    Name ="Yehua Hanassi/Yehara",
                    Longitude = 34.84973,
                    Latitude =32.151037,
                    Adress="Yehuda Hanassi 119",

                },
 
                new Station 	

                {
                    Code =61412,
                    Name ="Derech Nachal Kedem",
                    Longitude =35.321644,
                    Latitude =31.821209 ,
                    Adress="Derech Nachal Kedem 20",

                },
 
                new Station  	

                {
                    Code =61411,
                    Name ="Midbar Paran",
                    Longitude =35.288809,
                    Latitude =31.824836 ,
                    Adress="Midbar Paran 57",

                },
 
                new Station	

                {
                    Code =35268,
                    Name ="Hatamar/Hagefen",
                    Longitude =34.800939,
                    Latitude =31.846039,
                    Adress= "Hatamar 77",
                },
 
                new Station		

                {
                    Code =56376,
                    Name ="Haneviim",
                    Longitude =35.510469,
                    Latitude =32.786886,
                    Adress="Haneviim 78",

                },
 
                new Station 		

                {
                    Code =56289,
                    Name ="Alssad",
                    Longitude = 35.299156,
                    Latitude =32.859672,
                    Adress="Alssad 90",

                },
 
                new Station		

                {
                    Code =56302,
                    Name ="Matsada/Chermon",
                    Longitude =35.274401,
                    Latitude =33.00277,
                    Adress="Matsada 53",

                },
 
                new Station
                {
                    Code =56358 ,
                    Name ="Rabid Entrance",
                    Longitude =35.436042,
                    Latitude =32.844873,
                    Adress="Hagalil Hatachton 8079",

                },
 
                new Station		

                {
                    Code =57997 ,
                    Name ="Messed/Merkaz",
                    Longitude =35.424349,
                    Latitude =32.843974,
                    Adress="Messed 9",

                },
 
                new Station	

                {
                    Code =12492,
                    Name ="Limonit/Marwa",
                    Longitude =34.754165,
                    Latitude =31.258021,
                    Adress="Limonit 6",

                },
 
                new Station	
                {
                    Code =12440 ,
                    Name ="Sderot Chita/Nachal Kaziv",
                    Longitude =34.811188,
                    Latitude =31.362962   ,
                    Adress="Sderot Chita 3",

                },
 
                new Station	


                {
                    Code =43468,
                    Name ="Mizrah",
                    Longitude =35.106092,
                    Latitude =32.70887,
                    Adress="Mizrah 18",

                },

                 new Station		
                {
                    Code =61400,
                    Name ="Hagalil/Hayarden",
                    Longitude =35.138305
,
                    Latitude =31.957681,
                    Adress="Hagalil 88",

                },
 
                new Station		

                {
                    Code =43510,
                    Name ="Lotem",
                    Longitude =35.050336,
                    Latitude =32.453232,
                    Adress="Lotem 25",

                },

                new Station

                {
                    Code =12483,
                    Name ="Heshkol",
                    Longitude =34.666431,
                    Latitude = 31.449688,
                    Adress="Heshkol 10",

                },

                new Station

                {
                    Code =42218 ,
                    Name ="Central Station Chadera",
                    Longitude =34.900363,
                    Latitude =32.438755,
                    Adress="Chadera 5",

                },

                new Station

                {
                    Code =12522,
                    Name ="Nave Zohar",
                    Longitude =35.363509,
                    Latitude =31.181302,
                    Adress="Zohar 32",

                },

                new Station

                {
                    Code =12517,
                    Name ="Ein Bokek",
                    Longitude =35.362547,
                    Latitude =31.191618,
                    Adress="Ein Bokek 70",

                },
 
                new Station		

                {
                    Code =42612,
                    Name ="Raanan",
                    Longitude =34.9704,
                    Latitude = 32.80473,
                    Adress ="Raanan 77",

                },

                new Station
 
                {
                    Code =42577 ,
                    Name ="Guesher Paz",
                    Longitude =35.018059,
                    Latitude =32.798787,
                    Adress="Guesher Paz 12",

                },
 
                new Station	

                {
                    Code =42530,
                    Name ="Hakerem/Tehaya",
                    Longitude =34.953969,
                    Latitude =32.469568,
                    Adress="Hakerem 1",

                },
               
                new Station	

                {
                    Code =42435,
                    Name ="Harar/Haoren",
                    Longitude =35.135656,
                    Latitude =32.798087,
                    Adress="Harar 20",

                },
                
                new Station		

                {
                    Code =42159,
                    Name ="Truman",
                    Longitude =35.054777,
                    Latitude =32.835898,
                    Adress="Sderot President Truman",

                },
 
                new Station
                {
                    Code =40967,
                    Name ="Nave David",
                    Longitude =34.957982,
                    Latitude = 32.805406,
                    Adress="Sderot Haagana",

                },
                
                new Station 		

                {
                    Code =40386,
                    Name ="Ankor/Chassida",
                    Longitude =34.954776,
                    Latitude =32.462786,
                    Adress="Ankor 40",

                },
                
                new Station		

                {
                    Code =40322,
                    Name ="Mechlaf Yigor",
                    Longitude =35.071543,
                    Latitude =32.752167,
                    Adress="Zevulun 70",

                },
               
                new Station 		

                {
                    Code =40175,
                    Name ="Tzomet Pel Yam",
                    Longitude =34.920973,
                    Latitude =32.48007,
                    Adress="Ceisaria 651",

                },
               
                new Station
                {
                    Code =40096,
                    Name ="Beith Almin",
                    Longitude =34.911989,
                    Latitude =32.409079,
                    Adress="Itshak Ben Tzi 3",

                },
               
                new Station

                {
                    Code =39857,
                    Name ="Bath Iftach/Yeshayahu",
                    Longitude =34.937597,
                    Latitude =32.19008,
                    Adress="Yeshayahu 23",

                },

                new Station

                {
                    Code =39831,
                    Name ="Beith Cholim Meir",
                    Longitude =34.897648,
                    Latitude =32.181197,
                    Adress="Tshanichowski",

                },
 
                new Station
                {
                    Code =39625,
                    Name ="Tzomet Shaar Efraim",
                    Longitude =35.005424,
                    Latitude =32.279162,
                    Adress="Tayva 444",

                },
           
                new Station

                {
                    Code =39443,
                    Name ="Pankas/Hakader",
                    Longitude =34.874522,
                    Latitude =32.323412,
                    Adress="David Pankas",

                },
                
                new Station

                {
                    Code =39337,
                    Name ="Kvish 4/Tel Tsur",
                    Longitude = 34.895065,
                    Latitude =32.275284,
                    Adress="Iben Yehuda 4",

                },
                
                new Station 
                {
                    Code =39301,
                    Name ="Harav Maymon/Moryah",
                    Longitude =34.860892,
                    Latitude =32.345805,
                    Adress="Harav Maymon 27",

                },
                
                new Station
                {
                    Code =39284,
                    Name ="Weitzman/Shareth",
                    Longitude = 34.859784,
                    Latitude =32.337702,
                    Adress="Sderot Chaim Weitzman 76",

                },

            };
            #endregion

        }

    }
}
