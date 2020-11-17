using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class BusLineStation : BuStation
    {
        public BusLineStation(int distance, int time) : base (key,lat,lon,name) 
        {
            Station_Distance = distance ;
            Travel_Time_From_Station= time ;
        }
        int Station_Distance;
        int Travel_Time_From_Station;
    }
}
//הגדירו מחלקה שתייצג תחנת קו אוטובוס
//תחנת קו אוטובוס מכילה את כל נתוני תחנת האוטובוס כנ"ל ובנוסף לפחות את
//הנתונים הבאים:
//• מרחק מתחנת קו אוטובוס הקודמת
//• זמן נסיעה מתחנת קו אוטובוס הקודמת
//ניתן לבנות תחנת קו אוטובוס על בסיס אובייקט של תחנת אוטובוס ונתונים הנ"ל